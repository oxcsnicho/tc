// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class TheBrickTowerMediumDivTwo
{
    public int[] find(int[] heights)
    {
        h = heights;
        o = new int[h.Length];
        for (int i = 0; i < o.Length; i++)
        {
            o[i] = i;
        }
        res = new int[o.Length];
        Array.Copy(o, res, o.Length);
        reslen = 47 * 7;
        rec(0);
        return res;
    }

    int[] h;
    int[] o;
    int[] res;
    int reslen;
    void rec(int dep)
    {

        int len = 0;
        for (int i = 1; i < o.Length; i++)
        {
            len += Math.Max(h[o[i - 1]], h[o[i]]);
        }
        if (len <= reslen)
        {
            if (len == reslen)
            {
                int i = 0;
                while (i < o.Length && o[i] == res[i])
                    i++;
                if (i < o.Length && o[i] < res[i])
                {
                    Array.Copy(o, res, o.Length);
                }
            }
            else
            {
                Array.Copy(o, res, o.Length);
                reslen = len;
            }
        }

        if (dep >= o.Length - 1)
            return;

        for (int i = dep; i < o.Length; i++)
        {
            int tmp;
            tmp = o[dep];
            o[dep] = o[i];
            o[i] = tmp;
            rec(dep + 1);
            tmp = o[dep];
            o[dep] = o[i];
            o[i] = tmp;
        }
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new TheBrickTowerMediumDivTwo()).find(new int[] { 4, 7, 5 }), new int[] { 0, 2, 1 });
            eq(1, (new TheBrickTowerMediumDivTwo()).find(new int[] { 4, 4, 4, 4, 4, 4, 4 }), new int[] { 0, 1, 2, 3, 4, 5, 6 });
            eq(2, (new TheBrickTowerMediumDivTwo()).find(new int[] { 2, 3, 3, 2 }), new int[] { 0, 3, 1, 2 });
            eq(3, (new TheBrickTowerMediumDivTwo()).find(new int[] { 13, 32, 38, 25, 43, 47, 6 }), new int[] { 0, 6, 3, 1, 2, 4, 5 });
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

