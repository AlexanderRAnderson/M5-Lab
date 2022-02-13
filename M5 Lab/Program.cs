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

        public COMP(String s)
        {
            OperatorIF factory = new ModuleFactory();
            newModule = factory.createModule(s);
            System.Diagnostics.Debug.WriteLine(newModule);
            Form1 form = Form1.getForm();
            form.setTextBoxNumber(newModule.doOperation());
        }
    }
    interface ModuleIF
        {
            
            public abstract double doOperation();
            
        }
        
    interface OperatorIF
        {
            public ModuleIF createModule(String s);
        }

    class ModuleFactory : OperatorIF
    {
        public ModuleIF createModule(string s)
        { 
            Type type = Type.GetType("M5_Lab." + s);

            Object o = Activator.CreateInstance(type);
            ModuleIF module = (ModuleIF) o;

            return module;
        }
    }

    interface HasInput
    {
        protected static double getInput()
        {
            Form2 form = new Form2();
            DialogResult dialogResult = form.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                TextBox text = (TextBox) form.Controls.Find("textBox1", true).ElementAt(0);
                return double.Parse(text.Text);
            }
            return 0;
        }
    }

    
}