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
    }
}
