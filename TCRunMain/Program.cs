using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

class RunnerMain
{
    static void PerformTesting()
    {
        Assembly my = Assembly.GetExecutingAssembly();
        foreach (Type t in my.GetTypes())
        {
            MethodInfo mi = t.GetMethod("Test", BindingFlags.Static | BindingFlags.Public);
            if (mi != null)
            {
                mi.Invoke(null, null);
            }
        }
    }

    static int Main(string[] args)
    {
        PerformTesting();
        return 0;
    }

}