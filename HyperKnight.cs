// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class HyperKnight
{
    public long countCells(int a, int b, int numRows, int numColumns, int k)
    {
        long res = 1;
        int tmp = Math.Max(a, b);
        a = a + b - tmp;
        b = tmp;
        switch (k)
        {
            case 0:
            case 1:
                return 0L;
            case 2:
                return res * a * a * 4;
            case 3:
                return res*8*a*(b-a);
            case 4:
                return (res * numColumns + numRows - b - b - b - b) * a * 2 + ((long)b - a) * (b - a) * 4;
            case 5:
                return 0L;
            case 6:
                return (res * numRows + numColumns - b - b - b - b) * (b - a) * 2;
            case 7:
                return 0L;
            case 8:
                return res * (numColumns - b - b) * (numRows - b - b);
        }
        return res;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new HyperKnight()).countCells(2,3,7,7,3), 16L);
            eq(1, (new HyperKnight()).countCells(3, 2, 8, 8, 2), 16L);
            eq(2, (new HyperKnight()).countCells(1, 3, 7, 11, 0), 0L);
            eq(3, (new HyperKnight()).countCells(3, 2, 10, 20, 8), 56L);
            eq(4, (new HyperKnight()).countCells(1, 4, 100, 10, 6), 564L);
            eq(5, (new HyperKnight()).countCells(500000000, 500000000, 1000000000, 1000000000, 4), 999999988000000036L);
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

