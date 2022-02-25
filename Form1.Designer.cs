namespace WallPaperEngineWinForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectFolderPath = new System.Windows.Forms.Button();
            this.txtSelectFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbType2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSelectFolderPath
            // 
            this.btnSelectFolderPath.Location = new System.Drawing.Point(175, 41);
            this.btnSelectFolderPath.Name = "btnSelectFolderPath";
            this.btnSelectFolderPath.Size = new System.Drawing.Size(40, 23);
            this.btnSelectFolderPath.TabIndex = 0;
            this.btnSelectFolderPath.Text = "...";
            this.btnSelectFolderPath.UseVisualStyleBackColor = true;
            this.btnSelectFolderPath.Click += new System.EventHandler(this.btnSelectFolderPath_Click);
            // 
            // txtSelectFolderPath
            // 
            this.txtSelectFolderPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSelectFolderPath.Location = new System.Drawing.Point(49, 43);
            this.txtSelectFolderPath.Name = "txtSelectFolderPath";
            this.txtSelectFolderPath.ReadOnly = true;
            this.txtSelectFolderPath.Size = new System.Drawing.Size(120, 21);
            this.txtSelectFolderPath.TabIndex = 1;
            this.txtSelectFolderPath.Text = "请选择存储位置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "类型";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(49, 87);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(56, 20);
            this.cmbType.TabIndex = 3;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            this.cmbType.SelectionChangeCommitted += new System.EventHandler(this.cmbType_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "容量";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(49, 132);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(120, 21);
            this.txtCount.TabIndex = 5;
            this.txtCount.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "存储";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(221, 41);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 112);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbType2
            // 
            this.cmbType2.FormattingEnabled = true;
            this.cmbType2.Location = new System.Drawing.Point(113, 88);
            this.cmbType2.Name = "cmbType2";
            this.cmbType2.Size = new System.Drawing.Size(56, 20);
            this.cmbType2.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(352, 187);
            this.Controls.Add(this.cmbType2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSelectFolderPath);
            this.Controls.Add(this.btnSelectFolderPath);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFolderPath;
        private System.Windows.Forms.TextBox txtSelectFolderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbType2;
    }
}

