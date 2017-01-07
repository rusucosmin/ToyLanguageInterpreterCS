using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class VarExp : Exp
    {
        string id;
        public VarExp(string id)
        {
            this.id = id;
        }
        public override int evaluate(MyIDictionary<string, int> symTable)
        {
            return symTable.get(id);            
        }

        public override string ToString()
        {
            return this.id;
        }
    }
}
