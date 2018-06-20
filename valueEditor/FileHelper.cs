using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ValueEditor
{
    public class FileHelper
    {
        public List<Content> Contents { get; private set; } = new List<Content>();

        public void Read(string path)
        {
            Contents.Clear();
            using (MemoryMappedFile file = MemoryMappedFile.CreateFromFile(path, FileMode.Open))
            {
                MainForm.nameBox.TextBox.Text = "";
                MainForm.valueBox.TextBox.Text = "";
                MainForm.nameBox.TextBox.Sync = false;
                MainForm.valueBox.TextBox.Sync = false;

                string pattern = @"^(?<a>\s*?)(?<b>.+?)(?<c>\s*=\s*?)(?<d>.+?)(?<e>\s*?)$";
                Regex regex = new Regex(pattern, RegexOptions.Singleline);
                long lineno = 0;

                using (MemoryMappedViewStream stream = file.CreateViewStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Match match = regex.Match(line);
                            if (match.Success)
                            {
                                Contents.Add(new Content { Line = lineno, a = match.Groups["a"].Value, b = match.Groups["b"].Value, c = match.Groups["c"].Value, d = match.Groups["d"].Value, e = match.Groups["e"].Value });
                            }
                            else
                            {
                                Contents.Add(new Content { Line = lineno, Name = line, Value = "" });
                            }
                            lineno++;
                        }
                    }
                }
            }
            MainForm.nameBox.TextBox.Text = string.Join("\r\n", Contents.Select(en => en.b));
            MainForm.valueBox.TextBox.Text = string.Join("\r\n", Contents.Select(en => en.d));

            MainForm.nameBox.TextBox.Sync = true;
            MainForm.valueBox.TextBox.Sync = true;
        }


        public void Save(string path)
        {
            File.Copy(path, path + ".bak");
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Contents.Count - 1; i++)
            {
                var content = Contents[i];
                content.Name = MainForm.nameBox.TextBox.Lines[i];
                content.Value = MainForm.valueBox.TextBox.Lines[i];
                builder.AppendLine(content.ToString());
            }
            sw.Write(builder.ToString());
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

    }
}
