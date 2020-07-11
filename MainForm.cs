using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assigment6A
{
    public partial class MainForm : Form
    {
        TaskManager taskManager = new TaskManager();      

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            cmbUnit.Items.AddRange(Enum.GetNames(typeof(PriorityTypes)));
            cmbUnit.SelectedIndex = (int)PriorityTypes.Normal;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            bool success = false;

            TodoTask task = ReadInput(out success);
            if (success)
            {
                taskManager.AddTask(task);
                UpdateGUI();
            }
        }

        private TodoTask ReadInput(out bool success)
        {
            success = false;

            TodoTask task = new TodoTask();

            task.Description = ReadDescription(out success);
            if (!success)
                return null;

            task.Unit = ReadUnit(out success);

            return task;
        }     

        private PriorityTypes ReadUnit (out bool success)
        {
            success = false;
            PriorityTypes unit = PriorityTypes.Normal;

            if (cmbUnit.SelectedIndex >= 0)
            {
                success = true;
                unit = (PriorityTypes)cmbUnit.SelectedIndex;
            }
            else
                GiveMessage("Wrong unit!");

            return unit;
        }

        private void GiveMessage(string message)
        {
            MessageBox.Show(message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
        }

        private string ReadDescription (out bool success)
        {
            success = false;

            string text = txtDescription.Text.Trim();
            if (!string.IsNullOrEmpty(text))
                success = true;
            else
                GiveMessage("Provide a description");

            return text;
        }

        private void UpdateGUI()
        {
            lstItems.Items.Clear();
            string[] itemStrings = taskManager.GetTaskInfoStrings();
            if (itemStrings != null)
                lstItems.Items.AddRange(itemStrings);
        }

        private void Timer_Seconds_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();

        }

        private void Menu_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
