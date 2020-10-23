using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace BPSTool
{
    class UITools
    {
        private static ResourceManager rmInstance = null;
        static public void textBoxKeyPress_OnlyDigital(ref KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        static public void textBoxKeyPress_OnlyHex(ref KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar) && 
                e.KeyChar != 'a' && e.KeyChar != 'A' &&
                e.KeyChar != 'b' && e.KeyChar != 'B' &&
                e.KeyChar != 'c' && e.KeyChar != 'C' &&
                e.KeyChar != 'd' && e.KeyChar != 'D' &&
                e.KeyChar != 'e' && e.KeyChar != 'E')
            {
                e.Handled = true;
            }
        }

        static private ResourceManager getResourceMng()
        {
            if(null == rmInstance)
            {
                rmInstance = new ResourceManager("BPSTool.ResourceStr", Assembly.GetExecutingAssembly());
            }
            return rmInstance;
        }

        static public String GetString(String name)
        {
            return getResourceMng().GetString(name, System.Threading.Thread.CurrentThread.CurrentUICulture);
        }

        static public String PleaseReferTo(params ToolStripMenuItem[] toolStripMenuItemPath)
        {
            String ret = GetString("StrPleaseReferTo") + ":";
            for(int i = 0; i < toolStripMenuItemPath.Length; i++)
            {
                ret += "\"" + toolStripMenuItemPath[i].Text + "\"";
                if(i != toolStripMenuItemPath.Length - 1)
                {
                    ret += "->";
                }
            }
            return ret;
        }
    }
}
