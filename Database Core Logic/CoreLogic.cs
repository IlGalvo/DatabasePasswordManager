using DatabaseCoreLogic.Account;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace DatabaseCoreLogic
{
    public sealed class CoreLogic : IDisposable
    {
        #region GLOBAL_VARIABLES
        private SQLiteConnection sqliteConnection;

        public event EmailAccountChangesEventHandler EmailAccountChanges;
        public event GeneralAccountChangesEventHandler GeneralAccountChanges;
        #endregion

        #region CONSTRUCTOR
        public CoreLogic()
        {
            sqliteConnection = new SQLiteConnection(string.Format(Utilities.DatabaseConnection, Utilities.DatabaseName));
        }
        #endregion

        #region EXISTS
        public bool DatabaseExists()
        {
            return (File.Exists(Utilities.DatabaseName));
        }
        #endregion

        #region PASSWORD
        private byte[] SetEncryptedDatabasePassword(string plainTextPassword, bool isLogin)
        {
            using (Aes localAes = Aes.Create())
            using (SHA512 sha512 = SHA512.Create())
            using (SHA256 sha256 = SHA256.Create())
            using (MD5 md5 = MD5.Create())
            {
                plainTextPassword = FieldsValidator.ValidateDatabasePassword(plainTextPassword, isLogin);
                byte[] hashedPassword = sha512.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));

                localAes.Key = sha256.ComputeHash(hashedPassword);
                localAes.IV = md5.ComputeHash(hashedPassword);
                localAes.Padding = PaddingMode.None;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, localAes.CreateDecryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(hashedPassword, 0, hashedPassword.Length);

                    return (memoryStream.ToArray());
                }
            }
        }

        public void ChangeDatabasePassword(string plainTextPassword)
        {
            if (!IsDatabaseConnectionOpened())
            {
                throw (new CoreLogicException("You must open connection before.", CoreLogicErrorCode.ConnectionClosed));
            }

            try
            {
                sqliteConnection.ChangePassword(SetEncryptedDatabasePassword(plainTextPassword, false));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region CONNECTION
        private void OpenDatabaseConnection(byte[] encryptedPassword)
        {
            sqliteConnection.SetPassword(encryptedPassword);

            sqliteConnection.Open();
        }

        public bool IsDatabaseConnectionOpened()
        {
            return (sqliteConnection.State == ConnectionState.Open);
        }

        public void CloseDatabaseConnection()
        {
            if (IsDatabaseConnectionOpened())
            {
                sqliteConnection.Close();
            }
        }
        #endregion

        #region STARTUP
        public void CreateDatabase(string plainTextPassword)
        {
            try
            {
                SQLiteConnection.CreateFile(Utilities.DatabaseName);

                OpenDatabaseConnection(SetEncryptedDatabasePassword(plainTextPassword, false));

                using (SQLiteCommand sqliteCommand = new SQLiteCommand(sqliteConnection))
                {
                    sqliteCommand.CommandText = Utilities.CreateTableEmailAccount;
                    sqliteCommand.ExecuteNonQuery();

                    sqliteCommand.CommandText = Utilities.CreateTableGeneralAccount;
                    sqliteCommand.ExecuteNonQuery();
                }
            }
            catch (IOException)
            {
                throw (new CoreLogicException("You must first close the current connection.", CoreLogicErrorCode.ConnectionAlreadyOpened));
            }
            catch (Exception)
            {
                CloseDatabaseConnection();

                File.Delete(Utilities.DatabaseName);

                throw;
            }
        }

        public void LoginDatabase(string plainTextPassword)
        {
            if (!DatabaseExists())
            {
                throw (new CoreLogicException("You must first create database.", CoreLogicErrorCode.DatabaseNotFound));
            }
            else if (IsDatabaseConnectionOpened())
            {
                throw (new CoreLogicException("You must first close the current connection.", CoreLogicErrorCode.ConnectionAlreadyOpened));
            }

            try
            {
                OpenDatabaseConnection(SetEncryptedDatabasePassword(plainTextPassword, true));

                using (SQLiteCommand sqliteCommand = new SQLiteCommand(Utilities.DatabaseLogin, sqliteConnection))
                {
                    sqliteCommand.ExecuteScalar();
                }
            }
            catch (SQLiteException)
            {
                CloseDatabaseConnection();

                throw (new CoreLogicException("Incorrect password.", CoreLogicErrorCode.IncorrectPassword));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region INSERT
        public void InsertEmailAccountData(string name, string email, string password)
        {
            if (!IsDatabaseConnectionOpened())
            {
                throw (new CoreLogicException("You must open connection before.", CoreLogicErrorCode.ConnectionClosed));
            }

            using (SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction(IsolationLevel.Serializable))
            {
                using (SQLiteCommand sqliteCommand = new SQLiteCommand(Utilities.InsertEmailAccountData, sqliteConnection, sqliteTransaction))
                {
                    try
                    {
                        sqliteCommand.Parameters.Add("@name", DbType.String).Value = FieldsValidator.ValidateGenericField(name, "Name");
                        sqliteCommand.Parameters.Add("@email", DbType.String).Value = FieldsValidator.ValidateEmailField(email);
                        sqliteCommand.Parameters.Add("@password", DbType.String).Value = FieldsValidator.ValidateGenericField(password, "Password");

                        sqliteCommand.ExecuteNonQuery();
                    }
                    catch (SQLiteException sqliteException)
                    {
                        sqliteTransaction.Rollback();

                        if (sqliteException.Message.Contains("Name"))
                        {
                            throw (new CoreLogicException("An account with the same Name already exists.", CoreLogicErrorCode.AlreadyExists));
                        }

                        throw (new CoreLogicException("An account with the same Email already exists.", CoreLogicErrorCode.AlreadyExists));
                    }
                    catch (Exception exception)
                    {
                        if ((!(exception is ArgumentException)) &&
                            (!(exception is FormatException)))
                        {
                            sqliteTransaction.Rollback();
                        }

                        throw;
                    }
                }

                sqliteTransaction.Commit();
            }

            EmailAccountChanges?.Invoke(this, new EventArgs());
        }

        /// <exception cref="Exception">The project file could not be found.</exception>
        public void InsertGeneralAccountData(string name, string username, string password, string other, uint? emailID)
        {
            if (!IsDatabaseConnectionOpened())
            {
                throw (new CoreLogicException("You must open connection before.", CoreLogicErrorCode.ConnectionClosed));
            }

            using (SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction(IsolationLevel.Serializable))
            {
                using (SQLiteCommand sqliteCommand = new SQLiteCommand(Utilities.InsertGeneralAccountData, sqliteConnection, sqliteTransaction))
                {
                    try
                    {
                        sqliteCommand.Parameters.Add("@name", DbType.String).Value = FieldsValidator.ValidateGenericField(name, "Name");
                        sqliteCommand.Parameters.Add("@username", DbType.String).Value = FieldsValidator.ValidateGenericField(username, "Username");
                        sqliteCommand.Parameters.Add("@password", DbType.String).Value = FieldsValidator.ValidateGenericField(password, "Password");
                        sqliteCommand.Parameters.Add("@other", DbType.String).Value = FieldsValidator.ValidateGenericField(other, "Other");
                        sqliteCommand.Parameters.Add("@emailID", DbType.UInt32).Value = emailID;

                        sqliteCommand.ExecuteNonQuery();
                    }
                    catch (SQLiteException sqliteException)
                    {
                        sqliteTransaction.Rollback();

                        if (sqliteException.Message.Contains("Name"))
                        {
                            throw (new CoreLogicException("An account with the same Name already exists.", CoreLogicErrorCode.AlreadyExists));
                        }
                        else if (sqliteException.Message.Contains("FOREIGN KEY"))
                        {
                            throw (new CoreLogicException("The associated Email does not exist.", CoreLogicErrorCode.NotExists));
                        }

                        throw (new CoreLogicException("Username and Email values cannot be both empty.", CoreLogicErrorCode.InvalidOperation));
                    }
                    catch (Exception exception)
                    {
                        if ((!(exception is ArgumentException)) &&
                            (!(exception is FormatException)))
                        {
                            sqliteTransaction.Rollback();
                        }

                        throw;
                    }
                }

                sqliteTransaction.Commit();
            }

            GeneralAccountChanges?.Invoke(this, new EventArgs());
        }
        #endregion

        #region UPDATE
        public void UpdateEmailAccountData(string name, string email, string password, uint id)
        {
            if (!IsDatabaseConnectionOpened())
            {
                throw (new CoreLogicException("You must open connection before.", CoreLogicErrorCode.ConnectionClosed));
            }

            using (SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction(IsolationLevel.Serializable))
            {
                using (SQLiteCommand sqliteCommand = new SQLiteCommand(Utilities.UpdateEmailAccountData, sqliteConnection, sqliteTransaction))
                {
                    try
                    {
                        sqliteCommand.Parameters.Add("@name", DbType.String).Value = FieldsValidator.ValidateGenericField(name, "Name");
                        sqliteCommand.Parameters.Add("@email", DbType.String).Value = FieldsValidator.ValidateEmailField(email);
                        sqliteCommand.Parameters.Add("@password", DbType.String).Value = FieldsValidator.ValidateGenericField(password, "Password");
                        sqliteCommand.Parameters.Add("@id", DbType.UInt32).Value = id;

                        if (sqliteCommand.ExecuteNonQuery() == 0)
                        {
                            throw (new CoreLogicException("The associated ID does not exist.", CoreLogicErrorCode.NotExists));
                        }
                    }
                    catch (SQLiteException sqliteException)
                    {
                        sqliteTransaction.Rollback();

                        if (sqliteException.Message.Contains("Name"))
                        {
                            throw (new CoreLogicException("An account with the same Name already exists.", CoreLogicErrorCode.AlreadyExists));
                        }

                        throw (new CoreLogicException("An account with the same Email already exists.", CoreLogicErrorCode.AlreadyExists));
                    }
                    catch (Exception exception)
                    {
                        if ((!(exception is ArgumentException)) &&
                            (!(exception is FormatException)))
                        {
                            sqliteTransaction.Rollback();
                        }

                        throw;
                    }
                }

                sqliteTransaction.Commit();
            }

            EmailAccountChanges?.Invoke(this, new EventArgs());
            GeneralAccountChanges?.Invoke(this, new EventArgs());
        }

        public void UpdateGeneralAccountData(string name, string username, string password, string other, uint? emailID, uint id)
        {
            if (!IsDatabaseConnectionOpened())
            {
                throw (new CoreLogicException("You must open connection before.", CoreLogicErrorCode.ConnectionClosed));
            }

            using (SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction(IsolationLevel.Serializable))
            {
                using (SQLiteCommand sqliteCommand = new SQLiteCommand(Utilities.UpdateGeneralAccountData, sqliteConnection, sqliteTransaction))
                {
                    try
                    {
                        sqliteCommand.Parameters.Add("@name", DbType.String).Value = FieldsValidator.ValidateGenericField(name, "Name");
                        sqliteCommand.Parameters.Add("@username", DbType.String).Value = FieldsValidator.ValidateGenericField(username, "Username");
                        sqliteCommand.Parameters.Add("@password", DbType.String).Value = FieldsValidator.ValidateGenericField(password, "Password");
                        sqliteCommand.Parameters.Add("@other", DbType.String).Value = FieldsValidator.ValidateGenericField(other, "Other");
                        sqliteCommand.Parameters.Add("@emailID", DbType.UInt32).Value = emailID;
                        sqliteCommand.Parameters.Add("@id", DbType.UInt32).Value = id;

                        if (sqliteCommand.ExecuteNonQuery() == 0)
                        {
                            throw (new CoreLogicException("The associated ID does not exist.", CoreLogicErrorCode.NotExists));
                        }
                    }
                    catch (SQLiteException sqliteException)
                    {
                        sqliteTransaction.Rollback();

                        if (sqliteException.Message.Contains("Name"))
                        {
                            throw (new CoreLogicException("An account with the same Name already exists.", CoreLogicErrorCode.AlreadyExists));
                        }
                        else if (sqliteException.Message.Contains("FOREIGN KEY"))
                        {
                            throw (new CoreLogicException("The associated Email does not exist.", CoreLogicErrorCode.NotExists));
                        }

                        throw (new CoreLogicException("Username and Email values cannot be both empty.", CoreLogicErrorCode.InvalidOperation));
                    }
                    catch (Exception exception)
                    {
                        if ((!(exception is ArgumentException)) &&
                            (!(exception is FormatException)))
                        {
                            sqliteTransaction.Rollback();
                        }

                        throw;
                    }
                }

                sqliteTransaction.Commit();
            }

            GeneralAccountChanges?.Invoke(this, new EventArgs());
        }
        #endregion

        #region DELETE
        public void DeleteSelectedAccountData(AccountType accountType, uint id)
        {
            if (!IsDatabaseConnectionOpened())
            {
                throw (new CoreLogicException("You must open connection before.", CoreLogicErrorCode.ConnectionClosed));
            }

            using (SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction(IsolationLevel.Serializable))
            {
                string commandText = string.Format(Utilities.DeleteAccountData, accountType);

                using (SQLiteCommand sqliteCommand = new SQLiteCommand(commandText, sqliteConnection, sqliteTransaction))
                {
                    sqliteCommand.Parameters.Add("@id", DbType.UInt32).Value = id;

                    try
                    {
                        if (sqliteCommand.ExecuteNonQuery() == 0)
                        {
                            throw (new CoreLogicException("The associated ID does not exist.", CoreLogicErrorCode.NotExists));
                        }
                    }
                    catch (SQLiteException)
                    {
                        sqliteTransaction.Rollback();

                        string message = ("You cannot delete this Email Account because it would leave some General Account entries " +
                            "with both Username and Email empty.");

                        throw (new CoreLogicException(message, CoreLogicErrorCode.InvalidOperation));
                    }
                    catch (Exception exception)
                    {
                        if ((!(exception is ArgumentException)) &&
                            (!(exception is CoreLogicException)))
                        {
                            sqliteTransaction.Rollback();
                        }

                        throw;
                    }
                }

                sqliteTransaction.Commit();
            }

            if (accountType == AccountType.EmailAccount)
            {
                EmailAccountChanges?.Invoke(this, new EventArgs());
            }

            GeneralAccountChanges?.Invoke(this, new EventArgs());
        }
        #endregion

        #region QUERY
        private SQLiteDataReader QuerySearchSelectedAccountData(string commandText, string searchFilteredText = null)
        {
            if (!IsDatabaseConnectionOpened())
            {
                throw (new CoreLogicException("You must open connection before.", CoreLogicErrorCode.ConnectionClosed));
            }

            using (SQLiteCommand sqliteCommand = new SQLiteCommand(commandText, sqliteConnection))
            {
                searchFilteredText = (((searchFilteredText != null) ? searchFilteredText.Trim().Normalize() : string.Empty) + "%");
                sqliteCommand.Parameters.Add("@input", DbType.String).Value = searchFilteredText;

                try
                {
                    return (sqliteCommand.ExecuteReader());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public EmailAccount[] QuerySearchEmailAccountData(string searchFilteredText = null)
        {
            EmailAccount[] emailAccountList = new EmailAccount[0];

            using (SQLiteDataReader sqliteDataReader = QuerySearchSelectedAccountData(Utilities.QuerySearchEmailAccountData, searchFilteredText))
            {
                if (sqliteDataReader.HasRows)
                {
                    for (int i = 0; sqliteDataReader.Read(); i++)
                    {
                        Array.Resize(ref emailAccountList, (emailAccountList.Length + 1));

                        emailAccountList[i].ID = uint.Parse(sqliteDataReader["ID"].ToString());
                        emailAccountList[i].Name = sqliteDataReader["Name"].ToString();
                        emailAccountList[i].Email = sqliteDataReader["Email"].ToString();
                        emailAccountList[i].Password = sqliteDataReader["Password"].ToString();
                        emailAccountList[i].CreationDate = DateTime.Parse(sqliteDataReader["CreationDate"].ToString());
                        emailAccountList[i].LastUpdate = DateTime.Parse(sqliteDataReader["LastUpdate"].ToString());
                    }
                }
            }

            return emailAccountList;
        }

        public GeneralAccount[] QuerySearchGeneralAccountData(string searchFilteredText = null)
        {
            GeneralAccount[] generalAccountList = new GeneralAccount[0];

            using (SQLiteDataReader sqliteDataReader = QuerySearchSelectedAccountData(Utilities.QuerySearchGeneralAccountData, searchFilteredText))
            {
                if (sqliteDataReader.HasRows)
                {
                    for (int i = 0; sqliteDataReader.Read(); i++)
                    {
                        Array.Resize(ref generalAccountList, (generalAccountList.Length + 1));

                        generalAccountList[i].ID = uint.Parse(sqliteDataReader["ID"].ToString());
                        generalAccountList[i].Name = sqliteDataReader["Name"].ToString();
                        generalAccountList[i].Username = sqliteDataReader["Username"].ToString();
                        generalAccountList[i].Email = sqliteDataReader["Email"].ToString();
                        generalAccountList[i].Password = sqliteDataReader["Password"].ToString();
                        generalAccountList[i].Other = sqliteDataReader["Other"].ToString();
                        generalAccountList[i].CreationDate = DateTime.Parse(sqliteDataReader["CreationDate"].ToString());
                        generalAccountList[i].LastUpdate = DateTime.Parse(sqliteDataReader["LastUpdate"].ToString());
                    }
                }
            }

            return generalAccountList;
        }
        #endregion

        #region BACKUP
        public void BackupDatabase(string plainTextPassword)
        {
            if (!IsDatabaseConnectionOpened())
            {
                throw (new CoreLogicException("You must open connection before.", CoreLogicErrorCode.ConnectionClosed));
            }
            else if (!DatabaseExists())
            {
                throw (new CoreLogicException("You must first create database.", CoreLogicErrorCode.DatabaseNotFound));
            }

            string backupNamePath = Path.Combine(Utilities.BackupDir, Utilities.DatabaseName);
            string fullBackupNamePath = Path.Combine(Utilities.BackupDir, string.Format(Utilities.BackupName, DateTime.Now.ToString("yyyy-MM-dd")));

            try
            {
                Directory.CreateDirectory(Utilities.BackupDir);

                using (SQLiteConnection sqliteConnectionBackup = new SQLiteConnection(string.Format(Utilities.DatabaseConnection, backupNamePath)))
                {
                    sqliteConnectionBackup.SetPassword(SetEncryptedDatabasePassword(plainTextPassword, true));
                    sqliteConnectionBackup.Open();

                    sqliteConnection.BackupDatabase(sqliteConnectionBackup, "main", "main", -1, null, 0);
                }

                using (ZipArchive zipArchive = ZipFile.Open(fullBackupNamePath, ZipArchiveMode.Create))
                {
                    zipArchive.CreateEntryFromFile(backupNamePath, Utilities.DatabaseName);
                }
            }
            catch (Exception exception)
            {
                File.Delete(fullBackupNamePath);

                throw (new CoreLogicException(("Error while creating backup.\n" + exception.Message), CoreLogicErrorCode.BackupFailed));
            }
            finally
            {
                File.Delete(backupNamePath);
            }
        }
        #endregion

        #region DISPOSE
        private bool disposedValue = false;

        public void Dispose()
        {
            if (!disposedValue)
            {
                disposedValue = true;

                CloseDatabaseConnection();
                sqliteConnection.Dispose();

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        #endregion
    }
}