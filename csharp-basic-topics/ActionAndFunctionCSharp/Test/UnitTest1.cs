using FunctionAndAction.Services;

namespace Test;

public class Tests
{
  
    [Test]
    public void Test1()
    {
        ConverterService converterService = new ConverterService((_)=>_.ToUpper());
        string result=converterService.Convert("toupperexample");
        Assert.AreEqual("TOUPPEREXAMPLE",result);
    }       
}
