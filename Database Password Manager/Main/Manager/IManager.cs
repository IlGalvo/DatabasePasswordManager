namespace DatabasePasswordManager.Main.Manager
{
    internal interface IManager<T>
    {
        T GetAccountRow();
    }
}
