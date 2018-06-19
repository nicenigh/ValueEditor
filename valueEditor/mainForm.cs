using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ValueEditor
{
    public partial class MainForm : Form
    {
        public static CustomRichTextBox nameBox;
        public static CustomRichTextBox valueBox;

        private FileHelper file;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "ValueEditor";
            nameBox = this.customRichTextBox1;
            valueBox = this.customRichTextBox2;
            nameBox.OtherTextBox = valueBox.TextBox;
            valueBox.OtherTextBox = nameBox.TextBox;
            file = new FileHelper();
        }

        private void open_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.Focus();
            this.Text = "ValueEditor - " + this.openFileDialog1.SafeFileName;
            this.InvokeSync(() =>
            {
                file.Read(this.openFileDialog1.FileName);
                MainForm.nameBox.TextBox.Focus();
            });
        }
        private void exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void save_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.InvokeSync(() =>
            {
                file.Save(this.openFileDialog1.FileName);
            });
        }

        private void close_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file.Contents.Clear();
            nameBox.TextBox.Text = "";
            valueBox.TextBox.Text = "";
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            String str = "valueEditor   v0.12\rby NiceNight\r2018-8-19";
            MessageBox.Show(str);
        }

    }
}
