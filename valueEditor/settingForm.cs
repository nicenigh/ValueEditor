using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace valueEditor
{
    public partial class settingForm : Form
    {
        private mode _mode;
        Setting s = Setting.getHandler();

        public settingForm(mode _mode)
        {
            InitializeComponent();
            this._mode = _mode;
        }

        public enum mode
        {
            split,
            node
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case mode.split:
                    this.Text = "分隔符设定";
                    kwp.Visible = true;
                    foreach (string kw in s.splitkw)
                    {
                        kwlistBox.Items.Add(kw);
                    }
                    break;
                case mode.node:
                    this.Text = "注释符设定";
                    kwp.Visible = true;
                    foreach (string kw in s.nodekw)
                    {
                        kwlistBox.Items.Add(kw);
                    }
                    break;
            }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            string c = InputBox.ShowInputBox("添加关键字");
            if (c.Trim() != string.Empty)
            {
                kwlistBox.Items.Add(c);
            }
        }

        private void delbutton_Click(object sender, EventArgs e)
        {
            kwlistBox.Items.Remove(kwlistBox.SelectedItem);
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case mode.split:
                    s.splitkw.Clear();
                    foreach (string kw in kwlistBox.Items)
                    {
                        s.splitkw.Add(kw);
                    }
                    break;
                case mode.node:
                    s.nodekw.Clear();
                    foreach (string kw in kwlistBox.Items)
                    {
                        s.nodekw.Add(kw);
                    }
                    break;
            }

            Configuration.UpdateAppConfig();
            this.Close();
        }
    }
}
