using Generic;
using demon_3t;
using System.Numerics;
using System.Collections;

BitArray bA = new BitArray(9000000);
Console.WriteLine(sizeof(int));
Console.ReadLine();

Complex[,] cmpx = new Complex[,]
    {{new Complex(0,0), new Complex(0,1), new Complex(0,2) },
    { new Complex(1,0), new Complex(1,1), new Complex(1,2) },
    { new Complex(2,0), new Complex(2,1), new Complex(2,2) }};

Complex[,] cmpx1 = new Complex[,]
    {{new Complex(10,2), new Complex(0,0), new Complex(17,19) },
    { new Complex(15,69), new Complex(15,65), new Complex(16,81) },
    { new Complex(15,98), new Complex(76,48), new Complex(15,61) }};

Random[,] vv = new Random[,]
    {{new Random(), new Random(), new Random() },
    { new Random(), new Random(), new Random() },
    { new Random(), new Random(), new Random() }};

Matrix<Complex> matrix1 = cmpx1;
Matrix<Complex> matrix = cmpx;


Console.WriteLine(matrix1 + matrix1 - matrix);


class Test : IMatrix
{
    double Value { get; set; }

    public object Add(object first, object second)
    {
        return new Test() { Value = first. + second };
    }

    public object Divide(object first, object second)
    {
        throw new NotImplementedException();
    }

    public object Multiply(object first, object second)
    {
        throw new NotImplementedException();
    }

    public object Subtract(object first, object second)
    {
        throw new NotImplementedException();
    }
}
    