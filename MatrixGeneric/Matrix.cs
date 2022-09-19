using MatrixGeneric;
using System.Text;

namespace demon_3tt
{
    public struct Matrix<T>
        where T : IMatrix<T>
    {
        private readonly T[,] M;
        public T this[int i, int j]
        {
            get { return M[i, j]; }
            set { M[i, j] = value; }
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

        #region Операторы преобразования

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
            return Addition(matrix1, matrix2);
        }
        private static Matrix<T> Addition(Matrix<T> a, Matrix<T> b)
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
        private static Matrix<T> Subtract(Matrix<T> a, Matrix<T> b)
        {
            if (a.M.GetLength(0) != b.M.GetLength(0) ||
                a.M.GetLength(1) != b.M.GetLength(1)) throw new Exception("Размеры посылаемых матриц не равны");

            Matrix<T> result = new (a.GetLength(0), a.GetLength(1));
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        result[i, j] = a[i, j].Subtract(a[i, j], b[i, j]);
            return result;
        }

        #endregion

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
        public override string ToString() // реализовано
        {
            StringBuilder @string = new();
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                    @string.Append(M[i, j]?.ToString() + " ");
                @string.AppendLine();
            }
            return @string.ToString();
        }
    }
}