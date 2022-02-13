using System;
using System.Collections.Generic;
using System.Text;

namespace M5_Lab
{
    class Product : ModuleIF, HasInput
    {
        public double doOperation()
        {
            Form1 form = Form1.getForm();
            return form.getTextBoxNumber() * HasInput.getInput();
        }
    }
}
