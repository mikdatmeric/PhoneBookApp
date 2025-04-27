﻿
namespace Shared.BaseResponses.Response
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static BaseResponse<T> SuccessResponse(T data, string message = "")
        {
            return new BaseResponse<T> { Success = true, Data = data, Message = message };
        }

        public static BaseResponse<T> FailureResponse(string message)
        {
            return new BaseResponse<T> { Success = false, Message = message };
        }
    }
}
