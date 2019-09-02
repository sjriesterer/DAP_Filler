﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        public int autoSortIndex = 0;
        public int rowSelected = 0;
        public int colSelected = 1;
        public ComboBox autoSortCB;
        public TextBox entryBox;
        public TextBox searchBox;
        public List<int> searchHits;
        public Boolean searchMode = false;
        public int searchIndex = 0;
        public DataGridView dataGridView;
        public SortOrder[] sortOrder = new SortOrder[3];
        // -------------------------------------------------------------------------------------------------

        public Tab(String name)
            {
            Console.WriteLine("Init new tab : " + name);
            this.tabName = name;
            LoadAutoFillList();
            this.searchHits = new List<int>();
            this.checkboxClicks = new List<int>();
            sortOrder[0] = SortOrder.None;
            sortOrder[1] = SortOrder.None;
            sortOrder[2] = SortOrder.None;
            this.bindingList = new BindingList<AutoFillEntry>(autoFillList);
            }
        // -------------------------------------------------------------------------------------------------
        public void InitTab(DataGridView dataGridView, TextBox textBox, TextBox searchBox, ComboBox comboBox)
            {
            this.entryBox = textBox;
            this.autoSortCB = comboBox;
            this.searchBox = searchBox;
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
                AutoFillEntry ae = new AutoFillEntry("This is autofill " + i + ".", i);
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
        public void DeleteAutoFillEntry()
            {
            entryBox.Text = "";
            }
        // -------------------------------------------------------------------------------------------------
        public void CutButtonClick()
            {
            if (entryBox.Text.CompareTo("") != 0)
                {
                System.Windows.Forms.Clipboard.SetText(C.StripArrows(entryBox.Text));
                if (C.learnMode)
                    {
                    if (C.realNamePlaceholder.Equals(C.realName)) /// If no name has been entered
                        {
                        MessageBox.Show(C.enterNameFirstText);
                        }
                    else
                        {
                        entryBox.Text = "";
                        Learn();
                        }
                    }
                }
            }

        // -------------------------------------------------------------------------------------------------
        public void CopyButtonClick()
            {
            if (entryBox.Text.CompareTo("") != 0)
                {
                System.Windows.Forms.Clipboard.SetText(C.StripArrows(entryBox.Text));
                if (C.learnMode)
                    {
                    if (C.realNamePlaceholder.Equals(C.realName)) /// If no name has been entered
                        {
                        MessageBox.Show(C.enterNameFirstText);
                        }
                    else
                        Learn();
                    }
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void LearnButtonClick()
            {
            if (entryBox.Text.CompareTo("") != 0)
                {
                if (C.learnMode)
                    {
                    if (C.realNamePlaceholder.Equals(C.realName)) /// If no name has been entered
                        {
                        MessageBox.Show(C.enterNameFirstText);
                        }
                    else
                        Learn();
                    }
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void EntryBox_Enter()
            { }
        public void EntryBox_Leave()
            {
            Console.WriteLine("EntryBox_Leave : " + tabName);
            String newS = C.genericPeerName.Substring(0, C.genericPeerName.Length - 1) + "s" + ">"; /// Makes a plural version of the peer name with arrows 
            String[] list = { C.StripArrows(C.genericName), C.genericName, C.StripArrows(C.genericPatientName), C.genericPatientName, C.StripArrows(C.genericPeerName), C.genericPeerName, C.StripArrows(C.genericPeerName)+ "s", newS };
            entryBox.Text = ReplaceWordsInStringRegex(C.StripArrows(entryBox.Text), list); /// Strips the existing arrows from the textbox before making adjustments.
            }
        public void EntryBox_TextChanged()
            { }
        // -------------------------------------------------------------------------------------------------
        public void DeleteCheckedEntries()
            {
            checkboxClicks.Sort();
            for (int i = checkboxClicks.Count - 1; i >= 0; i--)
                {
                autoFillList.RemoveAt(checkboxClicks[i]);
                }
            SaveAutoFillList();
            ResetBindingList();
            UnCheckAll();
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
            if (autoFillList.Count > 0)
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
            m1.Click += delegate (object sender, System.EventArgs e) { MenuItemDeleteClick(row); };
            m.MenuItems.Add(m1);

            MenuItem m2 = new MenuItem("Edit");
            m2.Click += delegate (object sender, System.EventArgs e) { MenuItemEditClick(row); };
            m.MenuItems.Add(m2);

            MenuItem m3 = new MenuItem("Cut");
            m3.Click += delegate (object sender, System.EventArgs e) { MenuItemCutClick(row); };
            m.MenuItems.Add(m3);

            MenuItem m4 = new MenuItem("Copy");
            m4.Click += delegate (object sender, System.EventArgs e) { MenuItemCopyClick(row); };
            m.MenuItems.Add(m4);

            MenuItem m5 = new MenuItem("Paste");
            m5.Click += delegate (object sender, System.EventArgs e) { MenuItemPasteOverClick(row); };
            m.MenuItems.Add(m5);

            MenuItem m6 = new MenuItem("Paste (Append)");
            m6.Click += delegate (object sender, System.EventArgs e) { MenuItemAddPasteClick(row); };
            m.MenuItems.Add(m6);

            MenuItem m7 = new MenuItem("Post");
            m7.Click += delegate (object sender, System.EventArgs e) { MenuItemAddPostClick(row); };
            m.MenuItems.Add(m7);

            SelectCell(row, col);
            m.Show(dataGridView, p);

            }
        // -------------------------------------------------------------------------------------------------
        /* Context Menu */
        public void MenuItemDeleteClick(int row)
            {
            Console.WriteLine("Context menu Delete click : tab = " + tabName + "; row = " + row);
            autoFillList.RemoveAt(row);
            SaveAutoFillList();
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
        public void MenuItemCutClick(int row)
            {
            Console.WriteLine("Context menu Cut click : tab = " + tabName);
            System.Windows.Forms.Clipboard.SetText(autoFillList[row].Entry);
            MenuItemDeleteClick(row);
            }
        public void MenuItemCopyClick(int row)
            {
            Console.WriteLine("Context menu Copy click : tab = " + tabName);
            System.Windows.Forms.Clipboard.SetText(autoFillList[row].Entry);
            }
        public void MenuItemPasteOverClick(int row)
            {
            Console.WriteLine("Context menu Paste over click : tab = " + tabName);
            autoFillList[row].Entry = System.Windows.Forms.Clipboard.GetText();
            SaveAutoFillList();
            }
        public void MenuItemAddPasteClick(int row)
            {
            Console.WriteLine("Context menu add Paste click : tab = " + tabName);
            autoFillList[row].Entry += " " + System.Windows.Forms.Clipboard.GetText();
            SaveAutoFillList();
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
        public void ColumnHeaderMouseClick(int col)
            {
            string colName = dataGridView.Columns[col].Name;
            Console.WriteLine("ColumnHeaderMouseClick() " + tabName + " : columnName = " + colName);

            if (autoFillList.Count > 1)
                {
                if ("Post".CompareTo(colName) != 0) /// If not clicking the first column
                    {
                    //SortOrder strSortOrder = GetCurrentSortOrder(col);
                    SortList(col, GetCurrentSortOrder(col));
                    }
                SaveAutoFillList();
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void SortList(int col, SortOrder sortOrder)
            {
            Console.WriteLine("SortList() : column = " + col + "; sortOrder = " + sortOrder);
            this.sortOrder[col] = sortOrder; /// Records current sort order
            if (sortOrder == SortOrder.Ascending)
                {
                if(col == 1)
                    autoFillList = autoFillList.OrderBy(x => x.uses).ToList();
                else
                    autoFillList = autoFillList.OrderBy(x => x.entry).ToList();
                //autoFillList = autoFillList.OrderBy(x => typeof(AutoFillEntry).GetPro.GetProperty(colName).GetValue(x, null)).ToList();
                }
            else
                {
                if (col == 1)
                    autoFillList = autoFillList.OrderByDescending(x => x.uses).ToList();
                else
                    autoFillList = autoFillList.OrderByDescending(x => x.entry).ToList();
                //autoFillList = autoFillList.OrderByDescending(x => typeof(AutoFillEntry).GetProperty(colName).GetValue(x, null)).ToList();
                }
            checkboxClicks.Clear();
            ResetGrid();

            PrintList();
            }
        // -------------------------------------------------------------------------------------------------
        public SortOrder GetCurrentSortOrder(int col)
            {
            Console.WriteLine("GetSortOrder() : order is " + dataGridView.Columns[col].HeaderCell.SortGlyphDirection);

            if (sortOrder[col] == SortOrder.None || sortOrder[col] == SortOrder.Descending)
                {
                return SortOrder.Ascending;
                }
            else
                {
                return SortOrder.Descending;
                }
            }

        // -------------------------------------------------------------------------------------------------
        public void CellClick(int row, int col)
            {
            Console.WriteLine("CellClick() " + tabName + " : [" + row + "][" + col + "]");
            if(col != 0 && row >= 0)
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
        public void CellDoubleClick(int row, int col)
            {
            Console.WriteLine("CellDoubleClick() " + tabName + " : [" + row + "][" + col + "]");
            if (row >= 0 && col == 2)
                PostEntry(row);
            }
        // -------------------------------------------------------------------------------------------------
        public void ResetTab()
            {
            entryBox.Text = "";
            }
        // -------------------------------------------------------------------------------------------------
        public void RealNameChange()
            {
            Console.WriteLine("PatientChange() : oldName = " + C.oldRealName + "; newName = " + C.realName + "; oldIsMale = " + C.oldIsMale + "; isMale = " + C.isMale);

            if (entryBox.Text.Length > 0)
                {
                entryBox.Text = ReplaceWholeWordRegex(entryBox.Text.ToString(), C.oldRealName, C.realName);
                String[] list = { C.genericRealNamePlaceholder, C.realName };

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
            String[] list = { C.oldGenericPatientName, C.genericPatientName, C.LowerCaseWithArrows(C.oldGenericPatientName), C.genericPatientName };

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
            String[] list = { C.realNamePlaceholder, C.realName, C.genericPatientNamePlaceholder, C.genericPatientName, C.genericPeerNamePlaceholder, C.genericPeerName };
            // Appends post entry to entry box. Replaces old words with new words in list
            if (String.IsNullOrWhiteSpace(entryBox.Text))
                entryBox.AppendText(ReplaceWordsInString(dataGridView.Rows[row].Cells[2].Value.ToString(), list));
            else
                entryBox.AppendText(" " + ReplaceWordsInString(dataGridView.Rows[row].Cells[2].Value.ToString(), list));
            }
        // -------------------------------------------------------------------------------------------------
        /* Takes a string and replaces old word with new word and returns the string. params is the array of 
         words to replace. Takes in an even number of params in the pattern of: oldString, newString. */
        public String ReplaceWordsInStringRegex(String s, params String[] list)
            {
            Console.WriteLine("ReplaceWordsInString() : s = " + s + "; list[0] = " + list[0] + "; list[1] = " + list[1]);
            int length = list.Count<String>();
            if (length == 0 || length % 2 != 0)
                throw new ArgumentException("Parameter list must be even number", "original");

            for (int i = 0; i < length; i += 2)
                {
                s = ReplaceWholeWordRegex(s, list[i], list[i + 1]);
                }

            return s;
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
        public string ReplaceWholeWordRegex(string original, string wordToFind, string replacement)
            {
            string pattern = String.Format(@"\b{0}\b", wordToFind);
            return Regex.Replace(original, pattern, replacement);
            }

        // -------------------------------------------------------------------------------------------------
        public void Learn()
            {
            Console.WriteLine("Learn() : " + tabName);
            Boolean matchFound = true;
            entryBox.Text = TrimSpaces(entryBox.Text.ToString()) + " "; /// Trims extra spaces in entry box
            string[] sentences = Regex.Split(entryBox.Text.ToString(), @"(?<=[\.!\?])\s+"); /// Splits sentences
                                                                                            /// Loops through all the sentences and compares each one to the entries in the autoFillList:
            for (int i = 0; i < sentences.Count<String>(); i++)
                {
                if (!String.IsNullOrWhiteSpace(sentences[i])) /// If not an empty string
                    {
                    matchFound = false;
                    sentences[i] = ReplaceWholeWord(sentences[i], C.realName, C.genericName); /// Replaces real name with a generic one
                    Console.WriteLine("\nsentence[" + i + "] = \"" + sentences[i] + "\"");
                    foreach (var j in autoFillList)
                        {
                        Console.WriteLine("autofill[] = \"" + j.Entry + "\"");
                        if (j.Entry.Equals(sentences[i])) /// Match found in list
                            {
                            j.Uses++;
                            matchFound = true;
                            break;
                            }
                        else
                            {
                            matchFound = false;
                            }
                        }
                    if (!matchFound) /// Looped through entire list, no match found
                        {
                        AutoFillEntry ae = new AutoFillEntry(sentences[i]);
                        autoFillList.Add(ae);
                        }
                    }
                }
            SaveAutoFillList();
            ResetBindingList();
            }
        // -------------------------------------------------------------------------------------------------
        public void RowValidated(int row)
            {
            Console.WriteLine("RowValidated() : " + tabName + "; row = " + row);
            if(row < autoFillList.Count)
                autoFillList[row].Entry = TrimSpaces(autoFillList[row].Entry);
            SaveAutoFillList();
            }
        // -------------------------------------------------------------------------------------------------
        // Trims leading and trailing spaces
        public String TrimSpaces(String s)
            {
            Regex trimmer = new Regex(@"  +");
            return trimmer.Replace(s, " ").Trim(' ');
            }
        // -------------------------------------------------------------------------------------------------
        public void RecheckBoxes()
            {
            for (int i = 0; i < checkboxClicks.Count; i++)
                dataGridView.Rows[checkboxClicks[i]].Cells[0].Value = true;
            }
        // -------------------------------------------------------------------------------------------------
        public void CheckAll()
            {
            checkboxClicks.Clear();
            for (int i = 0; i < autoFillList.Count; i++)
                {
                dataGridView.Rows[i].Cells[0].Value = true; /// Setting this to true will trigger cell value changed event and will add the clicks to the array from there
                //checkboxClicks.Add(i);
                }
            PrintCheckBoxArray();
            }
        // -------------------------------------------------------------------------------------------------
        public void PrintCheckBoxArray()
            {
            for(int i =0;i<checkboxClicks.Count;i++)
                {
                Console.WriteLine("CheckboxClick array [" + i + "] = " + checkboxClicks[i]);
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void UnCheckAll()
            {
            checkboxClicks.Clear();
            for (int i = 0; i < autoFillList.Count; i++)
                {
                dataGridView.Rows[i].Cells[0].Value = false;
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void SetAutoSortCB()
            {
            autoSortCB.SelectedIndex = autoSortIndex;
            AutoSortIndexChanged(autoSortIndex);
            }
        // -------------------------------------------------------------------------------------------------
        public void AutoSortIndexChanged(int index)
            {
            autoSortIndex = index;
            if (index == C.NONE)
                return;
            int col = 1;
            SortOrder so = SortOrder.Ascending;
            if (index == C.USE_D)
                so = SortOrder.Descending;
            else if(index == C.ENTRY_A)
                col = 2;
            else if(index == C.ENTRY_D)
                {
                col = 2;
                so = SortOrder.Descending;
                }

            SortList(col, so);
            SaveAutoSort();
            }
        // -------------------------------------------------------------------------------------------------
        public void SaveAll()
            {
            SaveAutoSort();
            SaveEntryBoxText();
            SaveAutoFillList();
            }
        // -------------------------------------------------------------------------------------------------
        public void SaveEntryBoxText()
            {
            if (tabName.Equals(C.tab1))
                Properties.Settings.Default.entryBoxText_D = entryBox.Text;
            else if (tabName.Equals(C.tab2))
                Properties.Settings.Default.entryBoxText_A = entryBox.Text;
            else
                Properties.Settings.Default.entryBoxText_P = entryBox.Text;
            Properties.Settings.Default.Save();

            }
        // -------------------------------------------------------------------------------------------------
        public void SaveAutoSort()
            {
            if (tabName.Equals(C.tab1))
                Properties.Settings.Default.autoSort_D = autoSortIndex;
            else if (tabName.Equals(C.tab2))
                Properties.Settings.Default.autoSort_A = autoSortIndex;
            else
                Properties.Settings.Default.autoSort_P = autoSortIndex;
            Properties.Settings.Default.Save();
            }
        // -------------------------------------------------------------------------------------------------
        public void SaveAutoFillList()
            {
            using (MemoryStream ms = new MemoryStream())
                {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, autoFillList);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                if(tabName.Equals(C.tab1))
                    Properties.Settings.Default.tabData = Convert.ToBase64String(buffer);
                else if (tabName.Equals(C.tab2))
                    Properties.Settings.Default.tabAssessment = Convert.ToBase64String(buffer);
                else Properties.Settings.Default.tabPlan = Convert.ToBase64String(buffer);

                Properties.Settings.Default.Save();
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void LoadAutoFillList()
            {
            MemoryStream ms = null;
            if (tabName.Equals(C.tab1))
                ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.tabData));
            else if (tabName.Equals(C.tab2))
                ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.tabAssessment));
            else ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.tabPlan));

            using (ms)
                {
                if (ms.Length == 0)
                    autoFillList = new List<AutoFillEntry>();
                else
                    {
                    BinaryFormatter bf = new BinaryFormatter();
                    autoFillList = (List<AutoFillEntry>)bf.Deserialize(ms);
                    }
                }
            }
        // -------------------------------------------------------------------------------------------------
        public void SearchBoxLeave()
            {
            searchHits.Clear();
            dataGridView.ClearSelection();
            searchMode = false;
            searchIndex = 0;
            }
        // -------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------
        public void SearchGrid()
            {
            Console.WriteLine("SearchGrid() : \"" + searchBox.Text + "\"");
            if (autoFillList.Count > 0 && searchIndex < autoFillList.Count)
                {
                int match = GetMatchingRow(searchIndex, TrimSpaces(searchBox.Text));
                if (match != C.NOT_FOUND)
                    {
                    searchIndex = match + 1;
                    searchHits.Add(match);
                    if (searchMode == false)
                        {
                        dataGridView.ClearSelection();
                        searchMode = true;
                        }
                    dataGridView.Rows[match].Selected = true;
                    dataGridView.FirstDisplayedScrollingRowIndex = match;
                    }
                }
            }
        // -------------------------------------------------------------------------------------------------
        public int GetMatchingRow(int start, String find)
            {
            for(int i = start; i< autoFillList.Count; i++)
                {
                if (autoFillList[i].entry.IndexOf(find, StringComparison.OrdinalIgnoreCase) >= 0)
                    return i;
                }
            return C.NOT_FOUND;
            }
        // -------------------------------------------------------------------------------------------------
        }
    }
