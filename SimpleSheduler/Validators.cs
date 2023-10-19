using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace SimpleSheduler
{
    public static class Validators
    {
        public static HashSet<string> Validate_SheduledTaskList(List<Dictionary<string, string>> taskList)
        {
            HashSet<string> check = new HashSet<string>();
            foreach (var item in taskList)
            {
                if (check.Count > 0) return check;
                foreach(var keyValuePair in item)
                {
                    switch (keyValuePair.Key) 
                    {
                        case "TaskName":
                            if (string.IsNullOrWhiteSpace(keyValuePair.Value)) check.Add(keyValuePair.Key);
                            break;
                        case "IsFinished":
                        case "IsInProcess":
                            if (string.IsNullOrWhiteSpace(keyValuePair.Value)) check.Add(keyValuePair.Key);
                            if (Convert.ToInt32(keyValuePair.Value) > 1 || Convert.ToInt32(keyValuePair.Value) < 0) check.Add(keyValuePair.Key);
                            break;
                        case "CreatedDate":
                            if(!DateTime.TryParse(keyValuePair.Value, out _)) check.Add(keyValuePair.Key);
                            break;
                        case "ChangedDate":
                            if (!string.IsNullOrWhiteSpace(keyValuePair.Value))
                            {
                                if(!DateTime.TryParse(keyValuePair.Value, out _)) check.Add(keyValuePair.Key);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return check;
        }
    }
}
