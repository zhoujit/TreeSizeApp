using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeSizeApp
{
    class MsgHelper
    {
        public static void ShowMessage(string message, string caption = "TreeSize")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }

        public static void ShowException(Exception ex)
        {
            List<string> messages = new List<string>();
            messages.Add(ex.Message);
            messages.Add(ex.StackTrace);

            ShowMessage(string.Join("\r\n", messages));
        }
    }
}
