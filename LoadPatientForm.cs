using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAP_Filler
    {
    public static class LoadPatientForm
        {
        static int numEntries;
        static int width = 350;
        static int height = 500;
        static int buttonHeight = 30;
        static int buttonWidth = 70;
        static int marginButtonsVertical = 10;

        static int maxLinesNoScrollBar = 22;

        static int marginButtonsHorz;
        static int headerHeight = 40;
        static int scrollBarWidth = 15;
        static int colDateWidth;
        static int colNameWidth;
        static int colSexWidth;

        static Boolean load; /// Set to true if patient is to be loaded after form closes
        // -------------------------------------------------------------------------------------------------
        public static int ShowDialog()
            {
            load = false;
            // -------------------------------------------------------------------------------------------------
            // INIT FORM
            // -------------------------------------------------------------------------------------------------
            Form prompt = new Form()
                {
                Width = width,
                Height = height,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Select Patient to Load",
                StartPosition = FormStartPosition.CenterScreen
                };

            ListView listView1 = new ListView();
            // -------------------------------------------------------------------------------------------------
            // SET DIMENSIONS
            // -------------------------------------------------------------------------------------------------
            numEntries = Form1.PatientList.Count;
            if (numEntries <= maxLinesNoScrollBar)
                scrollBarWidth = 0;

            listView1.Width = width - scrollBarWidth;
            listView1.Height = height - headerHeight - buttonHeight - (2 * marginButtonsVertical);

            colDateWidth = (((listView1.Width) / 8) * 2) - (scrollBarWidth / 3);
            colNameWidth = (((listView1.Width) / 8) * 5) - (scrollBarWidth / 3);
            colSexWidth = (((listView1.Width) / 8) * 1) - (scrollBarWidth / 3);

            marginButtonsHorz = (width - (2 * buttonWidth)) / 3;
            // -------------------------------------------------------------------------------------------------
            // SET LIST VIEW PROPERTIES
            // -------------------------------------------------------------------------------------------------
            listView1.Scrollable = true;
            listView1.View = View.Details; // Set the view to show details.
            listView1.LabelEdit = true; // Allow the user to edit item text.
            listView1.AllowColumnReorder = true; // Allow the user to rearrange columns.
            listView1.FullRowSelect = true; // Select the item and subitems when selection is made.
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;
            listView1.MultiSelect = false;
            listView1.LabelEdit = false;
            // -------------------------------------------------------------------------------------------------
            // ADD ITEMS TO LIST VIEW
            // -------------------------------------------------------------------------------------------------
            listView1.Columns.Add("Date", colDateWidth, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", colNameWidth, HorizontalAlignment.Left);
            listView1.Columns.Add("M/F", colSexWidth, HorizontalAlignment.Left);

            for (int i = Form1.PatientList.Count - 1; i >= 0; i--)
                AddItem(listView1, Form1.PatientList[i]);
            // -------------------------------------------------------------------------------------------------
            // BUTTONS & CLICKS
            // -------------------------------------------------------------------------------------------------
            //Console.WriteLine("listView height = " + listView1.Height + "; marginButtonHorz = " + marginButtonsHorz + "; y = " + (height - buttonHeight - marginButtonsVertical));

            Button cancel = new Button() { Text = "Cancel", Left = marginButtonsHorz, Height = buttonHeight, Width = buttonWidth, Top = height - buttonHeight - marginButtonsVertical - headerHeight };
            cancel.Click += (sender, e) => { prompt.Close(); };

            Button confirmation = new Button() { Text = "Load", Left = buttonWidth + (2 * marginButtonsHorz), Height = buttonHeight, Width = buttonWidth, Top = height - buttonHeight - marginButtonsVertical - headerHeight };
            confirmation.Click += (sender, e) => { load = true; prompt.Close(); };

            listView1.DoubleClick += delegate {
                load = true;
                prompt.Close();
                };

            // -------------------------------------------------------------------------------------------------
            // ADD ITEMS TO FORM
            // -------------------------------------------------------------------------------------------------
            prompt.Controls.Add(listView1);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);

            prompt.ShowDialog();

            return (listView1.SelectedIndices.Count > 0 && load)? listView1.SelectedIndices[0] : -1;
            }
        // -------------------------------------------------------------------------------------------------
        private static void AddItem(ListView lv, Patient p)
            {
            String s = p.isMale ? "M" : "F";
            ListViewItem lvi = new ListViewItem(new[] { p.date.ToString("MM/dd/yy"), p.name, s });
            lv.Items.Add(lvi);
            }
        }
    }
