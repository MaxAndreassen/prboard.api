namespace prboard.api.data.Transactions.Enums
{
    public enum TransactionStatus
    {
        PreCreation = 1,
        Succeeded = 2,
        Processing = 3,
        RequiresConfirmation = 4,
        RequiresPaymentMethod = 5,
        RequiresCapture = 6,
        RequiresAction = 7,
        Cancelled = 8,
        FailedToCreateInProvider = 9,
        SucceededWithCredit = 10
    }
}