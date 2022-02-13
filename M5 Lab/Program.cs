using M5_Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M5_Lab
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class COMP
    {
        ModuleIF newModule;
        string function;

        public COMP(String s)
        {
            function = s;
            OperatorAC factory = new ModuleFactory();
            Console.WriteLine(s);
            newModule = factory.createModule(s);
            Form1 form = Form1.getForm();
            newModule.doOperation(form.getTextBoxNumber());
        }
    }
    class ModuleIF
        {
            public ModuleIF()
        {

        }
            public double doOperation(double d)
            {
                return 0;
            }
        }
        #region
        interface NoInput
        {
            public double doOperation();
        }

        interface TakeInput
        {
            public double doOperation()
            {
                Form form = new Form();
                form.Controls.Add(new Button());
                TextBox textBox = new TextBox();
                form.Controls.Add(textBox);
                return doOperation(double.Parse(textBox.Text));
            }
            public double doOperation(double d);
        }
    #endregion
    abstract class OperatorAC
        {
            abstract public ModuleIF createModule(String s);
        }

    class NoInputFactory : OperatorAC
    {
        public override ModuleIF createModule(string s)
        {
            throw new NotImplementedException();
        }
    }

    class ModuleFactory : OperatorAC
    {
        public override ModuleIF createModule(string s)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = Type.GetType(s);

            Object o = Activator.CreateInstance(type);
            ModuleIF module = (ModuleIF) o;

            return module;
        }
    }

    class Log : ModuleIF
    {
        public double doOperation(double d)
        {
            Form1 form = Form1.getForm();
            return Math.Log(form.getTextBoxNumber());
        }
    }

    class Sum : ModuleIF
    {
        public double doOperation(double d)
        {
            Form1 form = Form1.getForm();
            return d + form.getTextBoxNumber();
        }
    }


    class Subtract : ModuleIF
    {
        public double doOperation(double d)
        {
            Form1 form = Form1.getForm();
            return form.getTextBoxNumber() - d;
        }
    }

    class Initialize : ModuleIF
    {
        public double doOperation(double d)
        {
            Form1 form = Form1.getForm();
            return d;
        }
    }

    class Power : ModuleIF
    {
        public double doOperation(double d)
        {
            Form1 form = Form1.getForm();
            return Math.Pow(form.getTextBoxNumber(), d);
        }
    }

    class Product : ModuleIF
    {
        public double doOperation(double d)
        {
            Form1 form = Form1.getForm();
            return form.getTextBoxNumber() * d;
        }
    }
}