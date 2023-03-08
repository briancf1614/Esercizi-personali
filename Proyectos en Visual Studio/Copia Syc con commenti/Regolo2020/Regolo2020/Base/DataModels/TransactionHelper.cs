namespace Regolo2020.Base.DataModels
{
    /// <summary>
    /// This class should be used as a dependency (DI) of a Business class. It provides access to executing code inside
    /// a DbContext transaction.
    /// Example usage: a business method that calls methods from other business classes, but must commit or rollback
    /// all the actions together.
    /// </summary>
    public class TransactionHelper
    {
        private readonly RegoloDbContext _context;

        public TransactionHelper(RegoloDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Executes some code inside a transaction, using the context from the DI (shared with the scope: request).
        /// If the Action work throws any exception all the work done in the transaction will be rolled back.
        /// </summary>
        public void ExecuteWithinTransaction(Action work)
        {
            ExecuteWithinTransaction(() => {
                work();
                return true;
            });
        }

        /// <summary>
        /// Executes some code inside a transaction, using the context from the DI (shared with the scope: request).
        /// If the Func work throws any exception or returns false all the work done in the transaction will be rolled
        /// back. If it returns true the work done in the transaction will be committed.
        /// </summary>
        public void ExecuteWithinTransaction(Func<bool> work)
        {
            // If there is already a transaction active, throw an error.
            // This may be changed in the future if we want to support nested calls to this method.
            if (_context.Database.CurrentTransaction != null)
                throw new InvalidOperationException("There is already an active transaction");

            // If an exception is thrown inside the transaction it will be rolled back automatically.
            using var transaction = _context.Database.BeginTransaction();
            var shouldCommit = work();
            if (shouldCommit) transaction.Commit();
        }
    }
}
