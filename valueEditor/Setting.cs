using System;
using System.Collections.Generic;
using System.Text;

namespace valueEditor
{
    class Setting
    {
        public static List<char> splitkw = new List<char>();
        public static List<char> nodekw = new List<char>();
        public static bool returnwithother = true;
        public static bool rollwithother = true;
        public static bool selectwithother = true;
        public static bool showlineno = true;
        private static Setting s;

        private Setting()
        {
            splitkw.AddRange(new char[] { '=' });
            nodekw.AddRange(new char[] { '#', ';', '/' });
        }

        public static Setting GetSetting()
        {
            if (s == null)
                s = new Setting();
            return s;
        }

        public void Setsplit()
        {
            Form2 f2 = new Form2("split");
            f2.ShowDialog();
        }

        public void Setnode()
        {
            Form2 f2 = new Form2("node");
            f2.ShowDialog();
        }
    }
}
