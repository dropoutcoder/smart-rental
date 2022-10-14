namespace SmartRental.Infrastructure.Database
{
    public class StoreException : ApplicationException
    {
        public StoreException(string message, Exception? innerException)
            : base(message, innerException) { }
    }
}
