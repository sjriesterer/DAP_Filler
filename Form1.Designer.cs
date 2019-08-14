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
            this.components = new System.ComponentModel.Container();
            this.Patient = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DataTab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.autoFillListView = new System.Windows.Forms.ListView();
            this.PostCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AutoFillCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UndoDButton = new System.Windows.Forms.Button();
            this.CopyDButton = new System.Windows.Forms.Button();
            this.CutDButton = new System.Windows.Forms.Button();
            this.DeleteDButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.AssessmentTab = new System.Windows.Forms.TabPage();
            this.PlanTab = new System.Windows.Forms.TabPage();
            this.autoFillEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patient.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.DataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoFillEntryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Patient
            // 
            this.Patient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Patient.Controls.Add(this.button1);
            this.Patient.Controls.Add(this.radioButton2);
            this.Patient.Controls.Add(this.radioButton1);
            this.Patient.Controls.Add(this.textBox1);
            this.Patient.Location = new System.Drawing.Point(5, 5);
            this.Patient.Name = "Patient";
            this.Patient.Size = new System.Drawing.Size(767, 45);
            this.Patient.TabIndex = 0;
            this.Patient.TabStop = false;
            this.Patient.Text = "Patient";
            this.Patient.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(709, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.NewPatient_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(377, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Female";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.FemaleButton_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(323, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Male";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.MaleButton_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.PatientName_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.PatientName_Enter);
            this.textBox1.Leave += new System.EventHandler(this.PatientName_Leave);
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
            this.tabControl1.Size = new System.Drawing.Size(763, 542);
            this.tabControl1.TabIndex = 1;
            // 
            // DataTab
            // 
            this.DataTab.Controls.Add(this.dataGridView1);
            this.DataTab.Controls.Add(this.autoFillListView);
            this.DataTab.Controls.Add(this.UndoDButton);
            this.DataTab.Controls.Add(this.CopyDButton);
            this.DataTab.Controls.Add(this.CutDButton);
            this.DataTab.Controls.Add(this.DeleteDButton);
            this.DataTab.Controls.Add(this.textBox2);
            this.DataTab.Location = new System.Drawing.Point(4, 25);
            this.DataTab.Name = "DataTab";
            this.DataTab.Padding = new System.Windows.Forms.Padding(3);
            this.DataTab.Size = new System.Drawing.Size(755, 513);
            this.DataTab.TabIndex = 0;
            this.DataTab.Text = "Data";
            this.DataTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Freq,
            this.Column2});
            this.dataGridView1.DataSource = this.autoFillEntryBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(17, 311);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(699, 191);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // autoFillListView
            // 
            this.autoFillListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PostCol,
            this.AutoFillCol});
            this.autoFillListView.GridLines = true;
            this.autoFillListView.Location = new System.Drawing.Point(2, 134);
            this.autoFillListView.Name = "autoFillListView";
            this.autoFillListView.Size = new System.Drawing.Size(750, 171);
            this.autoFillListView.TabIndex = 5;
            this.autoFillListView.UseCompatibleStateImageBehavior = false;
            this.autoFillListView.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // PostCol
            // 
            this.PostCol.Text = "Post";
            this.PostCol.Width = 10;
            // 
            // AutoFillCol
            // 
            this.AutoFillCol.Text = "Auto Fill Entry";
            this.AutoFillCol.Width = 600;
            // 
            // UndoDButton
            // 
            this.UndoDButton.BackgroundImage = global::DAP_Filler.Properties.Resources._004_undo_button;
            this.UndoDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UndoDButton.Location = new System.Drawing.Point(107, 98);
            this.UndoDButton.Name = "UndoDButton";
            this.UndoDButton.Size = new System.Drawing.Size(30, 30);
            this.UndoDButton.TabIndex = 4;
            this.UndoDButton.UseVisualStyleBackColor = true;
            this.UndoDButton.Click += new System.EventHandler(this.UndoDButton_Click);
            // 
            // CopyDButton
            // 
            this.CopyDButton.BackgroundImage = global::DAP_Filler.Properties.Resources._003_copy_content;
            this.CopyDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyDButton.Location = new System.Drawing.Point(71, 98);
            this.CopyDButton.Name = "CopyDButton";
            this.CopyDButton.Size = new System.Drawing.Size(30, 30);
            this.CopyDButton.TabIndex = 3;
            this.CopyDButton.UseVisualStyleBackColor = true;
            // 
            // CutDButton
            // 
            this.CutDButton.BackgroundImage = global::DAP_Filler.Properties.Resources._002_scissors;
            this.CutDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CutDButton.Location = new System.Drawing.Point(35, 98);
            this.CutDButton.Name = "CutDButton";
            this.CutDButton.Size = new System.Drawing.Size(30, 30);
            this.CutDButton.TabIndex = 2;
            this.CutDButton.UseVisualStyleBackColor = true;
            // 
            // DeleteDButton
            // 
            this.DeleteDButton.BackgroundImage = global::DAP_Filler.Properties.Resources._001_rubbish_bin;
            this.DeleteDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteDButton.Location = new System.Drawing.Point(0, 98);
            this.DeleteDButton.Name = "DeleteDButton";
            this.DeleteDButton.Size = new System.Drawing.Size(30, 30);
            this.DeleteDButton.TabIndex = 1;
            this.DeleteDButton.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(755, 92);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // AssessmentTab
            // 
            this.AssessmentTab.Location = new System.Drawing.Point(4, 25);
            this.AssessmentTab.Name = "AssessmentTab";
            this.AssessmentTab.Padding = new System.Windows.Forms.Padding(3);
            this.AssessmentTab.Size = new System.Drawing.Size(755, 513);
            this.AssessmentTab.TabIndex = 1;
            this.AssessmentTab.Text = "Assessment";
            this.AssessmentTab.UseVisualStyleBackColor = true;
            // 
            // PlanTab
            // 
            this.PlanTab.Location = new System.Drawing.Point(4, 25);
            this.PlanTab.Name = "PlanTab";
            this.PlanTab.Padding = new System.Windows.Forms.Padding(3);
            this.PlanTab.Size = new System.Drawing.Size(755, 513);
            this.PlanTab.TabIndex = 2;
            this.PlanTab.Text = "Plan";
            this.PlanTab.UseVisualStyleBackColor = true;
            // 
            // autoFillEntryBindingSource
            // 
            this.autoFillEntryBindingSource.DataSource = typeof(DAP_Filler.AutoFillEntry);
            // 
            // Freq
            // 
            this.Freq.HeaderText = "Freq";
            this.Freq.Name = "Freq";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "AutoFill";
            this.Column2.Name = "Column2";
            this.Column2.Width = 400;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(776, 602);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Patient);
            this.Name = "Form1";
            this.Text = "DAP Filler";
            this.Patient.ResumeLayout(false);
            this.Patient.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.DataTab.ResumeLayout(false);
            this.DataTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoFillEntryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Patient;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage DataTab;
        private System.Windows.Forms.TabPage AssessmentTab;
        private System.Windows.Forms.TabPage PlanTab;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button DeleteDButton;
        private System.Windows.Forms.Button UndoDButton;
        private System.Windows.Forms.Button CopyDButton;
        private System.Windows.Forms.Button CutDButton;
        private System.Windows.Forms.ListView autoFillListView;
        private System.Windows.Forms.ColumnHeader PostCol;
        private System.Windows.Forms.ColumnHeader AutoFillCol;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource autoFillEntryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freq;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

