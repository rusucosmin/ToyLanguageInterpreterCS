using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class ReadFileStmt : IStmt
    {
        Exp exp;
        string var;
        public ReadFileStmt(Exp exp, string var)
        {
            this.exp = exp;
            this.var = var;
        }
        public PrgState execute(PrgState state)

        {
            int fd = this.exp.evaluate(state.getSymTable());
            Tuple<String, TextReader> br = state.getFileTable().get(fd);
            if (br == null)
                throw new Exception("FileNotOpenedException at: " + this.ToString() + "\nNo such file descriptor: " + fd.ToString());
            String line = br.Item2.ReadLine();
            int val = 0;
            if (line != null)
                val = int.Parse(line);
            state.getSymTable().put(this.var, val);
            return state;
        }

        public override string ToString()
        {
            return "readFileStmt(" + exp.ToString() + ", " + this.var + ")";
        }
    }
}
