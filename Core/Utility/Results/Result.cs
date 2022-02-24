namespace Core.Utility.Results
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        public string MessageId { get; }

        public Result(bool success, string message, string messageId) : this(success)
        {
            Message = message;
            MessageId = messageId;
        }
        public Result(bool success)
        {
            IsSuccess = success;
        }
    }
}
