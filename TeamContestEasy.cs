// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class TeamContestEasy
{
    public int worstRank(int[] ss)
    {
        int A = ss[0] + ss[1] + ss[2] - Math.Min(ss[0], Math.Min(ss[1], ss[2]));
        int[] s = new int[ss.Length - 3];
        Array.Copy(ss, 3, s, 0, s.Length);
        int[] s1 = Array.FindAll(s, (x) => x > A / 2.0);
        int[] s2 = Array.FindAll(s, (x) => x <= A / 2.0);
        Array.Sort(s1);
        Array.Sort(s2);
        Array.Reverse(s2);
        // BEGIN CUT HERE
        print(ss);
        print(s1);
        print(s2);
        // END CUT HERE
        // split into s1 and s2
        // sort s1

        int res = 0;
        int i = 0;
        int j = 0;
        while (i < s1.Length && j < s2.Length)
        {
            int b = A - s1[i];
            if (b >= s2[j])
                i++;
            else
            {
                // BEGIN CUT HERE
                print(s1[i].ToString());
                print(s2[j].ToString());
                // END CUT HERE
                j++;
                i++;
                res++;
            }
        }
        // foreach s1, match s1 with some s2
        if ((res + (s1.Length - res) / 2) * 3 > s.Length)
            return s.Length / 3 + 1;
        else
            return (res + (s1.Length - res) / 2) + 1;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new TeamContestEasy()).worstRank(new int[] { 28481, 557292, 14188, 61649, 510253, 509530, 749211, 171570, 441589 }), 3);
            eq(1, (new TeamContestEasy()).worstRank(new int[] { 5, 7, 3 }), 1);
            eq(2, (new TeamContestEasy()).worstRank(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }), 1);
            eq(3, (new TeamContestEasy()).worstRank(new int[] { 2, 2, 1, 1, 3, 1, 3, 2, 1, 3, 1, 2, 1, 2, 1 }
               ), 4);
            eq(4, (new TeamContestEasy()).worstRank(new int[] { 45, 72, 10, 42, 67, 51, 33, 21, 8, 51, 17, 72 }
               ), 3);
            eq(5, (new TeamContestEasy()).worstRank(new int[] {570466,958327,816467,17,403,953808,734850,5824,917784,921731,161921,1734,823437,3218,81,932681,2704,981643,1232,475,873323,6558,45660,1813,4714,224,
               32301,28081,6728,17055,561,15146,842613,5559,1860,783,989,2811,20664,112531,1933,866794,805528,53821,2465,137385,39,2007}), 6);
            eq(6, (new TeamContestEasy()).worstRank(new int[] {610297,849870,523999,6557,976530,731458,7404,795100,147040,110947,159692,40785,4949,2903,1688,37278,620703,28156,16823,1159,12132,971379,5916,1159,988589,
               12215,133,1490,911360,920059,544070,40249,514852,852,745070,1105,715897,714696,589133,698317,5683,631612,16453,101000,764881,101,2053,754661}), 10);
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

