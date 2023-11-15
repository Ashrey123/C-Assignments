using System;

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
sealed class DeprecatedAttribute : Attribute
{
    public string Message { get; }

    public DeprecatedAttribute(string message)
    {
        Message = message;
    }
}

class Example
{
    [Deprecated("This method is deprecated. Use NewMethod instead.")]
    public void DeprecatedMethod()
    {
        Console.WriteLine("This method is deprecated.");
    }

    public void NewMethod()
    {
        Console.WriteLine("This is the new method.");
    }
}

class Program
{
    static void Main()
    {
        Example example = new Example();

        var deprecatedAttribute = (DeprecatedAttribute)Attribute.GetCustomAttribute(
            typeof(Example).GetMethod("DeprecatedMethod"),
            typeof(DeprecatedAttribute)
        );

        if (deprecatedAttribute != null)
        {
            Console.WriteLine($"Deprecated Method: {deprecatedAttribute.Message}");
        }

        example.DeprecatedMethod();
        example.NewMethod();
    }
}
