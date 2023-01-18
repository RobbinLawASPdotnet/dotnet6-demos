namespace Tests;
using Classlib;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Class1 myobject = new Class1();
        var actual = myobject.Add(1, 3);
        Assert.AreEqual(4, actual);
    }
}