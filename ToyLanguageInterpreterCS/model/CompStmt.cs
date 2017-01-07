using System;

namespace ToyLanguageInterpreterCS.model
{
    public class CompStmt : IStmt
    {
        IStmt first, second;
        public CompStmt(IStmt first, IStmt second)
        {
            this.first = first;
            this.second = second;
        }

        public PrgState execute(PrgState prgState)
        {
            MyIStack<IStmt> stk = prgState.getExeStack();
            stk.push(second);
            stk.push(first);
            return prgState;
        }

        public override string ToString()
        {
            return first.ToString() + "; " + second.ToString();
        }
    }
}
