using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace valueEditor
{
    public partial class InputBox : System.Windows.Forms.Form
    { 
        private System.Windows.Forms.TextBox txtData;

        private InputBox()
        {
            InitializeComponent();
        }
        
        //对键盘进行响应
        private void txtData_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }

            else if (e.KeyCode == Keys.Escape)
            {
                txtData.Text = string.Empty;
                this.Close();
            }

        }

        //显示InputBox
        public static string ShowInputBox(string Title)
        {
            InputBox inputbox = new InputBox();
            inputbox.Text = Title;
            inputbox.ShowDialog();

            return inputbox.txtData.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtData.Text = string.Empty;
            this.Close();
        }
    }

}
