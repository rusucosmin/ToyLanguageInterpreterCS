using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class ArithExp : Exp
    {
        public enum Operation {
            ADD,
            SUBTRACT,
            MULTIPLY,
            DIVIDE
        }
        Exp e1, e2;
        Operation op;
        public ArithExp(Operation op, Exp e1, Exp e2)
        {
            this.op = op;
            this.e1 = e1;
            this.e2 = e2;
        }
        public override int evaluate(MyIDictionary<string, int> symTable)
        {
            int x1 = this.e1.evaluate(symTable);
            int x2 = this.e2.evaluate(symTable);
            int ret = x1;
            switch(this.op)
            {
                case Operation.ADD:
                    ret += x2;
                    break;
                case Operation.SUBTRACT:
                    ret -= x2;
                    break;
                case Operation.MULTIPLY:
                    ret *= x2;
                    break;
                case Operation.DIVIDE:
                    ret /= x2;
                    break;
            }
            return ret;
        }

        public override string ToString()
        {
            string ret = this.e1.ToString();
            switch(this.op)
            {
                case Operation.ADD:
                    ret += " + ";
                    break;
                case Operation.SUBTRACT:
                    ret += " - ";
                    break;
                case Operation.MULTIPLY:
                    ret += " * ";
                    break;
                case Operation.DIVIDE:
                    ret += " / ";
                    break;
            }
            ret += this.e2.ToString();
            return ret;
        }
    }
}
