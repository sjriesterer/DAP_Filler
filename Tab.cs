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
        public String autoEntry = "";
        public DataGridView dataGridView;
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

        public void InitTabGrid(DataGridView dataGridView)
            {
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


        }
    }
