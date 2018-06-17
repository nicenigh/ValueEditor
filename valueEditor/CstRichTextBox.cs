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
        private  bool syncroll = true;
        private bool syncreturn = true;
        private bool syncselect = true;
        private int s = 0, l = 0, lines = 0;

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

        public bool SyncRoll
        {
            get { return this.syncroll; }

            set { this.syncroll = value; }
        }
        public bool SyncReturn
        {
            get { return this.syncreturn; }

            set { this.syncreturn = value; }
        }
        public bool SyncSelect
        {
            get { return this.syncselect; }

            set { this.syncselect = value; }
        }

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

        #region 同步滚动
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
            if (_otherRichTextBox != null &&
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
            if (this.syncroll)
            {
                m.HWnd = this.Handle;
                WndProc(ref m);
            }
        }
        #endregion

        #region 同步选取
        private void CstRichTextBox_Enter(object sender, EventArgs e)
        {
            lines = this.Text.Split('\n').Length;
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
            if (this.syncselect)
            {
                deColor();
                selColor();
            }
        }

        public void selColor()
        {
            if (_otherRichTextBox != null)
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
        #endregion

        #region 同步换行
        private void CstRichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(this.syncselect)
            {
                int nlines = this.Text.Split('\n').Length;
                if (nlines != lines && _otherRichTextBox != null)
                {
                    if (e.KeyChar == '\r' || e.KeyChar == '\n')
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
                    if (e.KeyChar == '\b')
                    {
                        try
                        {
                            int row = this.GetLineFromCharIndex(this.SelectionStart);
                            int i = _otherRichTextBox.GetFirstCharIndexFromLine(row);
                            int i2 = _otherRichTextBox.GetFirstCharIndexFromLine(row + lines - nlines);
                            _otherRichTextBox.Text = _otherRichTextBox.Text.Substring(0, i) + _otherRichTextBox.Text.Substring(i2);
                        }
                        catch { }
                    }
                    lines = nlines;
                }
            }
        }
        #endregion

    }
}
