﻿using MatrixGeneric;
using System.Collections;
using System.Text;

namespace Generic
{
    public struct Matrix<T>
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

        #region Конструкторы

        public Matrix(int i, int j)
        {
            M = new T[i, j];
        }
        public Matrix(T[,] matrix) : this(matrix.GetLength(0), matrix.GetLength(1))
        {
            FillInstance(matrix);
        }
        public Matrix(IMatrix<T>[,] matrix) : this(matrix.GetLength(0), matrix.GetLength(1))
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
                    result[i, j] = (dynamic?)a[i, j] + (dynamic?)b[i, j];
            return result;
        }

        private static Matrix<T> Addition<T>(Matrix<T> a, Matrix<T> b) where T : IMatrix<T>
        {
            if (a.M.GetLength(0) != b.M.GetLength(0) ||
                a.M.GetLength(1) != b.M.GetLength(1)) throw new Exception("Размеры посылаемых матриц не равны");

            Matrix<T> result = new(a.GetLength(0), a.GetLength(1));
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = result[i, j].Add(a[i, j], b[i, j]);
            return result;
        }
        #endregion

        #region operator - вычитание матриц

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            try
            {
                return Subtract<T>(matrix1, matrix2);
            }
            catch
            {
                return ISubtract<T>(matrix1, matrix2);
            }
        }
        private static Matrix<TM> Subtract<TM>(Matrix<TM> a, Matrix<TM> b) where TM : struct
        {
            if (a.M.GetLength(0) != b.M.GetLength(0) ||
                a.M.GetLength(1) != b.M.GetLength(1)) throw new Exception("Размеры посылаемых матриц не равны");

            Matrix<TM> result = new(a.GetLength(0), a.GetLength(1));
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = (dynamic?)a[i, j] - (dynamic?)b[i, j];
            return result;
        }
        private static Matrix<TM> ISubtract<TM>(Matrix<TM> a, Matrix<TM> b) where TM : class, IMatrix<TM>
        {
            if (a.M.GetLength(0) != a.M.GetLength(0) ||
                a.M.GetLength(1) != a.M.GetLength(1)) throw new Exception("Размеры посылаемых матриц не равны");

            Matrix<TM> result = new(a.GetLength(0), a.GetLength(1));
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = result[i, j].Subtract(a.M[i, j], b.M[i, j]);
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
        public void FillInstance(IMatrix<T>[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    this.M[i, j] = (T)matrix[i, j];
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