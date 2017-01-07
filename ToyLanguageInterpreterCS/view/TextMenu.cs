using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLanguageInterpreterCS.model;

namespace ToyLanguageInterpreterCS.view
{
    class TextMenu
    {
        MyIDictionary<String, Command> cmds;
        public TextMenu(MyIDictionary<String, Command> cmds)
        {
            this.cmds = cmds;
        }
        public void addCommand(Command cmd)
        {
            this.cmds.put(cmd.getKey(), cmd);
        }
        public void printMenu()
        {
            Console.WriteLine("Available commands: ");
            foreach (Command cmd in this.cmds.values())
            {
                String line = String.Format("Command {0}: {1}", cmd.getKey(), cmd.getDescription());
                Console.WriteLine(line);
            }
        }

        public List<String> getCommandList()
        {
            List<String> l = new List<String>();
            foreach (Command cmd in this.cmds.values())
                l.Add(cmd.getDescription());
            return l;
        }

        public void show()
        {
            while (true)
            {
                printMenu();
                Console.WriteLine("Input the command: ");
                Command cmd = cmds.get(Console.ReadLine());
                if (cmd == null)
                {
                    Console.WriteLine("Invalid command");
                    continue;
                }
                cmd.execute();
            }
        }
    }
}
