using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixGeneric
{
    public interface IMatrix<T>
    {
        public T Add(T obj, T obj1);
        public T Subtract(T obj, T obj1);
        public T Multiply(T obj, T obj1);
        public T Divide(T obj, T obj1);
    }
}
