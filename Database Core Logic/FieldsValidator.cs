using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DatabaseCoreLogic
{
    internal static class FieldsValidator
    {
        #region DATABASEPASSWORD_VALIDATOR
        public static string ValidateDatabasePassword(string databasePassword, bool isLogin)
        {
            if (string.IsNullOrEmpty(databasePassword))
            {
                throw (new ArgumentNullException("Password"));
            }

            databasePassword = databasePassword.Trim().Normalize();

            if ((!isLogin) && (!(new Regex(Utilities.DatabasePasswordRegex).IsMatch(databasePassword))))
            {
                throw (new FormatException("Incorrect Password format.\n\n" +
                    "It must contains at least the first letter uppercase.\n" +
                    "At least one digit and lowercase letter.\n" +
                    "It supports some special and unicode characters.\n" +
                    "Repeated occurrences must be lower than three.\n" +
                    "Length must be between '" + Utilities.MinDatabasePasswordLength + " and " + Utilities.MaxGenericLength + "'."));
            }

            return databasePassword;
        }
        #endregion

        #region GENERIC_VALIDATOR
        public static string ValidateGenericField(string genericField, string fieldName)
        {
            if (genericField == null)
            {
                throw (new ArgumentNullException(fieldName));
            }

            genericField = genericField.Trim().Normalize();

            if (genericField.Length > Utilities.MaxGenericLength)
            {
                throw new ArgumentOutOfRangeException(fieldName, "Length must be lower than " + Utilities.MaxGenericLength + ".");
            }

            return genericField;
        }
        #endregion

        #region EMAIL_VALIDATOR
        public static string ValidateEmailField(string emailField)
        {
            if (string.IsNullOrEmpty(emailField))
            {
                throw (new ArgumentNullException("Email"));
            }

            emailField = emailField.Trim().Normalize();

            if (emailField.Length > Utilities.MaxEmailLength)
            {
                throw (new ArgumentOutOfRangeException("Email", "Length must be lower than " + Utilities.MaxEmailLength + "."));
            }

            if (!(new EmailAddressAttribute().IsValid(emailField)))
            {
                throw (new FormatException("Incorrect Email format."));
            }

            return emailField;
        }
        #endregion
    }
}
