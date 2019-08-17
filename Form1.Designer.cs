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
            this.NewPatientButton = new System.Windows.Forms.Button();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.PatientNameTB = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DataTab = new System.Windows.Forms.TabPage();
            this.AddEntryButton = new System.Windows.Forms.Button();
            this.DataGridView_D = new System.Windows.Forms.DataGridView();
            this.UndoButton_D = new System.Windows.Forms.Button();
            this.CopyButton_D = new System.Windows.Forms.Button();
            this.CutButton_D = new System.Windows.Forms.Button();
            this.DeleteButton_D = new System.Windows.Forms.Button();
            this.AutoFillEntry_D = new System.Windows.Forms.TextBox();
            this.AssessmentTab = new System.Windows.Forms.TabPage();
            this.PlanTab = new System.Windows.Forms.TabPage();
            this.Post = new System.Windows.Forms.DataGridViewImageColumn();
            this.Uses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entry = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Patient.Controls.Add(this.NewPatientButton);
            this.Patient.Controls.Add(this.FemaleRadioButton);
            this.Patient.Controls.Add(this.MaleRadioButton);
            this.Patient.Controls.Add(this.PatientNameTB);
            this.Patient.Location = new System.Drawing.Point(5, 5);
            this.Patient.Name = "Patient";
            this.Patient.Size = new System.Drawing.Size(767, 45);
            this.Patient.TabIndex = 0;
            this.Patient.TabStop = false;
            this.Patient.Text = "Patient";
            // 
            // button1
            // 
            this.NewPatientButton.Location = new System.Drawing.Point(709, 13);
            this.NewPatientButton.Name = "button1";
            this.NewPatientButton.Size = new System.Drawing.Size(50, 23);
            this.NewPatientButton.TabIndex = 3;
            this.NewPatientButton.Text = "New";
            this.NewPatientButton.UseVisualStyleBackColor = true;
            this.NewPatientButton.Click += new System.EventHandler(this.NewPatient_Click);
            // 
            // radioButton2
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Location = new System.Drawing.Point(377, 17);
            this.FemaleRadioButton.Name = "radioButton2";
            this.FemaleRadioButton.Size = new System.Drawing.Size(59, 17);
            this.FemaleRadioButton.TabIndex = 2;
            this.FemaleRadioButton.Text = "Female";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            this.FemaleRadioButton.CheckedChanged += new System.EventHandler(this.FemaleButton_CheckedChanged);
            // 
            // radioButton1
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Checked = true;
            this.MaleRadioButton.Location = new System.Drawing.Point(323, 17);
            this.MaleRadioButton.Name = "radioButton1";
            this.MaleRadioButton.Size = new System.Drawing.Size(48, 17);
            this.MaleRadioButton.TabIndex = 1;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "Male";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            this.MaleRadioButton.CheckedChanged += new System.EventHandler(this.MaleButton_CheckedChanged);
            // 
            // tb_patientName
            // 
            this.PatientNameTB.Location = new System.Drawing.Point(9, 16);
            this.PatientNameTB.Name = "tb_patientName";
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
            this.tabControl1.Location = new System.Drawing.Point(8, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 620);
            this.tabControl1.TabIndex = 1;
            // 
            // DataTab
            // 
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
            this.DataTab.Size = new System.Drawing.Size(755, 591);
            this.DataTab.TabIndex = 0;
            this.DataTab.Text = "Data";
            this.DataTab.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.AddEntryButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.AddEntryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddEntryButton.Location = new System.Drawing.Point(725, 98);
            this.AddEntryButton.Name = "button2";
            this.AddEntryButton.Size = new System.Drawing.Size(30, 30);
            this.AddEntryButton.TabIndex = 7;
            this.AddEntryButton.UseVisualStyleBackColor = true;
            this.AddEntryButton.Click += new System.EventHandler(this.AddRowButtonClick_D);
            // 
            // dataGridView_D
            // 
            this.DataGridView_D.AllowUserToAddRows = false;
            this.DataGridView_D.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.DataGridView_D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_D.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Post,
            this.Uses,
            this.Entry});
            this.DataGridView_D.Location = new System.Drawing.Point(0, 134);
            this.DataGridView_D.Name = "dataGridView_D";
            this.DataGridView_D.Size = new System.Drawing.Size(755, 457);
            this.DataGridView_D.TabIndex = 6;
            this.DataGridView_D.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClick_D);
            //this.DataGridView_D.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick_D);
            this.DataGridView_D.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick_D);
            this.DataGridView_D.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_ColumnHeaderMouseClick_D);
            this.DataGridView_D.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridView_RowsAdded_D);
            //this.DataGridView_D.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged_D);
            this.DataGridView_D.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_MouseClick_D);
            //this.DataGridView_D.MouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_MouseDown_D);
            
            // 
            // UndoDButton
            // 
            this.UndoButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UndoDButton.BackgroundImage")));
            this.UndoButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UndoButton_D.Location = new System.Drawing.Point(107, 98);
            this.UndoButton_D.Name = "UndoDButton";
            this.UndoButton_D.Size = new System.Drawing.Size(30, 30);
            this.UndoButton_D.TabIndex = 4;
            this.UndoButton_D.UseVisualStyleBackColor = true;
            this.UndoButton_D.Click += new System.EventHandler(this.UndoButton_Click_D);
            // 
            // CopyDButton
            // 
            this.CopyButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CopyDButton.BackgroundImage")));
            this.CopyButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyButton_D.Location = new System.Drawing.Point(71, 98);
            this.CopyButton_D.Name = "CopyDButton";
            this.CopyButton_D.Size = new System.Drawing.Size(30, 30);
            this.CopyButton_D.TabIndex = 3;
            this.CopyButton_D.UseVisualStyleBackColor = true;
            this.CopyButton_D.Click += new System.EventHandler(this.CopyButton_Click_D);
            // 
            // CutDButton
            // 
            this.CutButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CutDButton.BackgroundImage")));
            this.CutButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CutButton_D.Location = new System.Drawing.Point(35, 98);
            this.CutButton_D.Name = "CutDButton";
            this.CutButton_D.Size = new System.Drawing.Size(30, 30);
            this.CutButton_D.TabIndex = 2;
            this.CutButton_D.UseVisualStyleBackColor = true;
            this.CutButton_D.Click += new System.EventHandler(this.CutButton_Click_D);
            // 
            // DeleteDButton
            // 
            this.DeleteButton_D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteDButton.BackgroundImage")));
            this.DeleteButton_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButton_D.Location = new System.Drawing.Point(0, 98);
            this.DeleteButton_D.Name = "DeleteDButton";
            this.DeleteButton_D.Size = new System.Drawing.Size(30, 30);
            this.DeleteButton_D.TabIndex = 1;
            this.DeleteButton_D.UseVisualStyleBackColor = true;
            this.DeleteButton_D.Click += new System.EventHandler(this.DeleteButton_Click_D);
            // 
            // autoFillEntry_D
            // 
            this.AutoFillEntry_D.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoFillEntry_D.Location = new System.Drawing.Point(0, 0);
            this.AutoFillEntry_D.Multiline = true;
            this.AutoFillEntry_D.Name = "autoFillEntry_D";
            this.AutoFillEntry_D.Size = new System.Drawing.Size(755, 92);
            this.AutoFillEntry_D.TabIndex = 0;
            this.AutoFillEntry_D.TextChanged += new System.EventHandler(this.AutoFillEntry_TextChanged_D);
            // 
            // AssessmentTab
            // 
            this.AssessmentTab.Location = new System.Drawing.Point(4, 25);
            this.AssessmentTab.Name = "AssessmentTab";
            this.AssessmentTab.Padding = new System.Windows.Forms.Padding(3);
            this.AssessmentTab.Size = new System.Drawing.Size(755, 591);
            this.AssessmentTab.TabIndex = 1;
            this.AssessmentTab.Text = "Assessment";
            this.AssessmentTab.UseVisualStyleBackColor = true;
            // 
            // PlanTab
            // 
            this.PlanTab.Location = new System.Drawing.Point(4, 25);
            this.PlanTab.Name = "PlanTab";
            this.PlanTab.Padding = new System.Windows.Forms.Padding(3);
            this.PlanTab.Size = new System.Drawing.Size(755, 591);
            this.PlanTab.TabIndex = 2;
            this.PlanTab.Text = "Plan";
            this.PlanTab.UseVisualStyleBackColor = true;
            // 
            // Post
            // 
            this.Post.HeaderText = "Post";
            this.Post.Image = global::DAP_Filler.Properties.Resources._007_clipboard_paste_button_16;
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
        private System.Windows.Forms.TabPage DataTab;
        private System.Windows.Forms.TabPage AssessmentTab;
        private System.Windows.Forms.TabPage PlanTab;
        private System.Windows.Forms.TextBox AutoFillEntry_D;
        private System.Windows.Forms.Button DeleteButton_D;
        private System.Windows.Forms.Button UndoButton_D;
        private System.Windows.Forms.Button CopyButton_D;
        private System.Windows.Forms.Button CutButton_D;
        private System.Windows.Forms.DataGridView DataGridView_D;
        private System.Windows.Forms.Button AddEntryButton;
        private System.Windows.Forms.DataGridViewImageColumn Post;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entry;
        }
}

