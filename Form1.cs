using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAP_Filler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void PatientName_Enter(object sender, EventArgs e)
        {
            Debug.WriteLine("Entering, text = " + textBox1.Text);
            textBox1.ForeColor = Color.Black;
            if (textBox1.Text == "Enter Name")
            {
                textBox1.Text = "";
            }
            else
            {
                BeginInvoke((Action)delegate
                {
                    textBox1.SelectAll();
                });
            }

        }

        private void PatientName_Leave(object sender, EventArgs e)
        {
            Debug.WriteLine("Leaving, text = " + textBox1.Text);
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Name";
                textBox1.ForeColor = Color.Gray;
            }
            else
            {
                textBox1.ForeColor = Color.Black;
            }
        }
        private void PatientName_TextChanged(object sender, EventArgs e)
        {

        }


        private void NewPatient_Click(object sender, EventArgs e)
        {

        }

        private void MaleButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FemaleButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
