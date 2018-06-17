using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace valueEditor
{
    public class Class1
    {
        public List<char> splitkw = new List<char>();
        public List<char> nodekw = new List<char>();

        public string sname;
        public string svalue;

        public Class1()
        {
            splitkw.AddRange(new char[] { '=' });
            nodekw.AddRange(new char[] { '#', ';', '/' });
        }
        public void readFile(string file)
        {
            string fs = File.ReadAllText(file);
            fs = fs.Replace("\r", "");
            string[] fl = fs.Split('\n');
            string tname;
            string tvalue;
            char f;
            sname = "";
            svalue = "";

            for (int i = 0; i < fl.Length; i++)
            {
                tname = "";
                tvalue = "";
                f = '\0';
                if (fl[i].Length > 0)
                {
                    foreach(char kw in splitkw)
                    {
                        if (fl[i].IndexOf(kw) > -1)
                        {
                            f = kw;
                            break;
                        }
                    }
                    foreach (char kw in nodekw)
                    {
                        if (fl[i].Trim().IndexOf(kw) == 0)
                        {
                            f = '\0';
                            break;
                        }
                    }
                    if (f != '\0')
                    {
                        tname = fl[i].Substring(0, fl[i].LastIndexOf(f));
                        tvalue = fl[i].Substring(fl[i].LastIndexOf(f) + 1);
                    }
                    else
                    {
                        tname = fl[i];
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
                    sname += tname + "\n";
                    svalue += tvalue + "\n";
                }
                else
                {
                    sname += tname + "\n";
                    svalue += tvalue + "\n";
                }
            }
        }
    }
}
