namespace TestProject2;

[TestFixture]
public class FigureTests
{
    [Test]
    public void TestFigureName()
    {
        Figure figure = new Triangle("TestTriangle", 3, 4, 5);
        Assert.AreEqual("TestTriangle", figure.Name, "Name property is incorrect");
    }

    [Test]
    public void TestFigurePrint()
    {
        Figure figure = new Triangle("TestTriangle", 3, 4, 5);
        Assert.DoesNotThrow(() => figure.Print(), "Print method should not throw an exception");
    }
}

[TestFixture]
public class TriangleTests
{
    [Test]
    public void TestTriangleAreaCalculation()
    {
        Triangle triangle = new Triangle("TestTriangle", 3, 4, 5);
        Assert.AreEqual(6, triangle.Area(), 0.001, "Area calculation is incorrect");
    }

    [Test]
    public void TestTrianglePrint()
    {
        Triangle triangle = new Triangle("TestTriangle", 3, 4, 5);
        Assert.DoesNotThrow(() => triangle.Print(), "Print method should not throw an exception");
    }
}

[TestFixture]
public class TriangleColorTests
{
    [Test]
    public void TestTriangleColorAreaCalculation()
    {
        TriangleColor triangleColor = new TriangleColor("TestTriangleColor", 3, 4, 5, "red");
        Assert.AreEqual(6, triangleColor.Area(), 0.001, "Area calculation is incorrect");
    }

    [Test]
    public void TestTriangleColorPrint()
    {
        TriangleColor triangleColor = new TriangleColor("TestTriangleColor", 3, 4, 5, "red");
        Assert.DoesNotThrow(() => triangleColor.Print(), "Print method should not throw an exception");
    }
}
