using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace valueEditor
{
    public class OpenFile
    {

        private static OpenFile f = null;
        public OpenFile()
        {
        }

        public static OpenFile GetOpenFile()
        {
            if (f == null)
                f = new OpenFile();
            return f;
        }

        public void readFile(string file, CustomRichTextBox name, CustomRichTextBox value)
        {
            Setting.selectwithother = false;
            string fs = File.ReadAllText(file);
            fs = fs.Replace("\r", "");
            string[] fl = fs.Split('\n');
            name.cstRichTextBox1.Text = "";
            value.cstRichTextBox1.Text = "";

            for (int i = 0; i < fl.Length; i++)
            {
                if (fl[i].Length > 0)
                {
                    String[] tsplit = Splitv(fl[i]);
                    name.cstRichTextBox1.Text += tsplit[0] + "\n";
                    value.cstRichTextBox1.Text += tsplit[1] + "\n";
                }
                else
                {
                    name.cstRichTextBox1.Text += "\n";
                    value.cstRichTextBox1.Text += "\n";
                }
            }
            Setting.selectwithother = true;
        }

        public String[] Splitv(String line)
        {
            string tname = "";
            string tvalue = "";
            char f = '\0';
            foreach (char kw in Setting.splitkw)
            {
                if (line.IndexOf(kw) > -1)
                {
                    f = kw;
                    break;
                }
            }
            foreach (char kw in Setting.nodekw)
            {
                if (line.Trim().IndexOf(kw) == 0)
                {
                    f = '\0';
                    break;
                }
            }
            if (f != '\0')
            {
                tname = line.Substring(0, line.LastIndexOf(f));
                tvalue = line.Substring(line.LastIndexOf(f) + 1);
            }
            else
            {
                tname = line;
                System.Diagnostics.Debug.WriteLine(tname);
            }
            if (tname.Length > 4090)
            {
                tname = tname.Substring(0, 4090);
            }
            if (tvalue.Length > 4090)
            {
                tvalue = tvalue.Substring(0, 4090);
            }
            return new String[] { tname, tvalue };
        }
    }
}
