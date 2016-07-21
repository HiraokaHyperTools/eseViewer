using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace eseViewer {
    class WPUt {
        internal static void Center(Form child, Form parent) {
            Rectangle rc = Screen.GetWorkingArea(parent);
            child.Left = Math.Min(rc.Right - child.Width, Math.Max(rc.Left, parent.Left + parent.Width / 2 - child.Width / 2));
            child.Top = Math.Min(rc.Bottom - child.Height, Math.Max(rc.Top, parent.Top + parent.Height / 2 - child.Height / 2));
            child.StartPosition = FormStartPosition.Manual;
        }
    }
}
