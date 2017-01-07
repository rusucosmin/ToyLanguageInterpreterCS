using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class AssignStmt : IStmt
    {
        String id;
        Exp exp;
        public AssignStmt(String id, Exp exp)
        {
            this.id = id;
            this.exp = exp;
        }
        public PrgState execute(PrgState prgState)
        {
            int val = this.exp.evaluate(prgState.getSymTable());
            prgState.getSymTable().put(id, val);
            return prgState;
        }

        public override string ToString()
        {
            return id + " = " + this.exp.ToString();
        }
    }
}
