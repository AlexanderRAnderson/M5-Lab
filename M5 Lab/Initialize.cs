using System;
using System.Collections.Generic;
using System.Text;

namespace M5_Lab
{
    class Initialize : ModuleIF, HasInput
    {
        public double doOperation()
        {
            return HasInput.getInput();
        }
    }
}
