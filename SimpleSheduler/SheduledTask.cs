using System;

namespace SimpleSheduler
{
    public sealed class SheduledTask
    {
        public int TaskID { get; }
        public string TaskName { get; }
        public string TaskDescription { get; }
        public bool IsFinished { get; }
        public bool IsInProcess { get; }
        public DateTime CreatedDate { get; }
        public DateTime ChangedDate { get; }


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
