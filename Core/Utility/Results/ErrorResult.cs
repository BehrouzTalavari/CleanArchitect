namespace Core.Utility.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message, string messageId) : base(true, message, messageId)
        {
        }
        public ErrorResult() : base(false)
        {
        }
    }
}
