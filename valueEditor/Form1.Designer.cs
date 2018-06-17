namespace valueEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.分隔符ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注释符ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customRichTextBox1 = new valueEditor.CustomRichTextBox();
            this.customRichTextBox2 = new valueEditor.CustomRichTextBox();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设定ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设定ToolStripMenuItem
            // 
            this.设定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.分隔符ToolStripMenuItem,
            this.注释符ToolStripMenuItem});
            this.设定ToolStripMenuItem.Name = "设定ToolStripMenuItem";
            this.设定ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设定ToolStripMenuItem.Text = "设定";
            this.设定ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.customRichTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.customRichTextBox2);
            this.splitContainer1.Size = new System.Drawing.Size(764, 423);
            this.splitContainer1.SplitterDistance = 364;
            this.splitContainer1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // 分隔符ToolStripMenuItem
            // 
            this.分隔符ToolStripMenuItem.Name = "分隔符ToolStripMenuItem";
            this.分隔符ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.分隔符ToolStripMenuItem.Text = "分隔符";
            this.分隔符ToolStripMenuItem.Click += new System.EventHandler(this.分隔符ToolStripMenuItem_Click);
            // 
            // 注释符ToolStripMenuItem
            // 
            this.注释符ToolStripMenuItem.Name = "注释符ToolStripMenuItem";
            this.注释符ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.注释符ToolStripMenuItem.Text = "注释符";
            this.注释符ToolStripMenuItem.Click += new System.EventHandler(this.注释符ToolStripMenuItem_Click);
            // 
            // customRichTextBox1
            // 
            this.customRichTextBox1.CustomFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.customRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.customRichTextBox1.Name = "customRichTextBox1";
            this.customRichTextBox1.OtherRichTextBox = null;
            this.customRichTextBox1.Size = new System.Drawing.Size(364, 423);
            this.customRichTextBox1.TabIndex = 0;
            // 
            // customRichTextBox2
            // 
            this.customRichTextBox2.CustomFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.customRichTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRichTextBox2.Location = new System.Drawing.Point(0, 0);
            this.customRichTextBox2.Name = "customRichTextBox2";
            this.customRichTextBox2.OtherRichTextBox = null;
            this.customRichTextBox2.Size = new System.Drawing.Size(396, 423);
            this.customRichTextBox2.TabIndex = 0;
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 448);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CustomRichTextBox customRichTextBox1;
        private CustomRichTextBox customRichTextBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分隔符ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注释符ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
    }
}

