using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment6A
{
    class TodoTask
    {
        private string description;       
        private PriorityTypes unit;
        

        public TodoTask(string name, PriorityTypes unit)
        {
            this.description = name;         
            this.unit = Unit;
            
        }

        public TodoTask() : this("Unknown", PriorityTypes.Normal)
        {

        }

        public TodoTask (string description) : this(description, PriorityTypes.Normal)
        {

        }

        public TodoTask (TodoTask theOther)
        {
            description = theOther.description;          
            unit = theOther.unit;
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    description = value;
            }
        }      

        public PriorityTypes Unit
        {
            get { return unit; }
            set
            {
                if (Enum.IsDefined ( typeof ( PriorityTypes ), value ))
                    unit = value;
            }
        }

        public override string ToString()
        {
            string textOut = string.Empty;
            textOut = $"{description,-45} {unit,-6}";
            return textOut;
        }
    }
}
