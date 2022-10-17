using SmartRental.Operations.Abstraction;

namespace SmartRental.Operations.Internal.Handlers
{
    public abstract class Handler<TCommand, TResult> : IHandler<TCommand, TResult>
    {
        public async Task<TResult> ExecuteAsync(TCommand command)
        {
            // Start transaction

            var isValid = await ValidateAsync(command);

            if (!isValid)
            {
                throw new OperationException(command, "We couldn't process your request!");
            }

            return await ExecuteCoreAsync(command);

            // End trasaction with commit or rollback
        }

        protected abstract Task<TResult> ExecuteCoreAsync(TCommand command);

        protected abstract Task<bool> ValidateAsync(TCommand command);
    }
}
