using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueEditor
{
    public class Settings
    {
        public static bool ShowBlank { get; set; } = false;

        public static bool ShowComment { get; set; } = false;

        public static bool ShowIndent { get; set; } = false;

        public static Encoding Encoding { get; set; } = Encoding.Default;

        public static string Split { get; set; } = "=";
    }
}
