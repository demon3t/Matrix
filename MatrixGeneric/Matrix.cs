using MatrixGeneric;
using System.Collections;
using System.Text;

namespace MatrixGeneric
{
    public enum MethodInversion
    {
        Approximations = 0,
        GaussSeidel = 1,
        Triangulation = 2,
    }

    public struct Matrix<T> where T : IMatrixOperation<T>
    {
        private readonly T[,] M;
        public T this[int i, int j]
        {
            get
            {
                if (!CheckInRange(i: i, j: j)) throw new ArgumentOutOfRangeException($"Параметр не в диапазоне массива.");
                return M[i, j];
            }
            set
            {
                if (!CheckInRange(i: i, j: j)) throw new ArgumentOutOfRangeException($"Параметр не в диапазоне массива.");
                M[i, j] = value;
            }
        }

        public static MethodInversion Invers;

        static Matrix()
        {
            Invers = MethodInversion.Triangulation;
        }

        #region Конструкторы

        public Matrix(int i, int j)
        {
            M = new T[i, j];
        }
        public Matrix(T[,] matrix) : this(matrix.GetLength(0), matrix.GetLength(1))
        {
            FillInstance(matrix);
        }
        #endregion

        #region оператор преобразования

        public static implicit operator T[,](Matrix<T> matrix)
        {
            return matrix.M;
        }
        public static implicit operator Matrix<T>(T[,] matrix)
        {
            return new Matrix<T>(matrix);
        }

        #endregion

        #region operator + сложение матриц

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            return Add(matrix1, matrix2);
        }
        public static Matrix<T> Add(Matrix<T> a, Matrix<T> b)
        {
            if (a.M.GetLength(0) != b.M.GetLength(0) ||
                a.M.GetLength(1) != b.M.GetLength(1)) throw new Exception("Размеры посылаемых матриц не равны");

            Matrix<T> result = new(a.GetLength(0), a.GetLength(1));
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j].Add(a[i, j], b[i, j]);
            return result;
        }

        #endregion

        #region operator - вычитание матриц

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            return Subtract(matrix1, matrix2);
        }
        public static Matrix<T> Subtract(Matrix<T> a, Matrix<T> b)
        {
            if (a.M.GetLength(0) != b.M.GetLength(0) ||
                a.M.GetLength(1) != b.M.GetLength(1)) throw new Exception("Размеры посылаемых матриц не равны");

            Matrix<T> result = new(a.GetLength(0), a.GetLength(1));
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j].Subtract(a[i, j], b[i, j]);
            return result;
        }

        #endregion

        #region operator * умножение матриц

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            return Mul(matrix1, matrix2);
        }
        public static Matrix<T> Mul(Matrix<T> a, Matrix<T> b)
        {
            if (a.GetLength(1) != b.GetLength(0))
                throw new IndexOutOfRangeException("Умножение невозможно, не корректные размеры матриц");

            Matrix<T> result = new(a.GetLength(0), b.GetLength(1));
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        if (k == 0) result[i, j] = a[i, j].Multiply(a[i, k], b[k, j]);
                        else result[i, j] = a[i, j].Add(result[i, j], a[i, j].Multiply(a[i, k], b[k, j]));
            return new Matrix<T>(result);
        }

        #endregion

        #region operator ! транспонирование матрицы

        public static Matrix<T> operator !(Matrix<T> matrix1)
        {
            return Transposition(matrix1);
        }
        public static Matrix<T> Transposition(Matrix<T> a)
        {
            Matrix<T> result = new (a.GetLength(1), a.GetLength(0));
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    result[i, j] = a[j, i];
            return new Matrix<T>(result);
        }

        #endregion

        #region operator ^ обращение матрицы

        public static Matrix<T> operator ~(Matrix<T> matrix)
        {
            return Invers switch
            {
                MethodInversion.Triangulation => InversionTriangulation(matrix),
                _ => throw new NotImplementedException(),
            };
        }

        public static Matrix<T> InversionTriangulation(Matrix<T> a)
        {
            var result = new Matrix<T>(a.GetLength(0), a.GetLength(1));

            return new Matrix<T>();
        }

        #endregion

        public bool CheckInRange(int? i = null, int? j = null)
        {
            if (i == null && j == null)
                return false;
            if (i != null && j != null)
                return (i < 0 || i >= M.GetLength(0)) && ((j < 0 || j >= M.GetLength(0))) ? false : true;
            if (i != null)
                return j < 0 || j >= M.GetLength(0) ? false : true;
            else
                return i < 0 || i >= M.GetLength(0) ? false : true;
        }
        private int GetLength(int v)
        {
            return M.GetLength(v);
        }

        public void FillInstance(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    this.M[i, j] = matrix[i, j];
        }

        public override string ToString()
        {
            if (M.GetLength(0) == 0 || M.GetLength(1) == 0) return "null";
            StringBuilder @string = new();
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                    @string.Append(M[i, j].ToString() + " ");
                @string.AppendLine();
            }
            return @string.ToString();
        }

    }

}