namespace ActionFilterDemo.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class NoLogAttribute:Attribute
    {
    }
}
