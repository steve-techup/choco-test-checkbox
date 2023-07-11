using System;
using System.Threading.Tasks;
using Caretag_Class.EventReporting;
using Caretag_Class.Exceptions;
using LanguageExt;
using Polly;
using Refit;

namespace Caretag_Class.ApiClient
{
    public static class ApiClientExtensions
    {
        private static EventReporter _eventReporter = null;
        public static void InitApiClientExtensions(EventReporter eventReporter)
        {
            ApiClientExtensions._eventReporter = eventReporter;
        }

        private static void CheckInitialized()
        {
            if (_eventReporter == null)
                throw new CaretagApplicationException(
                    "ApiClientExtensions not initialized with required EventReporter instance");
        }

        public static TryOptionAsync<TApiResult> AsTryOptionAsync<TApiResult>(this Task<ApiResponse<TApiResult>> request)
        {
            CheckInitialized();
            return (from r in request
                select r.IsSuccessStatusCode ? (r.Content != null ?
                        Option<TApiResult>.Some(r.Content).ToTryOption() :
                        Option<TApiResult>.None.ToTryOption()) :
                    Prelude.Try<TApiResult>(r.Error).ToTryOption()).ToAsync();
        }


        public static TryOptionAsync<TApiResult> AsTryOptionAsyncWithRetry<TApiResult>(this Task<ApiResponse<TApiResult>> request, int retries = 3)
        {
            var policy = Policy.HandleResult<ApiResponse<TApiResult>>(m => !m.IsSuccessStatusCode)
                .WaitAndRetryAsync(retryCount: retries, sleepDurationProvider: _ => TimeSpan.FromSeconds(1));

            return policy.ExecuteAsync(async () => await request.ConfigureAwait(false)).AsTryOptionAsync();
        }

        public static async Task<Option<TApiResult>> ToOptionHandleError<TApiResult>(this TryOptionAsync<TApiResult> monad,
            string operationDescription, string errorCode)
        {
            CheckInitialized();
            if (await monad.IsFail())
            {
                await monad.IfFail().With((ApiException x) =>
                {
                    _eventReporter.ReportError(x, operationDescription, operationDescription, errorCode, true, true);
                    return default(TApiResult);
                }).OtherwiseReThrow();
                return Option<TApiResult>.None;
            }

            return await monad.ToOption();
        }

        public static async Task<TApiResult> UnsafeUnpackAndHandleError<TApiResult>(this TryOptionAsync<TApiResult> monad, string operationDescription, string errorCode)
        {
            CheckInitialized();
            return await monad.IfFail().With((ApiException x) =>
            {
                _eventReporter.ReportError(x, operationDescription, operationDescription, errorCode, true, true);
                return default;
            }).Otherwise(default(TApiResult)).IfNoneAsync(default(TApiResult));
        }

        
    }
}