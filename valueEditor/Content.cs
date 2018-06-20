using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueEditor
{
    public class Content
    {
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
        public string d { get; set; }
        public string e { get; set; }
        public long Line { get; set; }
        public string Name { get => b; set => b = value; }
        public string Value { get => d; set => d = value; }
        public override string ToString()
        {
            return (a ?? "") + (b ?? "") + (c ?? "") + (d ?? "") + (e ?? "");
        }
    }
}
