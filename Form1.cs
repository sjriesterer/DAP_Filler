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


//TODO add auto sort options

namespace DAP_Filler
    {

    public partial class Form1 : Form
        {
        private static Tab tabData;
        private static Tab tabAssessment;
        private static Tab tabPlan;

        internal static Tab TabData { get => tabData; set => tabData = value; }
        internal static Tab TabAssessment { get => tabAssessment; set => tabAssessment = value; }
        internal static Tab TabPlan { get => tabPlan; set => tabPlan = value; }

        public Form1()
            {
            InitializeComponent();
            InitTabs();
            InitSavedSettings();
            InitComponents();
            InitToolTips();
            SetLearnButtonVisibility();
            }
        /* ----------------------------------------------------------------------------------------*/
        private void InitSavedSettings()
            {
            C.isMale = Properties.Settings.Default.isMale;
            C.oldIsMale = Properties.Settings.Default.isMale;
            C.realName = Properties.Settings.Default.realName;
            C.oldRealName = C.realName;
            C.genericName = Properties.Settings.Default.genericName;
            C.oldGenericName = C.genericName;
            C.genericPatientName = Properties.Settings.Default.genericPatientName;
            C.oldGenericPatientName = C.genericPatientName;
            C.genericPeerName = Properties.Settings.Default.genericPeerName;
            C.oldGenericPeerName = C.genericPeerName;
            C.learnMode = Properties.Settings.Default.learnMode;
            C.autoArrows = Properties.Settings.Default.autoArrows;
            tabData.autoSortIndex = Properties.Settings.Default.autoSort_D;
            tabAssessment.autoSortIndex = Properties.Settings.Default.autoSort_A;
            tabPlan.autoSortIndex = Properties.Settings.Default.autoSort_P;
            }
        /* ----------------------------------------------------------------------------------------*/
        private void InitTabs()
            {
            TabData = new Tab(C.tab1);
            TabData.InitTab(DataGridView_D, EntryBox_D, autoSortCB_D);
            TabAssessment = new Tab(C.tab2);
            TabAssessment.InitTab(DataGridView_A, EntryBox_A, autoSortCB_A);
            TabPlan = new Tab(C.tab3);
            TabPlan.InitTab(DataGridView_P, EntryBox_P, autoSortCB_P);
            }
        /* ----------------------------------------------------------------------------------------*/
        private void InitComponents()
            {
            realNameTB.Text = C.realName;
            genericPatientNameTB.Text = C.genericPatientName;
            genericPeerNameTB.Text = C.genericPeerName;
            genericNameTB.Text = C.genericName;
            MaleRadioButton.Checked = Properties.Settings.Default.isMale;
            FemaleRadioButton.Checked = !C.isMale;
            autoArrowsCB.Checked = C.autoArrows;

            TabData.entryBox.Text = Properties.Settings.Default.entryBoxText_D;
            TabAssessment.entryBox.Text = Properties.Settings.Default.entryBoxText_A;
            TabPlan.entryBox.Text = Properties.Settings.Default.entryBoxText_P;

            autoSortCB_D.SelectedIndex = tabData.autoSortIndex;
            autoSortCB_A.SelectedIndex = tabAssessment.autoSortIndex;
            autoSortCB_P.SelectedIndex = tabPlan.autoSortIndex;
            }
        /* ----------------------------------------------------------------------------------------*/
        private void InitToolTips()
            {
            ToolTip ToolTipNew = new ToolTip();
            ToolTip ToolTipSave = new ToolTip();
            ToolTip ToolTipLearnMode = new ToolTip();
            ToolTip ToolTipGenericName = new ToolTip();
            ToolTip ToolTipGenericPatientName = new ToolTip();
            ToolTip ToolTipGenericPeerName = new ToolTip();
            ToolTip ToolTipAutoArrows = new ToolTip();
            ToolTip ToolTipHappyFace = new ToolTip();
            ToolTipNew.SetToolTip(NewPatientButton, "Start a new patient");
            ToolTipSave.SetToolTip(DefaultButton, "Returns to defaults");
            ToolTipLearnMode.SetToolTip(learnModeCB, "Learn Mode will automatically create new entries based on the text in the entry box whenever cut or copy button is pressed");
            ToolTipGenericName.SetToolTip(genericNameTB, "The name used to reference the patient's real name in the auto entries");
            ToolTipGenericPatientName.SetToolTip(genericPatientNameTB, "The name used to reference the patient in the auto entries");
            ToolTipGenericPeerName.SetToolTip(genericPeerNameTB, "The name used to reference the patient's peers in the auto entries");
            ToolTipAutoArrows.SetToolTip(autoArrowsCB, "Automatically enters surrounding arrows <> around generic patient and peer names");
            ToolTipHappyFace.SetToolTip(happyFaceButton, "Click me");

            String entryBoxTip = "Entry Box";
            String learnButtonTip = "Creates new entries based on the text in the entry box";
            String copyButtonTip = "Copies the text in the entry box to the clipboard";
            String cutButtonTip = "Copies the text in the entry box to the clipboard and clears the entry box";
            String deleteButtonTip = "Clears the entry box";
            String checkAllButtonTip = "Checks all the autofill entries";
            String uncheckAllButtonTip = "Unchecks all the autofill entries";
            String postButtonTip = "Posts all the checked autofill entries to the entry box (retains the order in which the checkboxes are checked)";
            String deleteEntryButtonTip = "Deletes all the checked autofill entries";
            String addButtonTip = "Adds a new autofill entry";
            String autoSortTip = "Automatically sorts list as changes are made";

            ToolTip ToolTipEntryBox_D = new ToolTip();
            ToolTip ToolTipLearn_D = new ToolTip();
            ToolTip ToolTipCopy_D = new ToolTip();
            ToolTip ToolTipCut_D = new ToolTip();
            ToolTip ToolTipDelete_D = new ToolTip();
            ToolTip ToolTipCheckAll_D = new ToolTip();
            ToolTip ToolTipUncheckAll_D = new ToolTip();
            ToolTip ToolTipPost_D = new ToolTip();
            ToolTip ToolTipDeleteEntry_D = new ToolTip();
            ToolTip ToolTipAdd_D = new ToolTip();
            ToolTip ToolTipAutoSort_D = new ToolTip();
            ToolTipEntryBox_D.SetToolTip(EntryBox_D, entryBoxTip);
            ToolTipLearn_D.SetToolTip(LearnButton_D, learnButtonTip);
            ToolTipCopy_D.SetToolTip(CopyButton_D, copyButtonTip);
            ToolTipCut_D.SetToolTip(CutButton_D, cutButtonTip);
            ToolTipDelete_D.SetToolTip(DeleteButton_D, deleteButtonTip);
            ToolTipCheckAll_D.SetToolTip(CheckAllButton_D, checkAllButtonTip);
            ToolTipUncheckAll_D.SetToolTip(UnCheckAllButton_D, uncheckAllButtonTip);
            ToolTipPost_D.SetToolTip(PostButton_D, postButtonTip);
            ToolTipDeleteEntry_D.SetToolTip(DeleteRowsButton_D, deleteEntryButtonTip);
            ToolTipAdd_D.SetToolTip(AddEntryButton_D, addButtonTip);
            ToolTipAutoSort_D.SetToolTip(autoSortCB_D, autoSortTip);

            ToolTip ToolTipEntryBox_A = new ToolTip();
            ToolTip ToolTipLearn_A = new ToolTip();
            ToolTip ToolTipCopy_A = new ToolTip();
            ToolTip ToolTipCut_A = new ToolTip();
            ToolTip ToolTipDelete_A = new ToolTip();
            ToolTip ToolTipCheckAll_A = new ToolTip();
            ToolTip ToolTipUncheckAll_A = new ToolTip();
            ToolTip ToolTipPost_A = new ToolTip();
            ToolTip ToolTipDeleteEntry_A = new ToolTip();
            ToolTip ToolTipAdd_A = new ToolTip();
            ToolTip ToolTipAutoSort_A = new ToolTip();
            ToolTipEntryBox_A.SetToolTip(EntryBox_A, entryBoxTip);
            ToolTipLearn_A.SetToolTip(LearnButton_A, learnButtonTip);
            ToolTipCopy_A.SetToolTip(CopyButton_A, copyButtonTip);
            ToolTipCut_A.SetToolTip(CutButton_A, cutButtonTip);
            ToolTipDelete_A.SetToolTip(DeleteButton_A, deleteButtonTip);
            ToolTipCheckAll_A.SetToolTip(CheckAllButton_A, checkAllButtonTip);
            ToolTipUncheckAll_A.SetToolTip(UnCheckAllButton_A, uncheckAllButtonTip);
            ToolTipPost_A.SetToolTip(PostButton_A, postButtonTip);
            ToolTipDeleteEntry_A.SetToolTip(DeleteRowsButton_A, deleteEntryButtonTip);
            ToolTipAdd_A.SetToolTip(AddEntryButton_A, addButtonTip);
            ToolTipAutoSort_A.SetToolTip(autoSortCB_A, autoSortTip);

            ToolTip ToolTipEntryBox_P = new ToolTip();
            ToolTip ToolTipLearn_P = new ToolTip();
            ToolTip ToolTipCopy_P = new ToolTip();
            ToolTip ToolTipCut_P = new ToolTip();
            ToolTip ToolTipDelete_P = new ToolTip();
            ToolTip ToolTipCheckAll_P = new ToolTip();
            ToolTip ToolTipUncheckAll_P = new ToolTip();
            ToolTip ToolTipPost_P = new ToolTip();
            ToolTip ToolTipDeleteEntry_P = new ToolTip();
            ToolTip ToolTipAdd_P = new ToolTip();
            ToolTip ToolTipAutoSort_P = new ToolTip();
            ToolTipEntryBox_P.SetToolTip(EntryBox_P, entryBoxTip);
            ToolTipLearn_P.SetToolTip(LearnButton_P, learnButtonTip);
            ToolTipCopy_P.SetToolTip(CopyButton_P, copyButtonTip);
            ToolTipCut_P.SetToolTip(CutButton_P, cutButtonTip);
            ToolTipDelete_P.SetToolTip(DeleteButton_P, deleteButtonTip);
            ToolTipCheckAll_P.SetToolTip(CheckAllButton_P, checkAllButtonTip);
            ToolTipUncheckAll_P.SetToolTip(UnCheckAllButton_P, uncheckAllButtonTip);
            ToolTipPost_P.SetToolTip(PostButton_P, postButtonTip);
            ToolTipDeleteEntry_P.SetToolTip(DeleteRowsButton_P, deleteEntryButtonTip);
            ToolTipAdd_P.SetToolTip(AddEntryButton_P, addButtonTip);
            ToolTipAutoSort_P.SetToolTip(autoSortCB_P, autoSortTip);
            }
        /* ----------------------------------------------------------------------------------------*/
        private void SetLearnButtonVisibility()
            {
            if (C.learnMode)
                {
                LearnButton_D.Visible = false;
                }
            else
                {
                LearnButton_D.Visible = true;
                }
            }

        /* ----------------------------------------------------------------------------------------*/
        /* COMMON METHODS */
        /* ----------------------------------------------------------------------------------------*/
        private void ReturnToDefaults(object sender, EventArgs e)
            {
            C.learnMode = true;
            C.oldGenericName = C.genericName;
            C.genericName = C.genericRealNamePlaceholder;
            C.oldGenericPatientName = C.genericPatientName;
            C.genericPatientName = C.genericPatientNamePlaceholder;
            C.oldGenericPeerName = C.genericPeerName;
            C.genericPeerName = C.genericPeerNamePlaceholder;

            learnModeCB.Checked = C.learnMode;
            genericNameTB.Text = C.genericName;
            genericPatientNameTB.Text = C.genericPatientName;
            genericPeerNameTB.Text = C.genericPeerName;

            Properties.Settings.Default.learnMode = C.learnMode;
            SaveTextBoxText();
            TabData.GenericNameChange();
            TabData.GenericPatientNameChange();
            TabData.GenericPeerNameChange();
            TabData.autoSortIndex = C.USE_D;
            TabData.SetAutoSortCB();
            TabAssessment.GenericNameChange();
            TabAssessment.GenericPatientNameChange();
            TabAssessment.GenericPeerNameChange();
            TabAssessment.autoSortIndex = C.USE_D;
            TabAssessment.SetAutoSortCB();
            TabPlan.GenericNameChange();
            TabPlan.GenericPatientNameChange();
            TabPlan.GenericPeerNameChange();
            TabPlan.autoSortIndex = C.USE_D;
            TabPlan.SetAutoSortCB();
            SaveAll();
            }
        /* ----------------------------------------------------------------------------------------*/
        private void HappyFace_Click(object sender, EventArgs e)
            {
            Random random = new Random();
            int index = random.Next(0, C.phrases.Length-1);
            MessageBox.Show(C.phrases[index], "Hello");
            }
        /* ----------------------------------------------------------------------------------------*/
        public static void SaveGeneral()
            {
            Console.WriteLine("SaveGeneral()");
            Properties.Settings.Default.realName = C.realName;
            Properties.Settings.Default.genericName = C.genericName;
            Properties.Settings.Default.genericPatientName = C.genericPatientName;
            Properties.Settings.Default.genericPeerName = C.genericPeerName;
            Properties.Settings.Default.isMale = C.isMale;
            Properties.Settings.Default.learnMode = C.learnMode;
            Properties.Settings.Default.autoArrows = C.autoArrows;
            Properties.Settings.Default.Save();
            }
        /* ----------------------------------------------------------------------------------------*/
        public static void SaveAll()
            {
            Console.WriteLine("SaveAll()");
            SaveGeneral();
            TabData.SaveAll();
            TabAssessment.SaveAll();
            TabPlan.SaveAll();
            }

        /* ----------------------------------------------------------------------------------------*/
        /* COMMON EVENTS */
        /* ----------------------------------------------------------------------------------------*/
        /* Patient Name */
        /* ----------------------------------------------------------------------------------------*/
        private void TabIndex_Changed(object sender, EventArgs e)
            {
            Console.WriteLine("TabIndexChanged : " + tabControl1.SelectedTab);
            if (tabControl1.SelectedTab == tabControl1.TabPages["DataTab"])
                {
                C.currentTab = 1;
                }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["AssessmentTab"])
                {
                C.currentTab = 2;
                }
            else C.currentTab = 3;
            Console.WriteLine("Tab index = " + C.currentTab);
            }
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
            Properties.Settings.Default.realName = C.realName;
            Properties.Settings.Default.Save();
            TabData.RealNameChange();
            TabAssessment.RealNameChange();
            TabPlan.RealNameChange();
            }

        private void RealName_TextChanged(object sender, EventArgs e)
            {
            Console.WriteLine("PatientName_TextChanged() : name = " + realNameTB.Text);
            //C.patientName = PatientNameTB.Text;
            }

        /* ----------------------------------------------------------------------------------------*/
        /* Generic Name TB */
        /* ----------------------------------------------------------------------------------------*/
        private void GenericNameTB_TextChanged(object sender, EventArgs e)
            {
            }
        /* ----------------------------------------------------------------------------------------*/
        private void GenericNameTB_Enter(object sender, EventArgs e)
            {
            TextBoxEnter(genericNameTB, C.genericRealNamePlaceholder);
            }
        /* ----------------------------------------------------------------------------------------*/
        private void GenericNameTB_Leave(object sender, EventArgs e)
            {
            TextBoxLeave(C.genericRealNamePlaceholder, ref C.oldGenericName, ref C.genericName, genericNameTB);
            TabData.GenericNameChange();
            TabAssessment.GenericNameChange();
            TabPlan.GenericNameChange();
            }

        /* ----------------------------------------------------------------------------------------*/
        /* Generic Patient Name TB*/
        /* ----------------------------------------------------------------------------------------*/
        private void PatientGenericNameTB_TextChanged(object sender, EventArgs e)
            {
            //C.genericPatientName = PatientGenericNameTB.Text;
            }
        /* ----------------------------------------------------------------------------------------*/
        private void PatientGenericNameTB_Enter(object sender, EventArgs e)
            {
            TextBoxEnter(genericPatientNameTB, C.genericPatientNamePlaceholder);
            }
        /* ----------------------------------------------------------------------------------------*/
        private void PatientGenericNameTB_Leave(object sender, EventArgs e)
            {
            TextBoxLeave(C.genericPatientNamePlaceholder, ref C.oldGenericPatientName, ref C.genericPatientName, genericPatientNameTB);
            TabData.GenericPatientNameChange();
            TabAssessment.GenericPatientNameChange();
            TabPlan.GenericPatientNameChange();
            }

        /* ----------------------------------------------------------------------------------------*/
        /* Generic Peer Name TB*/
        /* ----------------------------------------------------------------------------------------*/
        private void PeerGenericNameTB_TextChanged(object sender, EventArgs e)
            {
            //C.genericPeerName = PeerGenericNameTB.Text;
            }
        /* ----------------------------------------------------------------------------------------*/
        private void PeerGenericNameTB_Enter(object sender, EventArgs e)
            {
            TextBoxEnter(genericPeerNameTB, C.genericPeerNamePlaceholder);
            }
        /* ----------------------------------------------------------------------------------------*/
        private void PeerGenericNameTB_Leave(object sender, EventArgs e)
            {

            TextBoxLeave(C.genericPeerNamePlaceholder, ref C.oldGenericPeerName, ref C.genericPeerName, genericPeerNameTB);
            TabData.GenericPeerNameChange();
            TabAssessment.GenericPeerNameChange();
            TabPlan.GenericPeerNameChange();
            }

        /* ----------------------------------------------------------------------------------------*/
        /* Generic Enter & Leave Methods */
        /* ----------------------------------------------------------------------------------------*/
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
        /* ----------------------------------------------------------------------------------------*/
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
                    textBox.Text = C.AddArrows(C.Capitalize(C.StripArrows(textBox.Text)));
                //textBox.Text = C.AddArrows(textBox.Text.ToString());
                textBox.ForeColor = Color.Black;
                }
            newName = textBox.Text;
            SaveTextBoxText();
            Properties.Settings.Default.Save();
            }
        /* ----------------------------------------------------------------------------------------*/
        private void SaveTextBoxText()
            {
            Properties.Settings.Default.genericName = C.genericName;
            Properties.Settings.Default.genericPatientName = C.genericPatientName;
            Properties.Settings.Default.genericPeerName = C.genericPeerName;
            Properties.Settings.Default.Save();
            }
        /* ----------------------------------------------------------------------------------------*/
        private void NewPatient_Click(object sender, EventArgs e)
            {
            C.oldRealName = C.realNamePlaceholder;
            C.realName = C.realNamePlaceholder;
            realNameTB.Text = C.realNamePlaceholder;
            MaleRadioButton.Checked = true;
            C.oldIsMale = true;
            C.isMale = true;
            TabData.ResetTab();
            TabAssessment.ResetTab();
            TabPlan.ResetTab();

            Properties.Settings.Default.realName = C.realName;
            Properties.Settings.Default.isMale = C.isMale;
            Properties.Settings.Default.entryBoxText_D = TabData.entryBox.Text;
            Properties.Settings.Default.entryBoxText_A = TabAssessment.entryBox.Text;
            Properties.Settings.Default.entryBoxText_P = TabPlan.entryBox.Text;
            Properties.Settings.Default.Save();
            }
        // -------------------------------------------------------------------------------------------------
        private void GenericPeerNameTB_KeyUp(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                SelectNextFocus();
                }
            }

        private void GenericPatientNameTB_KeyUp(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                SelectNextFocus();
                }
            }

        private void GenericNameTB_KeyUp(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                SelectNextFocus();
                }
            }

        private void SelectNextFocus()
            {
            this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        /* ----------------------------------------------------------------------------------------*/
        /* Gender Buttons */
        /* ----------------------------------------------------------------------------------------*/
        private void MaleButton_CheckedChanged(object sender, EventArgs e)
            {
            Properties.Settings.Default.isMale = MaleRadioButton.Checked;
            Properties.Settings.Default.Save();
            C.oldIsMale = C.isMale;
            C.isMale = MaleRadioButton.Checked;
            }
        /* ----------------------------------------------------------------------------------------*/
        private void FemaleButton_CheckedChanged(object sender, EventArgs e)
            {
            }

        /* ----------------------------------------------------------------------------------------*/
        private void LearnModeCB_CheckedChanged(object sender, EventArgs e)
            {
            C.learnMode = learnModeCB.Checked;
            SetLearnButtonVisibility();
            }
        /* ----------------------------------------------------------------------------------------*/
        private void AutoArrowsCB_CheckedChanged(object sender, EventArgs e)
            {
            C.autoArrows = autoArrowsCB.Checked;
            Properties.Settings.Default.autoArrows = C.autoArrows;
            Properties.Settings.Default.Save();
            }

        /* ----------------------------------------------------------------------------------------*/
        /* Data Tab */
        /* ----------------------------------------------------------------------------------------*/

        private void EntryBox_Enter_D(object sender, EventArgs e)
            { TabData.EntryBox_Enter(); }
        private void EntryBox_Leave_D(object sender, EventArgs e)
            {
            TabData.EntryBox_Leave();
            Properties.Settings.Default.entryBoxText_D = TabData.entryBox.Text;
            Properties.Settings.Default.Save();
            }
        private void EntryBox_TextChanged_D(object sender, EventArgs e)
            { TabData.EntryBox_TextChanged(); }
        private void DeleteButton_Click_D(object sender, EventArgs e)
            { TabData.DeleteAutoFillEntry(); }
        private void CutButton_Click_D(object sender, EventArgs e)
            { TabData.CutButtonClick(); }
        private void CopyButton_Click_D(object sender, EventArgs e)
            { TabData.CopyButtonClick(); }
        private void LearnButton_D_Click(object sender, EventArgs e)
            { TabData.LearnButtonClick(); }

        // -------------------------------------------------------------------------------------------------
        private void AutoSortCB_D_SelectedIndexChanged(object sender, EventArgs e)
            {
            tabData.AutoSortIndexChanged(autoSortCB_D.SelectedIndex);
            }
        /* ----------------------------------------------------------------------------------------*/
        /* Data Grid View Data */
        /* ----------------------------------------------------------------------------------------*/
        private void DataGridView_RowValidated_D(object sender, DataGridViewCellEventArgs e)
            {
            TabData.RowValidated(e.RowIndex);
            }
        private void DataGridView_ColumnHeaderMouseClick_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Left)
                TabData.ColumnHeaderMouseClick(e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellValueChanged_D(object sender, DataGridViewCellEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                TabData.CheckboxClick(e.RowIndex);
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellContentClick_D(object sender, DataGridViewCellEventArgs e)
            {
            }        
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellClick_D(object sender, DataGridViewCellEventArgs e)
            {
            TabData.CellClick(e.RowIndex, e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellDoubleClick_D(object sender, DataGridViewCellEventArgs e)
            {
            TabData.CellDoubleClick(e.RowIndex, e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void AddRowButtonClick_D(object sender, EventArgs e)
            {
            TabData.AddRowButtonClick();
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_RowsAdded_D(object sender, DataGridViewRowsAddedEventArgs e)
            {
            Console.WriteLine("RowsAdded(): list size = " + TabData.autoFillList.Count + "; row count = " + e.RowCount + "; row index = " + e.RowIndex);
            //dataGridView_D.CurrentCell = dataGridView_D.Rows[tabData.rowSelected].Cells[tabData.colSelected];
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_MouseUp_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {
                TabData.dataGridView.EndEdit();
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_MouseClick_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                TabData.RightMouseClick(e.RowIndex, e.ColumnIndex, TabData.RelativePoint(e));
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DeleteButtonRows_Click_D(object sender, EventArgs e)
            {
            TabData.DeleteCheckedEntries();
            }
        // -------------------------------------------------------------------------------------------------
        private void PostButton_Click_D(object sender, EventArgs e)
            {
            TabData.PostEntries();
            }
        // -------------------------------------------------------------------------------------------------
        private void CheckAll_Click_D(object sender, EventArgs e)
            {
            TabData.CheckAll();
            }
        // -------------------------------------------------------------------------------------------------
        private void UnCheckAll_Click_D(object sender, EventArgs e)
            {
            TabData.UnCheckAll();
            }

        /* ----------------------------------------------------------------------------------------*/
        /* Assessment Tab */
        /* ----------------------------------------------------------------------------------------*/

        private void EntryBox_Enter_A(object sender, EventArgs e)
            { TabAssessment.EntryBox_Enter(); }
        private void EntryBox_Leave_A(object sender, EventArgs e)
            {
            TabAssessment.EntryBox_Leave();
            Properties.Settings.Default.entryBoxText_A = TabAssessment.entryBox.Text;
            Properties.Settings.Default.Save();
            }
        private void EntryBox_TextChanged_A(object sender, EventArgs e)
            { TabAssessment.EntryBox_TextChanged(); }
        private void DeleteButton_Click_A(object sender, EventArgs e)
            { TabAssessment.DeleteAutoFillEntry(); }
        private void CutButton_Click_A(object sender, EventArgs e)
            { TabAssessment.CutButtonClick(); }
        private void CopyButton_Click_A(object sender, EventArgs e)
            { TabAssessment.CopyButtonClick(); }
        private void LearnButton_A_Click(object sender, EventArgs e)
            { TabAssessment.LearnButtonClick(); }

        // -------------------------------------------------------------------------------------------------
        private void AutoSortCB_A_SelectedIndexChanged(object sender, EventArgs e)
            {
            tabAssessment.AutoSortIndexChanged(autoSortCB_D.SelectedIndex);
            }
        /* ----------------------------------------------------------------------------------------*/
        /* Data Grid View Data */
        /* ----------------------------------------------------------------------------------------*/
        private void DataGridView_RowValidated_A(object sender, DataGridViewCellEventArgs e)
            {
            TabAssessment.RowValidated(e.RowIndex);
            }
        private void DataGridView_ColumnHeaderMouseClick_A(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Left)
                TabAssessment.ColumnHeaderMouseClick(e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellValueChanged_A(object sender, DataGridViewCellEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                TabAssessment.CheckboxClick(e.RowIndex);
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellContentClick_A(object sender, DataGridViewCellEventArgs e)
            {
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellClick_A(object sender, DataGridViewCellEventArgs e)
            {
            TabAssessment.CellClick(e.RowIndex, e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellDoubleClick_A(object sender, DataGridViewCellEventArgs e)
            {
            TabAssessment.CellDoubleClick(e.RowIndex, e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void AddRowButtonClick_A(object sender, EventArgs e)
            {
            TabAssessment.AddRowButtonClick();
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_RowsAdded_A(object sender, DataGridViewRowsAddedEventArgs e)
            {
            Console.WriteLine("RowsAdded(): list size = " + TabAssessment.autoFillList.Count + "; row count = " + e.RowCount + "; row index = " + e.RowIndex);
            //dataGridView_A.CurrentCell = dataGridView_A.Rows[tabAssessment.rowSelected].Cells[tabAssessment.colSelected];
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_MouseUp_A(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {
                TabAssessment.dataGridView.EndEdit();
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_MouseClick_A(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                TabAssessment.RightMouseClick(e.RowIndex, e.ColumnIndex, TabAssessment.RelativePoint(e));
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DeleteButtonRows_Click_A(object sender, EventArgs e)
            {
            TabAssessment.DeleteCheckedEntries();
            }
        // -------------------------------------------------------------------------------------------------
        private void PostButton_Click_A(object sender, EventArgs e)
            {
            TabAssessment.PostEntries();
            }
        // -------------------------------------------------------------------------------------------------
        private void CheckAll_Click_A(object sender, EventArgs e)
            {
            TabAssessment.CheckAll();
            }
        // -------------------------------------------------------------------------------------------------
        private void UnCheckAll_Click_A(object sender, EventArgs e)
            {
            TabAssessment.UnCheckAll();
            }

        /* ----------------------------------------------------------------------------------------*/
        /* Data Plan */
        /* ----------------------------------------------------------------------------------------*/

        private void EntryBox_Enter_P(object sender, EventArgs e)
            { TabPlan.EntryBox_Enter(); }
        private void EntryBox_Leave_P(object sender, EventArgs e)
            {
            TabPlan.EntryBox_Leave();
            Properties.Settings.Default.entryBoxText_P = TabPlan.entryBox.Text;
            Properties.Settings.Default.Save();
            }
        private void EntryBox_TextChanged_P(object sender, EventArgs e)
            { TabPlan.EntryBox_TextChanged(); }
        private void DeleteButton_Click_P(object sender, EventArgs e)
            { TabPlan.DeleteAutoFillEntry(); }
        private void CutButton_Click_P(object sender, EventArgs e)
            { TabPlan.CutButtonClick(); }
        private void CopyButton_Click_P(object sender, EventArgs e)
            { TabPlan.CopyButtonClick(); }
        private void LearnButton_P_Click(object sender, EventArgs e)
            { TabPlan.LearnButtonClick(); }
        // -------------------------------------------------------------------------------------------------
        private void AutoSortCB_P_SelectedIndexChanged(object sender, EventArgs e)
            {
            tabPlan.AutoSortIndexChanged(autoSortCB_D.SelectedIndex);
            }

        /* ----------------------------------------------------------------------------------------*/
        /* Data Grid View Data */
        /* ----------------------------------------------------------------------------------------*/
        private void DataGridView_RowValidated_P(object sender, DataGridViewCellEventArgs e)
            {
            TabPlan.RowValidated(e.RowIndex);
            }
        private void DataGridView_ColumnHeaderMouseClick_P(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Left)
                TabPlan.ColumnHeaderMouseClick(e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellValueChanged_P(object sender, DataGridViewCellEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                TabPlan.CheckboxClick(e.RowIndex);
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellContentClick_P(object sender, DataGridViewCellEventArgs e)
            {
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellClick_P(object sender, DataGridViewCellEventArgs e)
            {
            TabPlan.CellClick(e.RowIndex, e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellDoubleClick_P(object sender, DataGridViewCellEventArgs e)
            {
            TabPlan.CellDoubleClick(e.RowIndex, e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        private void AddRowButtonClick_P(object sender, EventArgs e)
            {
            TabPlan.AddRowButtonClick();
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_RowsAdded_P(object sender, DataGridViewRowsAddedEventArgs e)
            {
            Console.WriteLine("RowsAdded(): list size = " + TabPlan.autoFillList.Count + "; row count = " + e.RowCount + "; row index = " + e.RowIndex);
            //dataGridView_P.CurrentCell = dataGridView_P.Rows[tabPlan.rowSelected].Cells[tabPlan.colSelected];
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_MouseUp_P(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {
                TabPlan.dataGridView.EndEdit();
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_MouseClick_P(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                TabPlan.RightMouseClick(e.RowIndex, e.ColumnIndex, TabPlan.RelativePoint(e));
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void DeleteButtonRows_Click_P(object sender, EventArgs e)
            {
            TabPlan.DeleteCheckedEntries();
            }
        // -------------------------------------------------------------------------------------------------
        private void PostButton_Click_P(object sender, EventArgs e)
            {
            TabPlan.PostEntries();
            }
        // -------------------------------------------------------------------------------------------------
        private void CheckAll_Click_P(object sender, EventArgs e)
            {
            TabPlan.CheckAll();
            }
        // -------------------------------------------------------------------------------------------------
        private void UnCheckAll_Click_P(object sender, EventArgs e)
            {
            TabPlan.UnCheckAll();
            }


        // -------------------------------------------------------------------------------------------------
        }
    }