using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    public class PrgState
    {
        MyIStack<IStmt> exeStack;
        MyIDictionary<string, int> symTable;
        MyIDictionary<int, Tuple<string, TextReader>> fileTable;
        MyIList<int> outList;
        public PrgState(IStmt prg)
        {
            exeStack = new MyStack<IStmt>(new Stack<IStmt>());
            exeStack.push(prg);
            symTable = new MyDictionary<string, int>(new Dictionary<string, int>());
            outList = new MyList<int>(new List<int>());
            fileTable = new MyDictionary<int, Tuple<string, TextReader>>(new Dictionary<int, Tuple<string, TextReader>>());
        }
        public MyIDictionary<string, int> getSymTable()
        {
            return this.symTable;
        }

        public MyIDictionary<int, Tuple<string, TextReader>> getFileTable()
        {
            return this.fileTable;
        }
        public MyIList<int> getOut()
        {
            return this.outList;
        }
        public MyIStack<IStmt> getExeStack()
        { 
            return this.exeStack;
        }
        public override string ToString()
        {
            string ret = "";
            ret += "+++++++++++++PrgState+++++++++++++\n";
            ret += "-------------ExeStack-------------\n";
            ret += this.getExeStack().ToString() +  "\n";
            ret += "-------------SymTable-------------\n";
            ret += this.getSymTable().ToString() +  "\n";
            ret += "--------------Output--------------\n";
            ret += this.getOut().ToString() + "\n";
            ret += "\n";
            return ret;
        }
    }
}
