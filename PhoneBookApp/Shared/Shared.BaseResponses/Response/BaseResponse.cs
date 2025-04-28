
namespace Shared.BaseResponses.Response
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public BaseResponse()
        {
            Messages = new List<string>();
        }

        public BaseResponse(T data, int statusCode = 200)
        {
            Success = true;
            Data = data;
            StatusCode = statusCode;
            Messages = new List<string>();
        }

        // Fail için overload 1
        public static BaseResponse<T> Fail(string message)
        {
            return new BaseResponse<T>
            {
                Success = false,
                StatusCode = 400, // Default 400 BadRequest
                Messages = new List<string> { message }
            };
        }

        // Fail için overload 2 (custom StatusCode verebilmek için)
        public static BaseResponse<T> Fail(string message, int statusCode)
        {
            return new BaseResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Messages = new List<string> { message }
            };
        }

        // Fail için overload 3 (birden fazla mesaj için)
        public static BaseResponse<T> Fail(List<string> messages, int statusCode = 400)
        {
            return new BaseResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Messages = messages
            };
        }
    }
}
