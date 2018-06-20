using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueEditor
{
    public class Settings
    {
        public static bool Sync
        {
            get => MainForm.nameBox.TextBox.Sync & MainForm.valueBox.TextBox.Sync;
            set { MainForm.nameBox.TextBox.Sync = value; MainForm.valueBox.TextBox.Sync = value; }
        }

    }
}
