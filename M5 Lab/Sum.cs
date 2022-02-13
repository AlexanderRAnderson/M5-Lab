using System;
using System.Collections.Generic;
using System.Text;

namespace M5_Lab
{
    class Sum : ModuleIF, HasInput
    {
        public double doOperation()
        {
            Form1 form = Form1.getForm();
            return HasInput.getInput() + form.getTextBoxNumber();
        }
    }
}
