// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class ArcadeManao
{
    public int shortestLadder(string[] level, int coinRow, int coinColumn)
    {
        map = level;
        mark = new bool[map.Length, map[0].Length];
        int res = 0;
        while (res < map.Length)
        {
            Array.Clear(mark, 0, mark.Length);
            // BEGIN CUT HERE
            for (int i = 0; i < mark.GetLength(0); i++)
            {
                for (int j = 0; j < mark.GetLength(1); j++)
                {
                    Debug.Write(mark[i, j] ? "X" : ".");
                }
                Debug.Write(Environment.NewLine);
            }
            // END CUT HERE
            dfs(map.Length - 1, 0, res);
            // BEGIN CUT HERE
            for (int i = 0; i < mark.GetLength(0); i++)
            {
                for (int j = 0; j < mark.GetLength(1); j++)
                {
                    Debug.Write(mark[i, j] ? "X" : ".");
                }
                Debug.Write(Environment.NewLine);
            }
            // END CUT HERE
            if (mark[coinRow - 1, coinColumn - 1] == true)
                break;
            res++;
        }
        return res;
    }


    string[] map;
    bool[,] mark;
    void dfs(int i, int j, int l)
    {
        if (i < 0 || j < 0 || i >= map.Length || j >= map[0].Length)
            return;
        if (mark[i, j] == true)
            return;
        if (map[i][j] != 'X')
            return;

        mark[i, j] = true;
        dfs(i, j - 1, l);
        dfs(i, j + 1, l);
        for (int k = 1; k <= l; k++)
        {
            dfs(i + k, j, l);
            dfs(i - k, j, l);
        }
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new ArcadeManao()).shortestLadder(new string[] {"XXXX....",
                "...X.XXX",
                "XXX..X..",
                "......X.",
                "XXXXXXXX"}, 2, 4), 2);
            eq(1, (new ArcadeManao()).shortestLadder(new string[] {"XXXX",
                "...X",
                "XXXX"}, 1, 1), 1);
            eq(2, (new ArcadeManao()).shortestLadder(new string[] {"..X..",
                ".X.X.",
                "X...X",
                ".X.X.",
                "..X..",
                "XXXXX"}, 1, 3), 4);
            eq(3, (new ArcadeManao()).shortestLadder(new string[] { "X" }, 1, 1), 0);
            eq(4, (new ArcadeManao()).shortestLadder(new string[] {"XXXXXXXXXX",
                "...X......",
                "XXX.......",
                "X.....XXXX",
                "..XXXXX..X",
                ".........X",
                ".........X",
                "XXXXXXXXXX"}, 1, 1), 2);
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

