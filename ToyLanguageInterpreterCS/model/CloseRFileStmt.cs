using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class CloseRFileStmt : IStmt
    {
        private Exp exp;
        public CloseRFileStmt(Exp exp)
        {
            this.exp = exp;
        }

        public override string ToString()
        {
            return "closeRFileStmt(" + this.exp.ToString() + ")";
        }

        public PrgState execute(PrgState state)
        {
            int fd = this.exp.evaluate(state.getSymTable());
            Tuple<String, TextReader> act = state.getFileTable().get(fd);
            if (act == null)
                throw new Exception("FileNotOpened Exception at: " + this.ToString() + "\nThere is no opened file with fd = " + fd);
            act.Item2.Close();
            state.getFileTable().remove(fd);
            return state;
        }
    }
}
