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
        //public String newCellText = "<Edit Entry>";
        //public String patientName = "";
        //public Boolean isMale = true;

        internal Tab TabData { get => tabData; set => tabData = value; }

        public Form1()
            {
            InitializeComponent();
            tabData = new Tab("Data");
            tabData.InitTab(DataGridView_D, AutoFillEntry_D);
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
            SelectCurrentCell(tab);
            }
        private void SelectCurrentCell(Tab tab)
            {
            tab.dataGridView.CurrentCell = DataGridView_D.Rows[tab.rowSelected].Cells[tab.colSelected];
            }

        private void SelectCell(Tab tab, int row, int col)
            {
            tab.rowSelected = row;
            tab.colSelected = col;
            tab.dataGridView.CurrentCell = DataGridView_D.Rows[row].Cells[col];
            }

        private void PostEntry(Tab tab, int row)
            {
            Console.WriteLine("PostEntry() " + tab.tabName + " : [" + row + "]");

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
            if (PatientNameTB.Text == C.noNameText)
                {
                PatientNameTB.Text = "";
                C.patientName = "";
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
                PatientNameTB.Text = C.noNameText;
                C.patientName = C.noNameText;
                PatientNameTB.ForeColor = Color.Gray;
                }
            else
                {
                PatientNameTB.ForeColor = Color.Black;
                }
            C.oldPatientName = C.patientName;
            C.patientName = PatientNameTB.Text;
            tabData.PatientChange();
            }

        private void PatientName_TextChanged(object sender, EventArgs e)
            {
            Console.WriteLine("PatientName_TextChanged() : name = " + PatientNameTB.Text);
            }


        private void NewPatient_Click(object sender, EventArgs e)
            {
            C.oldPatientName = "";
            C.patientName = "";
            PatientNameTB.Text = "";
            MaleRadioButton.Checked = true;
            C.oldIsMale = true;
            C.isMale = true;
            tabData.ResetTab();
            }

        private void MaleButton_CheckedChanged(object sender, EventArgs e)
            {
            C.oldIsMale = C.isMale;
            C.isMale = MaleRadioButton.Checked;
            tabData.PatientChange();
            }

        private void FemaleButton_CheckedChanged(object sender, EventArgs e)
            {
            }

        /* Data Tab */
        private void AutoFillEntry_TextChanged_D(object sender, EventArgs e)
            {
            tabData.AutoFillEntry_TextChanged();
            }

        private void DeleteButton_Click_D(object sender, EventArgs e)
            {
            tabData.DeleteButtonClick();
            }

        private void UndoButton_Click_D(object sender, EventArgs e)
            {
            tabData.UndoButtonClick();
            }


        private void CutButton_Click_D(object sender, EventArgs e)
            {
            tabData.CutButtonClick();
            }

        private void CopyButton_Click_D(object sender, EventArgs e)
            {
            tabData.CopyButtonClick();
            }


        /* Data Grid View Data */

        private void DataGridView_ColumnHeaderMouseClick_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Left)
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

        private void DataGridView_CellMouseClick()
            {

            }
        private void DataGridView_MouseClick_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                Point p = RelativePoint(tabData.dataGridView, e);
                RightMouseClick(tabData,e.RowIndex, e.ColumnIndex, p);
                }
            }

        /* UNIVERSAL METHODS */

        private void RightMouseClick(Tab tab, int row, int col, Point p)
            {
            Console.WriteLine("RightMouseClick() " + tab.tabName + " at point [" + p.X + "][" + p.Y + "]; row = " + row + "; col = " + col);
            ContextMenu m = new ContextMenu();
            MenuItem m1 = new MenuItem("Delete");
            //m1.Click += new System.EventHandler(this.MenuItemDeleteClick);
            m1.Click += delegate (object sender, System.EventArgs e) { MenuItemDeleteClick(tab, sender, e); };
            m.MenuItems.Add(m1);

            MenuItem m2 = new MenuItem("Edit");
            m2.Click += delegate(object sender, System.EventArgs e) { MenuItemEditClick(tab, sender, e); };
            m.MenuItems.Add(m2);

            MenuItem m3 = new MenuItem("Cut");
            m3.Click += delegate (object sender, System.EventArgs e) { MenuItemCutClick(tab, sender, e); };
            m.MenuItems.Add(m3);

            MenuItem m4 = new MenuItem("Copy");
            m4.Click += delegate (object sender, System.EventArgs e) { MenuItemCopyClick(tab, sender, e); };
            m.MenuItems.Add(m4);

            MenuItem m5 = new MenuItem("Paste");
            m5.Click += delegate (object sender, System.EventArgs e) { MenuItemPasteClick(tab, sender, e); };
            m.MenuItems.Add(m5);


            SelectCell(tab, row, col);
            m.Show(tab.dataGridView, p);

            }

        private void MenuItemDeleteClick(Tab tab, object sender, System.EventArgs e)
            {
            Console.WriteLine("Context menu Delete click : tab = " + tab.tabName);

            }
        private void MenuItemEditClick(Tab tab, object sender, System.EventArgs e)
            {
            Console.WriteLine("Context menu Edit click : tab = " + tab.tabName);
            }
        private void MenuItemCutClick(Tab tab, object sender, System.EventArgs e)
            {
            Console.WriteLine("Context menu Cut click : tab = " + tab.tabName);

            }
        private void MenuItemCopyClick(Tab tab, object sender, System.EventArgs e)
            {
            Console.WriteLine("Context menu Copy click : tab = " + tab.tabName);

            }
        private void MenuItemPasteClick(Tab tab, object sender, System.EventArgs e)
            {
            Console.WriteLine("Context menu Paste click : tab = " + tab.tabName);

            }


        public static Point RelativePoint(DataGridView dgv, DataGridViewCellMouseEventArgs e)
            {
            int x = e.X;
            int y = e.Y;
            if (dgv.RowHeadersVisible)
                x += dgv.RowHeadersWidth;
            if (dgv.ColumnHeadersVisible)
                y += dgv.ColumnHeadersHeight;
            for (int j = 0; j < e.ColumnIndex; j++)
                if (dgv.Columns[j].Visible)
                    x += dgv.Columns[j].Width;
            for (int i = 0; i < e.RowIndex; i++)
                if (dgv.Rows[i].Visible)
                    y += dgv.Rows[i].Height;
            return new Point(x, y);
            }

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
                tab.PostEntry(rowIndex);
                }
            else
                {
                /// Update current selection
                tab.rowSelected = tab.dataGridView.CurrentCell.RowIndex;
                tab.colSelected = tab.dataGridView.CurrentCell.ColumnIndex;
                if (tab.dataGridView.CurrentCell.ColumnIndex == 2) /// If selecting the Entry column
                    {
                    if (C.newCellText.CompareTo(tabData.autoFillList[tabData.rowSelected].entry) == 0) /// If entry is new and currently has placeholder
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
            tab.autoFillList.Add(new AutoFillEntry(C.newCellText));
            tab.rowSelected = tab.autoFillList.Count - 1;
            tab.colSelected = 2;
            ResetGrid(tab);
            tab.dataGridView.BeginEdit(true); /// Auto selects new cell text
            }

        }
    }