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

        internal Tab TabData { get => tabData; set => tabData = value; }

        public Form1()
            {
            InitializeComponent();
            // Get persisted data
            PatientGenericNameTB.Text = C.genericPatientName;
            PeerGenericNameTB.Text = C.genericPeerName;
            tabData = new Tab("Data");
            tabData.InitTab(DataGridView_D, AutoFillEntry_D);
            }

        /* ----------------------------------------------------------------------------------------*/
        /* COMMON EVENTS */
        /* ----------------------------------------------------------------------------------------*/
        private void SaveButton_Click(object sender, EventArgs e)
            {
            //TODO save function
            }

        /* Patient Name */
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

        /* Gender Buttons */
        private void MaleButton_CheckedChanged(object sender, EventArgs e)
            {
            C.oldIsMale = C.isMale;
            C.isMale = MaleRadioButton.Checked;
            tabData.PatientChange();
            }

        private void FemaleButton_CheckedChanged(object sender, EventArgs e)
            {
            }

        /* Learn Mode */
        private void LearnModeCB_CheckedChanged(object sender, EventArgs e)
            {
            C.learnMode = LearnModeCB.Checked;
            }

        /* Patient Generic Name TB*/
        private void PatientGenericNameTB_TextChanged(object sender, EventArgs e)
            {
            C.genericPatientName = PatientGenericNameTB.Text;
            }
        private void PatientGenericNameTB_Enter(object sender, EventArgs e)
            {
            }
        private void PatientGenericNameTB_Leave(object sender, EventArgs e)
            {
            //TODO change all references
            }

        /* Peer Generic Name TB*/
        private void PeerGenericNameTB_TextChanged(object sender, EventArgs e)
            {
            C.genericPeerName = PeerGenericNameTB.Text;
            }
        private void PeerGenericNameTB_Enter(object sender, EventArgs e)
            {
            }
        private void PeerGenericNameTB_Leave(object sender, EventArgs e)
            {
            //TODO change all references
            }

        /* ----------------------------------------------------------------------------------------*/
        /* Data Tab */
        /* ----------------------------------------------------------------------------------------*/

        private void AutoFillEntry_Enter_D(object sender, EventArgs e)
            { tabData.AutoFillEntry_Enter(); }
        private void AutoFillEntry_Leave_D(object sender, EventArgs e)
            { tabData.AutoFillEntry_Leave(); }
        private void AutoFillEntry_TextChanged_D(object sender, EventArgs e)
            { tabData.AutoFillEntry_TextChanged(); }
        private void DeleteButton_Click_D(object sender, EventArgs e)
            { tabData.DeleteButtonClick(); }
        private void UndoButton_Click_D(object sender, EventArgs e)
            { tabData.UndoButtonClick(); }
        private void CutButton_Click_D(object sender, EventArgs e)
            { tabData.CutButtonClick(); }
        private void CopyButton_Click_D(object sender, EventArgs e)
            { tabData.CopyButtonClick(); }
        private void LearnButton_D_Click(object sender, EventArgs e)
            { tabData.Learn(); }

        /* ----------------------------------------------------------------------------------------*/
        /* Data Grid View Data */
        /* ----------------------------------------------------------------------------------------*/
        private void DataGridView_ColumnHeaderMouseClick_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Left)
                tabData.ColumnHeaderMouseClick(e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellValueChanged_D(object sender, DataGridViewCellEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                tabData.CheckboxClick(e.RowIndex);
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellContentClick_D(object sender, DataGridViewCellEventArgs e)
            {
            }        
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellClick_D(object sender, DataGridViewCellEventArgs e)
            {
            tabData.CellClick(e.RowIndex, e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellDoubleClick_D(object sender, DataGridViewCellEventArgs e)
            {
            tabData.CellDoubleClick(e.RowIndex, e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void AddRowButtonClick_D(object sender, EventArgs e)
            {
            tabData.AddRowButtonClick();
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_RowsAdded_D(object sender, DataGridViewRowsAddedEventArgs e)
            {
            Console.WriteLine("RowsAdded(): list size = " + tabData.autoFillList.Count + "; row count = " + e.RowCount + "; row index = " + e.RowIndex);
            //dataGridView_D.CurrentCell = dataGridView_D.Rows[tabData.rowSelected].Cells[tabData.colSelected];
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_MouseUp_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {
                tabData.dataGridView.EndEdit();
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_MouseClick_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                tabData.RightMouseClick(e.RowIndex, e.ColumnIndex, tabData.RelativePoint(e));
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DeleteButtonRows_Click_D(object sender, EventArgs e)
            {

            }
        // -------------------------------------------------------------------------------------------------
        private void PostButton_Click_D(object sender, EventArgs e)
            {
            tabData.PostEntries();
            }
        // -------------------------------------------------------------------------------------------------
        private void CheckAll_Click_D(object sender, EventArgs e)
            {
            tabData.checkAll();
            }
        // -------------------------------------------------------------------------------------------------
        private void UnCheckAll_Click_D(object sender, EventArgs e)
            {
            tabData.unCheckAll();
            }
        }
    }