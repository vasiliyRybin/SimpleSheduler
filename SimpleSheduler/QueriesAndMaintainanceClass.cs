using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SimpleSheduler
{
    public static class QueriesAndMaintainanceClass
    {
        public static bool CheckIfDBExists()
        {
            return File.Exists(Environment.CurrentDirectory + "\\Sheduler");
        }
        public static bool CreateDBAndTable_MissingDB()
        {
            const string CreateMainTableQuery = "CREATE TABLE TaskList (\r\n " +
                                                "TaskID          INTEGER   PRIMARY KEY ASC AUTOINCREMENT\r\n  NOT NULL\r\n UNIQUE\r\n DEFAULT (1),\r\n " +
                                                "TaskName        TEXT (50) NOT NULL\r\n  DEFAULT ('New Task'),\r\n    " +
                                                "TaskDescription TEXT,\r\n " +
                                                "IsFinished      INTEGER   NOT NULL\r\n DEFAULT (0),\r\n " +
                                                "IsInProcess     INTEGER   DEFAULT (0) \r\n  NOT NULL,\r\n " +
                                                "CreatedDate     TEXT      NOT NULL\r\n  DEFAULT ('1900-01-01 00:00:00'),\r\n    " +
                                                "ChangedDate     TEXT      DEFAULT ('1900-01-01 00:00:00') \r\n);";

            return false;
        }
    }
}
