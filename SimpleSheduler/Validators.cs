using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheduler
{
    public static class Validators
    {
        public static bool Validate_SheduledTaskList(List<Dictionary<string, string>> taskList)
        {
            foreach (var item in taskList)
            {
                foreach(var key in item) 
                { 
                    switch (key.Key) 
                    {
                        case "":
                            break;
                        default:
                            break;
                    }
                }
            }

            return true;
        }
    }
}
