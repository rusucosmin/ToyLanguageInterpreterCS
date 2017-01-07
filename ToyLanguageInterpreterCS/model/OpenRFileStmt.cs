using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class OpenRFileStmt : IStmt
    {
        private static int fd = 2;
        string varId, fileName;
        public OpenRFileStmt(String varId, String fileName)
        {
            this.varId = varId;
            this.fileName = fileName;
        }
        public PrgState execute(PrgState prgState)
        {
            var fileTable = prgState.getFileTable();
            foreach(Tuple<string, TextReader> act in fileTable.values())
                if (act.Item1 == this.fileName)
                    throw new Exception("already opened wtf?");
            TextReader t = File.OpenText(this.fileName);
            int actFd = ++ OpenRFileStmt.fd; /// static variable
            prgState.getFileTable().put(actFd, new Tuple<String, TextReader>(this.fileName, t));
            prgState.getSymTable().put(this.varId, actFd);
            return prgState;
        }

        public override string ToString()
        {
            return "openRFile(" + varId + ", " + this.fileName + ")";
        }
    }
}
