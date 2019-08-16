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
        private Tab tabData;
        public String newCellText = "<Edit Entry>";
        public String patientName = "";
        public Boolean isMale = true;

        internal Tab TabData { get => tabData; set => tabData = value; }

        public Form1()
            {
            InitializeComponent();
            tabData = new Tab("Data");
            tabData.InitTabGrid(DataGridView_D);
            }

        private void ResetGrid(Tab tab)
            {
            Console.WriteLine("ResetGrid()");
            tab.dataGridView.DataSource = null;
            tab.bindingList = new BindingList<AutoFillEntry>(tab.autoFillList);
            tab.dataGridView.DataSource = tab.bindingList;
            tab.dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            tab.dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            tab.dataGridView.Columns[1].Width = 40;
            tab.dataGridView.Columns[1].ReadOnly = true;
            tab.dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tab.dataGridView.RowHeadersVisible = false;
            tab.dataGridView.CurrentCell = DataGridView_D.Rows[tab.rowSelected].Cells[tab.colSelected];
            }

        private void PostEntry(Tab tab, int row)
            {
            Console.WriteLine("PostEntry() : Form = " + " : [" + row + "]");

            }

        private void SortList(Tab tab, String colName, SortOrder sortOrder)
            {
            Console.WriteLine("SortList() : columnName = " + colName + "; sortOrder = " + sortOrder);
            if (sortOrder == SortOrder.Ascending)
                {
                tab.autoFillList = tab.autoFillList.OrderBy(x => typeof(AutoFillEntry).GetProperty(colName).GetValue(x, null)).ToList();
                }
            else
                {
                tab.autoFillList = tab.autoFillList.OrderByDescending(x => typeof(AutoFillEntry).GetProperty(colName).GetValue(x, null)).ToList();
                }
            tab.PrintList();
            }


        private SortOrder GetSortOrder(Tab tab, int colIndex)
            {
            Console.WriteLine("GetSortOrder() : order is " + tab.dataGridView.Columns[colIndex].HeaderCell.SortGlyphDirection);

            if (tab.sortOrder[colIndex] == SortOrder.None || tab.sortOrder[colIndex] == SortOrder.Descending)
                {
                tab.sortOrder[colIndex] = SortOrder.Ascending;
                return SortOrder.Ascending;
                }
            else
                {
                tab.sortOrder[colIndex] = SortOrder.Descending;
                return SortOrder.Descending;
                }
            }


        /* EVENTS */

        /* Patient Info */
        private void PatientName_Enter(object sender, EventArgs e)
            {
            Debug.WriteLine("PatientName_Enter : name = " + PatientNameTB.Text);
            PatientNameTB.ForeColor = Color.Black;
            if (PatientNameTB.Text == "Enter Name")
                {
                PatientNameTB.Text = "";
                }
            else
                {
                BeginInvoke((Action)delegate
                    {
                        PatientNameTB.SelectAll();
                        });
                }
            }

        private void PatientName_Leave(object sender, EventArgs e)
            {
            Console.WriteLine("PatientName_Leave : name = " + PatientNameTB.Text);
            if (PatientNameTB.Text == "")
                {
                PatientNameTB.Text = "Enter Name";
                PatientNameTB.ForeColor = Color.Gray;
                }
            else
                {
                PatientNameTB.ForeColor = Color.Black;
                }
            }

        private void PatientName_TextChanged(object sender, EventArgs e)
            {
            Console.WriteLine("PatientName_TextChanged() : name = " + PatientNameTB.Text);
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

        /* Data Tab */

        private void AutoFillEntry_TextChanged_D(object sender, EventArgs e)
            {

            }
        private void DeleteButton_Click_D(object sender, EventArgs e)
            {
            AutoFillEntry_D.Text = "";
            tabData.autoEntry = "";
            }

        private void UndoButton_Click_D(object sender, EventArgs e)
            {

            }


        private void CutButton_Click_D(object sender, EventArgs e)
            {
            if (tabData.autoEntry.CompareTo("") != 0)
                {
                System.Windows.Forms.Clipboard.SetText(tabData.autoEntry);
                AutoFillEntry_D.Text = "";
                tabData.autoEntry = "";
                }
            }

        private void CopyButton_Click_D(object sender, EventArgs e)
            {
            if (tabData.autoEntry.CompareTo("") != 0)
                System.Windows.Forms.Clipboard.SetText(tabData.autoEntry);
            }

        /* Data Grid View Data */

        private void DataGridView_ColumnHeaderMouseClick_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            ColumnHeaderMouseClick(tabData, e.ColumnIndex);
            }

        private void DataGridView_CellClick_D(object sender, DataGridViewCellEventArgs e)
            {
            CellClick(tabData, e.RowIndex, e.ColumnIndex);
            }

        private void DataGridView_CellDoubleClick_D(object sender, DataGridViewCellEventArgs e)
            {
            CellDoubleClick(tabData, e.RowIndex, e.ColumnIndex);
            }

        private void AddRowButtonClick_D(object sender, EventArgs e)
            {
            AddRowButtonClick(tabData);
            }

        private void DataGridView_RowsAdded_D(object sender, DataGridViewRowsAddedEventArgs e)
            {
            Console.WriteLine("RowsAdded(): list size = " + tabData.autoFillList.Count + "; row count = " + e.RowCount + "; row index = " + e.RowIndex);
            //tabData.PrintList();
            //dataGridView_D.CurrentCell = dataGridView_D.Rows[tabData.rowSelected].Cells[tabData.colSelected];
            }


        /* UNIVERSAL METHODS */

        private void ColumnHeaderMouseClick(Tab tab, int colIndex)
            {
            string colName = DataGridView_D.Columns[colIndex].Name;
            Console.WriteLine("ColumnHeaderMouseClick() " + tab.tabName + " : columnName = " + colName);

            if ("Post".CompareTo(colName) != 0)
                {
                SortOrder strSortOrder = GetSortOrder(tab, colIndex);
                SortList(tab, colName, strSortOrder);
                ResetGrid(tab);
                }
            }

        private void CellClick(Tab tab, int rowIndex, int colIndex)
            {
            Console.WriteLine("CellClick() " + tab.tabName + " : [" + rowIndex + "][" + colIndex + "]");
            if (colIndex == 0) /// If selecting the Post column
                {
                tab.dataGridView.CurrentCell.Selected = false;
                tab.dataGridView.CurrentCell = tab.dataGridView.Rows[tabData.rowSelected].Cells[tabData.colSelected];
                PostEntry(tab, rowIndex);
                }
            else
                {
                /// Update current selection
                tab.rowSelected = tab.dataGridView.CurrentCell.RowIndex;
                tab.colSelected = tab.dataGridView.CurrentCell.ColumnIndex;
                if (tab.dataGridView.CurrentCell.ColumnIndex == 2) /// If selecting the Entry column
                    {
                    if (newCellText.CompareTo(tabData.autoFillList[tabData.rowSelected].entry) == 0) /// If entry is new and currently has placeholder
                        {
                        /// Handle auto cell text
                        }
                    }
                }

            }

        private void CellDoubleClick(Tab tab, int rowIndex, int colIndex)
            {
            Console.WriteLine("CellDoubleClick() " + tab.tabName + " : [" + rowIndex + "][" + colIndex + "]");
            }

        private void AddRowButtonClick(Tab tab)
            {
            Console.WriteLine("AddRowButtonClick() : " + tab.tabName);
            tab.autoFillList.Add(new AutoFillEntry(newCellText));
            tab.rowSelected = tabData.autoFillList.Count - 1;
            tab.colSelected = 2;
            ResetGrid(tab);
            }

        }
    }