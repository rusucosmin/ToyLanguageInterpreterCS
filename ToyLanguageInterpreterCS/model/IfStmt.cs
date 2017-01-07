using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class IfStmt : IStmt
    {
        Exp exp;
        IStmt thenStmt, elseStmt;
        public IfStmt(Exp exp, IStmt thenStmt, IStmt elseStmt)
        {
            this.exp = exp;
            this.thenStmt = thenStmt;
            this.elseStmt = elseStmt;
        }

        public PrgState execute(PrgState prgState)
        {
            MyIStack<IStmt> stk = prgState.getExeStack();
            int val = this.exp.evaluate(prgState.getSymTable());
            if (val != 0)
                stk.push(this.thenStmt);
            else
                stk.push(this.elseStmt);
            return prgState;
        }

        public override string ToString()
        {
            return "if(" + this.exp.ToString() + ") then " + this.thenStmt.ToString() + " else " + this.elseStmt.ToString();
        }
    }
}
