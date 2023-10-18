using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler
{
    public class SheduledTask
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsFinished { get; set; }
        public bool IsInProcess { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }


        public SheduledTask(int taskId, string taskName, string taskDescription, bool isFinished, bool isInProcess, DateTime createdDt, DateTime changedDt) 
        {
            TaskID = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            IsFinished = isFinished;
            IsInProcess = isInProcess;
            CreatedDate = createdDt;
            ChangedDate = changedDt;
        }   
    }
}
