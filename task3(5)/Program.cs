using System;

public abstract class Figure
{
    protected string name;

    public Figure(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
    }

    public abstract double Area2 { get; }

    public abstract double Area();

    public virtual void Print()
    {
        Console.WriteLine("Figure name: {0}", name);
    }
}

public class Triangle : Figure
{
    private double a, b, c;

    public Triangle(string name, double a, double b, double c)
        : base(name)
    {
        SetABC(a, b, c);
    }

    public void SetABC(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double[] GetABC()
    {
        return new double[] { a, b, c };
    }

    public override double Area2
    {
        get
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }

    public override double Area()
    {
        return Area2;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Sides: {0}, {1}, {2}", a, b, c);
    }
}

public class TriangleColor : Triangle
{
    private string color;

    public TriangleColor(string name, double a, double b, double c, string color)
        : base(name, a, b, c)
    {
        this.color = color;
    }

    public string Color
    {
        get { return color; }
    }

    public override double Area2
    {
        get { return base.Area2; }
    }

    public override double Area()
    {
        return base.Area();
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Color: {0}", color);
    }
}

class Program
{
    static void Main(string[] args)
    {
        TriangleColor triangle = new TriangleColor("Triangle 1", 3, 4, 5, "red");
        Console.WriteLine("Triangle area: " + triangle.Area());
        triangle.Print();
    }
}