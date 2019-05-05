namespace DatabaseCoreLogic
{
    internal static class Utilities
    {
        #region GENERAL
        public static int MaxGenericLength { get { return 32; } }

        public static int MaxEmailLength { get { return 50; } }
        #endregion

        #region DATABASE_PASSWORD
        public static int MinDatabasePasswordLength { get { return 8; } }

        public static string DatabasePasswordRegex
        {
            get
            {
                return (@"^(?!.*(.)\1{2})[A-Z]{1}(?=.*\d)[(\p{L}\w)a-zA-Z0-9!#$%&*+\-<=>?@^_~]{" +
                    MinDatabasePasswordLength + (@",") + MaxGenericLength + (@"}$"));
            }
        }
        #endregion

        #region DATABASE_UTILITIES
        public static string DatabaseName { get { return ("DatabasePassword.sqlite"); } }

        public static string DatabaseConnection { get { return ("Data Source = {0}; Version = 3; Foreign Keys = True;"); } }

        public static string DatabaseLogin { get { return ("PRAGMA application_id;"); } }
        #endregion

        #region DATABASE_BACKUP
        public static string BackupDir { get { return ("Backup"); } }

        public static string BackupName { get { return ("DatabasePasswordBackup_{0}.zip"); } }
        #endregion

        #region CREATE_TABLES
        public static string CreateTableEmailAccount
        {
            get
            {
                return (@"CREATE TABLE 'EmailAccount'
                        ('ID' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        'Name' TEXT NOT NULL UNIQUE COLLATE NOCASE,
                        'Email' TEXT NOT NULL UNIQUE COLLATE NOCASE,
                        'Password' TEXT NOT NULL,
                        'CreationDate' TEXT NOT NULL,
                        'LastUpdate' TEXT NOT NULL);");
            }
        }

        public static string CreateTableGeneralAccount
        {
            get
            {
                return (@"CREATE TABLE 'GeneralAccount'
                        ('ID' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        'Name' TEXT NOT NULL UNIQUE COLLATE NOCASE,
                        'Username' TEXT NOT NULL,
                        'Password' TEXT NOT NULL,
                        'Other' TEXT NOT NULL,
                        'EmailID' INTEGER NULL REFERENCES EmailAccount('ID') ON UPDATE NO ACTION ON DELETE SET NULL,
                        'CreationDate' TEXT NOT NULL,
                        'LastUpdate' TEXT NOT NULL,
                        CHECK((Username != '') OR (EmailID IS NOT NULL)));");
            }
        }
        #endregion

        #region INSERT_FIELDS
        public static string InsertEmailAccountData
        {
            get
            {
                return (@"INSERT INTO EmailAccount('Name', 'Email', 'Password', 'CreationDate', 'LastUpdate')
                        VALUES(@name, @email, @password, DATETIME('NOW', 'LOCALTIME'), DATETIME('NOW', 'LOCALTIME'));");
            }
        }

        public static string InsertGeneralAccountData
        {
            get
            {
                return (@"INSERT INTO GeneralAccount('Name', 'Username', 'Password', 'Other', 'EmailID', 'CreationDate', 'LastUpdate')
                        VALUES(@name, @username, @password, @other, @emailID, DATETIME('NOW', 'LOCALTIME'), DATETIME('NOW', 'LOCALTIME'));");
            }
        }
        #endregion

        #region UPDATE_FIELDS
        public static string UpdateEmailAccountData
        {
            get
            {
                return (@"UPDATE 'EmailAccount'
                        SET 'Name' = @name, 'Email' = @email, 'Password' = @password, 'LastUpdate' = DATETIME('NOW', 'LOCALTIME')
                        WHERE ID = @id;");
            }
        }

        public static string UpdateGeneralAccountData
        {
            get
            {
                return (@"UPDATE 'GeneralAccount'
                        SET 'Name' = @name, 'Username' = @username, 'Password' = @password, 'Other' = @other, 'EmailID' = @emailID, 'LastUpdate' = DATETIME('NOW', 'LOCALTIME')
                        WHERE ID = @id;");
            }
        }
        #endregion

        #region DELETE_FIELDS
        public static string DeleteAccountData { get { return (@"DELETE FROM '{0}' WHERE ID = @id;"); } }
        #endregion

        #region QUERY_FIELDS
        public static string QuerySearchEmailAccountData
        {
            get
            {
                return (@"SELECT * FROM 'EmailAccount'
                        WHERE Name LIKE @input
                        ORDER BY Name ASC;");
            }
        }

        public static string QuerySearchGeneralAccountData
        {
            get
            {
                return (@"SELECT GA.ID, GA.Name, GA.Username, EA.Email, GA.Password, GA.Other, GA.CreationDate, GA.LastUpdate
                        FROM 'GeneralAccount' GA
                        LEFT OUTER JOIN 'EmailAccount' EA
                        ON GA.EmailID = EA.ID
                        WHERE GA.Name LIKE @input
                        ORDER BY GA.Name ASC;");
            }
        }
        #endregion
    }
}
