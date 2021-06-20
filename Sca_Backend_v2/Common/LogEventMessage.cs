using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sca_Backend_v2.Common
{
    public class LogEventMessage
    {
        public const string UpdateSubmissionDetailsCalled = "UpdateSubmissionDetails called. ";
        public const string UpdateDecryptVerifyDetailsCalled = "UpdateDecryptVerifyDetails called. ";
        public const string UserExit = "User.Exit ";
        public const string SqlConnectionEstablished = "SQL connection successfully established";
        public const string LineItemAcceptedSuccessfully = "Lineitem accepted successfully ";
        public const string MediaLocationsAcceptedSuccessfully = "Media Locations accepted successfully. ";
        public const string UpdateStageDetailsCalled = "UpdateStageDetails called. ";
    }
}
