using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace valueEditor
{
    public class Content
    {
        string name;
        string value;
        string line;
        string split;

        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }
        public string Line { get => line; set => line = value; }
        public string Split { get => split; set => split = value; }
    }
}
