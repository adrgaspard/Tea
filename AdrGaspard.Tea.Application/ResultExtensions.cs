using AdrGaspard.Tea.Application.Contracts.OutputResults;
using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application
{
    public static class ResultExtensions
    {
        public static Response ToResponse(this Result result, Func<Exception, ErrorResult> errorConvertionMethod)
        {
            return result.IsSuccess ? Response.Ok : errorConvertionMethod(result.Error);
        }

        public static Response<TResult> ToResponse<TValue, TResult>(this Result<TValue> result, Func<TValue, TResult> valueConvertionMethod, Func<Exception, ErrorResult> errorConvertionMethod)
        {
            return result.IsSuccess ? valueConvertionMethod(result.Value) : errorConvertionMethod(result.Error);
        }
    }
}