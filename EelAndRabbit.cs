// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class EelAndRabbit
{
    public int getmax(int[] l, int[] t)
    {
        int res = 0;
        HashSet<int> a = new HashSet<int>();
        for (int i = 0; i < l.Length; i++)
        {
            a.Add(t[i]);
            a.Add(l[i] + t[i]);
        }
        var b = a.ToArray();
        for (int j = 0; j < b.Length; j++)
        {
            for (int k = j + 1; k < b.Length; k++)
            {
                int ress = 0;
                for (int i = 0; i < l.Length; i++)
                {
                    if ((l[i] + t[i] >= b[j] && t[i] <= b[j])
                    || (l[i] + t[i] >= b[k] && t[i] <= b[k]))
                        ress++;
                }
                res = Math.Max(res, ress);
            }
        }
        return res;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new EelAndRabbit()).getmax(new int[] { 2, 4, 3, 2, 2, 1, 10 }, new int[] { 2, 6, 3, 7, 0, 2, 0 }), 6);
            eq(1, (new EelAndRabbit()).getmax(new int[] { 1, 1, 1 }, new int[] { 2, 0, 4 }), 2);
            eq(2, (new EelAndRabbit()).getmax(new int[] { 1 }, new int[] { 1 }), 1);
            eq(3, (new EelAndRabbit()).getmax(new int[] { 8, 2, 1, 10, 8, 6, 3, 1, 2, 5 }, new int[] { 17, 27, 26, 11, 1, 27, 23, 12, 11, 13 }), 7);
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

