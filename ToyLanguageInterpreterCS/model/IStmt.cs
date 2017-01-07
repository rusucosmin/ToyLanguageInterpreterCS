using System;

namespace ToyLanguageInterpreterCS.model
{
    public interface IStmt
    {
        string ToString();
        PrgState execute(PrgState prgState);
    }
}
