using System;
using System.Drawing;
using System.Windows.Forms;

namespace ValueEditor
{
    public partial class CustomRichTextBox : System.Windows.Forms.RichTextBox
    {
        //同步框
        public bool InSync { get; set; } = true;
        //显示行号
        public bool ShowLineNo { get; set; } = true;
        //本框
        public RichTextBox TextBox { get => this.richTextBox1; }
        //彼框
        public CustomRichTextBox OtherTextBox { get; set; } = null;
        //本框行数改变事件(多线程)
        public event EventHandler<LinesChangedEventArgs> LinesChanged;

        #region override
        public new bool Multiline { get => TextBox.Multiline; set => TextBox.Multiline = value; }
        public new int MaxLength { get => TextBox.MaxLength; set => TextBox.MaxLength = value; }
        public new Font Font { get => TextBox.Font; set => TextBox.Font = value; }
        public new Color ForeColor { get => TextBox.ForeColor; set => TextBox.ForeColor = value; }
        public new int TextLength { get => TextBox.TextLength; }
        public new string Text { get => TextBox.Text; set => TextBox.Text = value; }
        public new string[] Lines { get => TextBox.Lines; set => TextBox.Lines = value; }
        public new string SelectedText { get => TextBox.SelectedText; set => TextBox.SelectedText = value; }
        public new int SelectionStart { get => TextBox.SelectionStart; set => TextBox.SelectionStart = value; }
        public new int SelectionLength { get => TextBox.SelectionLength; set => TextBox.SelectionLength = value; }
        public new Color SelectionBackColor { get => TextBox.SelectionBackColor; set => TextBox.SelectionBackColor = value; }
        public new void Select(int start, int length) { TextBox.Select(start, length); }
        public new void SelectAll() { TextBox.SelectAll(); }
        public new void Undo() { TextBox.Undo(); }
        public new void Redo() { TextBox.Redo(); }
        public new int GetCharIndexFromPosition(Point pt) { return TextBox.GetCharIndexFromPosition(pt); }
        public new int GetLineFromCharIndex(int index) { return TextBox.GetLineFromCharIndex(index); }
        public new Point GetPositionFromCharIndex(int index) { return TextBox.GetPositionFromCharIndex(index); }
        public new char GetCharFromPosition(Point pt) { return TextBox.GetCharFromPosition(pt); }
        public new int GetFirstCharIndexFromLine(int lineNumber) { return TextBox.GetFirstCharIndexFromLine(lineNumber); }
        public new int GetFirstCharIndexOfCurrentLine() { return TextBox.GetFirstCharIndexOfCurrentLine(); }
        public new void ScrollToCaret() { TextBox.ScrollToCaret(); }
        //public new event EventHandler VScroll { add => TextBox.VScroll += value; remove => TextBox.VScroll -= value; }
        //public new event MouseEventHandler MouseClick { add => TextBox.MouseClick += value; remove => TextBox.MouseClick -= value; }
        //public new event EventHandler SelectionChanged { add => TextBox.SelectionChanged += value; remove => TextBox.SelectionChanged -= value; }
        //public new event EventHandler Click { add => TextBox.Click += value; remove => TextBox.Click -= value; }
        //public new event EventHandler GotFocus { add => TextBox.GotFocus += value; remove => TextBox.GotFocus -= value; }
        //public new event EventHandler LostFocus { add => TextBox.LostFocus += value; remove => TextBox.LostFocus -= value; }
        //public new event EventHandler Enter { add => TextBox.Enter += value; remove => TextBox.Enter -= value; }
        //public new event EventHandler Leave { add => TextBox.Leave += value; remove => TextBox.Leave -= value; }

        public new bool Focused { get => TextBox.Focused && (OtherTextBox ?? throw new Exception("OtherTextBox Undefined")) != null; }
        #endregion
        public CustomRichTextBox()
        {
            InitializeComponent();
            this.ScrollBars = RichTextBoxScrollBars.None;
            this.Enter += (s, e) => { TextBox.Focus(); };
            this.GotFocus += (s, e) => { TextBox.Focus(); };
            TextBox.SelectionChanged += new System.EventHandler(richTextBox_SelectionChanged);
            TextBox.VScroll += new System.EventHandler(richTextBox_VScroll);
            TextBox.TextChanged += new System.EventHandler(richTextBox_TextChanged);
            TextBox.Enter += new System.EventHandler(richTextBox_Enter);
            TextBox.Leave += new System.EventHandler(richTextBox_Leave);
            TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(richTextBox_KeyDown);
            TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(richTextBox_KeyPress);
            TextBox.Resize += new System.EventHandler(richTextBox_Resize);
        }
        //触发本框行数改变事件(多线程)
        private void OnLinesChanged(LinesChangedEventArgs e)
        {
            this.InvokeSync(() => { LinesChanged?.Invoke(this, e); });
        }

        #region 显示行号
        //本框上次刷新行号范围
        private int firstLine = -1;
        private int lastLine = -1;
        private void richTextBox_Resize(object sender, EventArgs e)
        {
            if (ShowLineNo)
                DrawLineNo();
        }
        private void DrawLineNo()
        {
            this.InvokeSync(() =>
            {
                //获得当前坐标信息
                Point p = new Point(0, 0);
                int crntFirstIndex = TextBox.GetCharIndexFromPosition(p);
                int crntFirstLine = TextBox.GetLineFromCharIndex(crntFirstIndex);
                Point crntFirstPos = TextBox.GetPositionFromCharIndex(crntFirstIndex);

                p.Y += TextBox.Height;
                int crntLastIndex = TextBox.GetCharIndexFromPosition(p);
                int crntLastLine = TextBox.GetLineFromCharIndex(crntLastIndex);
                if (TextBox.Lines.Length > 0 && TextBox.Lines[TextBox.Lines.Length - 1].Length == 0)
                {
                    crntLastLine += 1;
                    crntLastIndex = TextBox.GetFirstCharIndexFromLine(crntLastLine);
                }
                Point crntLastPos = TextBox.GetPositionFromCharIndex(crntLastIndex);

                if (firstLine == crntFirstLine && lastLine == crntLastLine)
                    return;

                //准备画图
                Graphics g = panel1.CreateGraphics();
                Font font = new Font(TextBox.Font, TextBox.Font.Style);
                SolidBrush brush = new SolidBrush(Color.RoyalBlue);

                //刷新画布
                Rectangle rect = panel1.ClientRectangle;
                brush.Color = panel1.BackColor;
                g.FillRectangle(brush, 0, 0, panel1.ClientRectangle.Width, panel1.ClientRectangle.Height);
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
                int brushX = panel1.ClientRectangle.Width - Convert.ToInt32(font.Size * 4);
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
            });
        }
        #endregion


        #region 同步滚动
        private void richTextBox_VScroll(object sender, EventArgs e)
        {
            if (ShowLineNo)
                DrawLineNo();
            if (Focused && InSync && !selecting)
                OtherTextBox.Scroll();
        }
        private void Scroll()
        {
            this.InvokeSync(() =>
            {
                try
                {
                    Point p = new Point(0, 0);
                    int start = OtherTextBox.GetCharIndexFromPosition(p);
                    int line = OtherTextBox.GetLineFromCharIndex(start);
                    int nextLineStart = OtherTextBox.GetFirstCharIndexFromLine(line + 1);
                    Point nextLinePoint = OtherTextBox.GetPositionFromCharIndex(nextLineStart);
                    if (nextLinePoint.Y < 10)
                        line += 1;
                    int currStart = TextBox.GetCharIndexFromPosition(p);
                    int currLine = TextBox.GetLineFromCharIndex(currStart);
                    int scrollStart = TextBox.GetFirstCharIndexFromLine(line);
                    Point currPoint = TextBox.GetPositionFromCharIndex(scrollStart);
                    if ((scrollStart > -1 && scrollStart < TextBox.TextLength) && (currLine != line || currPoint.Y != 0))
                    {
                        TextBox.SelectionStart = scrollStart;
                        TextBox.ScrollToCaret();
                    }
                }
                catch { }
            });
        }
        #endregion

        #region 同步选取
        //本框高亮行号
        private int colorLine = -1;
        //本框正在设置高亮中
        private bool selecting = false;
        private void richTextBox_Leave(object sender, EventArgs e)
        {
            if (colorLine > 0)
                CleanColor();
        }
        private void richTextBox_Enter(object sender, EventArgs e)
        {
            if (colorLine > 0)
                CleanColor();
        }
        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (Focused && InSync && !selecting)
            {
                SetColor();
                OtherTextBox.SetColor();
                OtherTextBox.Scroll();
            }
        }

        //设置本框/彼框高亮
        private void SetColor()
        {
            this.InvokeSync(() =>
            {
                try
                {
                    selecting = true;
                    int backStart = TextBox.SelectionStart;
                    int backLenght = TextBox.SelectionLength;
                    Point p = new Point(0, 0);
                    int pStart = TextBox.GetCharIndexFromPosition(p);
                    int line;
                    if (Focused)
                        line = TextBox.GetLineFromCharIndex(TextBox.SelectionStart);
                    else
                        line = OtherTextBox.GetLineFromCharIndex(OtherTextBox.SelectionStart);
                    if (line == colorLine || line < 0 || line > TextBox.Lines.Length - 1) { selecting = false; return; }
                    if (colorLine > -1 && colorLine < TextBox.Lines.Length)
                    {
                        TextBox.SelectionStart = TextBox.GetFirstCharIndexFromLine(colorLine);
                        TextBox.SelectionLength = TextBox.Lines[colorLine].Length;
                        TextBox.SelectionBackColor = TextBox.BackColor;
                    }
                    int start = TextBox.GetFirstCharIndexFromLine(line);
                    int lenght = TextBox.Lines[line].Length;
                    TextBox.SelectionStart = start;
                    TextBox.SelectionLength = lenght;
                    if (Focused)
                        TextBox.SelectionBackColor = Color.SkyBlue;
                    else
                        TextBox.SelectionBackColor = Color.Gold;
                    colorLine = line;
                    int nStart = TextBox.GetCharIndexFromPosition(p);
                    if (nStart != pStart)
                    {
                        TextBox.SelectionStart = pStart;
                        TextBox.ScrollToCaret();
                    }
                    TextBox.SelectionStart = backStart;
                    TextBox.SelectionLength = backLenght;
                }
                catch { }
                selecting = false;
            });
        }

        //清楚本框的高亮
        private void CleanColor()
        {
            try
            {
                if (colorLine > -1)
                {
                    selecting = true;
                    int backStart = TextBox.SelectionStart;
                    int backLenght = TextBox.SelectionLength;
                    TextBox.SelectionStart = TextBox.GetFirstCharIndexFromLine(colorLine);
                    TextBox.SelectionLength = TextBox.Lines[colorLine].Length;
                    TextBox.SelectionBackColor = TextBox.BackColor;
                    TextBox.SelectionStart = backStart;
                    TextBox.SelectionLength = backLenght;
                    colorLine = -1;
                }
            }
            catch { }
            selecting = false;
        }
        #endregion

        #region 同步换行
        //本框目前行数
        private int lines = 0;
        //本框正在按下的键
        private Keys keyPressing = Keys.KeyCode;
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ShowLineNo)
                DrawLineNo();
            if (TextBox.Lines.Length != lines)
                SyncLines(keyPressing);
        }
        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            keyPressing = e.KeyCode;
            if (Focused && InSync)
            {
                if (e.Control && e.KeyCode == Keys.Z)
                    OtherTextBox.Undo();
            }
        }
        private void richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressing = Keys.KeyCode;
        }

        //同步彼框的行数
        private void SyncLines(Keys key)
        {
            this.InvokeSync(() =>
            {
                try
                {
                    if (key == Keys.KeyCode)
                    {
                    }
                    else if (key == Keys.Enter)
                    {
                        int line = TextBox.GetLineFromCharIndex(TextBox.SelectionStart);
                        this.OnLinesChanged(new LinesChangedEventArgs { StartLine = line, ChangedType = LinesChangedType.Add, ChangedCount = 1 });
                        int start = OtherTextBox.GetFirstCharIndexFromLine(line);
                        if (OtherTextBox.TextLength > 0 && start > -1)
                            OtherTextBox.Text = OtherTextBox.Text.Insert(start, "\n");
                        else
                            OtherTextBox.Text += "\n";
                    }
                    else if (key == Keys.Back || key == Keys.Delete)
                    {
                        int line = TextBox.GetLineFromCharIndex(TextBox.SelectionStart) + 1;
                        int count = lines - TextBox.Lines.Length;
                        this.OnLinesChanged(new LinesChangedEventArgs { StartLine = line, ChangedType = LinesChangedType.Remove, ChangedCount = count });
                        int start = OtherTextBox.GetFirstCharIndexFromLine(line) - 1;
                        int lenght = 1;
                        for (; count > 0; count--)
                        {
                            lenght += OtherTextBox.Lines[line + count - 1].Length;
                        }
                        if (OtherTextBox.TextLength > lenght && start > -1)
                            OtherTextBox.Text = OtherTextBox.Text.Remove(start, lenght);
                        else
                            OtherTextBox.Text = "";
                    }
                }
                catch { }
                lines = TextBox.Lines.Length;
                keyPressing = Keys.KeyCode;
            });
        }
        #endregion
    }
}
