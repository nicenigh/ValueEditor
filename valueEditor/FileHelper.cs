using System;
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
        public List<Content> Contents { get; } = new List<Content> { };
        private string splitPattern { get => @"^(?<a>\s*?)(?<b>\S+.*\S+?)(?<c>\s*[" + Settings.Split + @"]\s*?)(?<d>\S+.*\S+?)(?<e>\s*?)$"; }
        private Regex splitRegex;
        private string commentPattern { get => @"^\s*[/\*|\*/|\*|//+]+.*[\*/]*\s*$"; }
        private Regex commentRegex;
        public FileHelper()
        {
            splitRegex = new Regex(splitPattern, RegexOptions.Singleline | RegexOptions.Compiled);
            commentRegex = new Regex(commentPattern, RegexOptions.Singleline | RegexOptions.Compiled);
        }

        public void OpenFile(string path)
        {
            var file = new FileInfo(path);
            if (!file.Exists) return;
            using (MemoryMappedFile mfile = MemoryMappedFile.CreateFromFile(path, FileMode.Open))
            {
                using (MemoryMappedViewStream stream = mfile.CreateViewStream())
                {
                    Read(stream);
                }
            }
        }

        public void Read(Stream stream)
        {
            Contents.Clear();
            using (StreamReader sr = new StreamReader(stream, Settings.Encoding))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains('\0')) continue;
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        try
                        {
                            if (commentRegex.Match(line).Success)
                            {
                                Contents.Add(new Content { Comment = true, Name = line });
                            }
                            else
                            {
                                Match match = splitRegex.Match(line);
                                if (match.Success)
                                {
                                    var c = new Content { };
                                    if (match.Groups.Count < 2)
                                        Contents.Add(new Content { Name = line });
                                    if (match.Groups.Count == 2)
                                        Contents.Add(new Content
                                        {
                                            Name = match.Groups[1].Value,
                                        });
                                    else
                                        Contents.Add(new Content
                                        {
                                            Left = match.Groups.Count > 1 ? match.Groups[1].Value : null,
                                            Name = match.Groups.Count > 2 ? match.Groups[2].Value : null,
                                            Middle = match.Groups.Count > 3 ? match.Groups[3].Value : null,
                                            Value = match.Groups.Count > 4 ? match.Groups[4].Value : null,
                                            Right = match.Groups.Count > 5 ? match.Groups[5].Value : null
                                        });
                                }
                                else
                                    Contents.Add(new Content { Comment = true, Name = line });
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        Contents.Add(new Content { Blank = true, Name = line });
                    }
                }
            }
        }

        public void Reload()
        {
            splitRegex = new Regex(splitPattern, RegexOptions.Singleline | RegexOptions.Compiled);
            commentRegex = new Regex(commentPattern, RegexOptions.Singleline | RegexOptions.Compiled);
            for (var i = 0; i < Contents.Count; i++)
            {
                string line = Contents[i].ToString(); if (line.Contains('\0')) continue;
                if (!string.IsNullOrWhiteSpace(line))
                {
                    try
                    {
                        if (commentRegex.Match(line).Success)
                        {
                            Contents[i] = new Content { Comment = true, Name = line };
                        }
                        else
                        {
                            Match match = splitRegex.Match(line);
                            if (match.Success)
                            {
                                var c = new Content { };
                                if (match.Groups.Count < 2)
                                    Contents[i] = new Content { Name = line };
                                if (match.Groups.Count == 2)
                                    Contents[i] = new Content
                                    {
                                        Name = match.Groups[1].Value,
                                    };
                                else
                                    Contents[i] = new Content
                                    {
                                        Left = match.Groups.Count > 1 ? match.Groups[1].Value : null,
                                        Name = match.Groups.Count > 2 ? match.Groups[2].Value : null,
                                        Middle = match.Groups.Count > 3 ? match.Groups[3].Value : null,
                                        Value = match.Groups.Count > 4 ? match.Groups[4].Value : null,
                                        Right = match.Groups.Count > 5 ? match.Groups[5].Value : null
                                    };
                            }
                            else
                                Contents[i] = new Content { Comment = true, Name = line };
                        }
                    }
                    catch { }
                }
                else
                {
                    Contents[i] = new Content { Blank = true, Name = line };
                }
            }
        }

        public void SaveFile(string path)
        {
            if (File.Exists(path))
                File.Copy(path, path + ".bak", true);
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Settings.Encoding);

            StringBuilder builder = new StringBuilder();
            foreach (var content in Contents)
            {
                builder.AppendLine(content.ToString());
            }
            //开始写入
            sw.Write(builder.ToString());
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

    }
}
