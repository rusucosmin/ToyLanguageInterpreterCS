using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class ConstExp : Exp
    {
        int val;
        public ConstExp(int val)
        {
            this.val = val;
        }
        public override int evaluate(MyIDictionary<string, int> symTable)
        {
            return this.val;
        }

        public override string ToString()
        {
            return this.val.ToString();
        }
    }
}
