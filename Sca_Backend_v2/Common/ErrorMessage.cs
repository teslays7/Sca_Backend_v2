using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sca_Backend_v2.Common
{
    public class ErrorMessage
    {
        public const string SqlException = "SQL exception. ";
        public const string UserNotAuthorised = "Current user is not authorised. ";
        public const string InvalidSourcePath = "Invalid Source Path entered. ";
        public const string InvalidDestinationPath = "Invalid Destination Path entered. ";
        public const string InvalidSubmissionId = "Invalid Submission ID entered. ";
        public const string InvalidLineItemId = "Invalid LineItem ID entered. ";
        public const string InvalidFileSize = "Invalid File Size entered. ";
        public const string InvalidFileCount = "Invalid File Count entered. ";
        public const string InvalidSubmissionIdOrLineItemId = "Invalid Submission ID or LineItem ID entered. ";
        public const string InvalidChoiceFromMenu = "Invalid choice selected from the menu. ";
        public const string InvalidSubmissionDetailsFilePath = "Invalid path given for the Submission details. ";
        public const string JsonParseFailed = "Failed to parse the JSON File. ";
        public const string JsonSerializationFailed = "Failed to serialize the JSON File. ";
        public const string ErrorInLineNumber = "Error in line number ";
        public const string ErrorWhileLogging = "Error encountered while logging. ";
        public const string LineItemAlreadySubmitted = "LineItem already submitted. ";
        public const string CertificateThumbprintIsNull = "Certificate thumbprint is null. ";
        public const string CertificateThumbprintArrayLengthIsZero = "Certificate thumbprint array length is 0. ";
        public const string NoCertificateFoundForThumbprint = "Certificate not found for the thumbprint provided {0} in store name {1}. ";
        public const string DataToDecryptIsInvalid = "Data to decrypt is invalid. ";
        public const string EmptyListOfMediaLocations = "Empty list of Media Locations entered. ";
        public const string InvalidMediaLocations = "One or more media locations entered are invalid. ";
        public const string MediaLocationsAlreadySubmitted = "Media Locations already submitted. ";
        public const string InvalidDecryptVerifyDetailsFilePath = "Invalid path given for the DecryptVerify details. ";
        public const string InvalidMachineName = "Invalid Machine Name entered OR Machine is inactive ";
        public const string ProcessingLineItem = "Line Item is being processed right now. ";
        public const string InvalidStageDetailsFilePath = "Invalid path given for the Stage details. ";
        public const string InvalidDecryptVerifyStageDetailsFilePath = "Invalid path given for the Decrypt Verify Stage details. ";
    }
}
