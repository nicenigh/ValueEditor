using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ValueEditor
{
    public partial class SyncRichTextBox : System.Windows.Forms.RichTextBox
    {
        public SyncRichTextBox()
        {
            InitializeComponent();
            this.SelectionChanged += new System.EventHandler(this.SyncRichTextBox_SelectionChanged);
            this.VScroll += new System.EventHandler(this.SyncRichTextBox_VScroll);
            this.TextChanged += new System.EventHandler(this.SyncRichTextBox_TextChanged);
            this.Enter += new System.EventHandler(this.SyncRichTextBox_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SyncRichTextBox_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SyncRichTextBox_KeyPress);
            this.Resize += new System.EventHandler(this.SyncRichTextBox_Resize);
        }

        public bool Sync
        {
            get => SyncScrolll & SyncReturn & SyncSelect;
            set { SyncScrolll = value; SyncReturn = value; SyncSelect = value; }
        }

        public bool SyncScrolll { get; set; } = true;

        public bool SyncReturn { get; set; } = true;

        public bool SyncSelect { get; set; } = true;

        public SyncRichTextBox OtherTextBox { get; set; } = null;

        public event EventHandler DrawLineNo;


        private bool focused { get => this.Focused && OtherTextBox != null; }

        #region 显示行号
        private bool drawLock = false;
        private void SyncRichTextBox_Resize(object sender, EventArgs e)
        {
            RefreshLineNo();
        }
        private void RefreshLineNo()
        {
            if (!drawLock)
                DrawLineNo?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region 同步滚动
        private int scrollStart = 0;
        private void SyncRichTextBox_VScroll(object sender, EventArgs e)
        {
            RefreshLineNo();
            if (this.focused && this.SyncScrolll)
            {
                this.InvokeSync(this.OtherTextBox.Scroll);
            }
        }

        private void Scroll()
        {
            try
            {
                Point p = new Point(0, 0);
                int start = this.OtherTextBox.GetCharIndexFromPosition(p);
                int line = this.OtherTextBox.GetLineFromCharIndex(start);
                int nextLineStart = this.OtherTextBox.GetFirstCharIndexFromLine(line + 1);
                Point nextLinePoint = this.OtherTextBox.GetPositionFromCharIndex(nextLineStart);
                if (nextLinePoint.Y < 10)
                    line += 1;
                int nowStart = this.GetCharIndexFromPosition(p);
                int nowLine = this.GetLineFromCharIndex(nowStart);
                if (nowLine != line)
                {
                    this.scrollStart = this.GetFirstCharIndexFromLine(line);
                    this.Select(this.scrollStart, 0);
                    this.ScrollToCaret();
                }
            }
            catch { }
        }
        #endregion

        #region 同步选取
        private int colorStart = -1;
        private int colorLenght = -1;

        private void SyncRichTextBox_Enter(object sender, EventArgs e)
        {
            if (colorStart > 0 && colorLenght > 0)
                this.InvokeSync(CleanColor);
        }
        private void SyncRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (this.focused && this.SyncSelect)
            {
                this.InvokeSync(this.OtherTextBox.SetColor);
            }
        }

        private void SetColor()
        {
            try
            {
                drawLock = true;
                if (colorStart > -1 && colorLenght > -1)
                {
                    this.Select(colorStart, colorLenght);
                    this.SelectionBackColor = this.BackColor;
                }
                int line = this.OtherTextBox.GetLineFromCharIndex(this.OtherTextBox.SelectionStart);
                colorStart = this.GetFirstCharIndexFromLine(line);
                if (colorStart > this.TextLength || line > this.Lines.Length - 1)
                    return;
                colorLenght = this.Lines[line].Length;
                this.Select(colorStart, colorLenght);
                this.SelectionBackColor = Color.Gold;
                this.SelectionLength = 0;
                drawLock = false;
            }
            catch { }
            Scroll();
        }

        private void CleanColor()
        {
            try
            {
                drawLock = true;
                if (colorStart > -1 && colorLenght > -1)
                {
                    this.Select(colorStart, colorLenght);
                    this.SelectionBackColor = this.BackColor;
                }
                this.SelectionLength = 0;
                colorLenght = -1;
                colorStart = -1;
                drawLock = false;
            }
            catch { }
            Scroll();
        }
        #endregion

        #region 同步换行
        private int lines = 0;
        private bool keyPressing = false;
        private void SyncRichTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshLineNo();
            if (!this.keyPressing)
                this.lines = this.Lines.Length;
        }
        private void SyncRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressing = true;
        }
        private void SyncRichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.focused && this.SyncSelect)
            {
                this.InvokeSync(() => { ChangeLines(e.KeyChar); });
            }
            this.keyPressing = false;
        }

        private void ChangeLines(char key)
        {
            try
            {
                if (key == 26)
                {
                    this.OtherTextBox.Undo();
                }
                int nlines = this.Lines.Length;
                if (nlines != lines)
                {
                    if (key == '\r' || key == '\n')
                    {
                        int line = this.GetLineFromCharIndex(this.SelectionStart);
                        int start = this.OtherTextBox.GetFirstCharIndexFromLine(line);
                        if (this.OtherTextBox.TextLength > 0 && start > -1)
                            this.OtherTextBox.Text = this.OtherTextBox.Text.Insert(start, "\r\n");
                        else
                            this.OtherTextBox.Text += "\r\n";

                    }
                    else if (key == '\b')
                    {
                        int line = this.GetLineFromCharIndex(this.SelectionStart) + 1;
                        int start = this.OtherTextBox.GetFirstCharIndexFromLine(line);
                        int lenght = this.OtherTextBox.GetFirstCharIndexFromLine(line + lines - nlines) - start;
                        if (this.OtherTextBox.TextLength > lenght && start > -1)
                            this.OtherTextBox.Text = this.OtherTextBox.Text.Remove(start, lenght);
                        else
                            this.OtherTextBox.Text = "";
                    }
                    lines = nlines;
                }
            }
            catch { }
        }
        #endregion
    }
}
