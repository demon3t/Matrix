using MatrixGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixGeneric
{
    public interface IMatrixOperation<T>
    {
        public T Add(T first, T second);
        public T Subtract(T first, T second);
        public T Multiply(T first, T second);
        public T Divide(T first, T second);
    }
}
