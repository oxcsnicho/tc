// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class GUMIAndSongsDiv2
{
    public int maxSongs(int[] d, int[] tone, int T)
    {
        int res = 0;
        if (d.Length == 1)
            return T <= d[0] ? 0 : 1;
        Array.Sort(d);
        if (d[0] < T)
            res = 1;

        Array.Sort(tone, d);
        // BEGIN CUT HERE
        print(d);
        print(tone);
        // END CUT HERE
        for (int i = 0; i < d.Length; i++)
        {
            for (int j = i + 1; j < d.Length; j++)
            {
                int tt = T - tone[j] + tone[i];
                if (tt < 0)
                    continue;
                int[] aa = new int[j - i + 1];
                Array.Copy(d, i, aa, 0, j - i + 1);
                Array.Sort(aa);
                int ress = 0;
                for (int k = 0; k < aa.Length; k++)
                {
                    if (tt >=aa[k])
                    {
                        ress++;
                        tt -= aa[k];
                    }
                }
                res = Math.Max(ress, res);
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
            eq(0, (new GUMIAndSongsDiv2()).maxSongs(new int[] { 3, 5, 4, 11 }, new int[] { 2, 1, 3, 1 }, 17), 3);
            eq(1, (new GUMIAndSongsDiv2()).maxSongs(new int[] { 100, 200, 300 }, new int[] { 1, 2, 3 }, 10), 0);
            eq(2, (new GUMIAndSongsDiv2()).maxSongs(new int[] { 1, 2, 3, 4 }, new int[] { 1, 1, 1, 1 }, 100), 4);
            eq(3, (new GUMIAndSongsDiv2()).maxSongs(new int[] { 10, 10, 10 }, new int[] { 58, 58, 58 }, 30), 3);
            eq(4, (new GUMIAndSongsDiv2()).maxSongs(new int[] { 8, 11, 7, 15, 9, 16, 7, 9 }, new int[] { 3, 8, 5, 4, 2, 7, 4, 1 }, 14), 1);
            eq(5, (new GUMIAndSongsDiv2()).maxSongs(new int[] { 5611, 39996, 20200, 56574, 81643, 90131, 33486, 99568, 48112, 97168, 5600, 49145, 73590, 3979, 94614 }, new int[] { 2916, 53353, 64924, 86481, 44803, 61254, 99393, 5993, 40781, 2174, 67458, 74263, 69710, 40044, 80853 }, 302606), 8);
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

