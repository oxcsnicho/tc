// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class TheSquareRootDilemma
{
    public int countPairs(int N, int M)
    {
        List<int> sql = new List<int>();
        for (int i = 1; i * i <= Math.Max(M, N); i++)
            sql.Add(i * i);
        int[] sq = sql.ToArray();
        // BEGIN CUT HERE
        print(sq);
        // END CUT HERE

        int res = 0;
        for (int k = 1; k <= N; k++)
        {
            int l = k;
            for (int i = 1; i < sq.Length && sq[i] <= l; )
            {
                if (l % sq[i] == 0)
                    l /= sq[i];
                else
                    i++;
            }

            int j = 0;
            while (j < sq.Length && sq[j] * l <= M) j++;
            res += j;
        }
        //for each k in N
        // find l
        // find nr of matching l
        // add number
        return res;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new TheSquareRootDilemma()).countPairs(2, 2), 2);
            eq(1, (new TheSquareRootDilemma()).countPairs(10, 1), 3);
            eq(2, (new TheSquareRootDilemma()).countPairs(3, 8), 5);
            eq(3, (new TheSquareRootDilemma()).countPairs(100, 100), 310);
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

