// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class PiecewiseLinearFunctionDiv2
{
    public int[] countSolutions(int[] Y, int[] query)
    {
        int[] ress = new int[query.Length];
        for (int i = 0; i < ress.Length; i++)
        {
            int res = 0;
            for (int j = 0; j < Y.Length; j++)
            {
                if (Y[j] == query[i])
                    res++;
            }
            for (int j = 1; j < Y.Length; j++)
            {
                if (Y[j - 1] == query[i] && Y[j] == query[i])
                {
                    res = -1;
                    break;
                }
                if (Y[j - 1] < query[i] && Y[j] > query[i]
                || Y[j - 1] > query[i] && Y[j] < query[i])
                    res++;
            }
            ress[i] = res;
        }
        return ress;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new PiecewiseLinearFunctionDiv2()).countSolutions(new int[] { 1, 4, -1, 2 }, new int[] { -2, -1, 0, 1, 10, -10 }), new int[] { 0, 1, 2, 3, 0, 0 });
            eq(1, (new PiecewiseLinearFunctionDiv2()).countSolutions(new int[] { 0, 0 }, new int[] { -1, 0, 1 }), new int[] { 0, -1, 0 });
            eq(2, (new PiecewiseLinearFunctionDiv2()).countSolutions(new int[] { 2, 4, 8, 0, 3, -6, 10 }, new int[] { 0, 1, 2, 3, 4, 0, 65536 }), new int[] { 3, 4, 5, 4, 3, 3, 0 });
            eq(3, (new PiecewiseLinearFunctionDiv2()).countSolutions(new int[] { -178080289, -771314989, -237251715, -949949900, -437883156, -835236871, -316363230, -929746634, -671700962 }
               , new int[] { -673197622, -437883156, -251072978, 221380900, -771314989, -949949900, -910604034, -671700962, -929746634, -316363230 }), new int[] { 8, 6, 3, 0, 7, 1, 4, 8, 3, 4 });
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

