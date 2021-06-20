using Sca_Backend_v2.Models;
using System.Text;

namespace Sca_Backend_v2.Validators
{
    public interface IValidateDetails
    {
        StringBuilder ValidateCopyToStageDetails(CopyToStageDetail copyToStageDetails);
        StringBuilder ValidateDecryptAndVerifyDetails(DecryptAndVerifyDetail decryptAndVerifyDetail);
        StringBuilder ValidateStageDetails(StageDetail stageDetail);
    }
}
