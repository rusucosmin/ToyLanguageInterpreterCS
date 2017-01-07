using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    public class MyStack<T> : MyIStack<T>
    {
        Stack<T> stk;
        public MyStack(Stack<T> stk)
        {
            this.stk = stk;
        }
        public bool isEmpty()
        {
            return this.stk.Count == 0;
        }

        public T peek()
        {
            return this.stk.Peek();
        }

        public T pop()
        {
            return this.stk.Pop();
        }

        public void push(T el)
        {
            this.stk.Push(el);
        }

        public Stack<T> toStack()
        {
            return this.stk;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.stk.ToList().ForEach(e => sb.Append(e.ToString() + "\n"));
            return sb.ToString();
        }
    }
}
