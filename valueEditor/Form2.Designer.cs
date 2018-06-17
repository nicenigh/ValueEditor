namespace valueEditor
{
    partial class Form2
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
            this.kwp = new System.Windows.Forms.Panel();
            this.kwlistBox = new System.Windows.Forms.ListBox();
            this.delbutton = new System.Windows.Forms.Button();
            this.addbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.savebutton = new System.Windows.Forms.Button();
            this.kwp.SuspendLayout();
            this.SuspendLayout();
            // 
            // kwp
            // 
            this.kwp.Controls.Add(this.kwlistBox);
            this.kwp.Controls.Add(this.delbutton);
            this.kwp.Controls.Add(this.addbutton);
            this.kwp.Controls.Add(this.cancelbutton);
            this.kwp.Controls.Add(this.savebutton);
            this.kwp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwp.Location = new System.Drawing.Point(0, 0);
            this.kwp.Name = "kwp";
            this.kwp.Size = new System.Drawing.Size(335, 245);
            this.kwp.TabIndex = 0;
            this.kwp.Visible = false;
            // 
            // kwlistBox
            // 
            this.kwlistBox.FormattingEnabled = true;
            this.kwlistBox.ItemHeight = 12;
            this.kwlistBox.Location = new System.Drawing.Point(22, 22);
            this.kwlistBox.Name = "kwlistBox";
            this.kwlistBox.Size = new System.Drawing.Size(185, 148);
            this.kwlistBox.TabIndex = 17;
            // 
            // delbutton
            // 
            this.delbutton.Location = new System.Drawing.Point(227, 79);
            this.delbutton.Name = "delbutton";
            this.delbutton.Size = new System.Drawing.Size(75, 23);
            this.delbutton.TabIndex = 13;
            this.delbutton.Text = "删除";
            this.delbutton.UseVisualStyleBackColor = true;
            this.delbutton.Click += new System.EventHandler(this.delbutton_Click);
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(227, 22);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(75, 23);
            this.addbutton.TabIndex = 12;
            this.addbutton.Text = "添加";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(205, 197);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 15;
            this.cancelbutton.Text = "取消";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(52, 197);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 14;
            this.savebutton.Text = "保存";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 245);
            this.Controls.Add(this.kwp);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.kwp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel kwp;
        private System.Windows.Forms.Button delbutton;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.ListBox kwlistBox;
    }
}