using Microsoft.AspNetCore.Mvc;
using Sca_Backend_v2.Models;
using Sca_Backend_v2.Repository;
using Sca_Backend_v2.Validators;
using System.Collections.Generic;
using System.Text;

namespace Sca_Backend_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScaAdminController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;
        private readonly IValidateDetails _validateDetails;

        public ScaAdminController(IDataAccess dataAccess, IValidateDetails validateDetails)
        {
            _dataAccess = dataAccess;
            _validateDetails = validateDetails;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public int GetSubmissionDetailCountController()
        {
            return _dataAccess.GetSubmissionDetailCount();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{lineItemId}")]
        public List<SubmissionDetail> GetSubmissionDetailForLineItemController(int lineItemId)
        {
            return _dataAccess.GetSubmissionDetailForLineItem(lineItemId);
        }

        // POST api/<ValuesController>
        [HttpPost("CopyToStage")]
        public List<string> UpdateCopyToStageDetailsController([FromBody] List<CopyToStageDetail> copyToStageDetails)
        {
            List<string> response = new();
            List<CopyToStageDetail> validCopyToStageDetails = new();

            foreach (CopyToStageDetail copyToStageDetail in copyToStageDetails)
            {
                StringBuilder errorsInValidationOfCopyToStageDetails = new();
                errorsInValidationOfCopyToStageDetails = _validateDetails.ValidateCopyToStageDetails(copyToStageDetail);
                if (errorsInValidationOfCopyToStageDetails.Length == 0)
                {
                    validCopyToStageDetails.Add(copyToStageDetail);
                }
                else
                {
                    response.Add("LineitemID: " + copyToStageDetail.LineItemId + ": " + errorsInValidationOfCopyToStageDetails);
                }
            }

            if (validCopyToStageDetails != null && validCopyToStageDetails.Count != 0)
            {
                response.AddRange(_dataAccess.UpdateCopyToStageDetails(validCopyToStageDetails));
            }

            return response;
        }

        [HttpPost("DecryptAndVerify")]
        public List<string> UpdateDecryptAndVerifyDetailsController([FromBody] List<DecryptAndVerifyDetail> decryptAndVerifyDetails)
        {
            List<string> response = new();
            List<DecryptAndVerifyDetail> validDecryptAndVerifyDetails = new();

            foreach (DecryptAndVerifyDetail decryptAndVerifyDetail in decryptAndVerifyDetails)
            {
                StringBuilder errorsInValidationOfDecryptAndVerifyDetails = new();
                errorsInValidationOfDecryptAndVerifyDetails = _validateDetails.ValidateDecryptAndVerifyDetails(decryptAndVerifyDetail);
                if (errorsInValidationOfDecryptAndVerifyDetails.Length == 0)
                {
                    validDecryptAndVerifyDetails.Add(decryptAndVerifyDetail);
                }
                else
                {
                    response.Add("Decrypt and Verify Details are invalid. Error Message: " + errorsInValidationOfDecryptAndVerifyDetails);
                }
            }

            if (validDecryptAndVerifyDetails != null && validDecryptAndVerifyDetails.Count != 0)
            {
                response.AddRange(_dataAccess.UpdateDecryptAndVerifyDetails(validDecryptAndVerifyDetails));
            }

            return response;
        }

        // POST api/<ValuesController>
        [HttpPost("Stage/{stageName}")]
        public List<string> UpdateStageDetailsController([FromBody] List<StageDetail> stageDetails, string stageName)
        {
            List<string> response = new();
            List<StageDetail> validStageDetails = new();

            foreach (StageDetail stageDetail in stageDetails)
            {
                StringBuilder errorsInValidationOfStageDetails = new();
                errorsInValidationOfStageDetails = _validateDetails.ValidateStageDetails(stageDetail);
                if (errorsInValidationOfStageDetails.Length == 0)
                {
                    validStageDetails.Add(stageDetail);
                }
                else
                {
                    response.Add("LineitemID: " + stageDetail.LineItemId + ": " + errorsInValidationOfStageDetails);
                }
            }

            if (validStageDetails != null && validStageDetails.Count != 0)
            {
                response.AddRange(_dataAccess.UpdateStageDetails(validStageDetails, stageName));
            }

            return response;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
