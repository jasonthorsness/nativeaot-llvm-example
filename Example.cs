namespace ExampleNamespace;

using System.Runtime.InteropServices;

public partial class Example
{
    [LibraryImport("lib")]
    internal static partial int foo(int n);

    [UnmanagedCallersOnly(EntryPoint = "Answer")]
    public static unsafe int Answer(int n)
    {
        return foo(n) + 1;
    }
}
