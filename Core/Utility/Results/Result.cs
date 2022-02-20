namespace Core.Utility.Results
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            IsSuccess = success;
        }
    }
}
