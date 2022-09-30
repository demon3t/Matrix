using System.Numerics;
using System.Collections;
using MatrixGeneric;


Complex[,] cmpx = new Complex[,]
    {{new Complex(0,0), new Complex(0,1), new Complex(0,2) },
    { new Complex(1,0), new Complex(1,1), new Complex(1,2) },
    { new Complex(2,0), new Complex(2,1), new Complex(2,2) }};

Complex[,] cmpx1 = new Complex[,]
    {{new Complex(10,2), new Complex(0,0), new Complex(17,19) },
    { new Complex(15,69), new Complex(15,65), new Complex(16,81) },
    { new Complex(15,98), new Complex(76,48), new Complex(15,61) }};

Voltage[,] vv = new Voltage[,]
    {{new Voltage(15,0), new Voltage(0,45), new Voltage(0,4) },
    { new Voltage(45,0), new Voltage(34,1), new Voltage(7,5) },
    { new Voltage(0,4), new Voltage(5,4), new Voltage(9,2) }};



Matrix<Voltage> matrix1 = vv;
Console.WriteLine(~matrix1);


public class Voltage : IMatrixOperation<Voltage>
{

    public Voltage(int value1, int value2 )
    {
        Value1 = value1;
        Value2 = value2;
    }

    public int Value1;
    public int Value2;
    public Voltage Add(Voltage first, Voltage second)
    {
        return new Voltage(first.Value1 + second.Value1, first.Value2 + second.Value2);
    }
    public Voltage Subtract(Voltage first, Voltage second)
    {
        return new Voltage(first.Value1 - second.Value1, first.Value2 - second.Value2);
    }
    public Voltage Multiply(Voltage first, Voltage second)
    {
        return new Voltage(first.Value1 * second.Value1, first.Value2 * second.Value2);
    }
    public Voltage Divide(Voltage first, Voltage second)
    {
        return new Voltage(first.Value1 / second.Value1, first.Value2 / second.Value2);
    }
    public override string ToString()
    {
        return $"({Value1}; {Value2})";
    }
    public override int GetHashCode()
    {
        return Value1 ^ Value2 ^ Value1;
    }
}


    