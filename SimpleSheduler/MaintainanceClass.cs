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
            var taskList = QueryDB_SelectStatement_ReturnListObject(QueriesStorage.SelectAllQuery);
            
            if (taskList != null)
            {

            }
            else
            {
                Log.Warning("Empty task list!!!");
                return;
            }
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

        private static List<Dictionary<string, string>> QueryDB_SelectStatement_ReturnListObject(string QueryString)
        {
            List<Dictionary<string, string>> DBObjects_List = new List<Dictionary<string, string>>();
            Dictionary<string, string> DBObject;
            using (var sqlite = new SQLiteConnection($"Data Source={GlobalVariables.dbPath}"))
            {
                sqlite.Open();
                SQLiteCommand command = new SQLiteCommand(QueryString, sqlite);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DBObject = new Dictionary<string, string>();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            DBObject.Add(reader.GetName(i), reader[i]?.ToString());
                        }

                        DBObjects_List.Add(DBObject);
                    }
                }
            }

            return DBObjects_List.Count > 0 ? DBObjects_List : null;
        }
    }
}
