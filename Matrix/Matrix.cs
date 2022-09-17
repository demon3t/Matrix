using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace demon_3t
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct Matrix : ICloneable, IComparable<Matrix>, IComparable, IEquatable<Matrix>
    {
        [FieldOffset(0)]
        readonly dynamic m;

        #region Конструкторы

        /// <summary>
        /// Конструктор, кторый принимает тип матрицы: byte[,] (System.Byte[,]).
        /// </summary>
        /// <param name="input"> Матрица данных. </param>
        public Matrix(byte[,] input) : this()
        {
            m = input;
        }
        /// <summary>
        /// Конструктор, кторый принимает тип матрицы: short[,] (System.Int16[,]).
        /// </summary>
        /// <param name="input"> Матрица данных. </param>
        public Matrix(short[,] input) : this()
        {
            m = input;
        }
        /// <summary>
        /// Конструктор, кторый принимает тип матрицы: int[,] (System.Int32[,]).
        /// </summary>
        /// <param name="input"> Матрица данных. </param>
        public Matrix(int[,] input) : this()
        {
            m = input;
        }
        /// <summary>
        /// Конструктор, кторый принимает тип матрицы: long[,] (System.Int64[,]).
        /// </summary>
        /// <param name="input"> Матрица данных. </param>
        public Matrix(long[,] input) : this()
        {
            m = input;
        }
        /// <summary>
        /// Конструктор, кторый принимает тип матрицы: float[,] (System.Single[,]).
        /// </summary>
        /// <param name="input"> Матрица данных. </param>
        public Matrix(float[,] input) : this()
        {
            m = input;
        }
        /// <summary>
        /// Конструктор, кторый принимает тип матрицы: double[,] (System.Double[,]).
        /// </summary>
        /// <param name="input"> Матрица данных. </param>
        public Matrix(double[,] input) : this()
        {
            m = input;
        }
        /// <summary>
        /// Конструктор, кторый принимает тип матрицы: decimal[,] (System.Decimal[,]).
        /// </summary>
        /// <param name="input"> Матрица данных. </param>
        public Matrix(decimal[,] input) : this()
        {
            m = input;
        }
        /// <summary>
        /// Конструктор, кторый принимает тип матрицы: Complex[,] (System.Complex[,]).
        /// </summary>
        /// <param name="input"> Матрица данных. </param>
        public Matrix(Complex[,] input) : this()
        {
            m = input;
        }

        #endregion

        #region Оператор преобразования

        public static explicit operator dynamic[,](Matrix matrix)
        {
            return matrix.m;
        }

        #endregion

        #region Оператор образования

        public static explicit operator Matrix(byte[,] input)
        {
            return new Matrix(input);
        }
        public static explicit operator Matrix(short[,] input)
        {
            return new Matrix(input);
        }
        public static explicit operator Matrix(int[,] input)
        {
            return new Matrix(input);
        }
        public static explicit operator Matrix(long[,] input)
        {
            return new Matrix(input);
        }
        public static explicit operator Matrix(float[,] input)
        {
            return new Matrix(input);
        }
        public static explicit operator Matrix(double[,] input)
        {
            return new Matrix(input);
        }
        public static explicit operator Matrix(decimal[,] input)
        {
            return new Matrix(input);
        }
        public static explicit operator Matrix(Complex[,] input)
        {
            return new Matrix(input);
        }

        #endregion

        #region operator + сложение матриц
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            return Add(matrix1, matrix2);
        }
        public static Matrix Add(Matrix a, Matrix b)
        {
            if (a.m.GetType() != b.m.GetType())
                throw new TypeAccessException("Типы посылаемых матриц не равны");

            if (a.m.GetLength(0) != b.m.GetLength(0) ||
                a.m.GetLength(1) != b.m.GetLength(1))
                throw new IndexOutOfRangeException("Размеры посылаемых матриц не равны");

            return Add(a.m, b.m);
        }
        private static Matrix Add(byte[,] a, byte[,] b)
        {
            byte[,] result = new byte[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = (byte)(a[i, j] + b[i, j]);
            return new Matrix(result);
        }
        private static Matrix Add(short[,] a, short[,] b)
        {
            short[,] result = new short[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = (short)(a[i, j] + b[i, j]);
            return new Matrix(result);
        }
        private static Matrix Add(int[,] a, int[,] b)
        {
            int[,] result = new int[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] + b[i, j];
            return new Matrix(result);
        }
        private static Matrix Add(long[,] a, long[,] b)
        {
            long[,] result = new long[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] + b[i, j];
            return new Matrix(result);
        }
        private static Matrix Add(float[,] a, float[,] b)
        {
            float[,] result = new float[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] + b[i, j];
            return new Matrix(result);
        }
        private static Matrix Add(double[,] a, double[,] b)
        {
            double[,] result = new double[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] + b[i, j];
            return new Matrix(result);
        }
        private static Matrix Add(decimal[,] a, decimal[,] b)
        {
            decimal[,] result = new decimal[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] + b[i, j];
            return new Matrix(result);
        }
        private static Matrix Add(Complex[,] a, Complex[,] b)
        {
            Complex[,] result = new Complex[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] + b[i, j];
            return new Matrix(result);
        }

        #endregion

        #region operator - вычитание матриц

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            return Sub(matrix1, matrix2);
        }
        public static Matrix Sub(Matrix a, Matrix b)
        {
            if (a.m.GetType() != b.m.GetType())
                throw new TypeAccessException("Типы посылаемых матриц не равны");

            if (a.m.GetLength(0) != b.m.GetLength(0) ||
                a.m.GetLength(1) != b.m.GetLength(1))
                throw new IndexOutOfRangeException("Размеры посылаемых матриц не равны");

            return Sub(a.m, b.m);
        }
        private static Matrix Sub(byte[,] a, byte[,] b)
        {
            byte[,] result = new byte[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = (byte)(a[i, j] - b[i, j]);
            return new Matrix(result);
        }
        private static Matrix Sub(short[,] a, short[,] b)
        {
            short[,] result = new short[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = (short)(a[i, j] - b[i, j]);
            return new Matrix(result);
        }
        private static Matrix Sub(int[,] a, int[,] b)
        {
            int[,] result = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] - b[i, j];
            return new Matrix(result);
        }
        private static Matrix Sub(long[,] a, long[,] b)
        {
            long[,] result = new long[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] - b[i, j];
            return new Matrix(result);
        }
        private static Matrix Sub(float[,] a, float[,] b)
        {
            float[,] result = new float[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] - b[i, j];
            return new Matrix(result);
        }
        private static Matrix Sub(double[,] a, double[,] b)
        {
            double[,] result = new double[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] - b[i, j];
            return new Matrix(result);
        }
        private static Matrix Sub(decimal[,] a, decimal[,] b)
        {
            decimal[,] result = new decimal[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] - b[i, j];
            return new Matrix(result);
        }
        private static Matrix Sub(Complex[,] a, Complex[,] b)
        {
            Complex[,] result = new Complex[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] - b[i, j];
            return new Matrix(result);
        }

        #endregion

        #region operator * умножение матриц

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            return Mul(matrix1, matrix2);
        }
        public static Matrix Mul(Matrix a, Matrix b)
        {
            if (a.m.GetType() != b.m.GetType())
                throw new TypeAccessException("Типы посылаемых матриц не равны");

            if (a.m.GetLength(1) != b.m.GetLength(0))
                throw new IndexOutOfRangeException("Умножение невозможно, не корректные размеры матриц");

            return Mul(a.m, b.m);
        }
        private static Matrix Mul(byte[,] a, byte[,] b)
        {
            byte[,] result = new byte[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        result[i, j] += (byte)(a[i, k] * b[k, j]);
            return new Matrix(result);
        }
        private static Matrix Mul(short[,] a, short[,] b)
        {
            short[,] result = new short[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        result[i, j] += (short)(a[i, k] * b[k, j]);
            return new Matrix(result);
        }
        private static Matrix Mul(int[,] a, int[,] b)
        {
            int[,] result = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        result[i, j] += a[i, k] * b[k, j];
            return new Matrix(result);
        }
        private static Matrix Mul(long[,] a, long[,] b)
        {
            long[,] result = new long[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        result[i, j] += a[i, k] * b[k, j];
            return new Matrix(result);
        }
        private static Matrix Mul(float[,] a, float[,] b)
        {
            float[,] result = new float[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        result[i, j] += a[i, k] * b[k, j];
            return new Matrix(result);
        }
        private static Matrix Mul(double[,] a, double[,] b)
        {
            double[,] result = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        result[i, j] += a[i, k] * b[k, j];
            return new Matrix(result);
        }
        private static Matrix Mul(decimal[,] a, decimal[,] b)
        {
            decimal[,] result = new decimal[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        result[i, j] += a[i, k] * b[k, j];
            return new Matrix(result);
        }
        private static Matrix Mul(Complex[,] a, Complex[,] b)
        {
            Complex[,] result = new Complex[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        result[i, j] += a[i, k] * b[k, j];
            return new Matrix(result);
        }

        #endregion

        #region operator ! транспонирование матриц

        /// <summary>
        /// Перегруженый оператор транспонирования матриц
        /// </summary>
        /// <param name="matrix1"> Трансонируемая матрица </param>
        /// <returns> Трансонированная матрица </returns>
        public static Matrix operator !(Matrix matrix1)
        {
            return Trans(matrix1);
        }
        public static Matrix Trans(Matrix a)
        {
            return Trans(a.m);
        }
        private static Matrix Trans(byte[,] a)
        {
            byte[,] result = new byte[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    result[i, j] = a[j, i];
            return new Matrix(result);
        }
        private static Matrix Trans(short[,] a)
        {
            short[,] result = new short[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    result[i, j] = a[j, i];
            return new Matrix(result);
        }
        private static Matrix Trans(int[,] a)
        {
            int[,] result = new int[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    result[i, j] = a[j, i];
            return new Matrix(result);
        }
        private static Matrix Trans(long[,] a)
        {
            long[,] result = new long[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    result[i, j] = a[j, i];
            return new Matrix(result);
        }
        private static Matrix Trans(float[,] a)
        {
            float[,] result = new float[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    result[i, j] = a[j, i];
            return new Matrix(result);
        }
        private static Matrix Trans(double[,] a)
        {
            double[,] result = new double[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    result[i, j] = a[j, i];
            return new Matrix(result);
        }
        private static Matrix Trans(decimal[,] a)
        {
            decimal[,] result = new decimal[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    result[i, j] = a[j, i];
            return new Matrix(result);
        }
        private static Matrix Trans(Complex[,] a)
        {
            Complex[,] result = new Complex[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    result[i, j] = a[j, i];
            return new Matrix(result);
        }

        #endregion

        #region индексатор

        /// <summary>
        /// Индексатор возвращающий [i,j] элемент матрицы.
        /// </summary>
        /// <param name="i"> Номер столбца. </param>
        /// <param name="j"> Номер строчки. </param>
        /// <returns> Если индексы в диапазоне матрицы, то вернётся значение, иначе null. </returns>
        public dynamic? this[int i, int j]
        {
            get { return GetValue(i, j); }
        }
        /// <summary>
        /// Возвращает значение [i,j] элемента матрицы.
        /// </summary>
        /// <param name="indexI"> Номер столбца. </param>
        /// <param name="indexJ"> Номер строчки. </param>
        /// <returns> Если индексы в диапазоне матрицы, то вернётся значение, иначе null. </returns>
        public dynamic? GetValue(int indexI, int indexJ)
        {
            if (m.GetLength(0) > indexI && m.GetLength(1) > indexJ && m.GetLength(0) != 0) return m[indexI, indexJ];
            else return null;
        }

        #endregion

        #region true и false

        public static bool operator true(Matrix matrix)
        {
            if (matrix.m.GetLength(0) == matrix.m.GetLength(1) && matrix.m.GetLength(0) != 0) return true;
            else return false;
        }

        public static bool operator false(Matrix matrix)
        {
            if (matrix.m.GetLength(0) != matrix.m.GetLength(1) && matrix.m.GetLength(0) == 0) return true;
            else return false;
        }

        #endregion


        /// <summary>
        /// Возвращает тип матрицы.
        /// </summary>
        /// <returns> Тип матрицы. </returns>
        public Type GetValueType()
        {
            return m.GetType();
        }
        public override string ToString() // реализовано
        {
            StringBuilder @string = new();
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                    @string.Append(m[i, j].ToString() + " ");
                @string.AppendLine();
            }
            return @string.ToString();
        }
        public override bool Equals([NotNullWhen(true)] object? obj) // реализовано
        {
            if (obj == null) return false;
            if (obj.GetHashCode() != GetHashCode()) return false;
            if (obj is Matrix) return Equals((Matrix)obj);
            return false;
        }
        public override int GetHashCode() // реализовано
        {
            if (m.GetLength(0) == 0 && m.GetLength(1) == 0) return 0;
            return m[0, 0] ^ m[m.GetLength(0) - 1, m.GetLength(1) - 1] ^ m[m.GetLength(0) - 1, 0] ^ m[0, m.GetLength(1) - 1];
        }
        public object Clone() => new Matrix(m); // реализовано
        public bool Equals(Matrix other) // реализовано
        {
            if (this.m.GetType() != other.m.GetType()) return false;

            if (this.m.GetLength(0) != other.m.GetLength(0) ||
                this.m.GetLength(1) != other.m.GetLength(1)) return false;

            for (int i = 0; i < other.m.GetLength; i++)
                for (int j = 0; j < other.m.GetLength; j++)
                    if (m[i, j] != other.m[i, j])
                        return false;

            return true;
        }
        public int CompareTo(Matrix other) // не реализовано
        {
            return 0;
        }

        public int CompareTo(object? obj) // не реализовано
        {
            if (obj == null) return -1;
            if (obj is Matrix) return CompareTo((Matrix)obj);
            return -1;
        }
    }
}