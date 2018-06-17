using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace valueEditor
{
    public partial class Form2 : Form
    {
        private string mode;
        public Form2(string _mode)
        {
            InitializeComponent();
            this.mode = _mode;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            switch(mode)
            {
                case "split":
                    this.Text = "分隔符设定";
                    kwp.Visible = true;
                    foreach (char kw in Setting.splitkw)
                    {
                        kwlistBox.Items.Add(kw);
                    }
                    break;
                case "node":
                    this.Text = "注释符设定";
                    kwp.Visible = true;
                    foreach (char kw in Setting.nodekw)
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
            switch (mode)
            {
                case "split":
                    Setting.splitkw.Clear();
                    foreach (char kw in kwlistBox.Items)
                    {
                        Setting.splitkw.Add(kw);
                    }
                    break;
                case "node":
                    Setting.nodekw.Clear();
                    foreach (char kw in kwlistBox.Items)
                    {
                        Setting.nodekw.Add(kw);
                    }
                    break;
            }
            this.Close();
        }
    }
}
