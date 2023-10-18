using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace SimpleSheduler
{
    public static class MaintainanceClass
    {
        public static bool CheckIfDBExists()
        {
            return File.Exists(Environment.CurrentDirectory + "\\Sheduler");
        }
        public static bool CreateDBAndTable_MissingDB()
        {            
            SQLiteConnection.CreateFile(GlobalVariables.dbPath);

            QueryDB_NonSelectStatement(QueriesStorage.CreateMainTableQuery);
            bool dataInserted = QueryDB_NonSelectStatement(QueriesStorage.SAMPLE_DATA) > 0;
            return dataInserted;
        }

        public static void GetAllDataFromMainTable()
        {
            QueryDB_NonSelectStatement(QueriesStorage.SelectAllQuery);
        }

        private static int QueryDB_NonSelectStatement(string QueryString)
        {
            using (var sqlite = new SQLiteConnection($"Data Source={GlobalVariables.dbPath}"))
            {
                sqlite.Open();
                SQLiteCommand command = new SQLiteCommand(QueryString, sqlite);
                return command.ExecuteNonQuery();
            }
        }

        private static List<object> QueryDB_SelectStatement_ReturnListObject(string QueryString)
        {
            object item = new object();
            List<object> list = new List<object>();

            using (var sqlite = new SQLiteConnection($"Data Source={GlobalVariables.dbPath}"))
            {
                sqlite.Open();
                SQLiteCommand command = new SQLiteCommand(QueryString, sqlite);
            }

            return list;
        }
    }
}
