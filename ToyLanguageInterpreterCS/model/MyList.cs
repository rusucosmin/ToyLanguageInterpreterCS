using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class MyList<T> : MyIList<T>
    {
        List<T> list;
        public MyList(List<T> list){
            this.list = list;
        }
        public void add(T el)
        {
            this.list.Add(el);
        }

        public T get(int index)
        {
            return this.list.ElementAt(index);
        }

        public T remove(int index)
        {
            T el = this.list.ElementAt(index);
            this.list.RemoveAt(index);
            return el;
        }

        public bool remove(T el)
        {
            return this.list.Remove(el);
        }

        public int size()
        {
            return this.list.Count;
        }

        public List<T> toList()
        {
            return this.list;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.list.ForEach(e => sb.Append(e.ToString() + "\n"));
            return sb.ToString();
        }
    }
}
