namespace Test.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
internal class TestMethodParameters : Attribute
{
    public TestMethodParameters(params object[] parameters)
    {
        Parameters = parameters;
    }

    public object[] Parameters { get; }
}
