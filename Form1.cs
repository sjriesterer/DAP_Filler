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
        public List<AutoFillEntry> autoFillList;
        public BindingList<AutoFillEntry> bindingList;

        public Form1()
            {
            InitializeComponent();
            autoFillList = new List<AutoFillEntry>();
            PopulateEntries();
            initDataGridView();
            }

        private void initDataGridView()
            {
            bindingList = new BindingList<AutoFillEntry>(autoFillList);
            dataGridView1.DataSource = bindingList;
            }

        private void ResetGrid()
            {
            Console.WriteLine("ResetGrid()");
            dataGridView1.DataSource = null;
            bindingList = new BindingList<AutoFillEntry>(autoFillList);
            dataGridView1.DataSource = bindingList;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }


        private void SortList(String columnName, SortOrder sortOrder)
            {
            Console.WriteLine("SortList() : columnName = " + columnName + "; sortOrder = " + sortOrder);
            if (sortOrder == SortOrder.Ascending)
                {
                autoFillList = autoFillList.OrderBy(x => typeof(AutoFillEntry).GetProperty(columnName).GetValue(x, null)).ToList();
                }
            else
                {
                autoFillList = autoFillList.OrderByDescending(x => typeof(AutoFillEntry).GetProperty(columnName).GetValue(x, null)).ToList();
                }
            PrintList();
            //dataGridView1.DataSource = autoFillList;
            //dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
            }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
            string strColumnName = dataGridView1.Columns[e.ColumnIndex].Name;

            Console.WriteLine("ColumnHeaderMouseClick() : columnName = " + strColumnName);
            if ("Post".CompareTo(strColumnName) != 0)
                {
                SortOrder strSortOrder = getSortOrder(e.ColumnIndex);
                SortList(strColumnName, strSortOrder);
                ResetGrid();
                //dataGridView1.DataSource = null;
                //dataGridView1.DataSource = autoFillList;
                //dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
                }

            }

        private SortOrder getSortOrder(int columnIndex)
            {
            if (dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
                {
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
                }
            else
                {
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
                }
            }


        private void PrintList()
            {
            Console.WriteLine("Contents of List: \n");
            for (int i = 0; i < autoFillList.Count; i++)
                {
                Console.WriteLine(i + " : " + autoFillList[i].entry);
                }
            }

        private void PopulateEntries()
            {
            for (int i = 10; i >= 0; i--)
                {
                AutoFillEntry ae = new AutoFillEntry("This is autofill " + i, i);
                autoFillList.Add(ae);
                }
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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
            Console.WriteLine("CellClick(): [" + e.ColumnIndex + "][" + e.RowIndex + "]");

            }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
            Console.WriteLine("CellDoubleClick(): [" + e.ColumnIndex + "][" + e.RowIndex + "]");

            }

        private void AddRowButtonClick(object sender, EventArgs e)
            {
            Console.WriteLine("AddRowButtonClick()");
            autoFillList.Add(new AutoFillEntry("sample"));
            ResetGrid();
            
            }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
            {
            Console.WriteLine("RowsAdded(): list size = " + autoFillList.Count + "; row count = " + e.RowCount + "; row index = " + e.RowIndex);
            PrintList();
            }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
            {
            Console.WriteLine("CellContentClick() : [" + e.ColumnIndex + "][" + e.RowIndex + "]" );

            }

        }
    }