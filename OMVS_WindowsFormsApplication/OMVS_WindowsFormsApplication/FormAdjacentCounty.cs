using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace OMVS_WindowsFormsApplication
{
    public partial class FormAdjacentValidation : Form
    {
        public FormAdjacentValidation()
        {
            InitializeComponent();
        }

        private void buttonValidateAdjacency_Click(object sender, EventArgs e)
        {
            try
            {
                int val1 = int.Parse(textBoxCounty1.Text);
                int val2 = int.Parse(textBoxCounty2.Text);
                //Call the method which takes as parameters two integers and returns a 
                //Boolean result which is true if the counties are adjacent to one-another.
                if (AdjacentCounties.adjacency(val1, val2))
                {
                    labelResultDisplay.ForeColor = Color.Green;
                    labelResultDisplay.Text = "TRUE: Counties are adjacent";
                }
                else
                {
                    labelResultDisplay.ForeColor = Color.Red;
                    labelResultDisplay.Text = "FALSE: Counties are NOT adjacent";

                }
            }
            catch
            {
                labelResultDisplay.ForeColor = Color.Black;
                labelResultDisplay.Text = "Error: Only enter numbers in the text fields";
            }

        }

        private void FormAdjacentValidation_Shown(object sender, EventArgs e)
        {
            labelResultDisplay.Text = "Connecting to database: please wait...";
            var thread = new Thread(() => {
                Counties.seed();
            });
            thread.Start();
            thread.Join();
            labelResultDisplay.Text = "";
        }

        private void textBoxCounty1_Enter(object sender, EventArgs e)
        {
            labelResultDisplay.Text = "";
        }
        private void textBoxCounty2_Enter(object sender, EventArgs e)
        {
            labelResultDisplay.Text = "";
        }
    }
}
