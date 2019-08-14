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
        private List<AutoFillEntry> autoFillList;

        public Form1()
        {
            InitializeComponent();
            autoFillList = new List<AutoFillEntry>();
            PopulateEntries();
            autoFillListView.View = View.Details;
            var bindingList = new BindingList<AutoFillEntry>(autoFillList);
            var source = new BindingSource(bindingList, null);
            //dataGridView1.DataSource = autoFillList;
            dataGridView1.DataSource = source;
            initListView();
        }


        private void PopulateEntries()
        {
            for (int i = 0; i < 100; i++)
            {
                AutoFillEntry ae = new AutoFillEntry("This is autofill " + i);
                autoFillList.Add(ae);
            }
        }

        private void initListView()
        {

            foreach (var o in autoFillList)
            {
                ListViewItem lvi = new ListViewItem();
                //lvi.Text = o.entry;
                lvi.Tag = o;
                lvi.SubItems.Add(o.entry);
                autoFillListView.Items.Add(lvi);
                
            }
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

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void UndoDButton_Click(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
