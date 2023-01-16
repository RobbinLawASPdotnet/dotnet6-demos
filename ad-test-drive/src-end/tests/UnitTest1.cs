namespace tests;

//additional namespaces
using classlib;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Class1 myobject = new Class1();
        var actual = myobject.Add(1, 3);
        Assert.Equal(4, actual);
    }
}