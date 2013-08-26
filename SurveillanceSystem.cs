// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class SurveillanceSystem
{
    public string getContainerInfo(string containers, int[] reports, int L)
    {
        int[] a = new int[containers.Length - L + 1];
        Array.Clear(a, 0, a.Length);
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < L; j++)
            {
                if (containers[i + j] == 'X')
                    a[i]++;
            }
        }

        Dictionary<int, int> rep = new Dictionary<int, int>();
        for (int i = 0; i < reports.Length; i++)
        {
            if (rep.ContainsKey(reports[i]))
                rep[reports[i]]++;
            else
                rep[reports[i]] = 1;
        }

        char[] res = new char[containers.Length];
        for (int i = 0; i < res.Length; i++)
            res[i] = '-';
        foreach (var item in rep)
        {
            var c = new List<int>();
            for (int j = 0; j < a.Length; j++)
            {
                if (a[j] == item.Key)
                    c.Add(j);
            }
            int[] d = new int[containers.Length];
            Array.Clear(d, 0, d.Length);
            for (int j = 0; j < c.Count; j++)
            {
                for (int k = 0; k < L; k++)
                {
                    d[c[j] + k]++;
                }
            }
            for (int j = 0; j < d.Length; j++)
            {
                if (d[j] >= c.Count - item.Value + 1)
                    res[j] = '+';
                else if (d[j] > 0)
                    if (res[j] != '+')
                        res[j] = '?';
            }
        }
        return new string(res);
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new SurveillanceSystem()).getContainerInfo("-X--XX", new int[] { 1, 2 }, 3), "??++++");
            eq(1, (new SurveillanceSystem()).getContainerInfo("-XXXXX-", new int[] { 2 }, 3), "???-???");
            eq(2, (new SurveillanceSystem()).getContainerInfo("------X-XX-", new int[] { 3, 0, 2, 0 }, 5), "++++++++++?");
            eq(3, (new SurveillanceSystem()).getContainerInfo("-XXXXX---X--", new int[] { 2, 1, 0, 1 }, 3), "???-??++++??");
            eq(4, (new SurveillanceSystem()).getContainerInfo("-XX--X-XX-X-X--X---XX-X---XXXX-----X", new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 }, 7), "???++++?++++++++++++++++++++??????--");
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

