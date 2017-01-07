using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLanguageInterpreterCS.model;

namespace ToyLanguageInterpreterCS.repository
{
    public class Repository : IRepository
    {
        List<PrgState> list;
        string log;
        public Repository(string log)
        {
            this.list = new List<PrgState>();
            this.log = log;        }
        public List<PrgState> getPrgList()
        {
            return this.list;
        }

        public void logPrgStateExec(PrgState state)
        {
            File.WriteAllText(this.log, state.ToString());
            Console.WriteLine(state.ToString());
        }

        public void setPrgList(List<PrgState> prgList)
        {
            this.list = prgList;
        }
    }
}
