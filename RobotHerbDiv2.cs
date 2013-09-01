// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class RobotHerbDiv2
{
    public int getdist(int T, int[] a)
    {
        xx = 0;
        yy = 0;
        oo = 0;
        for (int i = 0; i < T; i++)
        {
            execute(xx, yy, oo, a);
        }

        return Math.Abs(xx) + Math.Abs(yy);
    }

    int xx, yy, oo;
    void execute(int x, int y, int o, int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (o == 0)
                y += a[i];
            else if (o == 1)
                x += a[i];
            else if (o == 2)
                y -= a[i];
            else if (o == 3)
                x -= a[i];

            o += a[i] % 4;
            o = o % 4;
        }
        xx = x;
        yy = y;
        oo = o;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new RobotHerbDiv2()).getdist(1, new int[] { 1, 2, 3 }), 2);
            eq(1, (new RobotHerbDiv2()).getdist(100, new int[] { 1 }), 0);
            eq(2, (new RobotHerbDiv2()).getdist(5, new int[] { 1, 1, 2 }), 10);
            eq(3, (new RobotHerbDiv2()).getdist(100, new int[] { 400000 }), 40000000);
        }
        catch (Exception exx)
        {
            System.Console.WriteLine(exx);
            System.Console.WriteLine(exx.StackTrace);
        }
    }
    private static void eq(int n, object have, object need)
    {
        if (cases != null && cases.Count > 0)
            if (!cases.Exists((a) => a == n))
                return;
        if (eq(have, need))
        {
            Debug.WriteLine("Case " + n + " passed.");
        }
        else
        {
            Debug.Write("Case " + n + " failed: expected ");
            print(need);
            Debug.Write(", received ");
            print(have);
            Debug.WriteLine("");
        }
    }
    private static void eq(int n, Array have, Array need)
    {
        if (cases != null && cases.Count > 0)
            if (!cases.Exists((a) => a == n))
                return;
        if (have == null || have.Length != need.Length)
        {
            Debug.WriteLine("Case " + n + " failed: returned " + have.Length + " elements; expected " + need.Length + " elements.");
            print(have);
            print(need);
            return;
        }
        for (int i = 0; i < have.Length; i++)
        {
            if (!eq(have.GetValue(i), need.GetValue(i)))
            {
                Debug.WriteLine("Case " + n + " failed. Expected and returned array differ in position " + i);
                print(have);
                print(need);
                return;
            }
        }
        Debug.WriteLine("Case " + n + " passed.");
    }
    private static bool eq(object a, object b)
    {
        if (a is double && b is double)
        {
            return Math.Abs((double)a - (double)b) < 1E-9;
        }
        else
        {
            return a != null && b != null && a.Equals(b);
        }
    }
    private static void print(object a)
    {
        if (a is string)
        {
            Debug.Write(string.Format("\"{0}\"", a));
        }
        else if (a is long)
        {
            Debug.Write(string.Format("{0}L", a));
        }
        else
        {
            Debug.Write(a);
        }
    }
    private static void print(Array a)
    {
        if (a == null)
        {
            Debug.WriteLine("<NULL>");
        }
        Debug.Write('{');
        for (int i = 0; i < a.Length; i++)
        {
            print(a.GetValue(i));
            if (i != a.Length - 1)
            {
                Debug.Write(", ");
            }
        }
        Debug.WriteLine('}');
    }
    // END CUT HERE
}

