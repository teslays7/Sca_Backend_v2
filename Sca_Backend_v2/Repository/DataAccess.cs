using Microsoft.Extensions.Configuration;
using Sca_Backend_v2.Common;
using Sca_Backend_v2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sca_Backend_v2.Repository
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;
        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int GetSubmissionDetailCount()
        {
            List<SubmissionDetail> submissionDetails = new();
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ScaUatSqlConnection"));
            using var cmd = new SqlCommand()
            {
                CommandText = "SELECT COUNT(*) FROM SubmissionDetail",
                CommandType = CommandType.Text,
                Connection = sqlConnection
            };
            sqlConnection.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public List<SubmissionDetail> GetSubmissionDetailForLineItem(int lineItemId)
        {
            List<SubmissionDetail> submissionDetails = new();
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ScaUatSqlConnection"));
            using var cmd = new SqlCommand()
            {
                CommandText = "SELECT * FROM SubmissionDetail WHERE LineItemId = @lineItemId",
                CommandType = CommandType.Text,
                Connection = sqlConnection
            };
            cmd.Parameters.Add("@lineItemId", SqlDbType.Int).Value = lineItemId;
            sqlConnection.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SubmissionDetail submissionDetail = new SubmissionDetail
                {
                    SubmissionDetailId = Convert.ToInt32(reader["SubmissionDetailId"]),
                    LineItemId = Convert.ToInt32(reader["LineItemId"]),
                    SubmissionId = Convert.ToInt32(reader["SubmissionId"])
                };

                submissionDetails.Add(submissionDetail);
            }
            return submissionDetails;
        }

        public List<string> UpdateCopyToStageDetails(List<CopyToStageDetail> copyToStageDetails)
        {
            List<string> operationDetails = new();

            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ScaUatSqlConnection"));
            sqlConnection.Open();

            foreach (CopyToStageDetail copyToStageDetail in copyToStageDetails)
            {
                SqlCommand sqlCommand = new("UpdateStageStatus", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.Add(new SqlParameter("@DestinationPath", copyToStageDetail.DestinationPath));
                sqlCommand.Parameters.Add(new SqlParameter("@FileSizeInBytes", copyToStageDetail.FileSize));
                sqlCommand.Parameters.Add(new SqlParameter("@FileCount", copyToStageDetail.FileCount));
                sqlCommand.Parameters.Add(new SqlParameter("@SubmissionId", copyToStageDetail.SubmissionId));
                sqlCommand.Parameters.Add(new SqlParameter("@LineItemId", copyToStageDetail.LineItemId));
                sqlCommand.Parameters.Add(new SqlParameter("@SourcePath", copyToStageDetail.SourcePath));
                sqlCommand.Parameters.Add(new SqlParameter("@StageName", "CopyToStage"));

                var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();
                var result = Convert.ToInt32(returnParameter.Value);

                if (result == -1)
                {
                    operationDetails.Add("LineitemID " + copyToStageDetail.LineItemId + ": " + ErrorMessage.InvalidSubmissionIdOrLineItemId);
                }
                else if (result == 1)
                {
                    operationDetails.Add("LineitemID " + copyToStageDetail.LineItemId + ": " + LogEventMessage.LineItemAcceptedSuccessfully);
                }
                else if (result == 0)
                {
                    operationDetails.Add("LineitemID " + copyToStageDetail.LineItemId + ": " + ErrorMessage.ProcessingLineItem);
                }
                else
                {
                    operationDetails.Add("LineitemID " + copyToStageDetail.LineItemId + ": " + ErrorMessage.LineItemAlreadySubmitted);
                }
            }
            return operationDetails;
        }

        public List<string> UpdateDecryptAndVerifyDetails(List<DecryptAndVerifyDetail> decryptAndVerifyDetails)
        {
            List<string> operationDetails = new();

            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ScaUatSqlConnection"));
            sqlConnection.Open();

            foreach (DecryptAndVerifyDetail decryptAndVerifyDetail in decryptAndVerifyDetails)
            {
                foreach (var lineItemId in decryptAndVerifyDetail.LineItemId)
                {
                    SqlCommand sqlCommand = new("UpdateStageStatus", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add(new SqlParameter("@LineItemId", lineItemId));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubmissionId", DBNull.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@StageName", "DecryptVerify"));
                    sqlCommand.Parameters.Add(new SqlParameter("@SourcePath", decryptAndVerifyDetail.SourcePath));
                    sqlCommand.Parameters.Add(new SqlParameter("@DestinationPath", decryptAndVerifyDetail.DestinationPath));

                    //Get the Machine Name from the SourcePath

                    char[] separator = { '\\' };
                    Int32 maxSubstrings = 2;
                    String[] splitStringList = decryptAndVerifyDetail.SourcePath.Substring(2).Split(separator, maxSubstrings, StringSplitOptions.RemoveEmptyEntries);
                    string machineName = splitStringList[0];
                    sqlCommand.Parameters.Add(new SqlParameter("@MachineName", machineName));

                    var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    sqlCommand.ExecuteNonQuery();
                    var result = Convert.ToInt32(returnParameter.Value);

                    if (result == -1)
                    {
                        operationDetails.Add("LineitemID " + lineItemId + ": " + ErrorMessage.InvalidSubmissionIdOrLineItemId);
                    }

                    else if (result == 1)
                    {
                        operationDetails.Add("LineitemID " + lineItemId + ": " + LogEventMessage.LineItemAcceptedSuccessfully);
                    }

                    else if (result == 2)
                    {
                        operationDetails.Add("LineitemID " + lineItemId + ": " + ErrorMessage.LineItemAlreadySubmitted);
                    }

                    else
                    {
                        operationDetails.Add("LineitemID " + lineItemId + ": " + ErrorMessage.ProcessingLineItem);
                    }
                }
            }

            return operationDetails;
        }

        public List<string> UpdateStageDetails(List<StageDetail> stageDetails, string stageName)
        {
            List<string> operationDetails = new();

            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ScaUatSqlConnection"));
            sqlConnection.Open();

            foreach (StageDetail stageDetail in stageDetails)
            {
                SqlCommand sqlCommand = new("UpdateStageStatus", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.Add(new SqlParameter("@LineItemId", stageDetail.LineItemId));
                sqlCommand.Parameters.Add(new SqlParameter("@SubmissionId", stageDetail.SubmissionId));
                sqlCommand.Parameters.Add(new SqlParameter("@StageName", stageName));
                sqlCommand.Parameters.Add(new SqlParameter("@SourcePath", stageDetail.SourcePath));
                sqlCommand.Parameters.Add(new SqlParameter("@DestinationPath", stageDetail.DestinationPath));

                var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();
                var result = Convert.ToInt32(returnParameter.Value);

                if (result == -1)
                {
                    operationDetails.Add("LineitemID " + stageDetail.LineItemId + ": " + ErrorMessage.InvalidSubmissionIdOrLineItemId);
                }

                else if (result == 1)
                {
                    operationDetails.Add("LineitemID " + stageDetail.LineItemId + ": " + LogEventMessage.LineItemAcceptedSuccessfully);
                }

                else if (result == 2)
                {
                    operationDetails.Add("LineitemID " + stageDetail.LineItemId + ": " + ErrorMessage.LineItemAlreadySubmitted);
                }

                else
                {
                    operationDetails.Add("LineitemID " + stageDetail.LineItemId + ": " + ErrorMessage.ProcessingLineItem);
                }
            }

            return operationDetails;
        }
    }
}
