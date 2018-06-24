using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace ValueEditor
{
    public partial class MainForm : Form
    {
        public CustomRichTextBox NameBox { get; private set; }
        public CustomRichTextBox ValueBox { get; private set; }

        private List<Content> TextContents = new List<Content>();

        private FileHelper file;
        private string filePath;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "ValueEditor";
            this.customRichTextBox1.OtherTextBox = this.customRichTextBox2;
            this.customRichTextBox2.OtherTextBox = this.customRichTextBox1;
            NameBox = this.customRichTextBox1;
            ValueBox = this.customRichTextBox2;
            file = new FileHelper();
            var c = new Content { };
            file.Contents.Add(c);
            TextContents.Add(c);
            IntiEncoding();
            NameBox.LinesChanged += LinesChanged;
            ValueBox.LinesChanged += LinesChanged;
        }

        private void LinesChanged(object sender, LinesChangedEventArgs e)
        {
            try
            {
                var TextBox = (CustomRichTextBox)(sender);
                var OtherTextBox = TextBox.OtherTextBox;
                int nlines = TextBox.Lines.Length;
                if (e.ChangedType == LinesChangedType.Add)
                {
                    var c = new Content { };
                    var id = TextContents[e.StartLine].Id;
                    TextContents.Insert(e.StartLine, c);
                    var index = file.Contents.FindIndex(en => en.Id == id);
                    file.Contents.Insert(index, c);
                }
                else if (e.ChangedType == LinesChangedType.Remove)
                {
                    var id = TextContents[e.StartLine].Id;
                    TextContents.RemoveRange(e.StartLine, e.ChangedCount);
                    var index = file.Contents.FindIndex(en => en.Id == id);
                    file.Contents.RemoveRange(index, e.ChangedCount);
                }
            }
            catch { }
        }

        private void IntiEncoding()
        {
            var encodings = (new Dictionary<string, Encoding> { { "ANSI", Encoding.Default }/*, { "ASCII", Encoding.ASCII } */})
            .Concat(
                new string[] { "utf-8", "GB18030"/*, "gb2312"*/, "big5", "shift_jis" }
                .Select(name => Encoding.GetEncodings().FirstOrDefault(en => en.Name == name))
                .ToDictionary(en => en.DisplayName, en => en.GetEncoding())
            );
            foreach (var en in encodings)
            {
                var item = new ToolStripMenuItem(en.Key);
                item.Click += (s, e) =>
                {
                    Settings.Encoding = en.Value;
                    if (!string.IsNullOrEmpty(filePath))
                        this.InvokeSync(() =>
                        {
                            file.OpenFile(filePath);
                            LoadFromContents();
                        });
                };
                this.encoding_toolStrip.DropDownItems.Add(item);
            }
        }

        public void LoadFromContents()
        {
            var contents = file.Contents.AsQueryable();
            if (!Settings.ShowBlank)
                contents = contents.Where(en => !en.Blank);
            if (!Settings.ShowComment)
                contents = contents.Where(en => !en.Comment);
            TextContents.Clear();
            TextContents.AddRange(contents);
            if (Settings.ShowIndent)
                NameBox.Text = string.Join("\n", TextContents.Select(en => en.Left + en.Name));
            else
                NameBox.Text = string.Join("\n", TextContents.Select(en => en.Name));

            ValueBox.Text = string.Join("\n", TextContents.Select(en => en.Value));

            NameBox.Focus();
        }

        public void SaveToContents()
        {
            for (int i = 0; i < TextContents.Count - 1; i++)
            {
                TextContents[i].Name = NameBox.Lines[i];
                TextContents[i].Value = ValueBox.Lines[i];
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.Text = "ValueEditor - " + this.openFileDialog1.SafeFileName;
            filePath = this.openFileDialog1.FileName;
            this.InvokeSync(() =>
            {
                file.OpenFile(filePath);
                LoadFromContents();
            });
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            filePath = saveFileDialog1.FileName;
            this.Text = "ValueEditor - " + new FileInfo(filePath).Name;
            this.InvokeSync(() =>
            {
                SaveToContents();
                file.SaveFile(filePath);
            });
        }

        private void open_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private void exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void save_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToContents();
            if (string.IsNullOrEmpty(filePath))
                this.saveFileDialog1.ShowDialog();
            else
                this.InvokeSync(() =>
                {
                    file.SaveFile(filePath);
                });
        }

        private void saveas_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
        }

        private void close_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filePath = "";
            file.Contents.Clear();
            this.Text = "ValueEditor";
            NameBox.Text = "";
            ValueBox.Text = "";
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            var time = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToString("yyyy-MM-dd");
            string[] lines = new string[] {
                "ValueEditor  v" + version ,
                "by NiceNight" ,
                time
            };
            MessageBox.Show(string.Join("\n", lines));
        }

        private void comment_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.ShowComment = !Settings.ShowComment;
            this.comment_ToolStripMenuItem.Text = Settings.ShowComment ? "隐藏注释行" : "显示注释行";
            SaveToContents();
            LoadFromContents();
        }

        private void blank_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.ShowBlank = !Settings.ShowBlank;
            this.blank_ToolStripMenuItem.Text = Settings.ShowBlank ? "隐藏空白行" : "显示空白行";
            SaveToContents();
            LoadFromContents();
        }

        private void indent_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.ShowIndent = !Settings.ShowIndent;
            this.indent_ToolStripMenuItem.Text = Settings.ShowIndent ? "隐藏缩进" : "显示缩进";
            SaveToContents();
            LoadFromContents();
        }

        private void split_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var split = Settings.Split;
            if (InputBox.Show("设置分隔符", ref split) == DialogResult.OK)
            {
                Settings.Split = split;
                this.InvokeSync(() =>
                {
                    SaveToContents();
                    file.Reload();
                    LoadFromContents();
                });
            }
        }
    }
}
