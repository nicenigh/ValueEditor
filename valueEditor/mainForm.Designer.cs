namespace ValueEditor
{
    partial class MainForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.file_toolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.open_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.close_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveas_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.display_toolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.blank_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comment_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indent_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encoding_toolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.setting_toolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.split_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about_toolStrip = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.customRichTextBox1 = new ValueEditor.CustomRichTextBox();
            this.customRichTextBox2 = new ValueEditor.CustomRichTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_toolStrip,
            this.display_toolStrip,
            this.encoding_toolStrip,
            this.setting_toolStrip,
            this.toolStripSeparator2,
            this.about_toolStrip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // file_toolStrip
            // 
            this.file_toolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.file_toolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_ToolStripMenuItem,
            this.save_ToolStripMenuItem,
            this.close_ToolStripMenuItem,
            this.saveas_ToolStripMenuItem,
            this.toolStripSeparator1,
            this.exit_ToolStripMenuItem});
            this.file_toolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.file_toolStrip.Name = "file_toolStrip";
            this.file_toolStrip.Size = new System.Drawing.Size(53, 24);
            this.file_toolStrip.Text = "文件";
            // 
            // open_ToolStripMenuItem
            // 
            this.open_ToolStripMenuItem.Name = "open_ToolStripMenuItem";
            this.open_ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.open_ToolStripMenuItem.Text = "打开";
            this.open_ToolStripMenuItem.Click += new System.EventHandler(this.open_ToolStripMenuItem_Click);
            // 
            // save_ToolStripMenuItem
            // 
            this.save_ToolStripMenuItem.Name = "save_ToolStripMenuItem";
            this.save_ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.save_ToolStripMenuItem.Text = "保存";
            this.save_ToolStripMenuItem.Click += new System.EventHandler(this.save_ToolStripMenuItem_Click);
            // 
            // close_ToolStripMenuItem
            // 
            this.close_ToolStripMenuItem.Name = "close_ToolStripMenuItem";
            this.close_ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.close_ToolStripMenuItem.Text = "关闭";
            this.close_ToolStripMenuItem.Click += new System.EventHandler(this.close_ToolStripMenuItem_Click);
            // 
            // saveas_ToolStripMenuItem
            // 
            this.saveas_ToolStripMenuItem.Name = "saveas_ToolStripMenuItem";
            this.saveas_ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.saveas_ToolStripMenuItem.Text = "另存为";
            this.saveas_ToolStripMenuItem.Click += new System.EventHandler(this.saveas_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // exit_ToolStripMenuItem
            // 
            this.exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem";
            this.exit_ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exit_ToolStripMenuItem.Text = "退出";
            this.exit_ToolStripMenuItem.Click += new System.EventHandler(this.exit_ToolStripMenuItem_Click);
            // 
            // display_toolStrip
            // 
            this.display_toolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.display_toolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blank_ToolStripMenuItem,
            this.comment_ToolStripMenuItem,
            this.indent_ToolStripMenuItem});
            this.display_toolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.display_toolStrip.Name = "display_toolStrip";
            this.display_toolStrip.Size = new System.Drawing.Size(53, 24);
            this.display_toolStrip.Text = "显示";
            // 
            // blank_ToolStripMenuItem
            // 
            this.blank_ToolStripMenuItem.Name = "blank_ToolStripMenuItem";
            this.blank_ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.blank_ToolStripMenuItem.Text = "显示空白行";
            this.blank_ToolStripMenuItem.Click += new System.EventHandler(this.blank_ToolStripMenuItem_Click);
            // 
            // comment_ToolStripMenuItem
            // 
            this.comment_ToolStripMenuItem.Name = "comment_ToolStripMenuItem";
            this.comment_ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.comment_ToolStripMenuItem.Text = "显示注释行";
            this.comment_ToolStripMenuItem.Click += new System.EventHandler(this.comment_ToolStripMenuItem_Click);
            // 
            // indent_ToolStripMenuItem
            // 
            this.indent_ToolStripMenuItem.Name = "indent_ToolStripMenuItem";
            this.indent_ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.indent_ToolStripMenuItem.Text = "显示缩进";
            this.indent_ToolStripMenuItem.Click += new System.EventHandler(this.indent_ToolStripMenuItem_Click);
            // 
            // encoding_toolStrip
            // 
            this.encoding_toolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.encoding_toolStrip.Name = "encoding_toolStrip";
            this.encoding_toolStrip.Size = new System.Drawing.Size(53, 24);
            this.encoding_toolStrip.Text = "编码";
            // 
            // setting_toolStrip
            // 
            this.setting_toolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.setting_toolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.split_ToolStripMenuItem});
            this.setting_toolStrip.Name = "setting_toolStrip";
            this.setting_toolStrip.Size = new System.Drawing.Size(53, 24);
            this.setting_toolStrip.Text = "设置";
            // 
            // split_ToolStripMenuItem
            // 
            this.split_ToolStripMenuItem.Name = "split_ToolStripMenuItem";
            this.split_ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.split_ToolStripMenuItem.Text = "分隔符";
            this.split_ToolStripMenuItem.Click += new System.EventHandler(this.split_ToolStripMenuItem_Click);
            // 
            // about_toolStrip
            // 
            this.about_toolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.about_toolStrip.Name = "about_toolStrip";
            this.about_toolStrip.Size = new System.Drawing.Size(39, 24);
            this.about_toolStrip.Text = "关于";
            this.about_toolStrip.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.customRichTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.customRichTextBox2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 423);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // customRichTextBox1
            // 
            this.customRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRichTextBox1.InSync = true;
            this.customRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.customRichTextBox1.Name = "customRichTextBox1";
            this.customRichTextBox1.OtherTextBox = null;
            this.customRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.customRichTextBox1.ShowLineNo = true;
            this.customRichTextBox1.Size = new System.Drawing.Size(400, 423);
            this.customRichTextBox1.TabIndex = 0;
            this.customRichTextBox1.Text = "";
            // 
            // customRichTextBox2
            // 
            this.customRichTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRichTextBox2.InSync = true;
            this.customRichTextBox2.Location = new System.Drawing.Point(0, 0);
            this.customRichTextBox2.Name = "customRichTextBox2";
            this.customRichTextBox2.OtherTextBox = null;
            this.customRichTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.customRichTextBox2.ShowLineNo = true;
            this.customRichTextBox2.Size = new System.Drawing.Size(396, 423);
            this.customRichTextBox2.TabIndex = 0;
            this.customRichTextBox2.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton file_toolStrip;
        private System.Windows.Forms.ToolStripMenuItem open_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem close_ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveas_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton display_toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton encoding_toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton setting_toolStrip;
        private System.Windows.Forms.ToolStripLabel about_toolStrip;
        private System.Windows.Forms.ToolStripMenuItem blank_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comment_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indent_ToolStripMenuItem;
        private CustomRichTextBox customRichTextBox1;
        private CustomRichTextBox customRichTextBox2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem split_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

