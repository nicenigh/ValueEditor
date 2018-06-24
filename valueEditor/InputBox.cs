namespace System.Windows.Forms
{
    public partial class InputBox : Form
    {
        private string defalueValue = "";

        private InputBox(string title, string defalueValue = "")
        {
            InitializeComponent();
            this.Text = title;
            this.defalueValue = defalueValue;
            this.textBox1.Text = defalueValue;
        }

        //对键盘进行响应
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                textBox1.Text = string.Empty;
                this.Close();
            }
        }

        //显示InputBox
        public static DialogResult Show(string title, ref string value)
        {
            InputBox inputbox = new InputBox(title, value);
            var result = inputbox.ShowDialog();
            if (result == DialogResult.OK)
                value = inputbox.textBox1.Text;
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
