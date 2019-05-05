using System;
using System.Runtime.Serialization;

namespace DatabaseCoreLogic
{
    [Serializable]
    public sealed class CoreLogicException : Exception
    {
        #region GLOBAL_VARIABLE
        public CoreLogicErrorCode ResultErrorCode { get; private set; }
        #endregion

        #region CONSTRUCTORS
        public CoreLogicException() : base()
        {
            ResultErrorCode = CoreLogicErrorCode.None;
        }

        public CoreLogicException(string message) : base(message)
        {
            ResultErrorCode = CoreLogicErrorCode.None;
        }

        public CoreLogicException(string message, CoreLogicErrorCode resultErrorCode) : base(message)
        {
            ResultErrorCode = resultErrorCode;
        }

        public CoreLogicException(string message, Exception innerException) : base(message, innerException)
        {
            ResultErrorCode = CoreLogicErrorCode.None;
        }

        public CoreLogicException(string message, CoreLogicErrorCode resultCode, Exception innerException) : base(message, innerException)
        {
            ResultErrorCode = resultCode;
        }
        #endregion

        #region BASE_METHOD
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
        #endregion
    }
}
