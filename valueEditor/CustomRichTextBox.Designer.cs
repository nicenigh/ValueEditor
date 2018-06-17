namespace valueEditor
{
    partial class CustomRichTextBox
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cstRichTextBox1 = new valueEditor.CstRichTextBox(this.components);
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 261);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cstRichTextBox1
            // 
            this.cstRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cstRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cstRichTextBox1.Location = new System.Drawing.Point(35, 0);
            this.cstRichTextBox1.Name = "cstRichTextBox1";
            this.cstRichTextBox1.OtherRichTextBox = null;
            this.cstRichTextBox1.Size = new System.Drawing.Size(267, 261);
            this.cstRichTextBox1.TabIndex = 1;
            this.cstRichTextBox1.Text = "";
            this.cstRichTextBox1.WordWrap = false;
            this.cstRichTextBox1.VScroll += new System.EventHandler(this.cstRichTextBox1_VScroll);
            this.cstRichTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cstRichTextBox1_MouseClick);
            this.cstRichTextBox1.TextChanged += new System.EventHandler(this.cstRichTextBox1_TextChanged);
            this.cstRichTextBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cstRichTextBox1_MouseDown);
            this.cstRichTextBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cstRichTextBox1_MouseUp);
            // 
            // CustomRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cstRichTextBox1);
            this.Controls.Add(this.panel1);
            this.Name = "CustomRichTextBox";
            this.Size = new System.Drawing.Size(302, 261);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public  valueEditor.CstRichTextBox cstRichTextBox1;
    }
}
