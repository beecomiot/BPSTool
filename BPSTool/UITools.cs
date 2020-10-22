﻿using System;
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
        static public void textBoxKeyPress_OnlyDigital(ref KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        static public ResourceManager getResourceMng()
        {
            return new ResourceManager("BPSTool.ResourceStr", Assembly.GetExecutingAssembly());
        }
    }
}
