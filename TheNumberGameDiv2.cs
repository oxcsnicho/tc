// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class TheNumberGameDiv2
{
    public int minimumMoves(int A, int B)
    {
        string a = A.ToString();
        string b = B.ToString();
        int res=a.Length+10;
        if (a.Contains(b))
        {
            if (a.IndexOf(b) == 0)
            {
                res = a.Length - b.Length;
            }
            else
            {
                res = a.Length - b.Length + 2;
            }
        }
        var bc = b.ToCharArray();
        Array.Reverse(bc);
        string bb = new string(bc);
        if (a.Contains(bb))
        {
            res = Math.Min(res, a.Length - b.Length + 1);
        }
        return res == a.Length + 10 ? -1 : res ;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new TheNumberGameDiv2()).minimumMoves(25, 5), 2);
            eq(0, (new TheNumberGameDiv2()).minimumMoves(255335, 53), 5);
            eq(1, (new TheNumberGameDiv2()).minimumMoves(5162, 16), 4);
            eq(2, (new TheNumberGameDiv2()).minimumMoves(334, 12), -1);
            eq(3, (new TheNumberGameDiv2()).minimumMoves(218181918, 9181), 6);
            eq(4, (new TheNumberGameDiv2()).minimumMoves(9798147, 79817), -1);
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

