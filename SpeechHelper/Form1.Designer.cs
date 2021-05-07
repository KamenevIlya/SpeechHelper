
namespace SpeechHelper
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
            this.btnRecordVoice = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSpeechInfo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRecordsToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnFindRelated = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.entitiesRecordsListLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRecordVoice
            // 
            this.btnRecordVoice.Location = new System.Drawing.Point(39, 46);
            this.btnRecordVoice.Name = "btnRecordVoice";
            this.btnRecordVoice.Size = new System.Drawing.Size(132, 43);
            this.btnRecordVoice.TabIndex = 0;
            this.btnRecordVoice.Text = "Record";
            this.btnRecordVoice.UseVisualStyleBackColor = true;
            this.btnRecordVoice.Click += new System.EventHandler(this.btnRecordVoice_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(39, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 43);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSpeechInfo
            // 
            this.btnSpeechInfo.Location = new System.Drawing.Point(39, 178);
            this.btnSpeechInfo.Name = "btnSpeechInfo";
            this.btnSpeechInfo.Size = new System.Drawing.Size(132, 43);
            this.btnSpeechInfo.TabIndex = 3;
            this.btnSpeechInfo.Text = "Convert Speech";
            this.btnSpeechInfo.UseVisualStyleBackColor = true;
            this.btnSpeechInfo.Click += new System.EventHandler(this.btnSpeechInfo_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(39, 249);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(445, 191);
            this.textBox1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(509, 30);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem1,
            this.openFileToolStripMenuItem,
            this.chooseLanguageToolStripMenuItem,
            this.deleteRecordsToolStripMenu,
            this.settingsToolStripMenu,
            this.exitToolStripMenuItem});
            this.createToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(47, 26);
            this.createToolStripMenuItem.Text = "File";
            // 
            // createToolStripMenuItem1
            // 
            this.createToolStripMenuItem1.Name = "createToolStripMenuItem1";
            this.createToolStripMenuItem1.Size = new System.Drawing.Size(210, 26);
            this.createToolStripMenuItem1.Text = "Create";
            this.createToolStripMenuItem1.Click += new System.EventHandler(this.createToolStripMenuItem1_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.openFileToolStripMenuItem.Text = "Open file";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // chooseLanguageToolStripMenuItem
            // 
            this.chooseLanguageToolStripMenuItem.Name = "chooseLanguageToolStripMenuItem";
            this.chooseLanguageToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.chooseLanguageToolStripMenuItem.Text = "Choose language";
            this.chooseLanguageToolStripMenuItem.Click += new System.EventHandler(this.chooseLanguageToolStripMenuItem_Click);
            // 
            // deleteRecordsToolStripMenu
            // 
            this.deleteRecordsToolStripMenu.Name = "deleteRecordsToolStripMenu";
            this.deleteRecordsToolStripMenu.Size = new System.Drawing.Size(210, 26);
            this.deleteRecordsToolStripMenu.Text = "Delete records";
            this.deleteRecordsToolStripMenu.Click += new System.EventHandler(this.deleteRecordsToolStripMenu_Click);
            // 
            // settingsToolStripMenu
            // 
            this.settingsToolStripMenu.Name = "settingsToolStripMenu";
            this.settingsToolStripMenu.Size = new System.Drawing.Size(210, 26);
            this.settingsToolStripMenu.Text = "Settings";
            this.settingsToolStripMenu.Click += new System.EventHandler(this.settingsToolStripMenu_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "txt|*.txt;";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "txt|*.txt";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(444, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "00";
            // 
            // btnFindRelated
            // 
            this.btnFindRelated.Location = new System.Drawing.Point(187, 178);
            this.btnFindRelated.Name = "btnFindRelated";
            this.btnFindRelated.Size = new System.Drawing.Size(132, 43);
            this.btnFindRelated.TabIndex = 7;
            this.btnFindRelated.Text = "Find records";
            this.btnFindRelated.UseVisualStyleBackColor = true;
            this.btnFindRelated.Click += new System.EventHandler(this.btnFindRelated_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(200, 112);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(284, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // entitiesRecordsListLabel
            // 
            this.entitiesRecordsListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.entitiesRecordsListLabel.AutoSize = true;
            this.entitiesRecordsListLabel.Location = new System.Drawing.Point(197, 92);
            this.entitiesRecordsListLabel.Name = "entitiesRecordsListLabel";
            this.entitiesRecordsListLabel.Size = new System.Drawing.Size(100, 17);
            this.entitiesRecordsListLabel.TabIndex = 8;
            this.entitiesRecordsListLabel.Text = "Found records";
            this.entitiesRecordsListLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(509, 463);
            this.Controls.Add(this.entitiesRecordsListLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnFindRelated);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSpeechInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRecordVoice);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Speech Helper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRecordVoice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSpeechInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem chooseLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnFindRelated;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label entitiesRecordsListLabel;
        private System.Windows.Forms.ToolStripMenuItem deleteRecordsToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenu;
    }
}

