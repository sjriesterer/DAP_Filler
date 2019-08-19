using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAP_Filler
    {
    class Tab
        {
        public String tabName = "";
        public List<AutoFillEntry> autoFillList;
        public BindingList<AutoFillEntry> bindingList;
        public int rowSelected = 0;
        public int colSelected = 1;
        public DataGridView dataGridView;
        public TextBox autoEntryTB;
        public SortOrder[] sortOrder = new SortOrder[3];
        // -------------------------------------------------------------------------------------------------

        public Tab(String name)
            {
            Console.WriteLine("Init new tab : " + name);
            this.tabName = name;
            this.autoFillList = new List<AutoFillEntry>();
            PopulateList();
            sortOrder[0] = SortOrder.None;
            sortOrder[1] = SortOrder.None;
            sortOrder[2] = SortOrder.None;
            this.bindingList = new BindingList<AutoFillEntry>(autoFillList);
            }
        // -------------------------------------------------------------------------------------------------

        public void InitTab(DataGridView dataGridView, TextBox textBox)
            {
            this.autoEntryTB = textBox;
            this.dataGridView = dataGridView;
            this.dataGridView.DataSource = bindingList;
            this.dataGridView.RowHeadersVisible = false;
            }
        // -------------------------------------------------------------------------------------------------

        private void PopulateList()
            {
            for (int i = 10; i >= 0; i--)
                {
                AutoFillEntry ae = new AutoFillEntry("This is autofill " + i, i);
                autoFillList.Add(ae);
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void PrintList()
            {
            Console.WriteLine("Contents of List: \n");
            for (int i = 0; i < autoFillList.Count; i++)
                {
                Console.WriteLine(i + " : " + autoFillList[i].entry);
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void DeleteButtonClick()
            {
            autoEntryTB.Text = "";
            }
        // -------------------------------------------------------------------------------------------------
        public void CutButtonClick()
            {
            if (autoEntryTB.Text.CompareTo("") != 0)
                {
                System.Windows.Forms.Clipboard.SetText(autoEntryTB.Text);
                autoEntryTB.Text = "";
                Learn();
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void CopyButtonClick()
            {
            if (autoEntryTB.Text.CompareTo("") != 0)
                {
                System.Windows.Forms.Clipboard.SetText(autoEntryTB.Text);
                Learn();
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void UndoButtonClick()
            {

            }
        // -------------------------------------------------------------------------------------------------
        public void AutoFillEntry_Enter()
            {

            }
        public void AutoFillEntry_Leave()
            {

            }
        public void AutoFillEntry_TextChanged()
            {

            }
        // -------------------------------------------------------------------------------------------------
        public void AddRowButtonClick()
            {
            Console.WriteLine("AddRowButtonClick() : " + tabName);
            autoFillList.Add(new AutoFillEntry(C.newCellText));
            rowSelected = autoFillList.Count - 1;
            colSelected = 2;
            ResetGrid();
            dataGridView.BeginEdit(true); /// Auto selects new cell text
            }
        // -------------------------------------------------------------------------------------------------
        public void ResetGrid()
            {
            Console.WriteLine("ResetGrid()");
            dataGridView.DataSource = null;
            bindingList = new BindingList<AutoFillEntry>(autoFillList);
            dataGridView.DataSource = bindingList;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView.Columns[1].Width = 40;
            dataGridView.Columns[1].ReadOnly = true;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.RowHeadersVisible = false;
            SelectCurrentCell();
            }

        // -------------------------------------------------------------------------------------------------
        public void SelectCurrentCell()
            {
            dataGridView.CurrentCell = dataGridView.Rows[rowSelected].Cells[colSelected];
            }
        // -------------------------------------------------------------------------------------------------
        public void SelectCell(int row, int col)
            {
            rowSelected = row;
            colSelected = col;
            dataGridView.CurrentCell = dataGridView.Rows[row].Cells[col];
            }
        // -------------------------------------------------------------------------------------------------
        public void RightMouseClick(int row, int col, Point p)
            {
            Console.WriteLine("RightMouseClick() " + tabName + " at point [" + p.X + "][" + p.Y + "]; row = " + row + "; col = " + col);
            ContextMenu m = new ContextMenu();
            MenuItem m1 = new MenuItem("Delete");
            //m1.Click += new System.EventHandler(this.MenuItemDeleteClick);
            m1.Click += delegate (object sender, System.EventArgs e) { MenuItemDeleteClick( sender, e); };
            m.MenuItems.Add(m1);

            MenuItem m2 = new MenuItem("Edit");
            m2.Click += delegate (object sender, System.EventArgs e) { MenuItemEditClick( sender, e); };
            m.MenuItems.Add(m2);

            MenuItem m3 = new MenuItem("Cut");
            m3.Click += delegate (object sender, System.EventArgs e) { MenuItemCutClick( sender, e); };
            m.MenuItems.Add(m3);

            MenuItem m4 = new MenuItem("Copy");
            m4.Click += delegate (object sender, System.EventArgs e) { MenuItemCopyClick( sender, e); };
            m.MenuItems.Add(m4);

            MenuItem m5 = new MenuItem("Paste");
            m5.Click += delegate (object sender, System.EventArgs e) { MenuItemPasteClick( sender, e); };
            m.MenuItems.Add(m5);


            SelectCell(row, col);
            m.Show(dataGridView, p);

            }
        // -------------------------------------------------------------------------------------------------
        /* Context Menu */
        public void MenuItemDeleteClick( object sender, System.EventArgs e)
            {
            Console.WriteLine("Context menu Delete click : tab = " + tabName);

            }
        public void MenuItemEditClick( object sender, System.EventArgs e)
            {
            Console.WriteLine("Context menu Edit click : tab = " + tabName);
            }
        public void MenuItemCutClick( object sender, System.EventArgs e)
            {
            Console.WriteLine("Context menu Cut click : tab = " + tabName);

            }
        public void MenuItemCopyClick( object sender, System.EventArgs e)
            {
            Console.WriteLine("Context menu Copy click : tab = " + tabName);

            }
        public void MenuItemPasteClick( object sender, System.EventArgs e)
            {
            Console.WriteLine("Context menu Paste click : tab = " + tabName);

            }
        // -------------------------------------------------------------------------------------------------
        public Point RelativePoint(DataGridViewCellMouseEventArgs e)
            {
            int x = e.X;
            int y = e.Y;
            if (dataGridView.RowHeadersVisible)
                x += dataGridView.RowHeadersWidth;
            if (dataGridView.ColumnHeadersVisible)
                y += dataGridView.ColumnHeadersHeight;
            for (int j = 0; j < e.ColumnIndex; j++)
                if (dataGridView.Columns[j].Visible)
                    x += dataGridView.Columns[j].Width;
            for (int i = 0; i < e.RowIndex; i++)
                if (dataGridView.Rows[i].Visible)
                    y += dataGridView.Rows[i].Height;
            return new Point(x, y);
            }
        // -------------------------------------------------------------------------------------------------
        public void ColumnHeaderMouseClick( int colIndex)
            {
            string colName = dataGridView.Columns[colIndex].Name;
            Console.WriteLine("ColumnHeaderMouseClick() " + tabName + " : columnName = " + colName);

            if ("Post".CompareTo(colName) != 0)
                {
                SortOrder strSortOrder = GetSortOrder(colIndex);
                SortList(colName, strSortOrder);
                ResetGrid();
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void SortList( String colName, SortOrder sortOrder)
            {
            Console.WriteLine("SortList() : columnName = " + colName + "; sortOrder = " + sortOrder);
            if (sortOrder == SortOrder.Ascending)
                {
                autoFillList = autoFillList.OrderBy(x => typeof(AutoFillEntry).GetProperty(colName).GetValue(x, null)).ToList();
                }
            else
                {
                autoFillList = autoFillList.OrderByDescending(x => typeof(AutoFillEntry).GetProperty(colName).GetValue(x, null)).ToList();
                }
            PrintList();
            }
        // -------------------------------------------------------------------------------------------------
        public SortOrder GetSortOrder( int colIndex)
            {
            Console.WriteLine("GetSortOrder() : order is " + dataGridView.Columns[colIndex].HeaderCell.SortGlyphDirection);

            if (sortOrder[colIndex] == SortOrder.None || sortOrder[colIndex] == SortOrder.Descending)
                {
                sortOrder[colIndex] = SortOrder.Ascending;
                return SortOrder.Ascending;
                }
            else
                {
                sortOrder[colIndex] = SortOrder.Descending;
                return SortOrder.Descending;
                }
            }

        // -------------------------------------------------------------------------------------------------
        public void CellClick( int rowIndex, int colIndex)
            {
            Console.WriteLine("CellClick() " + tabName + " : [" + rowIndex + "][" + colIndex + "]");
            if (colIndex == 0)
                {
                //dataGridView.CurrentCell.Selected = false;
                //dataGridView.CurrentCell = dataGridView.Rows[tabData.rowSelected].Cells[tabData.colSelected];
                //PostEntry(rowIndex);
                }
            else
                {
                /// Update current selection
                rowSelected = dataGridView.CurrentCell.RowIndex;
                colSelected = dataGridView.CurrentCell.ColumnIndex;
                if (dataGridView.CurrentCell.ColumnIndex == 2) /// If selecting the Entry column
                    {
                    if (C.newCellText.CompareTo(autoFillList[rowSelected].entry) == 0) /// If entry is new and currently has placeholder
                        {
                        /// Handle auto cell text
                        }
                    }
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void CellDoubleClick( int rowIndex, int colIndex)
            {
            Console.WriteLine("CellDoubleClick() " + tabName + " : [" + rowIndex + "][" + colIndex + "]");
            PostEntry(rowIndex);
            }
        // -------------------------------------------------------------------------------------------------
        public void ResetTab()
            {
            autoEntryTB.Text = "";
            }
        // -------------------------------------------------------------------------------------------------

        public void PatientChange()
            {
            Console.WriteLine("PatientChange() : oldName = " + C.oldPatientName + "; newName = " + C.patientName + "; oldIsMale = " + C.oldIsMale + "; isMale = " + C.isMale);
            autoEntryTB.Text = PersonalizeText(autoEntryTB.Text);
            C.oldIsMale = C.isMale;
            }
        // -------------------------------------------------------------------------------------------------

        public void PostEntry(int rowIndex)
            {
            Console.WriteLine("PostEntry() " + tabName + " : ");
            autoEntryTB.Text += PersonalizePost(dataGridView.Rows[rowIndex].Cells[2].Value.ToString() + " ");
            }
        // -------------------------------------------------------------------------------------------------

        public String PersonalizePost(String s)
            {
            


            return s;

            }
        // -------------------------------------------------------------------------------------------------

        public String PersonalizeText(String oldString)
            {
            Console.WriteLine("PersonalizeText() : " + tabName);


            return oldString;
            }

        // -------------------------------------------------------------------------------------------------

        public void Learn()
            {
            Console.WriteLine("Learn() : " + tabName);

            }

        // -------------------------------------------------------------------------------------------------


        }
    }
