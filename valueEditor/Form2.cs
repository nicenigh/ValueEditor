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
        private Class1 c;
        public Form2(string _mode, Class1 _c)
        {
            InitializeComponent();
            this.mode = _mode;
            this.c = _c;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            switch(mode)
            {
                case "split":
                    this.Text = "分隔符设定";
                    kwp.Visible = true;
                    foreach (char kw in c.splitkw)
                    {
                        kwlistBox.Items.Add(kw);
                    }
                    break;
                case "node":
                    this.Text = "注释符设定";
                    kwp.Visible = true;
                    foreach (char kw in c.nodekw)
                    {
                        kwlistBox.Items.Add(kw);
                    }
                    break;
                case "about":
                    this.Text = "关于";
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
                    c.splitkw.Clear();
                    foreach (char kw in kwlistBox.Items)
                    {
                        c.splitkw.Add(kw);
                    }
                    break;
                case "node":
                    c.nodekw.Clear();
                    foreach (char kw in kwlistBox.Items)
                    {
                        c.nodekw.Add(kw);
                    }
                    break;
            }
            this.Close();
        }
    }
}
