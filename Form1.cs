using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using nucs.JsonSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private static MySettings settings;

        internal static Tab TabData { get => tabData; set => tabData = value; }
        internal static Tab TabAssessment { get => tabAssessment; set => tabAssessment = value; }
        internal static Tab TabPlan { get => tabPlan; set => tabPlan = value; }
        internal static MySettings Settings { get => settings; set => settings = value; }

        public Form1()
            {
            InitSettings();
            InitializeComponent();
            InitTabs();
            InitComponents();
            InitToolTips();
            SetLearnButtonVisibility();
            }
        // -------------------------------------------------------------------------------------------------
        // INIT METHODS 
        // -------------------------------------------------------------------------------------------------

        /* ----------------------------------------------------------------------------------------*/
        private void InitComponents()
            {
            realNameTB.Text = C.realName;
            genericPatientNameTB.Text = C.genericPatientName;
            genericPeerNameTB.Text = C.genericPeerName;
            genericNameTB.Text = C.genericName;
            MaleRadioButton.Checked = C.isMale;
            FemaleRadioButton.Checked = !C.isMale;
            autoArrowsCB.Checked = C.autoArrows;
            learnModeCB.Checked = C.learnMode;
            TabData.ResetTabComponents();
            TabAssessment.ResetTabComponents();
            TabPlan.ResetTabComponents();
            }
        /* ----------------------------------------------------------------------------------------*/
        private void InitTabs()
            {
            TabData = new Tab(C.tab1);
            TabData.InitTabComponents(DataGridView_D, EntryBox_D, searchTB_D, autoSortCB_D);
            TabAssessment = new Tab(C.tab2);
            TabAssessment.InitTabComponents(DataGridView_A, EntryBox_A, searchTB_A, autoSortCB_A);
            TabPlan = new Tab(C.tab3);
            TabPlan.InitTabComponents(DataGridView_P, EntryBox_P, searchTB_P, autoSortCB_P);
            }
        /* ----------------------------------------------------------------------------------------*/
        private void InitSettings()
            {
            if (File.Exists(GetSettingsFilePath(C.settingsFilename)))
                {
                Settings = VerifySettingsFile(GetSettingsFilePath(C.settingsFilename));
                if (Settings == null) /// Settings file is invalid
                    {
                    //TODO
                    /// Make backup copy of config.json file
                    /// Delete config.json file
                    Settings = JsonSettings.Load<MySettings>(C.settingsFilename); /// Makes a new blank settings file
                    }
                }
            else
                Settings = JsonSettings.Load<MySettings>(C.settingsFilename);
            LoadSettings();
            }
        /* ----------------------------------------------------------------------------------------*/
        private void LoadSettings()
            {
            C.isMale = Settings.isMale;
            C.oldIsMale = C.isMale;
            C.realName = Settings.realName;
            C.oldRealName = C.realName;
            C.genericName = Settings.genericName;
            C.oldGenericName = C.genericName;
            C.genericPatientName = Settings.genericPatientName;
            C.oldGenericPatientName = C.genericPatientName;
            C.genericPeerName = Settings.genericPeerName;
            C.oldGenericPeerName = C.genericPeerName;
            C.learnMode = Settings.learnMode;
            C.autoArrows = Settings.autoArrows;
            }
        /* ----------------------------------------------------------------------------------------*/
        private void LoadTabSettings()
            {
            TabData.TabReset();
            TabAssessment.TabReset();
            TabPlan.TabReset();
            }
        /* ----------------------------------------------------------------------------------------*/
        private void InitToolTips()
            {
            ToolTip ToolTipNew = new ToolTip();
            ToolTip ToolTipDefaults = new ToolTip();
            ToolTip ToolTipLearnMode = new ToolTip();
            ToolTip ToolTipGenericName = new ToolTip();
            ToolTip ToolTipGenericPatientName = new ToolTip();
            ToolTip ToolTipGenericPeerName = new ToolTip();
            ToolTip ToolTipAutoArrows = new ToolTip();
            ToolTip ToolTipHappyFace = new ToolTip();
            ToolTip ToolTipSave = new ToolTip();
            ToolTip ToolTipLoad = new ToolTip();

            ToolTipNew.SetToolTip(NewPatientButton, "Start a new patient");
            ToolTipDefaults.SetToolTip(DefaultButton, "Returns to defaults");
            ToolTipLearnMode.SetToolTip(learnModeCB, "Learn Mode will automatically create new entries based on the text in the entry box whenever cut or copy button is pressed");
            ToolTipGenericName.SetToolTip(genericNameTB, "The name used to reference the patient's real name in the auto entries");
            ToolTipGenericPatientName.SetToolTip(genericPatientNameTB, "The name used to reference the patient in the auto entries");
            ToolTipGenericPeerName.SetToolTip(genericPeerNameTB, "The name used to reference the patient's peers in the auto entries");
            ToolTipAutoArrows.SetToolTip(autoArrowsCB, "Automatically enters surrounding arrows <> around generic patient and peer names");
            ToolTipHappyFace.SetToolTip(happyFaceButton, "Click me");
            ToolTipSave.SetToolTip(saveButton, "Saves form and settings to external file");
            ToolTipLoad.SetToolTip(loadButton, "Loads form and settings from an external file");

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
                LearnButton_A.Visible = false;
                LearnButton_P.Visible = false;
                }
            else
                {
                LearnButton_D.Visible = true;
                LearnButton_A.Visible = true;
                LearnButton_P.Visible = true;
                }
            }
        // -------------------------------------------------------------------------------------------------
        // GENERAL METHODS 
        // -------------------------------------------------------------------------------------------------
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
        public static void SaveGeneral()
            {
            Console.WriteLine("SaveGeneral()");
            Settings.realName = C.realName;
            Settings.genericName = C.genericName;
            Settings.genericPatientName = C.genericPatientName;
            Settings.genericPeerName = C.genericPeerName;
            Settings.isMale = C.isMale;
            Settings.learnMode = C.learnMode;
            Settings.autoArrows = C.autoArrows;
            Settings.Save();
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
        private void SaveTextBoxText()
            {
            Settings.genericName = C.genericName;
            Settings.genericPatientName = C.genericPatientName;
            Settings.genericPeerName = C.genericPeerName;
            Settings.Save();
            }
        // -------------------------------------------------------------------------------------------------
        // REAL NAME 
        // -------------------------------------------------------------------------------------------------
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
            Settings.realName = C.realName;
            Settings.Save();
            TabData.RealNameChange();
            TabAssessment.RealNameChange();
            TabPlan.RealNameChange();
            }

        private void RealName_TextChanged(object sender, EventArgs e)
            {
            Console.WriteLine("PatientName_TextChanged() : name = " + realNameTB.Text);
            //C.patientName = PatientNameTB.Text;
            }
        // -------------------------------------------------------------------------------------------------
        // GENERIC REAL NAME 
        // -------------------------------------------------------------------------------------------------
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
        // -------------------------------------------------------------------------------------------------
        // GENERIC PATIENT NAME 
        // -------------------------------------------------------------------------------------------------
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
        // -------------------------------------------------------------------------------------------------
        // GENERIC PEER NAME 
        // -------------------------------------------------------------------------------------------------
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
        // -------------------------------------------------------------------------------------------------
        // TEXTBOX ENTER & LEAVE 
        // -------------------------------------------------------------------------------------------------
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
            Settings.Save();
            }
        // -------------------------------------------------------------------------------------------------
        // NEXT FOCUS 
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
        // -------------------------------------------------------------------------------------------------
        // GENDER BUTTONS
        // -------------------------------------------------------------------------------------------------
        private void MaleButton_CheckedChanged(object sender, EventArgs e)
            {
            Settings.isMale = MaleRadioButton.Checked;
            Settings.Save();
            C.oldIsMale = C.isMale;
            C.isMale = MaleRadioButton.Checked;
            }
        /* ----------------------------------------------------------------------------------------*/
        private void FemaleButton_CheckedChanged(object sender, EventArgs e)
            {
            }
        // -------------------------------------------------------------------------------------------------
        // LEARN MODE 
        // -------------------------------------------------------------------------------------------------
        private void LearnModeCB_CheckedChanged(object sender, EventArgs e)
            {
            C.learnMode = learnModeCB.Checked;
            Settings.learnMode = C.learnMode;
            Settings.Save();
            SetLearnButtonVisibility();
            }
        // -------------------------------------------------------------------------------------------------
        // AUTO ARROWS BUTTON
        // -------------------------------------------------------------------------------------------------
        private void AutoArrowsCB_CheckedChanged(object sender, EventArgs e)
            {
            C.autoArrows = autoArrowsCB.Checked;
            Settings.autoArrows = C.autoArrows;
            Settings.Save();
            }
        // -------------------------------------------------------------------------------------------------
        // HAPPY FACE BUTTON
        // -------------------------------------------------------------------------------------------------
        private void HappyFace_Click(object sender, EventArgs e)
            {
            Random random = new Random();
            int index = random.Next(0, C.phrases.Length - 1);
            MessageBox.Show(C.phrases[index], "Hello");
            }
        // -------------------------------------------------------------------------------------------------
        // SAVE & LOAD BUTTONS
        // -------------------------------------------------------------------------------------------------
        private void SaveButton_Click(object sender, EventArgs e)
            {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.Title = "Browse Text Files";
            saveFileDialog.Filter = "json files (*.json)|*.json|All files(*.*) | *.* ";
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                String destination = Path.GetDirectoryName(saveFileDialog.FileName) + "/" + Path.GetFileNameWithoutExtension(saveFileDialog.FileName) + ".json";
                if (!CopyFile(GetSettingsFilePath(C.settingsFilename), destination))
                    {
                    MessageBox.Show("Unable to save settings file \"" + destination + "\".", "Error");
                    }
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void LoadButton_Click(object sender, EventArgs e)
            {
            string workingDir = Directory.GetCurrentDirectory();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                openFileDialog.InitialDirectory = workingDir;
                openFileDialog.Filter = "json files (*.json)|*.json|All files(*.*) | *.* ";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                    MySettings m = VerifySettingsFile(openFileDialog.FileName);
                    if (m != null)
                        {
                        Settings = m;
                        Console.WriteLine("gridEntries_D = " + Settings.gridEntries_D);
                        LoadSettings();
                        LoadTabSettings();
                        InitComponents();
                        SetLearnButtonVisibility();
                        }
                    else
                        MessageBox.Show("The file \"" + openFileDialog.FileName + "\" is invalid", "Error");
                    }
                }
            }
        // -------------------------------------------------------------------------------------------------
        private MySettings VerifySettingsFile(String filename)
            {
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(MySettings)); /// Generate schema from MySettings object
            using (StreamReader r = new StreamReader(filename))
                {
                string json = r.ReadToEnd();
                MySettings m = TryParseJson<MySettings>(json, schema);
                return m;
                }
            }
        // -------------------------------------------------------------------------------------------------
        public T TryParseJson<T>(String json, JSchema schema) where T : new()
            {
            Console.WriteLine("TryParseJson() : making JObject");
            try
                {
                JObject jObject = JObject.Parse(json);
                return jObject.IsValid(schema) ?
                    JsonConvert.DeserializeObject<T>(json) : default;
                }
            catch
                {
                return default;
                }
            }
        // -------------------------------------------------------------------------------------------------
        private String GetSettingsFilePath(String filename)
            {
            String workingDir = Directory.GetCurrentDirectory();
            return workingDir + "/" + filename;
            }
        // -------------------------------------------------------------------------------------------------
        private Boolean CopyFile(String source, String destination)
            {
            Console.WriteLine("CopyFile() : source = " + source + "; destination = " + destination);
            String destinationPath = Path.GetDirectoryName(destination);
            if (File.Exists(source) && FileIsReadable(source) && HasWriteAccessToFolder(destinationPath))
                {
                try
                    {
                    File.Copy(source, destination, true);
                    }
                catch (IOException exception)
                    {
                    Console.WriteLine(exception.ToString());
                    return false;
                    }
                }
            else
                {
                return false;
                }
            return true;
            }
        // -------------------------------------------------------------------------------------------------
        private Boolean FileIsReadable(String filename)
            {
            try
                {
                File.Open(filename, FileMode.Open, FileAccess.Read).Dispose();
                return true;
                }
            catch (IOException exception)
                {
                Console.WriteLine(exception.ToString());
                return false;
                }
            }
        // -------------------------------------------------------------------------------------------------
        private Boolean HasWriteAccessToFolder(String folderPath)
            {
            try
                {
                // Attempt to get a list of security permissions from the folder. 
                // This will raise an exception if the path is read only or do not have access to view the permissions. 
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                return true;
                }
            catch (UnauthorizedAccessException)
                {
                return false;
                }
            }
        // -------------------------------------------------------------------------------------------------
        // NEW PATIENT BUTTON
        // -------------------------------------------------------------------------------------------------
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

            Settings.realName = C.realName;
            Settings.isMale = C.isMale;
            Settings.entryBoxText_D = TabData.entryBox.Text;
            Settings.entryBoxText_A = TabAssessment.entryBox.Text;
            Settings.entryBoxText_P = TabPlan.entryBox.Text;
            Settings.Save();
            }
        // -------------------------------------------------------------------------------------------------
        // ENTRY BOX
        // -------------------------------------------------------------------------------------------------
        private void EntryBox_Enter_D(object sender, EventArgs e)
            { TabData.EntryBox_Enter(); }
        private void EntryBox_Leave_D(object sender, EventArgs e)
            { TabData.EntryBox_Leave(); }
        private void EntryBox_TextChanged_D(object sender, EventArgs e)
            { TabData.EntryBox_TextChanged(); }
        // -------------------------------------------------------------------------------------------------
        private void EntryBox_Enter_A(object sender, EventArgs e)
            { TabAssessment.EntryBox_Enter(); }
        private void EntryBox_Leave_A(object sender, EventArgs e)
            { TabAssessment.EntryBox_Leave(); }
        private void EntryBox_TextChanged_A(object sender, EventArgs e)
            { TabAssessment.EntryBox_TextChanged(); }
        // -------------------------------------------------------------------------------------------------
        private void EntryBox_Enter_P(object sender, EventArgs e)
            { TabPlan.EntryBox_Enter(); }
        private void EntryBox_Leave_P(object sender, EventArgs e)
            { TabPlan.EntryBox_Leave(); }
        private void EntryBox_TextChanged_P(object sender, EventArgs e)
            { TabPlan.EntryBox_TextChanged(); }
        // -------------------------------------------------------------------------------------------------
        // DELETE/CUT/COPY/LEARN
        // -------------------------------------------------------------------------------------------------
        private void DeleteButton_Click_D(object sender, EventArgs e)
            { TabData.DeleteAutoFillEntry(); }
        private void CutButton_Click_D(object sender, EventArgs e)
            { TabData.CutButtonClick(); }
        private void CopyButton_Click_D(object sender, EventArgs e)
            { TabData.CopyButtonClick(); }
        private void LearnButton_D_Click(object sender, EventArgs e)
            { TabData.LearnButtonClick(); }
        // -------------------------------------------------------------------------------------------------
        private void DeleteButton_Click_A(object sender, EventArgs e)
            { TabAssessment.DeleteAutoFillEntry(); }
        private void CutButton_Click_A(object sender, EventArgs e)
            { TabAssessment.CutButtonClick(); }
        private void CopyButton_Click_A(object sender, EventArgs e)
            { TabAssessment.CopyButtonClick(); }
        private void LearnButton_A_Click(object sender, EventArgs e)
            { TabAssessment.LearnButtonClick(); }
        // -------------------------------------------------------------------------------------------------
        private void DeleteButton_Click_P(object sender, EventArgs e)
            { TabPlan.DeleteAutoFillEntry(); }
        private void CutButton_Click_P(object sender, EventArgs e)
            { TabPlan.CutButtonClick(); }
        private void CopyButton_Click_P(object sender, EventArgs e)
            { TabPlan.CopyButtonClick(); }
        private void LearnButton_P_Click(object sender, EventArgs e)
            { TabPlan.LearnButtonClick(); }
        // -------------------------------------------------------------------------------------------------
        // AUTO SORT INDEX CHANGED
        // -------------------------------------------------------------------------------------------------
        private void AutoSortCB_D_SelectedIndexChanged(object sender, EventArgs e)
            { tabData.AutoSortIndexChanged(autoSortCB_D.SelectedIndex); }
        private void AutoSortCB_A_SelectedIndexChanged(object sender, EventArgs e)
            { tabAssessment.AutoSortIndexChanged(autoSortCB_D.SelectedIndex); }
        private void AutoSortCB_P_SelectedIndexChanged(object sender, EventArgs e)
            { tabPlan.AutoSortIndexChanged(autoSortCB_D.SelectedIndex); }

        // -------------------------------------------------------------------------------------------------
        // ROW VALIDATED
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_RowValidated_D(object sender, DataGridViewCellEventArgs e)
            { TabData.RowValidated(e.RowIndex); }
        private void DataGridView_RowValidated_A(object sender, DataGridViewCellEventArgs e)
            { TabAssessment.RowValidated(e.RowIndex); }
        private void DataGridView_RowValidated_P(object sender, DataGridViewCellEventArgs e)
            { TabPlan.RowValidated(e.RowIndex); }
        // -------------------------------------------------------------------------------------------------
        // COLUMN HEADER CLICK
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_ColumnHeaderMouseClick_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Left)
                TabData.ColumnHeaderMouseClick(e.ColumnIndex);
            }
        private void DataGridView_ColumnHeaderMouseClick_A(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Left)
                TabAssessment.ColumnHeaderMouseClick(e.ColumnIndex);
            }
        private void DataGridView_ColumnHeaderMouseClick_P(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Left)
                TabPlan.ColumnHeaderMouseClick(e.ColumnIndex);
            }
        // -------------------------------------------------------------------------------------------------
        // CELL VALUE CHANGED
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellValueChanged_D(object sender, DataGridViewCellEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                TabData.CheckboxClick(e.RowIndex);
                }
            }
        private void DataGridView_CellValueChanged_A(object sender, DataGridViewCellEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                TabAssessment.CheckboxClick(e.RowIndex);
                }
            }
        private void DataGridView_CellValueChanged_P(object sender, DataGridViewCellEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                TabPlan.CheckboxClick(e.RowIndex);
                }
            }
        // -------------------------------------------------------------------------------------------------
        // CELL CLICK
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellClick_D(object sender, DataGridViewCellEventArgs e)
            { TabData.CellClick(e.RowIndex, e.ColumnIndex); }
        private void DataGridView_CellClick_A(object sender, DataGridViewCellEventArgs e)
            { TabAssessment.CellClick(e.RowIndex, e.ColumnIndex); }
        private void DataGridView_CellClick_P(object sender, DataGridViewCellEventArgs e)
            { TabPlan.CellClick(e.RowIndex, e.ColumnIndex); }
        // -------------------------------------------------------------------------------------------------
        // CELL DOUBLE CLICK
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_CellDoubleClick_D(object sender, DataGridViewCellEventArgs e)
            { TabData.CellDoubleClick(e.RowIndex, e.ColumnIndex); }
        private void DataGridView_CellDoubleClick_A(object sender, DataGridViewCellEventArgs e)
            { TabAssessment.CellDoubleClick(e.RowIndex, e.ColumnIndex); }
        private void DataGridView_CellDoubleClick_P(object sender, DataGridViewCellEventArgs e)
            { TabPlan.CellDoubleClick(e.RowIndex, e.ColumnIndex); }
        // -------------------------------------------------------------------------------------------------
        // MOUSE UP
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_MouseUp_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {
                TabData.dataGridView.EndEdit();
                }
            }
        private void DataGridView_MouseUp_A(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {
                TabAssessment.dataGridView.EndEdit();
                }
            }
        private void DataGridView_MouseUp_P(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {
                TabPlan.dataGridView.EndEdit();
                }
            }
        // -------------------------------------------------------------------------------------------------
        // MOUSE CLICK
        // -------------------------------------------------------------------------------------------------
        private void DataGridView_MouseClick_D(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                TabData.RightMouseClick(e.RowIndex, e.ColumnIndex, TabData.RelativePoint(e));
                }
            }
        private void DataGridView_MouseClick_A(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                TabAssessment.RightMouseClick(e.RowIndex, e.ColumnIndex, TabAssessment.RelativePoint(e));
                }
            }
        private void DataGridView_MouseClick_P(object sender, DataGridViewCellMouseEventArgs e)
            {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                TabPlan.RightMouseClick(e.RowIndex, e.ColumnIndex, TabPlan.RelativePoint(e));
                }
            }
        // -------------------------------------------------------------------------------------------------
        // SEARCH 
        // -------------------------------------------------------------------------------------------------
        private void SearchTB_KeyUp_D(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                TabData.SearchGrid();
                }
            }
        private void SearchTB_KeyUp_A(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                TabAssessment.SearchGrid();
                }
            }
        private void SearchTB_KeyUp_P(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                TabPlan.SearchGrid();
                }
            }
        // -------------------------------------------------------------------------------------------------
        private void SearchTB_Enter_D(object sender, EventArgs e)
            {
            BeginInvoke((Action)delegate
                { searchTB_D.SelectAll();});
            }
        private void SearchTB_Enter_A(object sender, EventArgs e)
            {
            BeginInvoke((Action)delegate
                { searchTB_A.SelectAll();});
            }
        private void SearchTB_Enter_P(object sender, EventArgs e)
            {
            BeginInvoke((Action)delegate
                { searchTB_P.SelectAll();});
            }
        // -------------------------------------------------------------------------------------------------
        private void SearchTB_Leave_D(object sender, EventArgs e)
            { TabData.SearchBoxLeave(); }
        private void SearchTB_Leave_P(object sender, EventArgs e)
            { TabPlan.SearchBoxLeave(); }
        private void SearchTB_Leave_A(object sender, EventArgs e)
            { TabAssessment.SearchBoxLeave(); }
        // -------------------------------------------------------------------------------------------------
        // CHECK ALL BUTTON
        // -------------------------------------------------------------------------------------------------
        private void CheckAll_Click_D(object sender, EventArgs e)
            { TabData.CheckAll(); }
        private void CheckAll_Click_A(object sender, EventArgs e)
            { TabAssessment.CheckAll(); }
        private void CheckAll_Click_P(object sender, EventArgs e)
            { TabPlan.CheckAll(); }
        // -------------------------------------------------------------------------------------------------
        // UNCHECK ALL BUTTON
        // -------------------------------------------------------------------------------------------------
        private void UnCheckAll_Click_D(object sender, EventArgs e)
            { TabData.UnCheckAll(); }
        private void UnCheckAll_Click_A(object sender, EventArgs e)
            { TabAssessment.UnCheckAll(); }
        private void UnCheckAll_Click_P(object sender, EventArgs e)
            { TabPlan.UnCheckAll(); }
        // -------------------------------------------------------------------------------------------------
        // POST BUTTON 
        // -------------------------------------------------------------------------------------------------
        private void PostButton_Click_D(object sender, EventArgs e)
            { TabData.PostEntries(); }
        private void PostButton_Click_A(object sender, EventArgs e)
            { TabAssessment.PostEntries(); }
        private void PostButton_Click_P(object sender, EventArgs e)
            { TabPlan.PostEntries(); }
        // -------------------------------------------------------------------------------------------------
        // DELETE ROW BUTTON 
        // -------------------------------------------------------------------------------------------------
        private void DeleteButtonRows_Click_D(object sender, EventArgs e)
            { TabData.DeleteCheckedEntries(); }
        private void DeleteButtonRows_Click_A(object sender, EventArgs e)
            { TabAssessment.DeleteCheckedEntries(); }
        private void DeleteButtonRows_Click_P(object sender, EventArgs e)
            { TabPlan.DeleteCheckedEntries(); }
        // -------------------------------------------------------------------------------------------------
        // ADD ROW BUTTON 
        // -------------------------------------------------------------------------------------------------
        private void AddRowButtonClick_D(object sender, EventArgs e)
            { TabData.AddRowButtonClick(); }
        private void AddRowButtonClick_A(object sender, EventArgs e)
            { TabAssessment.AddRowButtonClick(); }
        private void AddRowButtonClick_P(object sender, EventArgs e)
            { TabPlan.AddRowButtonClick(); }

        }
    }