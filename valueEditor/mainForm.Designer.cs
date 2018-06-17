namespace valueEditor
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.customRichTextBox1 = new valueEditor.CustomRichTextBox();
            this.customRichTextBox2 = new valueEditor.CustomRichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.打开ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.分隔符ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注释符ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.正则表达式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.uTF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gB2312ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bIG5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // customRichTextBox1
            // 
            this.customRichTextBox1.CustomFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.customRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.customRichTextBox1.Name = "customRichTextBox1";
            this.customRichTextBox1.OtherRichTextBox = null;
            this.customRichTextBox1.ShowLineNo = true;
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
            this.customRichTextBox2.ShowLineNo = true;
            this.customRichTextBox2.Size = new System.Drawing.Size(396, 423);
            this.customRichTextBox2.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton5,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton4,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(764, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem1,
            this.保存ToolStripMenuItem1,
            this.关闭ToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton1.Text = "文件";
            // 
            // 打开ToolStripMenuItem1
            // 
            this.打开ToolStripMenuItem1.Name = "打开ToolStripMenuItem1";
            this.打开ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.打开ToolStripMenuItem1.Text = "打开";
            this.打开ToolStripMenuItem1.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem1
            // 
            this.保存ToolStripMenuItem1.Name = "保存ToolStripMenuItem1";
            this.保存ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.保存ToolStripMenuItem1.Text = "保存";
            this.保存ToolStripMenuItem1.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton2.Text = "编辑";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton3.Text = "显示";
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.分隔符ToolStripMenuItem,
            this.注释符ToolStripMenuItem,
            this.正则表达式ToolStripMenuItem});
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton4.Text = "设定";
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
            // 正则表达式ToolStripMenuItem
            // 
            this.正则表达式ToolStripMenuItem.Name = "正则表达式ToolStripMenuItem";
            this.正则表达式ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.正则表达式ToolStripMenuItem.Text = "正则表达式";
            this.正则表达式ToolStripMenuItem.Click += new System.EventHandler(this.正则表达式ToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton1.Text = "关于";
            this.toolStripButton1.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton5
            // 
            this.toolStripDropDownButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uTF8ToolStripMenuItem,
            this.gB2312ToolStripMenuItem,
            this.bIG5ToolStripMenuItem});
            this.toolStripDropDownButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton5.Image")));
            this.toolStripDropDownButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton5.Name = "toolStripDropDownButton5";
            this.toolStripDropDownButton5.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton5.Text = "编码";
            // 
            // uTF8ToolStripMenuItem
            // 
            this.uTF8ToolStripMenuItem.Name = "uTF8ToolStripMenuItem";
            this.uTF8ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.uTF8ToolStripMenuItem.Text = "UTF-8";
            this.uTF8ToolStripMenuItem.Click += new System.EventHandler(this.uTF8ToolStripMenuItem_Click);
            // 
            // gB2312ToolStripMenuItem
            // 
            this.gB2312ToolStripMenuItem.Name = "gB2312ToolStripMenuItem";
            this.gB2312ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gB2312ToolStripMenuItem.Text = "GB2312";
            // 
            // bIG5ToolStripMenuItem
            // 
            this.bIG5ToolStripMenuItem.Name = "bIG5ToolStripMenuItem";
            this.bIG5ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bIG5ToolStripMenuItem.Text = "BIG5";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 448);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem 分隔符ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注释符ToolStripMenuItem;
        public CustomRichTextBox customRichTextBox2;
        public CustomRichTextBox customRichTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 正则表达式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.ToolStripMenuItem uTF8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gB2312ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bIG5ToolStripMenuItem;
    }
}

