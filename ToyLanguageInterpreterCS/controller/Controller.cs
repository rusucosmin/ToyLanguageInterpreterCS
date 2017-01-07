using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLanguageInterpreterCS.repository;
using ToyLanguageInterpreterCS.model;

namespace ToyLanguageInterpreterCS.controller
{
    public class Controller
    {
        IRepository repo;
        public Controller(IRepository repo)
        {
            this.repo = repo;
        }

        public void setMain(PrgState prgState)
        {
            this.repo.getPrgList().Clear();
            this.repo.getPrgList().Add(prgState);
        }

        public PrgState oneStep(PrgState prgState)
        {
            MyIStack<IStmt> exeStack = prgState.getExeStack();
            if (exeStack.isEmpty())
                throw new Exception("stack is empty");
            return exeStack.pop().execute(prgState);
        }

        public void allSteps()
        {
            PrgState prgState = this.repo.getPrgList().ElementAt(0);
            repo.logPrgStateExec(prgState);
            while(prgState.getExeStack().isEmpty() == false)
            {
                oneStep(prgState);
                repo.logPrgStateExec(prgState);
            }
        }
    }
}
