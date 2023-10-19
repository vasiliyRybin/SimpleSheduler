using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler
{
    public static class QueriesStorage
    {
        public const string CreateMainTableQuery =  "CREATE TABLE TaskList (\r\n " +
                                                    "TaskID          INTEGER   PRIMARY KEY ASC AUTOINCREMENT\r\n  NOT NULL\r\n UNIQUE\r\n DEFAULT (1),\r\n " +
                                                    "TaskName        TEXT (50) NOT NULL\r\n  DEFAULT ('New Task'),\r\n    " +
                                                    "TaskDescription TEXT,\r\n " +
                                                    "IsFinished      INTEGER   NOT NULL\r\n DEFAULT (0),\r\n " +
                                                    "IsInProcess     INTEGER   DEFAULT (0) \r\n  NOT NULL,\r\n " +
                                                    "CreatedDate     TEXT      NOT NULL\r\n  DEFAULT ('1900-01-01 00:00:00'),\r\n    " +
                                                    "ChangedDate     TEXT      DEFAULT ('1900-01-01 00:00:00') \r\n);";

        public const string SAMPLE_DATA = "INSERT INTO TaskList(TaskName,TaskDescription,IsFinished,IsInProcess,CreatedDate,ChangedDate)\r\n" +
                                          "VALUES('Walk with the Chop', 'And not forget to take goodies for him', 0, 0, '2023-10-18 19:10:00', '2023-10-18 19:20:00'), " +
                                          "('Buy goods. List in description', 'Milk, Fish, Potato, Kvas, Goodies for Chop', 0, 1, '2023-10-17 11:10:00', '2023-10-17 15:10:00')";

        public const string SelectAllQuery = "SELECT TaskID, TaskName, TaskDescription, IsFinished, IsInProcess, CreatedDate, ChangedDate FROM TaskList";
    }
}
