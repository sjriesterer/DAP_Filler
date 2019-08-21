using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAP_Filler
    {
    class Tab
        {
        public List<int> checkboxClicks;
        public String tabName = "";
        public List<AutoFillEntry> autoFillList;
        public BindingList<AutoFillEntry> bindingList;
        public int rowSelected = 0;
        public int colSelected = 1;
        public TextBox entryBox;
        public DataGridView dataGridView;
        public SortOrder[] sortOrder = new SortOrder[3];
        // -------------------------------------------------------------------------------------------------

        public Tab(String name)
            {
            Console.WriteLine("Init new tab : " + name);
            this.tabName = name;
            this.autoFillList = new List<AutoFillEntry>();
            this.checkboxClicks = new List<int>();
            PopulateList();
            sortOrder[0] = SortOrder.None;
            sortOrder[1] = SortOrder.None;
            sortOrder[2] = SortOrder.None;
            this.bindingList = new BindingList<AutoFillEntry>(autoFillList);
            }
        // -------------------------------------------------------------------------------------------------
        public void InitTab(DataGridView dataGridView, TextBox textBox)
            {
            this.entryBox = textBox;
            this.dataGridView = dataGridView;
            this.dataGridView.DataSource = bindingList;
            this.dataGridView.RowHeadersVisible = false;
            }
        // -------------------------------------------------------------------------------------------------
        public void ResetBindingList()
            {
            bindingList = new BindingList<AutoFillEntry>(autoFillList);
            dataGridView.DataSource = bindingList;
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
        public void DeleteAutFillEntry()
            {
            entryBox.Text = "";
            }
        // -------------------------------------------------------------------------------------------------
        public void CutButtonClick()
            {
            if (entryBox.Text.CompareTo("") != 0)
                {
                System.Windows.Forms.Clipboard.SetText(StripArrows(entryBox.Text));
                if (C.learnMode)
                    {
                    if (C.patientNamePlaceholder.Equals(C.patientName))
                        {
                        MessageBox.Show(C.enterNameFirstText);
                        }
                    else
                        {
                        entryBox.Text = "";
                        Learn();
                        }
                    }
                Learn();
                }
            }

        // -------------------------------------------------------------------------------------------------
        public void CopyButtonClick()
            {
            if (entryBox.Text.CompareTo("") != 0)
                {
                System.Windows.Forms.Clipboard.SetText(StripArrows(entryBox.Text));
                if (C.learnMode)
                    {
                    if (C.patientNamePlaceholder.Equals(C.patientName))
                        {
                        MessageBox.Show(C.enterNameFirstText);
                        }
                    else
                        Learn();
                    }
                }
            }
        // -------------------------------------------------------------------------------------------------
        //public void UndoButtonClick()
        //    {
        //    if(!String.IsNullOrWhiteSpace(entryBox.Text))
        //        {
        //        entryBox.Text = RemoveLastLine(entryBox.Text.ToString());
        //        }
        //    }
        // -------------------------------------------------------------------------------------------------
        /*        public String RemoveLine(String s)
                    {
                    Boolean b = false;
                    int lastLineIndex = -1;
                    for(int i = s.Length-1; i >= 0; i--)
                        {
                        if(!b)
                            {
                            if (s[i] == '.' || s[i] == '!' || s[i] == '?')
                                b = true;
                            }
                        else
                            {
                            if (s[i] == '.' || s[i] == '!' || s[i] == '?')
                                lastLineIndex = i + 1;
                            }

                        }
                    return s.Substring(0, lastLineIndex);
                    }
                // -------------------------------------------------------------------------------------------------
                public String RemoveLastLine(String myStr)
                    {
                    String result = "";
                    if (myStr.Length > 2)
                        {
                        // Ignore very last new-line character.
                        String temporary = myStr.Substring(0, myStr.Length - 2);

                        // Get the position of the last new-line character.
                        int lastNewLine = temporary.LastIndexOf("\r\n");

                        // If we have at least two elements separated by a new-line character.
                        if (lastNewLine != -1)
                            {
                            // Cut the string (starting from 0, ending at the last new-line character).
                            result = myStr.Substring(0, lastNewLine);
                            }
                        }
                    return (result);
                    }
        */
        // -------------------------------------------------------------------------------------------------
        public void LearnButtonClick()
            {
            if (entryBox.Text.CompareTo("") != 0)
                {
                if (C.learnMode)
                    {
                    if (C.patientNamePlaceholder.Equals(C.patientName))
                        {
                        MessageBox.Show(C.enterNameFirstText);
                        entryBox.Text = System.Windows.Forms.Clipboard.GetText(); /// Returns text from clipboard
                        }
                    else
                        Learn();
                    }
                }
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
        public void DeleteCheckedEntries()
            {
            checkboxClicks.Sort();
            for (int i = checkboxClicks.Count-1; i >=0; i--)
                {
                autoFillList.RemoveAt(checkboxClicks[i]);
                
                }
            ResetBindingList();
            unCheckAll();
            }
        // -------------------------------------------------------------------------------------------------
            public void AddRowButtonClick()
            {
            Console.WriteLine("AddRowButtonClick() : " + tabName);
            autoFillList.Add(new AutoFillEntry(C.newCellText));
            rowSelected = autoFillList.Count - 1;
            colSelected = 2;
            ResetGrid();
            RecheckBoxes();
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
        public void CheckboxClick(int row)
            {
            int index = checkboxClicks.IndexOf(row);
            if (Convert.ToBoolean(dataGridView.Rows[row].Cells[0].EditedFormattedValue) == true)
                {
                Console.WriteLine("Checkbox click true: index = " + index);
                if (index == -1)
                    checkboxClicks.Add(row);
                }
            else
                {
                Console.WriteLine("Checkbox click false: index = " + index);
                if (index != -1)
                    checkboxClicks.RemoveAt(index);
                }
            /*
            Console.WriteLine("Contents of checkboxClicks: ");
            for (int i = 0; i < checkboxClicks.Count; i++)
                Console.Write(i + " : " + checkboxClicks[i] + ", ");
            Console.WriteLine();
            */
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
            m1.Click += delegate (object sender, System.EventArgs e) { MenuItemDeleteClick( row); };
            m.MenuItems.Add(m1);

            MenuItem m2 = new MenuItem("Edit");
            m2.Click += delegate (object sender, System.EventArgs e) { MenuItemEditClick( row); };
            m.MenuItems.Add(m2);

            MenuItem m3 = new MenuItem("Cut");
            m3.Click += delegate (object sender, System.EventArgs e) { MenuItemCutClick( row); };
            m.MenuItems.Add(m3);

            MenuItem m4 = new MenuItem("Copy");
            m4.Click += delegate (object sender, System.EventArgs e) { MenuItemCopyClick(  row); };
            m.MenuItems.Add(m4);

            MenuItem m5 = new MenuItem("Paste");
            m5.Click += delegate (object sender, System.EventArgs e) { MenuItemPasteOverClick(row); };
            m.MenuItems.Add(m5);

            MenuItem m6 = new MenuItem("Paste (Append)");
            m6.Click += delegate (object sender, System.EventArgs e) { MenuItemAddPasteClick(  row); };
            m.MenuItems.Add(m6);

            MenuItem m7 = new MenuItem("Post");
            m7.Click += delegate (object sender, System.EventArgs e) { MenuItemAddPostClick(row); };
            m.MenuItems.Add(m7);

            SelectCell(row, col);
            m.Show(dataGridView, p);

            }
        // -------------------------------------------------------------------------------------------------
        /* Context Menu */
        public void MenuItemDeleteClick( int row)
            {
            Console.WriteLine("Context menu Delete click : tab = " + tabName + "; row = " + row);
            autoFillList.RemoveAt(row);
            ResetBindingList();
            checkboxClicks.Remove(row);
            for (int i = 0; i < checkboxClicks.Count; i++)
                if (checkboxClicks[i] > row)
                    checkboxClicks[i]--;
            RecheckBoxes();
            }
        public void MenuItemEditClick(int row)
            {
            Console.WriteLine("Context menu Edit click : tab = " + tabName);
            rowSelected = row;
            colSelected = 2;
            dataGridView.BeginEdit(true); /// Auto selects new cell text

            }
        public void MenuItemCutClick(  int row)
            {
            Console.WriteLine("Context menu Cut click : tab = " + tabName);
            System.Windows.Forms.Clipboard.SetText(autoFillList[row].Entry);
            MenuItemDeleteClick(row);
            }
        public void MenuItemCopyClick( int row)
            {
            Console.WriteLine("Context menu Copy click : tab = " + tabName);
            System.Windows.Forms.Clipboard.SetText(autoFillList[row].Entry);
            }
        public void MenuItemPasteOverClick(int row)
            {
            Console.WriteLine("Context menu Paste over click : tab = " + tabName);
            autoFillList[row].Entry = System.Windows.Forms.Clipboard.GetText();
            }
        public void MenuItemAddPasteClick(  int row)
            {
            Console.WriteLine("Context menu add Paste click : tab = " + tabName);
            autoFillList[row].Entry += " " + System.Windows.Forms.Clipboard.GetText();
            }
        public void MenuItemAddPostClick(int row)
            {
            Console.WriteLine("Context menu Post click : tab = " + tabName);
            PostEntry(row);
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
                checkboxClicks.Clear();
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
        public SortOrder GetSortOrder( int col)
            {
            Console.WriteLine("GetSortOrder() : order is " + dataGridView.Columns[col].HeaderCell.SortGlyphDirection);

            if (sortOrder[col] == SortOrder.None || sortOrder[col] == SortOrder.Descending)
                {
                sortOrder[col] = SortOrder.Ascending;
                return SortOrder.Ascending;
                }
            else
                {
                sortOrder[col] = SortOrder.Descending;
                return SortOrder.Descending;
                }
            }

        // -------------------------------------------------------------------------------------------------
        public void CellClick( int row, int col)
            {
            Console.WriteLine("CellClick() " + tabName + " : [" + row + "][" + col + "]");
            if (col == 0)
                {
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
        public void CellDoubleClick( int row, int col)
            {
            Console.WriteLine("CellDoubleClick() " + tabName + " : [" + row + "][" + col + "]");
            if(row >= 0 && col == 2)
                PostEntry(row);
            }
        // -------------------------------------------------------------------------------------------------
        public void ResetTab()
            {
            entryBox.Text = "";
            }
        // -------------------------------------------------------------------------------------------------
        public void PatientNameChange()
            {
            Console.WriteLine("PatientChange() : oldName = " + C.oldPatientName + "; newName = " + C.patientName + "; oldIsMale = " + C.oldIsMale + "; isMale = " + C.isMale);
            if(entryBox.Text.Length > 0)
                {
                String[] list = { C.oldPatientName, C.patientName };
                entryBox.Text = ReplaceWordsInString(entryBox.Text.ToString(), list);
                }
            C.oldIsMale = C.isMale;
            }
        // -------------------------------------------------------------------------------------------------
        public void GenericNameChange()
            {
            Console.WriteLine("GenericNameChange() : oldName = " + C.oldGenericName + "; newName = " + C.genericName + "; list.Count = " + autoFillList.Count);
            String[] list = { C.oldGenericName, C.genericName };
            
            if (autoFillList.Count > 0)
                {
                for (int i = 0; i < autoFillList.Count; i++)
                    {
                    autoFillList[i].Entry = ReplaceWordsInString(autoFillList[i].Entry, list);
                    }
                ResetBindingList();
                RecheckBoxes();
                }
            }

        // -------------------------------------------------------------------------------------------------
        public void GenericPatientNameChange()
            {
            Console.WriteLine("GenericPatientNameChange() : oldName = " + C.oldGenericPatientName + "; newName = " + C.genericPatientName + "; list.Count = " + autoFillList.Count);
            String[] list = { C.oldGenericPatientName, C.genericPatientName };
            if (entryBox.Text.Length > 0)
                {
                entryBox.Text = ReplaceWordsInString(entryBox.Text.ToString(), list);
                }
            if (autoFillList.Count > 0)
                {
                for (int i = 0; i < autoFillList.Count; i++)
                    {
                    autoFillList[i].Entry = ReplaceWordsInString(autoFillList[i].Entry, list);
                    }
                ResetBindingList();
                RecheckBoxes();
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void GenericPeerNameChange()
            {
            Console.WriteLine("GenericPeerNameChange() : oldName = " + C.oldGenericPeerName + "; newName = " + C.genericPeerName + "; list.Count = " + autoFillList.Count);
            String oldS = C.oldGenericPeerName.Substring(0, C.oldGenericPeerName.Length - 1) + "s" + ">";
            String newS = C.genericPeerName.Substring(0, C.genericPeerName.Length - 1) + "s" + ">";
            String[] list = { C.oldGenericPeerName, C.genericPeerName, oldS, newS };
            if (entryBox.Text.Length > 0)
                {
                entryBox.Text = ReplaceWordsInString(entryBox.Text.ToString(), list);
                }
            if (autoFillList.Count > 0)
                {
                for (int i = 0; i < autoFillList.Count; i++)
                    {
                    autoFillList[i].Entry = ReplaceWordsInString(autoFillList[i].Entry, list);
                    }
                ResetBindingList();
                RecheckBoxes();
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void PostEntries()
            {
            if (checkboxClicks.Count > 0)
                {
                for (int i = 0; i < checkboxClicks.Count; i++)
                    PostEntry(checkboxClicks[i]);
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void PostEntry(int row)
            {
            Console.WriteLine("PostEntry() " + tabName + " : ");
            String[] list = { C.patientNamePlaceholder, C.patientName, C.genericPatientNamePlaceholder, C.genericPatientName, C.genericPeerNamePlaceholder, C.genericPeerName};
            entryBox.Text += ReplaceWordsInString(dataGridView.Rows[row].Cells[2].Value.ToString(), list) + " ";
            }
        // -------------------------------------------------------------------------------------------------
        public String StripArrows(String s)
            {
            return s.Replace(">", "").Replace("<", "");
            }
        // -------------------------------------------------------------------------------------------------
        /* Takes a string and replaces old word with new word and returns the string. params is the array of 
         words to replace. Takes in an even number of params in the pattern of: oldString, newString. */
        public String ReplaceWordsInString(String s, params String[] list)
            {
            Console.WriteLine("ReplaceWordsInString() : s = " + s + "; list[0] = " + list[0] + "; list[1] = " + list[1]);
            int length = list.Count<String>();
            if (length == 0 || length % 2 != 0)
                throw new ArgumentException("Parameter list must be even number", "original");

            for (int i = 0; i < length; i += 2)
                {
                s = ReplaceWholeWord(s, list[i], list[i + 1]);
                }

            return s;
            }
        // -------------------------------------------------------------------------------------------------
        public string ReplaceWholeWord(string original, string wordToFind, string replacement)
            {
            return original.Replace(wordToFind, replacement);
            //string pattern = String.Format(@"\b{0}\b", wordToFind);
            //string ret = Regex.Replace(original, pattern, replacement, RegexOptions.IgnoreCase);
            //return ret;
            }

        // -------------------------------------------------------------------------------------------------
        public void Learn()
            {
            Console.WriteLine("Learn() : " + tabName);

            }
        // -------------------------------------------------------------------------------------------------
        public void RecheckBoxes()
            {
            for (int i = 0; i < checkboxClicks.Count; i++)
                dataGridView.Rows[checkboxClicks[i]].Cells[0].Value = true;
            }
        // -------------------------------------------------------------------------------------------------
        public void checkAll()
            {

            checkboxClicks.Clear();
            for (int i = 0; i < autoFillList.Count; i++)
                {
                dataGridView.Rows[i].Cells[0].Value = true;
                checkboxClicks.Add(i);
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void unCheckAll()
            {
            checkboxClicks.Clear();
            for (int i = 0; i < autoFillList.Count; i++)
                {
                dataGridView.Rows[i].Cells[0].Value = false;
                }
            }
        // -------------------------------------------------------------------------------------------------
        }
    }
