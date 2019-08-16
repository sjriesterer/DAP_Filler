using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void InitTab(DataGridView dataGridView, TextBox textBox)
            {
            this.autoEntryTB = textBox;
            this.dataGridView = dataGridView;
            this.dataGridView.DataSource = bindingList;
            this.dataGridView.RowHeadersVisible = false;
            }

        private void PopulateList()
            {
            for (int i = 10; i >= 0; i--)
                {
                AutoFillEntry ae = new AutoFillEntry("This is autofill " + i, i);
                autoFillList.Add(ae);
                }
            }

        public void PrintList()
            {
            Console.WriteLine("Contents of List: \n");
            for (int i = 0; i < autoFillList.Count; i++)
                {
                Console.WriteLine(i + " : " + autoFillList[i].entry);
                }
            }

        public void DeleteButtonClick()
            {
            autoEntryTB.Text = "";
            }

        public void CutButtonClick()
            {
            if (autoEntryTB.Text.CompareTo("") != 0)
                {
                System.Windows.Forms.Clipboard.SetText(autoEntryTB.Text);
                autoEntryTB.Text = "";
                Learn();
                }
            }

        public void CopyButtonClick()
            {
            if (autoEntryTB.Text.CompareTo("") != 0)
                {
                System.Windows.Forms.Clipboard.SetText(autoEntryTB.Text);
                Learn();
                }
            }

        public void UndoButtonClick()
            {

            }

        public void AutoFillEntry_TextChanged()
            {

            }

        public void ResetTab()
            {
            autoEntryTB.Text = "";
            }

        public void PatientChange()
            {
            Console.WriteLine("PatientChange() : oldName = " + C.oldPatientName + "; newName = " + C.patientName + "; oldIsMale = " + C.oldIsMale + "; isMale = " + C.isMale);
            autoEntryTB.Text = PersonalizeText(autoEntryTB.Text);
            C.oldIsMale = C.isMale;
            }

        public void PostEntry(int rowIndex)
            {
            Console.WriteLine("PostEntry() " + tabName + " : ");
            autoEntryTB.Text += PersonalizePost(dataGridView.Rows[rowIndex].Cells[2].Value.ToString() + " ");
            }

        public String PersonalizePost(String s)
            {
            


            return s;

            }

        public String PersonalizeText(String oldString)
            {


            return oldString;
            }


        public void Learn()
            {

            }


        /*
         
         <Patient> exhibits fear. <He/She> demonsrates.
         
         */


        }
    }
