// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class ArcadeManao
{
    public int shortestLadder(string[] level, int coinRow, int coinColumn)
    {
        int res = 0;
        while (bfs(level, coinRow-1, coinColumn-1, res) == false)
            res++;
        return res;
    }

    private bool bfs(string[] level, int coinRow, int coinColumn, int len)
    {
        List<int> a = new List<int>();
        List<int> b = new List<int>();
        bool[,] m = new bool[level.Length, level[0].Length];
        a.Add(level.Length-1);
        b.Add(0);
        m[level.Length-1, 0] = true;
        while (a.Count > 0)
        {
            if (a[0] == coinRow && b[0] == coinColumn)
                return true;
            int x,y;
            x=a[0];
            y = b[0]-1;
            if (x >= 0 && y >= 0 && x < level.Length && y < level[0].Length
                && m[x,y] == false && level[x][y] == 'X')
            {
                a.Add(x);
                b.Add(y);
                m[x, y] = true;
            }
            x=a[0];
            y = b[0]+1;
            if (x >= 0 && y >= 0 && x < level.Length && y < level[0].Length
                && m[x,y] == false && level[x][y] == 'X')
            {
                a.Add(x);
                b.Add(y);
                m[x, y] = true;
            }
            for (int i = 1; i <=len; i++)
            {
                x = a[0]-i;
                y = b[0];
                if (x >= 0 && y >= 0 && x < level.Length && y < level[0].Length
                    && m[x, y] == false && level[x][y] == 'X')
                {
                    a.Add(x);
                    b.Add(y);
                    m[x, y] = true;
                }
                x = a[0]+i;
                y = b[0];
                if (x >= 0 && y >= 0 && x < level.Length && y < level[0].Length
                    && m[x, y] == false && level[x][y] == 'X')
                {
                    a.Add(x);
                    b.Add(y);
                    m[x, y] = true;
                }
            }
            a.RemoveAt(0);
            b.RemoveAt(0);
        }
        // BEGIN CUT HERE
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                print(m[i,j]?'x':'.');
            }
            print(Environment.NewLine);
        }
        // END CUT HERE
        return false;
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

