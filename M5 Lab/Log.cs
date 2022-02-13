using System;
using System.Collections.Generic;
using System.Text;

namespace M5_Lab
{
    class Log : ModuleIF
    {
        public double doOperation()
        {
            Form1 form = Form1.getForm();
            return Math.Log(form.getTextBoxNumber());
        }
    }
}
