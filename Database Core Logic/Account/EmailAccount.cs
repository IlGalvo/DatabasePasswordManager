using System;

namespace DatabaseCoreLogic.Account
{
    public struct EmailAccount : IAccount
    {
        #region GLOBAL_VARIABLES
        public static readonly EmailAccount Empty;

        public uint ID { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; internal set; }
        public DateTime LastUpdate { get; internal set; }
        #endregion

        #region BASE_METHODS
        public override bool Equals(object obj)
        {
            return (base.Equals(obj));
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode());
        }

        public override string ToString()
        {
            return (base.ToString());
        }

        public static bool operator ==(EmailAccount left, EmailAccount right)
        {
            return (left.Equals(right));
        }

        public static bool operator !=(EmailAccount left, EmailAccount right)
        {
            return (!left.Equals(right));
        }
        #endregion
    }
}
