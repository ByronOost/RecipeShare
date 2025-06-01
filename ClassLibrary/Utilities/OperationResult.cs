namespace ClassLibrary.Operations
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }

        public static OperationResult SuccessResult(string message = "Operation completed successfully.")
        {
            return new OperationResult { Success = true, Message = message };
        }
        public static OperationResult FailureResult(string message, Exception? exception = null)
        {
            return new OperationResult { Success = false, Message = message, Exception = exception };
        }
    }
}
