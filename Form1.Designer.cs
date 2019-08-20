namespace DAP_Filler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PatientGB = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GenericPeerNameLabel = new System.Windows.Forms.Label();
            this.GenericPatientNameLabel = new System.Windows.Forms.Label();
            this.genericPeerNameTB = new System.Windows.Forms.TextBox();
            this.LearnModeCB = new System.Windows.Forms.CheckBox();
            this.genericPatientNameTB = new System.Windows.Forms.TextBox();
            this.NewPatientButton = new System.Windows.Forms.Button();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.PatientNameTB = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DataTab = new System.Windows.Forms.TabPage();
            this.CheckAllButton_D = new System.Windows.Forms.Button();
            this.UnCheckAllButton_D = new System.Windows.Forms.Button();
            this.PostButton_D = new System.Windows.Forms.Button();
            this.DeleteRowsButton_D = new System.Windows.Forms.Button();
            this.LearnButton_D = new System.Windows.Forms.Button();
            this.AddEntryButton_D = new System.Windows.Forms.Button();
            this.DataGridView_D = new System.Windows.Forms.DataGridView();
            this.Post = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Uses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CopyButton_D = new System.Windows.Forms.Button();
            this.CutButton_D = new System.Windows.Forms.Button();
            this.DeleteButton_D = new System.Windows.Forms.Button();
            this.EntryBox_D = new System.Windows.Forms.TextBox();
            this.AssessmentTab = new System.Windows.Forms.TabPage();
            this.PlanTab = new System.Windows.Forms.TabPage();
            this.PatientGB.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.DataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_D)).BeginInit();
            this.SuspendLayout();
            // 
            // PatientGB
            // 
            this.PatientGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientGB.Controls.Add(this.SaveButton);
            this.PatientGB.Controls.Add(this.GenericPeerNameLabel);
            this.PatientGB.Controls.Add(this.GenericPatientNameLabel);
            this.PatientGB.Controls.Add(this.genericPeerNameTB);
            this.PatientGB.Controls.Add(this.LearnModeCB);
            this.PatientGB.Controls.Add(this.genericPatientNameTB);
            this.PatientGB.Controls.Add(this.NewPatientButton);
            this.PatientGB.Controls.Add(this.FemaleRadioButton);
            this.PatientGB.Controls.Add(this.MaleRadioButton);
            this.PatientGB.Controls.Add(this.PatientNameTB);
            this.PatientGB.Location = new System.Drawing.Point(5, 5);
            this.PatientGB.Name = "PatientGB";
            this.PatientGB.Size = new System.Drawing.Size(767, 71);
            this.PatientGB.TabIndex = 0;
            this.PatientGB.TabStop = false;
            this.PatientGB.Text = "Patient";
            // 
            // SaveButton
            // 
            this.SaveButton.BackgroundImage = global::DAP_Filler.Properties.Resources.save;
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveButton.Location = new System.Drawing.Point(732, 10);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(30, 30);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GenericPeerNameLabel
            // 
            this.GenericPeerNameLabel.AutoSize = true;
            this.GenericPeerNameLabel.Location = new System.Drawing.Point(293, 48);
            this.GenericPeerNameLabel.Name = "GenericPeerNameLabel";
            this.GenericPeerNameLabel.Size = new System.Drawing.Size(103, 13);
            this.GenericPeerNameLabel.TabIndex = 14;
            this.GenericPeerNameLabel.Text = "Generic Peer Name:";
            // 
            // GenericPatientNameLabel
            // 
            this.GenericPatientNameLabel.AutoSize = true;
            this.GenericPatientNameLabel.Location = new System.Drawing.Point(11, 48);
            this.GenericPatientNameLabel.Name = "GenericPatientNameLabel";
            this.GenericPatientNameLabel.Size = new System.Drawing.Size(114, 13);
            this.GenericPatientNameLabel.TabIndex = 13;
            this.GenericPatientNameLabel.Text = "Generic Patient Name:";
            // 
            // genericPeerNameTB
            // 
            this.genericPeerNameTB.Location = new System.Drawing.Point(399, 45);
            this.genericPeerNameTB.MaxLength = 20;
            this.genericPeerNameTB.Name = "genericPeerNameTB";
            this.genericPeerNameTB.Size = new System.Drawing.Size(150, 20);
            this.genericPeerNameTB.TabIndex = 12;
            this.genericPeerNameTB.TextChanged += new System.EventHandler(this.PeerGenericNameTB_TextChanged);
            this.genericPeerNameTB.Enter += new System.EventHandler(this.PeerGenericNameTB_Enter);
            this.genericPeerNameTB.Leave += new System.EventHandler(this.PeerGenericNameTB_Leave);
            // 
            // LearnModeCB
            // 
            this.LearnModeCB.AutoSize = true;
            this.LearnModeCB.Checked = true;
            this.LearnModeCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LearnModeCB.Location = new System.Drawing.Point(586, 16);
            this.LearnModeCB.Name = "LearnModeCB";
            this.LearnModeCB.Size = new System.Drawing.Size(83, 17);
            this.LearnModeCB.TabIndex = 4;
            this.LearnModeCB.Text = "Learn Mode";
            this.LearnModeCB.UseVisualStyleBackColor = true;
            this.LearnModeCB.CheckedChanged += new System.EventHandler(this.LearnModeCB_CheckedChanged);
            // 
            // genericPatientNameTB
            // 
            this.genericPatientNameTB.Location = new System.Drawing.Point(128, 45);
            this.genericPatientNameTB.MaxLength = 20;
            this.genericPatientNameTB.Name = "genericPatientNameTB";
            this.genericPatientNameTB.Size = new System.Drawing.Size(150, 20);
            this.genericPatientNameTB.TabIndex = 11;
            this.genericPatientNameTB.TextChanged += new System.EventHandler(this.PatientGenericNameTB_TextChanged);
            this.genericPatientNameTB.Enter += new System.EventHandler(this.PatientGenericNameTB_Enter);
            this.genericPatientNameTB.Leave += new System.EventHandler(this.PatientGenericNameTB_Leave);
            // 
            // NewPatientButton
            // 
            this.NewPatientButton.Location = new System.Drawing.Point(674, 10);
            this.NewPatientButton.Name = "NewPatientButton";
            this.NewPatientButton.Size = new System.Drawing.Size(50, 30);
            this.NewPatientButton.TabIndex = 3;
            this.NewPatientButton.Text = "New";
            this.NewPatientButton.UseVisualStyleBackColor = true;
            this.NewPatientButton.Click += new System.EventHandler(this.NewPatient_Click);
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Location = new System.Drawing.Point(377, 17);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(59, 17);
            this.FemaleRadioButton.TabIndex = 2;
            this.FemaleRadioButton.Text = "Female";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            this.FemaleRadioButton.CheckedChanged += new System.EventHandler(this.FemaleButton_CheckedChanged);
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Checked = true;
            this.MaleRadioButton.Location = new System.Drawing.Point(323, 17);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(48, 17);
            this.MaleRadioButton.TabIndex = 1;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "Male";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            this.MaleRadioButton.CheckedChanged += new System.EventHandler(this.MaleButton_CheckedChanged);
            // 
            // PatientNameTB
            // 
            this.PatientNameTB.Location = new System.Drawing.Point(9, 16);
            this.PatientNameTB.MaxLength = 30;
            this.PatientNameTB.Name = "PatientNameTB";
            this.PatientNameTB.Size = new System.Drawing.Size(303, 20);
            this.PatientNameTB.TabIndex = 0;
            this.PatientNameTB.WordWrap = false;
            this.PatientNameTB.TextChanged += new System.EventHandler(this.PatientName_TextChanged);
            this.PatientNameTB.Enter += new System.EventHandler(this.PatientName_Enter);
            this.PatientNameTB.Leave += new System.EventHandler(this.PatientName_Leave);
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.DataTab);
            this.tabControl1.Controls.Add(this.AssessmentTab);
            this.tabControl1.Controls.Add(this.PlanTab);
            this.tabControl1.Location = new System.Drawing.Point(8, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 595);
            this.tabControl1.TabIndex = 1;
            // 
            // DataTab
            // 
            this.DataTab.Controls.Add(this.CheckAllButton_D);
            this.DataTab.Controls.Add(this.UnCheckAllButton_D);
            this.DataTab.Controls.Add(this.PostButton_D);
            this.DataTab.Controls.Add(this.DeleteRowsButton_D);
            this.DataTab.Controls.Add(this.LearnButton_D);
            this.DataTab.Controls.Add(this.AddEntryButton_D);
            this.DataTab.Controls.Add(this.DataGridView_D);
            this.DataTab.Controls.Add(this.CopyButton_D);
            this.DataTab.Controls.Add(this.CutButton_D);
            this.DataTab.Controls.Add(this.DeleteButton_D);
            this.DataTab.Controls.Add(this.EntryBox_D);
            this.DataTab.Location = new System.Drawing.Point(4, 25);
            this.DataTab.Name = "DataTab";
            this.DataTab.Padding = new System.Windows.Forms.Padding(3);
            this.DataTab.Size = new System.Drawing.Size(755, 566);
            this.DataTab.TabIndex = 0;
            this.DataTab.Text = "Data";
            this.DataTab.UseVisualStyleBackColor = true;
            // 
            // CheckAllButton_D
            // 
            this.CheckAllButton_D.BackgroundImage = global::DAP_Filler.Properties.Resources._001_check;
            this.CheckAllButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CheckAllButton_D.Location = new System.Drawing.Point(579, 98);
            this.CheckAllButton_D.Name = "CheckAllButton_D";
            this.CheckAllButton_D.Size = new System.Drawing.Size(30, 30);
            this.CheckAllButton_D.TabIndex = 12;
            this.CheckAllButton_D.UseVisualStyleBackColor = true;
            this.CheckAllButton_D.Click += new System.EventHandler(this.CheckAll_Click_D);
            // 
            // UnCheckAllButton_D
            // 
            this.UnCheckAllButton_D.BackgroundImage = global::DAP_Filler.Properties.Resources._002_square_with_round_corners;
            this.UnCheckAllButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UnCheckAllButton_D.Location = new System.Drawing.Point(615, 98);
            this.UnCheckAllButton_D.Name = "UnCheckAllButton_D";
            this.UnCheckAllButton_D.Size = new System.Drawing.Size(30, 30);
            this.UnCheckAllButton_D.TabIndex = 11;
            this.UnCheckAllButton_D.UseVisualStyleBackColor = true;
            this.UnCheckAllButton_D.Click += new System.EventHandler(this.UnCheckAll_Click_D);
            // 
            // PostButton_D
            // 
            this.PostButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PostButton_D.BackgroundImage")));
            this.PostButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PostButton_D.Location = new System.Drawing.Point(651, 98);
            this.PostButton_D.Name = "PostButton_D";
            this.PostButton_D.Size = new System.Drawing.Size(30, 30);
            this.PostButton_D.TabIndex = 10;
            this.PostButton_D.UseVisualStyleBackColor = true;
            this.PostButton_D.Click += new System.EventHandler(this.PostButton_Click_D);
            // 
            // DeleteRowsButton_D
            // 
            this.DeleteRowsButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteRowsButton_D.BackgroundImage")));
            this.DeleteRowsButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteRowsButton_D.Location = new System.Drawing.Point(687, 98);
            this.DeleteRowsButton_D.Name = "DeleteRowsButton_D";
            this.DeleteRowsButton_D.Size = new System.Drawing.Size(30, 30);
            this.DeleteRowsButton_D.TabIndex = 9;
            this.DeleteRowsButton_D.UseVisualStyleBackColor = true;
            this.DeleteRowsButton_D.Click += new System.EventHandler(this.DeleteButtonRows_Click_D);
            // 
            // LearnButton_D
            // 
            this.LearnButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LearnButton_D.BackgroundImage")));
            this.LearnButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LearnButton_D.Location = new System.Drawing.Point(146, 98);
            this.LearnButton_D.Name = "LearnButton_D";
            this.LearnButton_D.Size = new System.Drawing.Size(30, 30);
            this.LearnButton_D.TabIndex = 8;
            this.LearnButton_D.UseVisualStyleBackColor = true;
            this.LearnButton_D.Click += new System.EventHandler(this.LearnButton_D_Click);
            // 
            // AddEntryButton_D
            // 
            this.AddEntryButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddEntryButton_D.BackgroundImage")));
            this.AddEntryButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddEntryButton_D.Location = new System.Drawing.Point(719, 98);
            this.AddEntryButton_D.Name = "AddEntryButton_D";
            this.AddEntryButton_D.Size = new System.Drawing.Size(30, 30);
            this.AddEntryButton_D.TabIndex = 7;
            this.AddEntryButton_D.UseVisualStyleBackColor = true;
            this.AddEntryButton_D.Click += new System.EventHandler(this.AddRowButtonClick_D);
            // 
            // DataGridView_D
            // 
            this.DataGridView_D.AllowUserToAddRows = false;
            this.DataGridView_D.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.DataGridView_D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_D.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Post,
            this.Uses,
            this.Entry});
            this.DataGridView_D.Location = new System.Drawing.Point(0, 134);
            this.DataGridView_D.Name = "DataGridView_D";
            this.DataGridView_D.Size = new System.Drawing.Size(755, 457);
            this.DataGridView_D.TabIndex = 6;
            this.DataGridView_D.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClick_D);
            this.DataGridView_D.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick_D);
            this.DataGridView_D.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick_D);
            this.DataGridView_D.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_MouseClick_D);
            this.DataGridView_D.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_MouseUp_D);
            this.DataGridView_D.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged_D);
            this.DataGridView_D.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_ColumnHeaderMouseClick_D);
            this.DataGridView_D.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridView_RowsAdded_D);
            // 
            // Post
            // 
            this.Post.HeaderText = "";
            this.Post.Name = "Post";
            this.Post.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Post.ToolTipText = "Checkboxes (retains order in which boxes are checked)";
            this.Post.Width = 30;
            // 
            // Uses
            // 
            this.Uses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Uses.DataPropertyName = "uses";
            this.Uses.HeaderText = "Uses";
            this.Uses.Name = "Uses";
            this.Uses.ReadOnly = true;
            this.Uses.ToolTipText = "Number of times this entry has been used (Click to sort)";
            this.Uses.Width = 40;
            // 
            // Entry
            // 
            this.Entry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Entry.DataPropertyName = "entry";
            this.Entry.HeaderText = "Entry";
            this.Entry.MaxInputLength = 300;
            this.Entry.Name = "Entry";
            this.Entry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Entry.ToolTipText = "Autofill Entries (Click to sort)";
            // 
            // CopyButton_D
            // 
            this.CopyButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CopyButton_D.BackgroundImage")));
            this.CopyButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyButton_D.Location = new System.Drawing.Point(74, 98);
            this.CopyButton_D.Name = "CopyButton_D";
            this.CopyButton_D.Size = new System.Drawing.Size(30, 30);
            this.CopyButton_D.TabIndex = 3;
            this.CopyButton_D.UseVisualStyleBackColor = true;
            this.CopyButton_D.Click += new System.EventHandler(this.CopyButton_Click_D);
            // 
            // CutButton_D
            // 
            this.CutButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CutButton_D.BackgroundImage")));
            this.CutButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CutButton_D.Location = new System.Drawing.Point(38, 98);
            this.CutButton_D.Name = "CutButton_D";
            this.CutButton_D.Size = new System.Drawing.Size(30, 30);
            this.CutButton_D.TabIndex = 2;
            this.CutButton_D.UseVisualStyleBackColor = true;
            this.CutButton_D.Click += new System.EventHandler(this.CutButton_Click_D);
            // 
            // DeleteButton_D
            // 
            this.DeleteButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteButton_D.BackgroundImage")));
            this.DeleteButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButton_D.Location = new System.Drawing.Point(2, 98);
            this.DeleteButton_D.Name = "DeleteButton_D";
            this.DeleteButton_D.Size = new System.Drawing.Size(30, 30);
            this.DeleteButton_D.TabIndex = 1;
            this.DeleteButton_D.UseVisualStyleBackColor = true;
            this.DeleteButton_D.Click += new System.EventHandler(this.DeleteButton_Click_D);
            // 
            // EntryBox_D
            // 
            this.EntryBox_D.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryBox_D.Location = new System.Drawing.Point(0, 0);
            this.EntryBox_D.MaxLength = 1000;
            this.EntryBox_D.Multiline = true;
            this.EntryBox_D.Name = "EntryBox_D";
            this.EntryBox_D.Size = new System.Drawing.Size(755, 92);
            this.EntryBox_D.TabIndex = 0;
            this.EntryBox_D.TextChanged += new System.EventHandler(this.AutoFillEntry_TextChanged_D);
            this.EntryBox_D.Enter += new System.EventHandler(this.AutoFillEntry_Enter_D);
            this.EntryBox_D.Leave += new System.EventHandler(this.AutoFillEntry_Leave_D);
            // 
            // AssessmentTab
            // 
            this.AssessmentTab.Location = new System.Drawing.Point(4, 25);
            this.AssessmentTab.Name = "AssessmentTab";
            this.AssessmentTab.Padding = new System.Windows.Forms.Padding(3);
            this.AssessmentTab.Size = new System.Drawing.Size(755, 566);
            this.AssessmentTab.TabIndex = 1;
            this.AssessmentTab.Text = "Assessment";
            this.AssessmentTab.UseVisualStyleBackColor = true;
            // 
            // PlanTab
            // 
            this.PlanTab.Location = new System.Drawing.Point(4, 25);
            this.PlanTab.Name = "PlanTab";
            this.PlanTab.Padding = new System.Windows.Forms.Padding(3);
            this.PlanTab.Size = new System.Drawing.Size(755, 566);
            this.PlanTab.TabIndex = 2;
            this.PlanTab.Text = "Plan";
            this.PlanTab.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(776, 680);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.PatientGB);
            this.Name = "Form1";
            this.Text = "DAP Filler";
            this.PatientGB.ResumeLayout(false);
            this.PatientGB.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.DataTab.ResumeLayout(false);
            this.DataTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_D)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PatientGB;
        private System.Windows.Forms.TextBox PatientNameTB;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.Button NewPatientButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AssessmentTab;
        private System.Windows.Forms.TabPage PlanTab;
        private System.Windows.Forms.CheckBox LearnModeCB;
        private System.Windows.Forms.Label GenericPeerNameLabel;
        private System.Windows.Forms.Label GenericPatientNameLabel;
        private System.Windows.Forms.TextBox genericPeerNameTB;
        private System.Windows.Forms.TextBox genericPatientNameTB;
        private System.Windows.Forms.TabPage DataTab;
        private System.Windows.Forms.Button PostButton_D;
        private System.Windows.Forms.Button DeleteRowsButton_D;
        private System.Windows.Forms.Button LearnButton_D;
        private System.Windows.Forms.Button AddEntryButton_D;
        private System.Windows.Forms.DataGridView DataGridView_D;
        private System.Windows.Forms.Button CopyButton_D;
        private System.Windows.Forms.Button CutButton_D;
        private System.Windows.Forms.Button DeleteButton_D;
        private System.Windows.Forms.TextBox EntryBox_D;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CheckAllButton_D;
        private System.Windows.Forms.Button UnCheckAllButton_D;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Post;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entry;
        }
}

