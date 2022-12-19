//https://www.codemag.com/Article/2009101/Interactive-Unit-Testing-with-.NET-Core-and-VS-Code
namespace tests;

//additional namespaces
using System;
//using xunit;
using WestWindSystem;

public class UnitTest1
{
  [Fact]
  public void Test1()
  {
    var actual = Supplier.Add(1, 3);
    Assert.Equal(4, actual);
    //Supplier theSupplier = new Supplier("Robbin's Foods   ", "780-111-2222");
  }
}