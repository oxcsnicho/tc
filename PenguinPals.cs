// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class PenguinPals
{
    public int findMaximumMatching(string c)
    {
        memo = new Dictionary<string, int>();
        int res =  F(c);
        return res;
    }

    Dictionary<string, int> memo;
    int F(string c)
    {
        if (memo.ContainsKey(c))
            return memo[c];
        if (c.Length < 2)
            return 0;
        if (c.Length == 2)
            return c[0] == c[1] ? 1 : 0;

        int res = 0;
        for (int i = 1; i < c.Length; i++)
        {
            if (c[i] == c[0])
            {
                if(i==1)
                res = Math.Max(res, 1 + F(c.Substring(i + 1, c.Length - i - 1)));
                else if (i==c.Length-1)
                res = Math.Max(res, 1 + F(c.Substring(1, i-1)));
                else
                res = Math.Max(res, 1 + F(c.Substring(1, i-1)) + F(c.Substring(i + 1, c.Length - i - 1)));
            }
        }
        res = Math.Max(res, F(c.Substring(1, c.Length - 1)));
        memo[c] = res;
        return res;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new PenguinPals()).findMaximumMatching("RRBRBRBB"), 3);
            eq(1, (new PenguinPals()).findMaximumMatching("RRRR"), 2);
            eq(2, (new PenguinPals()).findMaximumMatching("BBBBB"), 2);
            eq(3, (new PenguinPals()).findMaximumMatching("RBRBRBRBR"), 4);
            eq(4, (new PenguinPals()).findMaximumMatching("RRRBRBRBRBRB"), 5);
            eq(5, (new PenguinPals()).findMaximumMatching("R"), 0);
            eq(6, (new PenguinPals()).findMaximumMatching("RBRRBBRB"), 3);
            eq(7, (new PenguinPals()).findMaximumMatching("RBRBBRBRB"), 4);
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

