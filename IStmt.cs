using System;

namespace model
{
    public interface IStmt
    {
        public void toString();
        public PrgState execute(PrgState prgState);
    }
}
