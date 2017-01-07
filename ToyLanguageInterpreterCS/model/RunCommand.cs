using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLanguageInterpreterCS.controller;

namespace ToyLanguageInterpreterCS.model
{
    public class RunExample : Command
    {
        private Controller ctr;
        public RunExample(String key, String desc, Controller ctr) : base(key, desc)
        {
            this.ctr = ctr;
        }
        public override void execute()
        {
            try
            {
                ctr.allSteps();
            }
            catch (Exception exception) { Console.WriteLine(exception.Message); } //here you must treat the exceptions that can not be solved in the controller
        }
    }
}
