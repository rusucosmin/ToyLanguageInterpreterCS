using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class PrintStmt : IStmt
    {
        Exp exp;
        public PrintStmt(Exp exp)
        {
            this.exp = exp;
        }
        public PrgState execute(PrgState prgState)
        {
            prgState.getOut().add(exp.evaluate(prgState.getSymTable()));
            return prgState;
        }

        public override string ToString()
        {
            return "print(" + this.exp.ToString() + ")";
        }
    }
}
