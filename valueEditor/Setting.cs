using System;
using System.Collections.Generic;
using System.Text;

namespace valueEditor
{
    class Setting
    {
        public List<string> splitkw = new List<string>();
        public List<string> nodekw = new List<string>();
        //public static bool returnwithother = true;
        //public static bool rollwithother = true;
        //public static bool selectwithother = true;
        //public static bool showlineno = true;
        private static Setting s;

        public static bool returnwithother
        {
            set
            {
                mainForm.nameBox.cstRichTextBox1.SyncReturn = value;
                mainForm.valueBox.cstRichTextBox1.SyncReturn = value;
            }
        }
        public static bool rollwithother
        {
            set
            {
                mainForm.nameBox.cstRichTextBox1.SyncRoll = value;
                mainForm.valueBox.cstRichTextBox1.SyncRoll = value;
            }
        }
        public static bool selectwithother
        {
            set
            {
                mainForm.nameBox.cstRichTextBox1.SyncSelect = value;
                mainForm.valueBox.cstRichTextBox1.SyncSelect = value;
            }
        }
        public static bool showlineno
        {
            set
            {
                mainForm.nameBox.ShowLineNo = value;
                mainForm.valueBox.ShowLineNo = value;
            }
        }


        private Setting()
        {
            splitkw.AddRange(new string[] { "=" });
            nodekw.AddRange(new string[] { "#", ";", "/" });
        }

        public static Setting getHandler()
        {
            if (s == null)
                s = new Setting();
            return s;
        }

        public void Setsplit()
        {
            settingForm f = new settingForm(settingForm.mode.split);
            f.ShowDialog();
        }

        public void Setnode()
        {
            settingForm f = new settingForm(settingForm.mode.node);
            f.ShowDialog();
        }
    }
}
