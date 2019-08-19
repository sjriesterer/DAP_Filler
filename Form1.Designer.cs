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
            this.Patient = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PeerGenericNameTB = new System.Windows.Forms.TextBox();
            this.LearnModeCB = new System.Windows.Forms.CheckBox();
            this.PatientGenericNameTB = new System.Windows.Forms.TextBox();
            this.NewPatientButton = new System.Windows.Forms.Button();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.PatientNameTB = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DataTab = new System.Windows.Forms.TabPage();
            this.PastButton_D = new System.Windows.Forms.Button();
            this.DeleteButtonRows_D = new System.Windows.Forms.Button();
            this.LearnButton_D = new System.Windows.Forms.Button();
            this.AddEntryButton = new System.Windows.Forms.Button();
            this.DataGridView_D = new System.Windows.Forms.DataGridView();
            this.Post = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Uses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UndoButton_D = new System.Windows.Forms.Button();
            this.CopyButton_D = new System.Windows.Forms.Button();
            this.CutButton_D = new System.Windows.Forms.Button();
            this.DeleteButton_D = new System.Windows.Forms.Button();
            this.AutoFillEntry_D = new System.Windows.Forms.TextBox();
            this.AssessmentTab = new System.Windows.Forms.TabPage();
            this.PlanTab = new System.Windows.Forms.TabPage();
            this.SaveButton = new System.Windows.Forms.Button();
            this.Patient.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.DataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_D)).BeginInit();
            this.SuspendLayout();
            // 
            // Patient
            // 
            this.Patient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Patient.Controls.Add(this.SaveButton);
            this.Patient.Controls.Add(this.label2);
            this.Patient.Controls.Add(this.label1);
            this.Patient.Controls.Add(this.PeerGenericNameTB);
            this.Patient.Controls.Add(this.LearnModeCB);
            this.Patient.Controls.Add(this.PatientGenericNameTB);
            this.Patient.Controls.Add(this.NewPatientButton);
            this.Patient.Controls.Add(this.FemaleRadioButton);
            this.Patient.Controls.Add(this.MaleRadioButton);
            this.Patient.Controls.Add(this.PatientNameTB);
            this.Patient.Location = new System.Drawing.Point(5, 5);
            this.Patient.Name = "Patient";
            this.Patient.Size = new System.Drawing.Size(767, 71);
            this.Patient.TabIndex = 0;
            this.Patient.TabStop = false;
            this.Patient.Text = "Patient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Generic Peer Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Generic Patient Name:";
            // 
            // PeerGenericNameTB
            // 
            this.PeerGenericNameTB.Location = new System.Drawing.Point(399, 45);
            this.PeerGenericNameTB.MaxLength = 20;
            this.PeerGenericNameTB.Name = "PeerGenericNameTB";
            this.PeerGenericNameTB.Size = new System.Drawing.Size(150, 20);
            this.PeerGenericNameTB.TabIndex = 12;
            this.PeerGenericNameTB.TextChanged += new System.EventHandler(this.PeerGenericNameTB_TextChanged);
            this.PeerGenericNameTB.Enter += new System.EventHandler(this.PeerGenericNameTB_Enter);
            this.PeerGenericNameTB.Leave += new System.EventHandler(this.PeerGenericNameTB_Leave);
            // 
            // LearnModeCB
            // 
            this.LearnModeCB.AutoSize = true;
            this.LearnModeCB.Checked = true;
            this.LearnModeCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LearnModeCB.Location = new System.Drawing.Point(569, 13);
            this.LearnModeCB.Name = "LearnModeCB";
            this.LearnModeCB.Size = new System.Drawing.Size(83, 17);
            this.LearnModeCB.TabIndex = 4;
            this.LearnModeCB.Text = "Learn Mode";
            this.LearnModeCB.UseVisualStyleBackColor = true;
            this.LearnModeCB.CheckedChanged += new System.EventHandler(this.LearnModeCB_CheckedChanged);
            // 
            // PatientGenericNameTB
            // 
            this.PatientGenericNameTB.Location = new System.Drawing.Point(128, 45);
            this.PatientGenericNameTB.MaxLength = 20;
            this.PatientGenericNameTB.Name = "PatientGenericNameTB";
            this.PatientGenericNameTB.Size = new System.Drawing.Size(150, 20);
            this.PatientGenericNameTB.TabIndex = 11;
            this.PatientGenericNameTB.TextChanged += new System.EventHandler(this.PatientGenericNameTB_TextChanged);
            this.PatientGenericNameTB.Enter += new System.EventHandler(this.PatientGenericNameTB_Enter);
            this.PatientGenericNameTB.Leave += new System.EventHandler(this.PatientGenericNameTB_Leave);
            // 
            // NewPatientButton
            // 
            this.NewPatientButton.Location = new System.Drawing.Point(658, 9);
            this.NewPatientButton.Name = "NewPatientButton";
            this.NewPatientButton.Size = new System.Drawing.Size(50, 23);
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
            this.DataTab.Controls.Add(this.PastButton_D);
            this.DataTab.Controls.Add(this.DeleteButtonRows_D);
            this.DataTab.Controls.Add(this.LearnButton_D);
            this.DataTab.Controls.Add(this.AddEntryButton);
            this.DataTab.Controls.Add(this.DataGridView_D);
            this.DataTab.Controls.Add(this.UndoButton_D);
            this.DataTab.Controls.Add(this.CopyButton_D);
            this.DataTab.Controls.Add(this.CutButton_D);
            this.DataTab.Controls.Add(this.DeleteButton_D);
            this.DataTab.Controls.Add(this.AutoFillEntry_D);
            this.DataTab.Location = new System.Drawing.Point(4, 25);
            this.DataTab.Name = "DataTab";
            this.DataTab.Padding = new System.Windows.Forms.Padding(3);
            this.DataTab.Size = new System.Drawing.Size(755, 566);
            this.DataTab.TabIndex = 0;
            this.DataTab.Text = "Data";
            this.DataTab.UseVisualStyleBackColor = true;
            // 
            // PastButton_D
            // 
            this.PastButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PastButton_D.BackgroundImage")));
            this.PastButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PastButton_D.Location = new System.Drawing.Point(651, 98);
            this.PastButton_D.Name = "PastButton_D";
            this.PastButton_D.Size = new System.Drawing.Size(30, 30);
            this.PastButton_D.TabIndex = 10;
            this.PastButton_D.UseVisualStyleBackColor = true;
            this.PastButton_D.Click += new System.EventHandler(this.PostButton_Click_D);
            // 
            // DeleteButtonRows_D
            // 
            this.DeleteButtonRows_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteButtonRows_D.BackgroundImage")));
            this.DeleteButtonRows_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButtonRows_D.Location = new System.Drawing.Point(687, 98);
            this.DeleteButtonRows_D.Name = "DeleteButtonRows_D";
            this.DeleteButtonRows_D.Size = new System.Drawing.Size(30, 30);
            this.DeleteButtonRows_D.TabIndex = 9;
            this.DeleteButtonRows_D.UseVisualStyleBackColor = true;
            this.DeleteButtonRows_D.Click += new System.EventHandler(this.DeleteButtonRows_Click_D);
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
            // AddEntryButton
            // 
            this.AddEntryButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddEntryButton.BackgroundImage")));
            this.AddEntryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddEntryButton.Location = new System.Drawing.Point(719, 98);
            this.AddEntryButton.Name = "AddEntryButton";
            this.AddEntryButton.Size = new System.Drawing.Size(30, 30);
            this.AddEntryButton.TabIndex = 7;
            this.AddEntryButton.UseVisualStyleBackColor = true;
            this.AddEntryButton.Click += new System.EventHandler(this.AddRowButtonClick_D);
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
            this.DataGridView_D.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick_D);
            this.DataGridView_D.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_MouseClick_D);
            this.DataGridView_D.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_ColumnHeaderMouseClick_D);
            this.DataGridView_D.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridView_RowsAdded_D);
            // 
            // Post
            // 
            this.Post.HeaderText = "Post";
            this.Post.Name = "Post";
            this.Post.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Post.ToolTipText = "Post entry to form";
            this.Post.Width = 30;
            // 
            // Uses
            // 
            this.Uses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Uses.DataPropertyName = "uses";
            this.Uses.HeaderText = "Uses";
            this.Uses.Name = "Uses";
            this.Uses.ReadOnly = true;
            this.Uses.ToolTipText = "Number of times this entry has been used";
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
            this.Entry.ToolTipText = "Autofill entry";
            // 
            // UndoButton_D
            // 
            this.UndoButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UndoButton_D.BackgroundImage")));
            this.UndoButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UndoButton_D.Location = new System.Drawing.Point(110, 98);
            this.UndoButton_D.Name = "UndoButton_D";
            this.UndoButton_D.Size = new System.Drawing.Size(30, 30);
            this.UndoButton_D.TabIndex = 4;
            this.UndoButton_D.UseVisualStyleBackColor = true;
            this.UndoButton_D.Click += new System.EventHandler(this.UndoButton_Click_D);
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
            // AutoFillEntry_D
            // 
            this.AutoFillEntry_D.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoFillEntry_D.Location = new System.Drawing.Point(0, 0);
            this.AutoFillEntry_D.MaxLength = 1000;
            this.AutoFillEntry_D.Multiline = true;
            this.AutoFillEntry_D.Name = "AutoFillEntry_D";
            this.AutoFillEntry_D.Size = new System.Drawing.Size(755, 92);
            this.AutoFillEntry_D.TabIndex = 0;
            this.AutoFillEntry_D.TextChanged += new System.EventHandler(this.AutoFillEntry_TextChanged_D);
            this.AutoFillEntry_D.Enter += new System.EventHandler(this.AutoFillEntry_Enter_D);
            this.AutoFillEntry_D.Leave += new System.EventHandler(this.AutoFillEntry_Leave_D);
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
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(732, 10);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(30, 30);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(776, 680);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Patient);
            this.Name = "Form1";
            this.Text = "DAP Filler";
            this.Patient.ResumeLayout(false);
            this.Patient.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.DataTab.ResumeLayout(false);
            this.DataTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_D)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Patient;
        private System.Windows.Forms.TextBox PatientNameTB;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.Button NewPatientButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AssessmentTab;
        private System.Windows.Forms.TabPage PlanTab;
        private System.Windows.Forms.CheckBox LearnModeCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PeerGenericNameTB;
        private System.Windows.Forms.TextBox PatientGenericNameTB;
        private System.Windows.Forms.TabPage DataTab;
        private System.Windows.Forms.Button PastButton_D;
        private System.Windows.Forms.Button DeleteButtonRows_D;
        private System.Windows.Forms.Button LearnButton_D;
        private System.Windows.Forms.Button AddEntryButton;
        private System.Windows.Forms.DataGridView DataGridView_D;
        private System.Windows.Forms.Button UndoButton_D;
        private System.Windows.Forms.Button CopyButton_D;
        private System.Windows.Forms.Button CutButton_D;
        private System.Windows.Forms.Button DeleteButton_D;
        private System.Windows.Forms.TextBox AutoFillEntry_D;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Post;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entry;
        private System.Windows.Forms.Button SaveButton;
        }
}

