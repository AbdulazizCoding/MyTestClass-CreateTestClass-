using Test.Attributes;
using TestingClasses;

namespace Test;

[TestClass]
internal class CalculateTest
{
    private readonly Calculate _calculate;

    public CalculateTest()
    {
        _calculate = new Calculate();
    }

    [Func]
    [TestMethodParameters(1, 2, 3)]
    [TestMethodParameters(1, 2, 4)]
    public void Qoshish(int a, int b, int c)
    {
        var qoshish = _calculate.Qoshish(a, b);
        if (qoshish == c)
            Console.WriteLine("Qo'shish to'g'ri");
        else
            Console.WriteLine("Qo'shish noto'g'ri");
    }

    [Func]
    [TestMethodParameters(3, 2, 1)]
    [TestMethodParameters(3, 2, 2)]
    public void Ayirish(int a, int b, int c)
    {
        var qoshish = _calculate.Ayitish(a, b);
        if (qoshish == c)
            Console.WriteLine("Ayitish to'g'ri");
        else
            Console.WriteLine("Ayitish noto'g'ri");
    }

    [Func]
    [TestMethodParameters(2, 2, 4)]
    [TestMethodParameters(2, 2, 3)]
    public void Kopaytirish(int a, int b, int c)
    {
        var qoshish = _calculate.Kopaytirish(a, b);
        if (qoshish == c)
            Console.WriteLine("Kopaytirish to'g'ri");
        else
            Console.WriteLine("Kopaytirish noto'g'ri");
    }

    [Func]
    [TestMethodParameters(4, 2, 2)]
    [TestMethodParameters(4, 2, 1)]
    public void Bolish(int a, int b, int c)
    {
        var qoshish = _calculate.Bolish(a, b);
        if (qoshish == c)
            Console.WriteLine("Bolish to'g'ri");
        else
            Console.WriteLine("Bolish noto'g'ri");
    }
}
