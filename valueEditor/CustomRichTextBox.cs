using System;
using System.Drawing;
using System.Windows.Forms;

namespace ValueEditor
{
    public partial class CustomRichTextBox : UserControl
    {
        public CustomRichTextBox()
        {
            InitializeComponent();
            this.TextBox.DrawLineNo += new EventHandler((s, e) =>
            {
                if (ShowLineNo)
                    this.InvokeSync(DrawLineNo);
            });
        }

        public SyncRichTextBox OtherTextBox
        {
            get => this.TextBox.OtherTextBox;
            set => this.TextBox.OtherTextBox = value;
        }

        public SyncRichTextBox TextBox { get => this.textBox; }

        public bool ShowLineNo
        {
            get => this.splitContainer1.SplitterDistance == 40;
            set => this.splitContainer1.SplitterDistance = value ? 40 : 0;
        }

        private int firstLine = -1;
        private int lastLine = -1;

        #region 显示行号
        private void DrawLineNo()
        {
            //获得当前坐标信息
            Point p = new Point(0, 0);
            int crntFirstIndex = this.TextBox.GetCharIndexFromPosition(p);
            int crntFirstLine = this.TextBox.GetLineFromCharIndex(crntFirstIndex);
            Point crntFirstPos = this.TextBox.GetPositionFromCharIndex(crntFirstIndex);

            p.Y += this.TextBox.Height;
            int crntLastIndex = this.TextBox.GetCharIndexFromPosition(p);
            int crntLastLine = this.TextBox.GetLineFromCharIndex(crntLastIndex);
            if (this.TextBox.Lines.Length > 0 && this.TextBox.Lines[TextBox.Lines.Length - 1].Length == 0)
            {
                crntLastLine += 1;
                crntLastIndex = this.TextBox.GetFirstCharIndexFromLine(crntLastLine);
            }
            Point crntLastPos = this.TextBox.GetPositionFromCharIndex(crntLastIndex);

            if (firstLine == crntFirstLine && lastLine == crntLastLine)
                return;

            //准备画图
            Graphics g = this.panel.CreateGraphics();
            Font font = new Font(this.TextBox.Font, this.TextBox.Font.Style);
            SolidBrush brush = new SolidBrush(Color.RoyalBlue);

            //刷新画布
            Rectangle rect = this.panel.ClientRectangle;
            brush.Color = this.panel.BackColor;
            g.FillRectangle(brush, 0, 0, this.panel.ClientRectangle.Width, this.panel.ClientRectangle.Height);
            brush.Color = Color.RoyalBlue;

            //绘制行号
            int lineSpace = 0;
            if (crntFirstLine != crntLastLine)
            {
                lineSpace = (crntLastPos.Y - crntFirstPos.Y) / (crntLastLine - crntFirstLine);
            }
            else
            {
                lineSpace = Convert.ToInt32(this.TextBox.Font.Size * 1.6f);
            }
            int brushX = this.panel.ClientRectangle.Width - Convert.ToInt32(font.Size * 4);
            int brushY = crntLastPos.Y + Convert.ToInt32(font.Size * 0.21f);
            for (int i = crntLastLine; i >= 0; i--)
            {
                int bit = Convert.ToInt32(Math.Floor(Math.Log10((i + 1))));
                string no = new string(' ', bit > 4 ? 0 : 4 - bit) + (i + 1).ToString();
                g.DrawString(no, font, brush, brushX, brushY);
                brushY -= lineSpace;
            }
            g.Dispose();
            font.Dispose();
            brush.Dispose();
            firstLine = crntFirstLine; lastLine = crntLastLine;
        }
        #endregion
    }
}
