using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace valueEditor
{
    public partial class Form1 : Form
    {
        Setting s = Setting.GetSetting();
        OpenFile f = OpenFile.GetOpenFile();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "valueEditor";
            customRichTextBox1.OtherRichTextBox = customRichTextBox2.cstRichTextBox1;
            customRichTextBox2.OtherRichTextBox = customRichTextBox1.cstRichTextBox1;
        }
        
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.Copy(openFileDialog1.FileName, openFileDialog1.FileName + ".bak");
                File.Delete(openFileDialog1.FileName);
                string[] fl = new string[customRichTextBox1.cstRichTextBox1.Lines.Length];
                for (int i = 0; i < customRichTextBox1.cstRichTextBox1.Lines.Length; i++)
                {
                    fl[i] += customRichTextBox1.cstRichTextBox1.Lines[i];
                    if (customRichTextBox2.cstRichTextBox1.Lines[i] != "")
                    {
                        fl[i] += "=" + customRichTextBox2.cstRichTextBox1.Lines[i];
                    }
                }
                File.WriteAllLines(openFileDialog1.FileName, fl);
            }
            catch
            {
                MessageBox.Show("保存失败");
            }
            
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String str = "valueEditor   v0.02\rby NiceNight\r2016-7-19";
            MessageBox.Show(str);
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            f.readFile(openFileDialog1.FileName, customRichTextBox1, customRichTextBox2);

            this.Text = "valueEditor - " + openFileDialog1.SafeFileName;
        }

        private void 分隔符ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Setsplit();
        }

        private void 注释符ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Setnode();
        }

    }
}
