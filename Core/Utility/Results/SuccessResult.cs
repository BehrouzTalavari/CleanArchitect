namespace Core.Utility.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message,string messageId) : base(true, message,messageId)
        {
        }
        public SuccessResult() : base(true)
        {
        }
    }
}
