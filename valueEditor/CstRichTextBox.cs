using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace valueEditor
{
    public delegate void SendMessage(Message msg);
    public partial class CstRichTextBox : RichTextBox
    {
        public bool isloaded = false;
        private int s = 0, l = 0;

        public const int WM_HSCROLL = 276;
        public const int WM_VSCROLL = 277;
        public const int WM_SETCURSOR = 32;
        public const int WM_MOUSEWHEEL = 522;
        public const int WM_MOUSEMOVE = 512;
        public const int WM_MOUSELEAVE = 675;
        public const int WM_MOUSELAST = 521;
        public const int WM_MOUSEHOVER = 673;
        public const int WM_MOUSEFIRST = 512;
        public const int WM_MOUSEACTIVATE = 33;



        public CstRichTextBox()
        {
            InitializeComponent();
            this.SendMessageEvent += new SendMessage(myRichTextBox1_SendMessageEvent);
        }

        public CstRichTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.SendMessageEvent += new SendMessage(myRichTextBox1_SendMessageEvent);
        }

        #region 设置同步滚动
        private CstRichTextBox otherRichTextBox;
        private CstRichTextBox _otherRichTextBox;
        public CstRichTextBox OtherRichTextBox
        {
            get { return otherRichTextBox; }

            set { otherRichTextBox = value; }
        }

        public event SendMessage SendMessageEvent;
        void myRichTextBox1_SendMessageEvent(Message msg)
        {
            otherRichTextBox.Scroll(msg);
        }
        protected override void WndProc(ref Message m)
        {
            if (isloaded && _otherRichTextBox != null &&
                (m.Msg == WM_HSCROLL
                || m.Msg == WM_VSCROLL
                //|| m.Msg == WM_SETCURSOR
                || m.Msg == WM_MOUSEWHEEL
                //|| m.Msg == WM_MOUSEMOVE
                //|| m.Msg == WM_MOUSELEAVE
                //|| m.Msg == WM_MOUSELAST
                //|| m.Msg == WM_MOUSEHOVER
                //|| m.Msg == WM_MOUSEFIRST
                //|| m.Msg == WM_MOUSEACTIVATE
                ))
            {
                if (SendMessageEvent != null)
                {
                    SendMessageEvent(m);
                }
            }
            base.WndProc(ref m);
        }
        public void Scroll(Message m)
        {
            m.HWnd = this.Handle;
            WndProc(ref m);
        }
        #endregion

        private void CstRichTextBox_Enter(object sender, EventArgs e)
        {
            _otherRichTextBox = otherRichTextBox;
            _otherRichTextBox.deColor();
        }

        private void CstRichTextBox_Leave(object sender, EventArgs e)
        {
            deColor();
            _otherRichTextBox = null;
        }

        private void CstRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            deColor();
            selColor();
        }

        public void selColor()
        {
            if (isloaded && _otherRichTextBox != null)
            {
                try
                {
                    int row = this.GetLineFromCharIndex(this.SelectionStart);
                    s = _otherRichTextBox.GetFirstCharIndexFromLine(row);
                    l = _otherRichTextBox.Lines[row].Length;
                    _otherRichTextBox.SelectionLength = 0;
                    _otherRichTextBox.Select(s, l);
                    _otherRichTextBox.SelectionBackColor = Color.OrangeRed;
                    _otherRichTextBox.SelectionLength = 0;
                }
                catch { }
            }
        }

        private void CstRichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && _otherRichTextBox != null)
            {
                try
                {
                    e.KeyChar = '\n';
                    int row = this.GetLineFromCharIndex(this.SelectionStart);
                    int i = _otherRichTextBox.GetFirstCharIndexFromLine(row);
                    _otherRichTextBox.Text = _otherRichTextBox.Text.Substring(0, i) + '\n' + _otherRichTextBox.Text.Substring(i);
                }
                catch { }
            }
        }

        public void deColor()
        {
            if (_otherRichTextBox != null)
            {
                try
                {
                    _otherRichTextBox.SelectionLength = 0;
                    _otherRichTextBox.Select(s, l);
                    _otherRichTextBox.SelectionBackColor = _otherRichTextBox.BackColor;
                    _otherRichTextBox.SelectionLength = 0;
                }
                catch { }
            }
                
        }
    }
}
