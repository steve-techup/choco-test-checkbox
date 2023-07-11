using Caretag.Contracts.Models;
using Main.Exceptions;
using System.Linq;
using System.Resources;

namespace Main.Extensions
{
    public static class ApiErrorResponseExtensions
    {
        public static CaretagApiException GetException(this ErrorResponse errorResponse, ResourceManager resourceManager)
        {
            var errorDetails = errorResponse.Errors?.FirstOrDefault()?.Details.FirstOrDefault();
            string message = string.Empty;

            if(errorDetails != null)
            {
                // Apply localization
                if(errorDetails.ErrorMessage == "Some assets are related to checkbox which is not completed")
                {

                    message = resourceManager.GetString("CheckInAssetAlreadyCheckedInInAnotherSession");
                }
                else
                {
                    message = errorDetails.ErrorMessage;
                }
            }
            else
            {

            }

            return new CaretagApiException(message);
        }
    }
}
