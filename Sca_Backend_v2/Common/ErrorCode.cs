using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sca_Backend_v2.Common
{
    public class ErrorCode
    {
        public const int UserNotAuthorised = 1001;
        public const int InvalidDestinationPath = 1002;
        public const int InvalidSourcePath = 1003;
        public const int SqlException = 1004;
        public const int InvalidSubmissionIdOrLineItemId = 1005;
        public const int InvalidLineItemId = 1006;
        public const int InvalidFileSize = 1007;
        public const int InvalidFileCount = 1008;
        public const int InvalidSubmissionId = 1009;
        public const int InvalidChoiceFromMenu = 1010;
        public const int InvalidSubmissionDetailsFilePath = 1011;
        public const int JsonParseFailed = 1012;
        public const int JsonSerializationFailed = 1013;
        public const int ErrorWhileLogging = 1014;
        public const int InvalidSubmissionDetails = 1015;
        public const int LineItemAlreadySubmitted = 1016;
        public const int EmptyListOfMediaLocations = 1017;
        public const int InvalidDecryptVerifyDetails = 1018;
        public const int InvalidMediaLocations = 1019;
        public const int MediaLocationsAlreadySubmitted = 1020;
        public const int InvalidDecryptVerifyDetailsFilePath = 1021;
        public const int InvalidStageDetailsFilePath = 1022;
        public const int InvalidMachineName = 1023;
        public const int ProcessingLineItem = 1024;
        public const int GeneralException = 1100;
    }
}
