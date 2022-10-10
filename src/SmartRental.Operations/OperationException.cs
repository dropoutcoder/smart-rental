namespace SmartRental.Operations
{
    public class OperationException : ApplicationException
    {
        public OperationException(object? command, string? message, Exception? innerException = null)
            : base(message, innerException)
        {
            Command = command;
        }

        public object? Command { get; }

        public Type? CommandType => Command?.GetType();
    }
}
