using System;

namespace SimpleSheduler
{
    public sealed class SheduledTask
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsFinished { get; set; }
        public bool IsInProcess { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }


        public SheduledTask(int taskId = 0,
                            string taskName = "",
                            string taskDescription = "",
                            bool isFinished = false,
                            bool isInProcess = false,
                            DateTime createdDt = new DateTime(),
                            DateTime changedDt = new DateTime())
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
