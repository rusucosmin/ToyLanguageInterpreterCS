using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    public interface MyIList<T>
    {
        void add(T el);
        T get(int index);
        bool remove(T el);
        T remove(int index);
        int size();
        List<T> toList();
        string ToString();
}
}
