using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace valueEditor
{
    public class FileHelper
    {

        private static FileHelper f = null;
        private Setting s = Setting.getHandler();

        private CstRichTextBox nameBox;
        private CstRichTextBox valueBox;
        private List<Content> lines;

        private string path;

        private FileHelper()
        {
        }

        public static FileHelper getHandler()
        {
            if (f == null)
                f = new FileHelper();
            return f;
        }

        public void setTextBox(CstRichTextBox name, CstRichTextBox value)
        {
            this.nameBox = name;
            this.valueBox = value;
        }

        public void read(string path)
        {
            this.path = path;
            lines = new List<Content>();
            Setting.selectwithother = false;
            nameBox.Text = "";
            valueBox.Text = "";

            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var split = splitValue(line);
                lines.Add(split);
                nameBox.Text += split.Name + "\n";
                valueBox.Text += split.Value + "\n";
            }

            Setting.selectwithother = true;
        }

        public void save()
        {
            File.Copy(path, path + ".bak");
            File.Delete(path);
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            string line;
            for (int i = 0; i < nameBox.Lines.Length; i++)
            {
                line = nameBox.Lines[i];
                if (valueBox.Lines[i] != "")
                {
                    line += lines[i].Split + valueBox.Lines[i];
                }
                sw.WriteLine(line);
            }
            sw.Write("Hello World!!!!");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }


        public Content splitValue(string line)
        {
            string name = line;
            string value = "";
            if (line.Trim().Length == 0)
            {
                return new Content { Name = name, Value = value, Split = "", Line = line };
            }
            foreach (var kw in s.nodekw)
            {
                if (line.Trim().IndexOf(kw) == 0)
                {
                    return new Content { Name = name, Value = value, Split = "", Line = line };
                }
            }
            foreach (var kw in s.splitkw)
            {
                if (line.IndexOf(kw) > -1)
                {
                    name = line.Substring(0, line.LastIndexOf(kw));
                    value = line.Substring(line.LastIndexOf(kw) + kw.Length);
                    return new Content { Name = name, Value = value, Split = kw, Line = line };
                }
            }
            return new Content { Name = name, Value = value, Split = "", Line = line };
        }

    }
}
