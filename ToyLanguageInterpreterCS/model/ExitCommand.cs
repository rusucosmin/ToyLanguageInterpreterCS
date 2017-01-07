using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
        public class ExitCommand : Command
        {
        public ExitCommand(string key, string description) : base(key, description)
        {
        }

        public override void execute()
        {
            Console.WriteLine("Bye Bye");
            Environment.Exit(0);
        }
        }
}
