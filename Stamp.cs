// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Stamp
{
    public int getMinimumCost(string dc, int sc, int pc)
    {
#if false
        var ptns = new string[] { @"[\*R]*R[\*R]*", @"[\*G]*G[\*G]*", @"[\*B]*B[\*B]*" };
        int L = dc.Length;
        for (int j = 0; j < ptns.Length; j++)
        {
            var RM = Regex.Matches(dc, ptns[j]);
            for (int i = 0; i < RM.Count; i++)
            {
                if (RM[i].Groups[0].Length < L)
                {
                    L = RM[i].Groups[0].Length;
                }
                // BEGIN CUT HERE
                print(RM[i].Groups[0].Value);
                // END CUT HERE
            }
        }
        // BEGIN CUT HERE
        print(L);
        // END CUT HERE
#endif
        int L = dc.Length;

        int[] dcc = new int[dc.Length];
        for (int i = 0; i < dcc.Length; i++)
        {
            if (dc[i] == 'R')
                dcc[i] = 1;
            if (dc[i] == 'G')
                dcc[i] = 2;
            if (dc[i] == 'B')
                dcc[i] = 4;
            if (dc[i] == '*')
                dcc[i] = 7;
        }

        int res = 1000000000;
        int[] F = new int[dc.Length];
        for (int l = 1; l <= L; l++)
        {
            Array.Clear(F, 0, F.Length);
            for (int i = 0; i < F.Length; i++)
            {
                F[i] = 1000000;
            }
            for (int i = l - 1; i < dc.Length; i++)
            {
                int chk = 7;
                for (int j = i - l + 1; j <= i; j++)
                    chk &= dcc[j];
                if (chk == 0)
                    continue;
                if (i - l < 0)
                    F[i] = 1;
                else
                    F[i] = Math.Min(F[i], F[i - l] + 1);
                for (int j = 1; i+j<dcc.Length && j < l; j++)
                {
                    chk &= dcc[i + j];
                    if (chk == 0)
                        break;
                    F[i + j] = Math.Min(F[i + j], F[i] + 1);
                }
            }
            if (F[F.Length - 1] < 1000000)
                res = Math.Min(sc * l + F[F.Length - 1] * pc, res);
        }
        return res;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new Stamp()).getMinimumCost("RR*BB", 1, 10000), 30002);
            eq(1, (new Stamp()).getMinimumCost("R**GB*", 1, 1), 5);
            eq(2, (new Stamp()).getMinimumCost("BRRB", 2, 7), 30);
            eq(3, (new Stamp()).getMinimumCost("R*RR*GG", 10, 58), 204);
            eq(4, (new Stamp()).getMinimumCost("*B**B**B*BB*G*BBB**B**B*", 5, 2), 33);
            eq(5, (new Stamp()).getMinimumCost("*R*RG*G*GR*RGG*G*GGR***RR*GG", 7, 1), 30);
#if false
#endif
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

