using System;

namespace DatabaseCoreLogic.Account
{
    public interface IAccount
    {
        uint ID { get; }
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        DateTime CreationDate { get; }
        DateTime LastUpdate { get; }
    }
}
