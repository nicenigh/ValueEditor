using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace valueEditor
{
    public partial class CustomRichTextBox : UserControl
    {
        public CustomRichTextBox()
        {
            InitializeComponent();
        }

        #region 设置字体大小
        [Description("设置字体大小")]
        private Font _font = new Font("宋体", 9);
        public Font CustomFont
        {
            get { return cstRichTextBox1.Font; }
            set
            {
                if (value != null)
                {
                    cstRichTextBox1.Font = value;
                    panel1.Font = value;
                }
                else
                {
                    cstRichTextBox1.Font = _font;
                    panel1.Font = _font;
                }
            }
        }
        #endregion

        public valueEditor.CstRichTextBox OtherRichTextBox
        {
            get { return this.cstRichTextBox1.OtherRichTextBox; }

            set { this.cstRichTextBox1.OtherRichTextBox = value; }
        }

        private void showLineNo()
        {
            //获得当前坐标信息
            Point p = new Point(0, 0);
            int crntFirstIndex = this.cstRichTextBox1.GetCharIndexFromPosition(p);
            int crntFirstLine = this.cstRichTextBox1.GetLineFromCharIndex(crntFirstIndex);
            Point crntFirstPos = this.cstRichTextBox1.GetPositionFromCharIndex(crntFirstIndex);
            
            p.Y += this.cstRichTextBox1.Height;
            int crntLastIndex = this.cstRichTextBox1.GetCharIndexFromPosition(p);
            int crntLastLine = this.cstRichTextBox1.GetLineFromCharIndex(crntLastIndex);
            Point crntLastPos = this.cstRichTextBox1.GetPositionFromCharIndex(crntLastIndex);
            //准备画图
            Graphics g = this.panel1.CreateGraphics();
            Font font = new Font(this.cstRichTextBox1.Font, this.cstRichTextBox1.Font.Style);
            SolidBrush brush = new SolidBrush(Color.RoyalBlue);

            //刷新画布
            Rectangle rect = this.panel1.ClientRectangle;
            brush.Color = this.panel1.BackColor;
            g.FillRectangle(brush, 0, 0, this.panel1.ClientRectangle.Width, this.panel1.ClientRectangle.Height);
            brush.Color = Color.RoyalBlue;

            //绘制行号
            int lineSpace = 0;
            if (crntFirstLine != crntLastLine)
            {
                lineSpace = (crntLastPos.Y - crntFirstPos.Y) / (crntLastLine - crntFirstLine);
            }
            else
            {
                lineSpace = (int)(Convert.ToInt32(this.cstRichTextBox1.Font.Size) * 1.6);
            }
            int brushX = this.panel1.ClientRectangle.Width - Convert.ToInt32(font.Size * 3);
            int brushY = crntLastPos.Y + Convert.ToInt32(font.Size * 0.21f);
            for (int i = crntLastLine; i >= 0; i--)
            {
                g.DrawString((i + 1).ToString(), font, brush, brushX, brushY);
                brushY -= lineSpace;
            }
            g.Dispose();
            font.Dispose();
            brush.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            showLineNo();
        }

        private void cstRichTextBox1_TextChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void cstRichTextBox1_VScroll(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void cstRichTextBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void cstRichTextBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cstRichTextBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
