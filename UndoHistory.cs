// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class UndoHistory
{
    public int minPresses(string[] lines)
    {
        int res = 0;
        string last = "";
        int[] pf = new int[lines.Length];
        Array.Clear(pf, 0, pf.Length);
        for (int i = 0; i < pf.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int k = 0;
                while (k < lines[j].Length && k < lines[i].Length && lines[i][k] == lines[j][k])
                    k++;
                if (pf[i] < k)
                    pf[i] = k;
            }
        }
        // BEGIN CUT HERE
        print(pf);
        // END CUT HERE

        // for each of the string
        for (int i = 0; i < lines.Length; i++)
        {
            // first string: type it
            if (last == "")
                res += lines[i].Length + 1;
            else
            {
                // onward: 2. continue typing 3. restore something and type
                int a = lines[i].Length + 3;
                if (lines[i].Length >= last.Length && lines[i].Substring(0, last.Length) == last)
                    a = lines[i].Length - last.Length + 1;
                int b = 2 + lines[i].Length - pf[i] + 1;
                // BEGIN CUT HERE
                print(Math.Min(a,b).ToString());
                // END CUT HERE
                res += Math.Min(a,b);
            }
            last = lines[i];
        }
        return res;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new UndoHistory()).minPresses(new string[] { "tomorrow", "topcoder" }), 18);
            eq(1, (new UndoHistory()).minPresses(new string[] { "a", "b" }), 6);
            eq(2, (new UndoHistory()).minPresses(new string[] { "a", "ab", "abac", "abacus" }), 10);
            eq(3, (new UndoHistory()).minPresses(new string[] { "pyramid", "sphinx", "sphere", "python", "serpent" }), 39);
            eq(4, (new UndoHistory()).minPresses(new string[] { "ba", "a", "a", "b", "ba" }
               ), 13);
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

