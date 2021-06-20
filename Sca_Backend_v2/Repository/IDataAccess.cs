using Sca_Backend_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sca_Backend_v2.Repository
{
    public interface IDataAccess
    {
        int GetSubmissionDetailCount();
        List<SubmissionDetail> GetSubmissionDetailForLineItem(int lineItemId);
        List<string> UpdateCopyToStageDetails(List<CopyToStageDetail> copyToStageDetails);
        List<string> UpdateDecryptAndVerifyDetails(List<DecryptAndVerifyDetail> decryptAndVerifyDetails);
        List<string> UpdateStageDetails(List<StageDetail> stageDetails, string stageName);
    }
}
