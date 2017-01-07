using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLanguageInterpreterCS.model;

namespace ToyLanguageInterpreterCS.repository
{
    public interface IRepository
    {
        List<PrgState> getPrgList();
        void logPrgStateExec(PrgState state);
        void setPrgList(List<PrgState> prgList);
    }
}
