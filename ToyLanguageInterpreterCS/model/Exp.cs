using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    abstract class Exp
    {
        public abstract int evaluate(MyIDictionary<String, int> symTable);
        public abstract override string ToString();
    }
}
