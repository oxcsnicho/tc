// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class FoxAndShogi
{
    public int differentOutcomes(string[] board)
    {
        int res = 1;
        int mod = 1000000007;
        string[] map = new string[board.Length];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = "";
        }
        for (int j = 0; j < board.Length; j++)
        {
            for (int i = 0; i < board.Length; i++)
            {
                map[j] += board[i][j];
            }
        }
        // BEGIN CUT HERE
        print(map);
        // END CUT HERE

        for (int i = 0; i < map.Length; i++)
        {
            string ptn = @"D[.D]*[.U]*U|^[.U]*U|D[.D]*$";
            var match = Regex.Matches(map[i], ptn);
            for (int j = 0; j < match.Count; j++)
            {
                // BEGIN CUT HERE
                print(match[j].Groups[0].Value);
                // END CUT HERE
                string s = match[j].Groups[0].Value;
                int nr = 0;
                for (int k = 0; k < s.Length; k++)
                {
                    if (s[k] == 'D' || s[k] == 'U')
                        nr++;
                }
                res = (int)(res * C(s.Length, nr)) % mod;
            }
        }
        return res;
    }

    private long C(int p, int nr)
    {
        long res = 1;
        if (nr == 0)
            return 1;
        for (int i = 0; i < nr; i++)
        {
            res *= p - i;
            res /= i + 1;
        }
        return res;

    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
#if false
            eq(0, (new FoxAndShogi()).differentOutcomes(new string[] {".D.",
                "...",
                "..."}
                ), 3);
            eq(1, (new FoxAndShogi()).differentOutcomes(new string[] {".D.",
                "...",
                ".U."}
                ), 3);
            eq(2, (new FoxAndShogi()).differentOutcomes(new string[] {"DDDDD",
                ".....",
                ".....",
                ".....",
                "....."}
               ), 3125);
            eq(3, (new FoxAndShogi()).differentOutcomes(new string[] {"DDDDD",
                "U....",
                ".U...",
                "..U..",
                "...U."}
               ), 900);
#endif
            eq(4, (new FoxAndShogi()).differentOutcomes(new string[] {"....D..",
                "U....D.",
                "D.D.U.D",
                "U.U...D",
                "....U..",
                "D.U...D",
                "U.U...."}
               ), 2268);
            eq(5, (new FoxAndShogi()).differentOutcomes(new string[] {"DDDDDDDDDD",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                ".........."}
               ), 999999937);
#if false
            eq(6, (new FoxAndShogi()).differentOutcomes(new string[] {"..",
                ".."}), 1);
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

