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

Voltage[,] vv = new Voltage[,]
    {{new Voltage(15), new Voltage(45), new Voltage(4) },
    { new Voltage(45), new Voltage(34), new Voltage(7) },
    { new Voltage(4), new Voltage(5), new Voltage(9) }};



Matrix<Voltage> matrix1 = vv;


Console.WriteLine(matrix1 - matrix1);


public class Voltage : IMatrix<Voltage>
{

    public Voltage(int value)
    {
        Value = value;
    }

    public int Value;
    public Voltage Add(Voltage first, Voltage second)
    {
        return new Voltage(first.Value + second.Value);
    }
    public Voltage Subtract(Voltage first, Voltage second)
    {
        return new Voltage(first.Value - second.Value);
    }
    public Voltage Multiply(Voltage first, Voltage second)
    {
        return new Voltage(first.Value * second.Value);
    }
    public Voltage Divide(Voltage first, Voltage second)
    {
        return new Voltage(first.Value / second.Value);
    }
    public override string ToString()
    {
        return Value.ToString();
    }
    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public bool Equals(Voltage first)
    {
        return object.Equals(this, first);
    }
}


    