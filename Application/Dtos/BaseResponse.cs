

namespace Application.Dtos
{
    public abstract class BaseResponse
    {

        public string Message { get; set; }
        public bool IsSuccessful { get; set; }

        public BaseResponse(string message, bool isSuccessful)
        {
            Message = message;
            IsSuccessful = isSuccessful;
        }
    }
}
