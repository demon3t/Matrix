//using System.Diagnostics.CodeAnalysis;
//using System.Numerics;
//using System.Runtime.InteropServices;
//using System.Text;

//namespace demon_3t
//{
//    [StructLayoutAttribute(LayoutKind.Explicit)]
//    public struct Matrix<T> : ICloneable, IEquatable<Matrix<T>>
//    {
//        public enum Inversion
//        {
//            Approximations = 0,
//            GaussSeidel = 1,
//            Triangulation = 2,
//        }

//        [FieldOffset(0)]
//        readonly T[,] m;

//        public static Inversion inversion = Inversion.Approximations;

//        #region Конструкторы

//        public Matrix(int i, int j)
//        {
//            m = new T[i, j];
//        }
//        /// <summary>
//        /// Конструктор, кторый принимает тип матрицы: byte[,] (System.Byte[,]).
//        /// </summary>
//        /// <param name="input"> Матрица данных. </param>
//        public Matrix(byte[,] input) : this(input.GetLength(0), input.GetLength(1))
//        {
//            FillInstance(input);
//        }
//        /// <summary>
//        /// Конструктор, кторый принимает тип матрицы: short[,] (System.Int16[,]).
//        /// </summary>
//        /// <param name="input"> Матрица данных. </param>
//        public Matrix(short[,] input) : this(input.GetLength(0), input.GetLength(1))
//        {
//            FillInstance(input);
//        }
//        /// <summary>
//        /// Конструктор, кторый принимает тип матрицы: int[,] (System.Int32[,]).
//        /// </summary>
//        /// <param name="input"> Матрица данных. </param>
//        public Matrix(int[,] input) : this(input.GetLength(0), input.GetLength(1))
//        {
//            FillInstance(input);
//        }
//        /// <summary>
//        /// Конструктор, кторый принимает тип матрицы: long[,] (System.Int64[,]).
//        /// </summary>
//        /// <param name="input"> Матрица данных. </param>
//        public Matrix(long[,] input) : this(input.GetLength(0), input.GetLength(1))
//        {
//            FillInstance(input);
//        }
//        /// <summary>
//        /// Конструктор, кторый принимает тип матрицы: float[,] (System.Single[,]).
//        /// </summary>
//        /// <param name="input"> Матрица данных. </param>
//        public Matrix(float[,] input) : this(input.GetLength(0), input.GetLength(1))
//        {
//            FillInstance(input);
//        }
//        /// <summary>
//        /// Конструктор, кторый принимает тип матрицы: double[,] (System.Double[,]).
//        /// </summary>
//        /// <param name="input"> Матрица данных. </param>
//        public Matrix(double[,] input) : this(input.GetLength(0), input.GetLength(1))
//        {
//            FillInstance(input);
//        }
//        /// <summary>
//        /// Конструктор, кторый принимает тип матрицы: decimal[,] (System.Decimal[,]).
//        /// </summary>
//        /// <param name="input"> Матрица данных. </param>
//        public Matrix(decimal[,] input) : this(input.GetLength(0), input.GetLength(1))
//        {
//            FillInstance(input);
//        }
//        /// <summary>
//        /// Конструктор, кторый принимает тип матрицы: Complex[,] (System.Complex[,]).
//        /// </summary>
//        /// <param name="input"> Матрица данных. </param>
//        public Matrix(Complex[,] input) : this(input.GetLength(0), input.GetLength(1))
//        {
//            FillInstance(input);
//        }
//        /// <summary>
//        /// Конструктор, кторый принимает тип матрицы: IMatrix[,] (IMatrix[,]).
//        /// </summary>
//        /// <param name="input"> Матрица данных. </param>
//        public Matrix(IMatrix<T>[,] input) : this(input.GetLength(0), input.GetLength(1))
//        {
//            FillInstance(input);
//        }

//        private Matrix(dynamic[,] input) : this(input.GetLength(0), input.GetLength(1))
//        {
//            FillInstance(input);
//        }

//        public Matrix(T[,] m)
//        {
//            this.m = m;
//        }

//        #endregion

//        #region Оператор преобразования

//        public static explicit operator T[,](Matrix<T> matrix)
//        {
//            return matrix.m;
//        }

//        #endregion

//        #region Оператор образования

//        public static implicit operator Matrix<T>(byte[,] input)
//        {
//            return new Matrix<T>(input);
//        }
//        public static implicit operator Matrix<T>(short[,] input)
//        {
//            return new Matrix<T>(input);
//        }
//        public static implicit operator Matrix<T>(int[,] input)
//        {
//            return new Matrix<T>(input);
//        }
//        public static implicit operator Matrix<T>(long[,] input)
//        {
//            return new Matrix<T>(input);
//        }
//        public static implicit operator Matrix<T>(float[,] input)
//        {
//            return new Matrix<T>(input);
//        }
//        public static implicit operator Matrix<T>(double[,] input)
//        {
//            return new Matrix<T>(input);
//        }
//        public static implicit operator Matrix<T>(decimal[,] input)
//        {
//            return new Matrix<T>(input);
//        }
//        public static implicit operator Matrix<T>(Complex[,] input)
//        {
//            return new Matrix<T>(input);
//        }
//        public static implicit operator Matrix<T>(IMatrix<T>[,] input)
//        {
//            return new Matrix<T>(input);
//        }

//        #endregion

//        #region operator + сложение матриц
//        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
//        {
//            return Add(matrix1, matrix2);
//        }
//        public static Matrix<T> Add(Matrix<T> a, Matrix<T> b)
//        {
//            if (a.m.GetType() != b.m.GetType())
//                throw new TypeAccessException("Типы посылаемых матриц не равны");

//            if (a.m.GetLength(0) != b.m.GetLength(0) ||
//                a.m.GetLength(1) != b.m.GetLength(1))
//                throw new IndexOutOfRangeException("Размеры посылаемых матриц не равны");

//            return Add(a, b);
//        }
//        private static Matrix<T> Add(byte[,] a, byte[,] b)
//        {
//            byte[,] result = new byte[a.GetLength(0), a.GetLength(1)];

//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = (byte)(a[i, j] + b[i, j]);
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Add(short[,] a, short[,] b)
//        {
//            short[,] result = new short[a.GetLength(0), a.GetLength(1)];

//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = (short)(a[i, j] + b[i, j]);
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Add(int[,] a, int[,] b)
//        {
//            int[,] result = new int[a.GetLength(0), a.GetLength(1)];

//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] + b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Add(long[,] a, long[,] b)
//        {
//            long[,] result = new long[a.GetLength(0), a.GetLength(1)];

//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] + b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Add(float[,] a, float[,] b)
//        {
//            float[,] result = new float[a.GetLength(0), a.GetLength(1)];

//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] + b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Add(double[,] a, double[,] b)
//        {
//            double[,] result = new double[a.GetLength(0), a.GetLength(1)];

//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] + b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Add(decimal[,] a, decimal[,] b)
//        {
//            decimal[,] result = new decimal[a.GetLength(0), a.GetLength(1)];

//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] + b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Add(Complex[,] a, Complex[,] b)
//        {
//            Complex[,] result = new Complex[a.GetLength(0), a.GetLength(1)];

//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] + b[i, j];
//            return new Matrix<T>(result);
//        }

//        private static Matrix<T> Add(IMatrix<T>[,] a, IMatrix<T>[,] b)
//        {
//            IMatrix<T>[,] result = new IMatrix<T>[a.GetLength(0), a.GetLength(1)];

//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = (IMatrix<T>)a[i, j].Add((T)a[i, j], (T)b[i, j]);
//            return new Matrix<T>(result);
//        }

//        #endregion

//        #region operator - вычитание матриц

//        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
//        {
//            return Sub(matrix1, matrix2);
//        }
//        public static Matrix<T> Sub(Matrix<T> a, Matrix<T> b)
//        {
//            if (a.m.GetType() != b.m.GetType())
//                throw new TypeAccessException("Типы посылаемых матриц не равны");

//            if (a.m.GetLength(0) != b.m.GetLength(0) ||
//                a.m.GetLength(1) != b.m.GetLength(1))
//                throw new IndexOutOfRangeException("Размеры посылаемых матриц не равны");

//            return Sub(a, b);
//        }
//        private static Matrix<T> Sub(byte[,] a, byte[,] b)
//        {
//            byte[,] result = new byte[a.GetLength(0), a.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = (byte)(a[i, j] - b[i, j]);
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Sub(short[,] a, short[,] b)
//        {
//            short[,] result = new short[a.GetLength(0), a.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = (short)(a[i, j] - b[i, j]);
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Sub(int[,] a, int[,] b)
//        {
//            int[,] result = new int[a.GetLength(0), a.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] - b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Sub(long[,] a, long[,] b)
//        {
//            long[,] result = new long[a.GetLength(0), a.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] - b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Sub(float[,] a, float[,] b)
//        {
//            float[,] result = new float[a.GetLength(0), a.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] - b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Sub(double[,] a, double[,] b)
//        {
//            double[,] result = new double[a.GetLength(0), a.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] - b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Sub(decimal[,] a, decimal[,] b)
//        {
//            decimal[,] result = new decimal[a.GetLength(0), a.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] - b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Sub(Complex[,] a, Complex[,] b)
//        {
//            Complex[,] result = new Complex[a.GetLength(0), a.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = a[i, j] - b[i, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Sub(IMatrix<T>[,] a, IMatrix<T>[,] b)
//        {
//            IMatrix<T>[,] result = new IMatrix<T>[a.GetLength(0), a.GetLength(1)];

//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < a.GetLength(1); j++)
//                    result[i, j] = (IMatrix<T>)a[i, j].Subtract((T)a[i, j], (T)b[i, j]);
//            return new Matrix<T>(result);
//        }

//        #endregion

//        #region operator * умножение матриц

//        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
//        {
//            return Mul(matrix1, matrix2);
//        }
//        public static Matrix<T> Mul(Matrix<T> a, Matrix<T> b)
//        {
//            if (a.m.GetType() != b.m.GetType())
//                throw new TypeAccessException("Типы посылаемых матриц не равны");

//            if (a.m.GetLength(1) != b.m.GetLength(0))
//                throw new IndexOutOfRangeException("Умножение невозможно, не корректные размеры матриц");

//            return Mul(a, b);
//        }
//        private static Matrix<T> Mul(byte[,] a, byte[,] b)
//        {
//            byte[,] result = new byte[a.GetLength(0), b.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < b.GetLength(1); j++)
//                    for (int k = 0; k < b.GetLength(0); k++)
//                        result[i, j] += (byte)(a[i, k] * b[k, j]);
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Mul(short[,] a, short[,] b)
//        {
//            short[,] result = new short[a.GetLength(0), b.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < b.GetLength(1); j++)
//                    for (int k = 0; k < b.GetLength(0); k++)
//                        result[i, j] += (short)(a[i, k] * b[k, j]);
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Mul(int[,] a, int[,] b)
//        {
//            int[,] result = new int[a.GetLength(0), b.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < b.GetLength(1); j++)
//                    for (int k = 0; k < b.GetLength(0); k++)
//                        result[i, j] += a[i, k] * b[k, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Mul(long[,] a, long[,] b)
//        {
//            long[,] result = new long[a.GetLength(0), b.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < b.GetLength(1); j++)
//                    for (int k = 0; k < b.GetLength(0); k++)
//                        result[i, j] += a[i, k] * b[k, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Mul(float[,] a, float[,] b)
//        {
//            float[,] result = new float[a.GetLength(0), b.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < b.GetLength(1); j++)
//                    for (int k = 0; k < b.GetLength(0); k++)
//                        result[i, j] += a[i, k] * b[k, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Mul(double[,] a, double[,] b)
//        {
//            double[,] result = new double[a.GetLength(0), b.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < b.GetLength(1); j++)
//                    for (int k = 0; k < b.GetLength(0); k++)
//                        result[i, j] += a[i, k] * b[k, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Mul(decimal[,] a, decimal[,] b)
//        {
//            decimal[,] result = new decimal[a.GetLength(0), b.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < b.GetLength(1); j++)
//                    for (int k = 0; k < b.GetLength(0); k++)
//                        result[i, j] += a[i, k] * b[k, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Mul(Complex[,] a, Complex[,] b)
//        {
//            Complex[,] result = new Complex[a.GetLength(0), b.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < b.GetLength(1); j++)
//                    for (int k = 0; k < b.GetLength(0); k++)
//                        result[i, j] += a[i, k] * b[k, j];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Mul(IMatrix<T>[,] a, IMatrix<T>[,] b)
//        {
//            IMatrix<T>[,] result = new IMatrix<T>[a.GetLength(0), b.GetLength(1)];
//            for (int i = 0; i < a.GetLength(0); i++)
//                for (int j = 0; j < b.GetLength(1); j++)
//                    for (int k = 0; k < b.GetLength(0); k++)
//                        result[i, j] = (IMatrix<T>)a[i, k].Add((T)result[i, j], a[i, k].Multiply((T)a[i, k], (T)b[k, j]));
//            return new Matrix<T>(result);
//        }

//        #endregion

//        #region operator ! транспонирование матриц

//        /// <summary>
//        /// Перегруженый оператор транспонирования матриц
//        /// </summary>
//        /// <param name="matrix1"> Трансонируемая матрица </param>
//        /// <returns> Трансонированная матрица </returns>
//        public static Matrix<T> operator !(Matrix<T> matrix1)
//        {
//            return Trans(matrix1);
//        }
//        public static Matrix<T> Trans(Matrix<T> a)
//        {
//            return Trans(a);
//        }
//        private static Matrix<T> Trans(byte[,] a)
//        {
//            byte[,] result = new byte[a.GetLength(1), a.GetLength(0)];
//            for (int i = 0; i < a.GetLength(1); i++)
//                for (int j = 0; j < a.GetLength(0); j++)
//                    result[i, j] = a[j, i];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Trans(short[,] a)
//        {
//            short[,] result = new short[a.GetLength(1), a.GetLength(0)];
//            for (int i = 0; i < a.GetLength(1); i++)
//                for (int j = 0; j < a.GetLength(0); j++)
//                    result[i, j] = a[j, i];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Trans(int[,] a)
//        {
//            int[,] result = new int[a.GetLength(1), a.GetLength(0)];
//            for (int i = 0; i < a.GetLength(1); i++)
//                for (int j = 0; j < a.GetLength(0); j++)
//                    result[i, j] = a[j, i];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Trans(long[,] a)
//        {
//            long[,] result = new long[a.GetLength(1), a.GetLength(0)];
//            for (int i = 0; i < a.GetLength(1); i++)
//                for (int j = 0; j < a.GetLength(0); j++)
//                    result[i, j] = a[j, i];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Trans(float[,] a)
//        {
//            float[,] result = new float[a.GetLength(1), a.GetLength(0)];
//            for (int i = 0; i < a.GetLength(1); i++)
//                for (int j = 0; j < a.GetLength(0); j++)
//                    result[i, j] = a[j, i];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Trans(double[,] a)
//        {
//            double[,] result = new double[a.GetLength(1), a.GetLength(0)];
//            for (int i = 0; i < a.GetLength(1); i++)
//                for (int j = 0; j < a.GetLength(0); j++)
//                    result[i, j] = a[j, i];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Trans(decimal[,] a)
//        {
//            decimal[,] result = new decimal[a.GetLength(1), a.GetLength(0)];
//            for (int i = 0; i < a.GetLength(1); i++)
//                for (int j = 0; j < a.GetLength(0); j++)
//                    result[i, j] = a[j, i];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Trans(Complex[,] a)
//        {
//            Complex[,] result = new Complex[a.GetLength(1), a.GetLength(0)];
//            for (int i = 0; i < a.GetLength(1); i++)
//                for (int j = 0; j < a.GetLength(0); j++)
//                    result[i, j] = a[j, i];
//            return new Matrix<T>(result);
//        }
//        private static Matrix<T> Trans(IMatrix<T>[,] a)
//        {
//            IMatrix<T>[,] result = new IMatrix<T>[a.GetLength(1), a.GetLength(0)];
//            for (int i = 0; i < a.GetLength(1); i++)
//                for (int j = 0; j < a.GetLength(0); j++)
//                    result[i, j] = a[j, i];
//            return new Matrix<T>(result);
//        }
//        #endregion

//        #region индексатор

//        public dynamic this[int i, int j]
//        {
//            get
//            {
//                if (i < 0 || i >= m.GetLength(0)) throw new ArgumentOutOfRangeException($"Параметр не в диапазоне массива i = {i}.");
//                if (j < 0 || j >= m.GetLength(0)) throw new ArgumentOutOfRangeException($"Параметр не в диапазоне массива j = {j}.");
//                return m[i, j];
//            }
//            set
//            {
//                if (i < 0 || i >= m.GetLength(0)) throw new ArgumentOutOfRangeException($"Параметр не в диапазоне массива i = {i}.");
//                if (j < 0 || j >= m.GetLength(0)) throw new ArgumentOutOfRangeException($"Параметр не в диапазоне массива j = {j}.");
//                if (value == null) throw new ArgumentNullException(nameof(value));
//                m[i, j] = value;
//            }
//        }

//        #endregion

//        #region true и false

//        public static bool operator true(Matrix<T> matrix)
//        {
//            if (matrix.m.GetLength(0) == matrix.m.GetLength(1) && matrix.m.GetLength(0) != 0) return true;
//            else return false;
//        }

//        public static bool operator false(Matrix<T> matrix)
//        {
//            if (matrix.m.GetLength(0) != matrix.m.GetLength(1) && matrix.m.GetLength(0) == 0) return true;
//            else return false;
//        }


//        #endregion

//        #region operator ^ обращения матриц



//        #endregion

//        private void FillInstance(dynamic matrix)
//        {
//            for (int i = 0; i < matrix.GetLength(0); i++)
//                for (int j = 0; j < matrix.GetLength(1); j++)
//                    this.m[i, j] = matrix[i, j];
//        }

//        /// <summary>
//        /// Возвращает тип матрицы.
//        /// </summary>
//        /// <returns> Тип матрицы. </returns>
//        public Type GetValueType()
//        {
//            return m.GetType();
//        }

//        public override string ToString() // реализовано
//        {
//            StringBuilder @string = new();
//            for (int i = 0; i < m.GetLength(0); i++)
//            {
//                for (int j = 0; j < m.GetLength(1); j++)
//                    @string.Append(m[i, j].ToString() + " ");
//                @string.AppendLine();
//            }
//            return @string.ToString();
//        }
//        public override bool Equals([NotNullWhen(true)] object? obj) // реализовано
//        {
//            if (obj == null) return false;
//            if (obj.GetHashCode() != GetHashCode()) return false;
//            if (obj is Matrix<T>) return Equals((Matrix<T>)obj);
//            return false;
//        }

//        public object Clone() => new Matrix<T>(m); // реализовано
//        public bool Equals(Matrix<T> other) // реализовано
//        {
//            if (this.m.GetType() != other.m.GetType()) return false;

//            if (this.m.GetLength(0) != other.m.GetLength(0) ||
//                this.m.GetLength(1) != other.m.GetLength(1)) return false;

//            for (int i = 0; i < other.m.GetLength(0); i++)
//                for (int j = 0; j < other.m.GetLength(1); j++)
//                    if (m[i, j].Equals((IMatrix<T>)other.m[i, j]))
//                        return false;

//            return true;
//        }
//    }
//    public interface IMatrix<T>
//    {
//        public T Add(T first, T second);
//        public T Subtract(T first, T second);
//        public T Multiply(T first, T second);
//        public T Divide(T first, T second);
//        public bool Equals(T first);
//    }

//}