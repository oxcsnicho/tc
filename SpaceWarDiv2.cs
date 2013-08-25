// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class SpaceWarDiv2
{
    public int minimalFatigue(int[] gs, int[] es, int[] ec)
    {
        Array.Sort(es, ec);
        Array.Sort(gs);
        Array.Reverse(es);
        Array.Reverse(ec);
        Array.Reverse(gs);

        int[] f = new int[gs.Length];
        Array.Clear(f, 0, f.Length);

        if (gs[0] < es[0])
            return -1;
        for (int i = 0; i < es.Length; i++)
        {
            while (ec[i] > 0)
            {
                int k = 0;
                int small = f[0];
                for (int j=0; j< gs.Length && gs[j]>= es[i] ; j++)
                {
                    if (f[j] < small)
                    {
                        small = f[j];
                        k = j;
                    }
                }
                f[k]++;
                ec[i]--;
            }

        }
        int res = 0;
        for (int i = 0; i < f.Length; i++)
        {
            if (f[i] > res)
                res = f[i];
        }
        return res;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new SpaceWarDiv2()).minimalFatigue(new int[] { 2, 3, 5 }, new int[] { 1, 3, 4 }, new int[] { 2, 9, 4 }), 7);
            eq(1, (new SpaceWarDiv2()).minimalFatigue(new int[] { 2, 3, 5 }, new int[] { 1, 1, 2 }, new int[] { 2, 9, 4 }), 5);
            eq(2, (new SpaceWarDiv2()).minimalFatigue(new int[] { 14, 6, 22 }, new int[] { 8, 33 }, new int[] { 9, 1 }), -1);
            eq(3, (new SpaceWarDiv2()).minimalFatigue(new int[] { 17, 10, 29, 48, 92, 60, 80, 100, 15, 69, 36, 43, 70, 14, 88, 12, 14, 29, 9, 40 }, new int[] { 93, 59, 27, 68, 48, 82, 15, 95, 61, 49, 68, 15, 16, 26, 64, 82, 7, 8, 92, 15 }, new int[] { 56, 26, 12, 52, 5, 19, 93, 36, 69, 61, 68, 66, 55, 28, 49, 55, 63, 57, 33, 45 }), 92);
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
