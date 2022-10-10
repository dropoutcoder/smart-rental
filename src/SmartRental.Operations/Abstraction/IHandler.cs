namespace SmartRental.Operations.Abstraction
{
    public interface IHandler<TCommand, TResult>
    {
        Task<TResult> ExecuteAsync(TCommand command);
    }
}