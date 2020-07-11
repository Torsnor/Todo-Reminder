using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assigment6A
{
    class TaskManager
    {
        private List<TodoTask> taskList;

        public TaskManager()
        {
            taskList = new List<TodoTask>();
        }

        public TodoTask GetItem (int index)
        {
            if (!CheckIndex(index))
                return null;

            return taskList[index];
        }

        public int Count()
        {
             return taskList.Count; 
        }

        public bool AddTask (TodoTask taskIn)
        {
            bool ok = false;
            if (taskIn != null)
            {
                taskList.Add(taskIn);
                ok = true;
            }
            return ok;
        }

        private bool CheckIndex (int index)
        {
            return (index >= 0) && (index < taskList.Count);
        }
 
        public string[] GetTaskInfoStrings()
        {
            string[] stringInfoStrings = new string[taskList.Count];

            int i = 0;
            foreach (TodoTask Taskobj in taskList)
            {
                stringInfoStrings[i++] = Taskobj.ToString();
            }
            return stringInfoStrings;
        }
    }
}
