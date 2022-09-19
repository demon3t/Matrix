using demon_3tt;
using System.Numerics;

Complex[,] cmpx = new Complex[,]
    {{new Complex(0,0), new Complex(0,1), new Complex(0,2) },
    { new Complex(1,0), new Complex(1,1), new Complex(1,2) },
    { new Complex(2,0), new Complex(2,1), new Complex(2,2) }};

Random[,] vv = new Random[,]
    {{new Random(), new Random(), new Random() },
    { new Random(), new Random(), new Random() },
    { new Random(), new Random(), new Random() }};

Matrix<Complex> matrix2 = cmpx;
Matrix<Random> matrix3 = vv;

matrix2[1, 1] = new Complex(5, 5);

Console.WriteLine(matrix2 + matrix2);
