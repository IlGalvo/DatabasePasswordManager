namespace DatabaseCoreLogic
{
    public enum CoreLogicErrorCode
    {
        None,
        ConnectionClosed,
        ConnectionAlreadyOpened,
        DatabaseNotFound,
        IncorrectPassword,
        AlreadyExists,
        NotExists,
        InvalidOperation,
        BackupFailed
    }
}
