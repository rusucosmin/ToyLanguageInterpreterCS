using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    public interface MyIStack<T>
    {
        void push(T el);
        T pop();
        T peek();
        bool isEmpty();
        Stack<T> toStack();
        string ToString();
    }
}
