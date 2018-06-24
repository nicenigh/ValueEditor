using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueEditor
{
    public class Content
    {
        public Content()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            this.Id = BitConverter.ToInt64(buffer, 0);
        }
        public long Id { get; }
        public string Left { get; set; }
        public string Name { get; set; }
        public string Middle { get; set; }
        public string Value { get; set; }
        public string Right { get; set; }
        public bool Comment { get; set; } = false;
        public bool Blank { get; set; } = false;
        public override string ToString()
        {
            return (Left ?? "") + (Name ?? "") + (Middle ?? "") + (Value ?? "") + (Right ?? "");
        }
    }
}
