// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class BallsSeparating
{
    public int minOperations(int[] red, int[] green, int[] blue)
    {
        if (red.Length < 3)
            return -1;

        int ress = -1;
        for (int i = 0; i < red.Length; i++)
        {
            for (int j = 0; j < red.Length; j++)
            {
                if (j != i)
                    for (int k = 0; k < red.Length; k++)
                    {
                        if (k != i && j != k)
                        {
                            int res = 0;
                            for (int l = 0; l < red.Length; l++)
                            {
                                if (l == i)
                                    res += green[l] + blue[l];
                                else if (l == j)
                                    res += red[l] + blue[l];
                                else if (l == k)
                                    res += green[l] + red[l];
                                else
                                    res += red[l] + blue[l] + green[l] - Math.Max(red[l], Math.Max(green[l], blue[l]));
                            }
                            if (ress == -1 || res < ress)
                                ress = res;
                        }
                    }
            }
        }

        return ress;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new BallsSeparating()).minOperations(
                new int[] { 852057, 889141, 662939, 340220 },
                new int[] { 600081, 390298, 376707, 372199 },
                new int[] { 435097, 40266, 145590, 505103 }), 2952434);
            eq(1, (new BallsSeparating()).minOperations(new int[] { 5 }, new int[] { 6 }, new int[] { 8 }), -1);
            eq(2, (new BallsSeparating()).minOperations(new int[] { 4, 6, 5, 7 }, new int[] { 7, 4, 6, 3 }, new int[] { 6, 5, 3, 8 }), 37);
            eq(3, (new BallsSeparating()).minOperations(new int[] { 7, 12, 9, 9, 7 }, new int[] { 7, 10, 8, 8, 9 }, new int[] { 8, 9, 5, 6, 13 }), 77);
            eq(4, (new BallsSeparating()).minOperations(new int[] { 842398, 491273, 958925, 849859, 771363, 67803, 184892, 391907, 256150, 75799 }, new int[] { 268944, 342402, 894352, 228640, 903885, 908656, 414271, 292588, 852057, 889141 }, new int[] { 662939, 340220, 600081, 390298, 376707, 372199, 435097, 40266, 145590, 505103 }), 7230607);
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

