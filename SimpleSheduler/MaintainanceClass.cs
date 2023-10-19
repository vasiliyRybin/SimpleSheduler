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

        public static List<SheduledTask> GetAllTasks_ToList()
        {
            var taskList = QueryDB_SelectStatement_ReturnListWithDictionary(QueriesStorage.SelectAllQuery);

            if (taskList == null || taskList.Count == 0)
            {
                Log.Warning("Empty task list!!!");
                return new List<SheduledTask>();

            }

            var check = Validators.Validate_SheduledTaskList(taskList);
            if (check.Count != 0)
            {
                Log.Warning("One of the tasks contains wrong values. Wrong values is: " + string.Join(", ", check));
                return new List<SheduledTask>();
            }

            List<SheduledTask> tasks = new List<SheduledTask>();
            foreach (var task in taskList)
            {
                var taskID = Convert.ToInt32(task["TaskID"]);
                var taskName = task["TaskName"];
                var taskDesc = task["TaskDescription"];
                var isFinished = Convert.ToBoolean(task["IsFinished"] == "1");
                var isInProcess = Convert.ToBoolean(task["IsInProcess"] == "1");
                var createdDate = DateTime.Parse(task["CreatedDate"]);
                var changedDate = string.IsNullOrWhiteSpace(task["ChangedDate"]) ? new DateTime() : DateTime.Parse(task["ChangedDate"]);

                var parsedTask = new SheduledTask(taskID, taskName, taskDesc, isFinished, isInProcess, createdDate, changedDate);
                tasks.Add(parsedTask);
            }

            return tasks;
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

        private static List<Dictionary<string, string>> QueryDB_SelectStatement_ReturnListWithDictionary(string QueryString)
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

            return DBObjects_List;
        }
    }
}
