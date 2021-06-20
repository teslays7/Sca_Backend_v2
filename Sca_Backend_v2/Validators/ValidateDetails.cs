using Sca_Backend_v2.Common;
using Sca_Backend_v2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sca_Backend_v2.Validators
{
    public class ValidateDetails : IValidateDetails
    {
        public StringBuilder ValidateCopyToStageDetails(CopyToStageDetail copyToStageDetails)
        {

            StringBuilder errorsInValidationOfSubmissionDetails = new();

            if (copyToStageDetails.SubmissionId <= 0)
            {
                errorsInValidationOfSubmissionDetails.Append(ErrorMessage.InvalidSubmissionId);
            }

            if (copyToStageDetails.LineItemId <= 0)
            {
                errorsInValidationOfSubmissionDetails.Append(ErrorMessage.InvalidLineItemId);
            }

            if (String.IsNullOrEmpty(copyToStageDetails.SourcePath))
            {
                errorsInValidationOfSubmissionDetails.Append(ErrorMessage.InvalidSourcePath);
            }

            if (!Directory.Exists(copyToStageDetails.DestinationPath))
            {
                errorsInValidationOfSubmissionDetails.Append(ErrorMessage.InvalidDestinationPath);
            }

            //else
            //{
            //    if (Convert.ToBoolean(ConfigurationManager.AppSettings["FileSizeValidation"]))
            //    {
            //        if (submissionDetails.FileSize != fileSystemHelper.GetFolderSize(copyToStageDetails.DestinationPath))
            //        {
            //            errorsInValidationOfSubmissionDetails.Append(ErrorMessage.InvalidFileSize);
            //        }
            //    }

            //    if (Convert.ToBoolean(ConfigurationManager.AppSettings["FileCountValidation"]))
            //    {
            //        if (submissionDetails.FileCount != Directory.GetFiles(copyToStageDetails.DestinationPath, "*.*", SearchOption.AllDirectories).Length)
            //        {
            //            errorsInValidationOfSubmissionDetails.Append(ErrorMessage.InvalidFileCount);
            //        }
            //    }
            //}

            return errorsInValidationOfSubmissionDetails;
        }

        public StringBuilder ValidateDecryptAndVerifyDetails(DecryptAndVerifyDetail decryptAndVerifyDetail)
        {
            StringBuilder errorsInValidationOfStageDetails = new StringBuilder();

            if (decryptAndVerifyDetail.LineItemId == null || decryptAndVerifyDetail.LineItemId.Length <= 0)
            {
                errorsInValidationOfStageDetails.Append(ErrorMessage.InvalidLineItemId);
            }

            if (String.IsNullOrEmpty(decryptAndVerifyDetail.DestinationPath))
            {
                errorsInValidationOfStageDetails.Append(ErrorMessage.InvalidDestinationPath);
            }

            if (String.IsNullOrEmpty(decryptAndVerifyDetail.SourcePath))
            {
                errorsInValidationOfStageDetails.Append(ErrorMessage.InvalidSourcePath);
            }

            return errorsInValidationOfStageDetails;
        }

        public StringBuilder ValidateStageDetails(StageDetail stageDetail)
        {
            StringBuilder errorsInValidationOfStageDetails = new();

            if (stageDetail.SubmissionId <= 0)
            {
                errorsInValidationOfStageDetails.Append(ErrorMessage.InvalidSubmissionId);
            }

            if (stageDetail.LineItemId <= 0)
            {
                errorsInValidationOfStageDetails.Append(ErrorMessage.InvalidLineItemId);
            }

            if (String.IsNullOrEmpty(stageDetail.DestinationPath))
            {
                errorsInValidationOfStageDetails.Append(ErrorMessage.InvalidDestinationPath);
            }

            if (String.IsNullOrEmpty(stageDetail.SourcePath))
            {
                errorsInValidationOfStageDetails.Append(ErrorMessage.InvalidSourcePath);
            }

            return errorsInValidationOfStageDetails;
        }
    }
}
