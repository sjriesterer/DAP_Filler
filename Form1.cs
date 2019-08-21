﻿using System;
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
            //TODO Get persisted data
            genericPatientNameTB.Text = C.genericPatientName;
            genericPeerNameTB.Text = C.genericPeerName;
            genericNameTB.Text = C.genericName;
            tabData = new Tab("Data");
            tabData.InitTab(DataGridView_D, EntryBox_D);
            InitToolTips();
            }

        private void InitToolTips()
            {
            ToolTip ToolTipNew = new ToolTip();
            ToolTip ToolTipSave = new ToolTip();
            ToolTip ToolTipLearnMode = new ToolTip();
            ToolTip ToolTipGenericName = new ToolTip();
            ToolTip ToolTipGenericPatientName = new ToolTip();
            ToolTip ToolTipGenericPeerName = new ToolTip();
            ToolTipNew.SetToolTip(NewPatientButton, "Start a new patient");
            ToolTipSave.SetToolTip(SaveButton, "Saves progress");
            ToolTipLearnMode.SetToolTip(LearnModeCB, "Learn Mode will automatically create new entries based on the text in the entry box whenever cut or copy button is pressed");
            ToolTipGenericName.SetToolTip(GenericNameLabel, "The name used to reference the patient's real name in the auto entries");
            ToolTipGenericPatientName.SetToolTip(GenericPatientNameLabel, "The name used to reference the patient in the auto entries");
            ToolTipGenericPeerName.SetToolTip(GenericPeerNameLabel, "The name used to reference the patient's peers in the auto entries");

            String entryBoxTip = "Entry Box";
            String learnButtonTip = "Creates new entries based on the text in the entry box";
            //String undoButtonTip = "Deletes the last line in the entry box";
            String copyButtonTip = "Copies the text in the entry box to the clipboard";
            String cutButtonTip = "Copies the text in the entry box to the clipboard and clears the entry box";
            String deleteButtonTip = "Clears the entry box";
            String checkAllButtonTip = "Checks all the autofill entries";
            String uncheckAllButtonTip = "Unchecks all the autofill entries";
            String postButtonTip = "Posts all the checked autofill entries to the entry box (retains the order in which the checkboxes are checked)";
            String deleteEntryButtonTip = "Deletes all the checked autofill entries";
            String addButtonTip = "Adds a new autofill entry";

            ToolTip ToolTipEntryBox_D = new ToolTip();
            ToolTip ToolTipLearn_D = new ToolTip();
            //ToolTip ToolTipUndo_D = new ToolTip();
            ToolTip ToolTipCopy_D = new ToolTip();
            ToolTip ToolTipCut_D = new ToolTip();
            ToolTip ToolTipDelete_D = new ToolTip();
            ToolTip ToolTipCheckAll_D = new ToolTip();
            ToolTip ToolTipUncheckAll_D = new ToolTip();
            ToolTip ToolTipPost_D = new ToolTip();
            ToolTip ToolTipDeleteEntry_D = new ToolTip();
            ToolTip ToolTipAdd_D = new ToolTip();

            ToolTipEntryBox_D.SetToolTip(EntryBox_D, entryBoxTip);
            ToolTipLearn_D.SetToolTip(LearnButton_D, learnButtonTip);
            //ToolTipUndo_D.SetToolTip(UndoButton_D, undoButtonTip);
            ToolTipCopy_D.SetToolTip(CopyButton_D, copyButtonTip);
            ToolTipCut_D.SetToolTip(CutButton_D, cutButtonTip);
            ToolTipDelete_D.SetToolTip(DeleteButton_D, deleteButtonTip);
            ToolTipCheckAll_D.SetToolTip(CheckAllButton_D, checkAllButtonTip);
            ToolTipUncheckAll_D.SetToolTip(UnCheckAllButton_D, uncheckAllButtonTip);
            ToolTipPost_D.SetToolTip(PostButton_D, postButtonTip);
            ToolTipDeleteEntry_D.SetToolTip(DeleteRowsButton_D, deleteEntryButtonTip);
            ToolTipAdd_D.SetToolTip(AddEntryButton_D, addButtonTip);

            }
        /* ----------------------------------------------------------------------------------------*/
        /* COMMON EVENTS */
        /* ----------------------------------------------------------------------------------------*/
        /* Patient Name */
        private void RealName_Enter(object sender, EventArgs e)
            {
            Console.WriteLine("PatientName_Enter : TB.Text = " + realNameTB.Text + "; patient name = " + C.realName);
            TextBoxEnter(realNameTB, C.realNamePlaceholder);
            }

        private void RealName_Leave(object sender, EventArgs e)
            {
            Console.WriteLine("PatientName_Leave : TB.Text = " + realNameTB.Text + "; patient name = " + C.realName);
            C.oldRealName = C.realName;
            if (String.IsNullOrWhiteSpace(realNameTB.Text))
                {
                realNameTB.Text = C.realNamePlaceholder;
                realNameTB.ForeColor = Color.Gray;
                }
            else
                {
                realNameTB.Text = C.Capitalize(realNameTB.Text.ToString());
                realNameTB.ForeColor = Color.Black;
                }
            C.realName = realNameTB.Text;
            tabData.RealNameChange();
            }

        private void RealName_TextChanged(object sender, EventArgs e)
            {
            Console.WriteLine("PatientName_TextChanged() : name = " + realNameTB.Text);
            //C.patientName = PatientNameTB.Text;
            }

        /* Generic Name TB */
        private void GenericNameTB_TextChanged(object sender, EventArgs e)
            {
            }
        private void GenericNameTB_Enter(object sender, EventArgs e)
            {
            TextBoxEnter(genericNameTB, C.genericRealNamePlaceholder);
/*
            genericNameTB.ForeColor = Color.Black;
            if (genericNameTB.Text.CompareTo(C.genericNamePlaceholder) == 0)
                {
                genericNameTB.Text = "";
                }
            else
                {
                BeginInvoke((Action)delegate
                    {
                        genericNameTB.SelectAll();
                        });
                }
                */
            }
        private void GenericNameTB_Leave(object sender, EventArgs e)
            {
            TextBoxLeave(C.genericRealNamePlaceholder, ref C.oldGenericName, ref C.genericName, genericNameTB);
            /*
            C.oldGenericName = C.genericName;
            if (String.IsNullOrWhiteSpace(genericNameTB.Text))
                {
                genericNameTB.Text = C.genericNamePlaceholder;
                genericNameTB.ForeColor = Color.Gray;
                }
            else
                {
                if (!C.genericName.Equals(genericNameTB.Text))
                    genericNameTB.Text = AddArrows(genericNameTB.Text.ToString());
                genericNameTB.ForeColor = Color.Black;
                }
            C.genericName = genericNameTB.Text;
            */
            tabData.GenericNameChange();
            }

        /* Generic Patient Name TB*/
        private void PatientGenericNameTB_TextChanged(object sender, EventArgs e)
            {
            //C.genericPatientName = PatientGenericNameTB.Text;
            }
        private void PatientGenericNameTB_Enter(object sender, EventArgs e)
            {
            TextBoxEnter(genericPatientNameTB, C.genericPatientNamePlaceholder);
            }
        private void PatientGenericNameTB_Leave(object sender, EventArgs e)
            {
            TextBoxLeave(C.genericPatientNamePlaceholder, ref C.oldGenericPatientName, ref C.genericPatientName, genericPatientNameTB);
            tabData.GenericPatientNameChange();
            }

        /* Generic Peer Name TB*/
        private void PeerGenericNameTB_TextChanged(object sender, EventArgs e)
            {
            //C.genericPeerName = PeerGenericNameTB.Text;
            }
        private void PeerGenericNameTB_Enter(object sender, EventArgs e)
            {
            TextBoxEnter(genericPeerNameTB, C.genericPeerNamePlaceholder);
            }
        private void PeerGenericNameTB_Leave(object sender, EventArgs e)
            {
            TextBoxLeave(C.genericPeerNamePlaceholder, ref C.oldGenericPeerName, ref C.genericPeerName, genericPeerNameTB);
            tabData.GenericPeerNameChange();
            }

        /* Generic Enter & Leave Methods */
        private void TextBoxEnter(TextBox textBox, String placeholder)
            {
            textBox.ForeColor = Color.Black;
            if (textBox.Text.CompareTo(placeholder) == 0)
                {
                textBox.Text = "";
                }
            else
                {
                BeginInvoke((Action)delegate
                    {
                        textBox.SelectAll();
                        });
                }

            }
        private void TextBoxLeave(String placeholder, ref String oldName, ref String newName, TextBox textBox)
            {
            oldName = newName;
            if (String.IsNullOrWhiteSpace(textBox.Text))
                {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
                }
            else
                {
                if (!newName.Equals(textBox.Text)) /// If there has been a change
                    textBox.Text = FormatGenericName(textBox.Text.ToString());
                textBox.ForeColor = Color.Black;
                }
            newName = textBox.Text;
            }

        public String FormatGenericName(String input)
            {
            if (input[0] != '<')
                input = "<" + input;
            if (input[input.Length - 1] != '>')
                input = input + '>';

            return C.CapitalizeWithArrows(input);
            }

        private void NewPatient_Click(object sender, EventArgs e)
            {
            C.oldRealName = C.realNamePlaceholder;
            C.realName = C.realNamePlaceholder;
            realNameTB.Text = C.realNamePlaceholder;
            MaleRadioButton.Checked = true;
            C.oldIsMale = true;
            C.isMale = true;
            tabData.ResetTab();
            }

        private void SaveButton_Click(object sender, EventArgs e)
            {
            //TODO save function
            }
        /* Gender Buttons */
        private void MaleButton_CheckedChanged(object sender, EventArgs e)
            {
            C.oldIsMale = C.isMale;
            C.isMale = MaleRadioButton.Checked;
            //tabData.PatientNameChange();
            }

        private void FemaleButton_CheckedChanged(object sender, EventArgs e)
            {
            }

        /* Learn Mode */
        private void LearnModeCB_CheckedChanged(object sender, EventArgs e)
            {
            C.learnMode = LearnModeCB.Checked;
            }

        /* ----------------------------------------------------------------------------------------*/
        /* Data Tab */
        /* ----------------------------------------------------------------------------------------*/

        private void EntryBox_Enter_D(object sender, EventArgs e)
            { tabData.EntryBox_Enter(); }
        private void EntryBox_Leave_D(object sender, EventArgs e)
            { tabData.EntryBox_Leave(); }
        private void EntryBox_TextChanged_D(object sender, EventArgs e)
            { tabData.EntryBox_TextChanged(); }
        private void DeleteButton_Click_D(object sender, EventArgs e)
            { tabData.DeleteAutFillEntry(); }
        private void CutButton_Click_D(object sender, EventArgs e)
            { tabData.CutButtonClick(); }
        private void CopyButton_Click_D(object sender, EventArgs e)
            { tabData.CopyButtonClick(); }
        private void LearnButton_D_Click(object sender, EventArgs e)
            { tabData.LearnButtonClick(); }

        /* ----------------------------------------------------------------------------------------*/
        /* Data Grid View Data */
        /* ----------------------------------------------------------------------------------------*/
        private void DataGridView_RowValidated_D(object sender, DataGridViewCellEventArgs e)
            {
            tabData.RowValidated(e.RowIndex);
            }
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
            tabData.DeleteCheckedEntries();
            }
        // -------------------------------------------------------------------------------------------------
        private void PostButton_Click_D(object sender, EventArgs e)
            {
            tabData.PostEntries();
            }
        // -------------------------------------------------------------------------------------------------
        private void CheckAll_Click_D(object sender, EventArgs e)
            {
            tabData.CheckAll();
            }
        // -------------------------------------------------------------------------------------------------
        private void UnCheckAll_Click_D(object sender, EventArgs e)
            {
            tabData.UnCheckAll();
            }

        }
    }