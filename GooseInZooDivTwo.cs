// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class GooseInZooDivTwo
{
    public int count(string[] field, int dist)
    {
        map = field;
        mark = new bool[map.Length, map[0].Length];
        int res = 0;
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[0].Length; j++)
            {
                if (map[i][j] == 'v' && mark[i, j] != true)
                {
                    dfsmark(i, j, dist);
                    res++;
                }
            }
        }
        int ress = 1;
        for (int i = 0; i < res; i++)
        {
            ress *= 2;
            ress %= 1000000007;
        }
        return ress - 1;
    }

    string[] map;
    bool[,] mark;
    void dfsmark(int i, int j, int d)
    {
        if (i < 0 || j < 0
            || i >= map.Length || j >= map[0].Length)
            return;
        if (mark[i, j] == true)
            return;
        if (map[i][j] != 'v')
            return;

        mark[i, j] = true;
        for (int k = 0; k <= d; k++)
        {
            for (int l = 0; l <= d; l++)
            {
                if (k + l <= d)
                {
                    dfsmark(i + k, j + l, d);
                    dfsmark(i - k, j + l, d);
                    dfsmark(i - k, j - l, d);
                    dfsmark(i + k, j - l, d);
                }
            }

        }
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new GooseInZooDivTwo()).count(new string[] { "vvv" }, 0), 7);
            eq(1, (new GooseInZooDivTwo()).count(new string[] { "." }, 100), 0);
            eq(2, (new GooseInZooDivTwo()).count(new string[] { "vvv" }, 1), 1);
            eq(2, (new GooseInZooDivTwo()).count(new string[] { "v..", "...", "..v" }, 1), 3);
            eq(3, (new GooseInZooDivTwo()).count(new string[] {"v.v..................v............................"
               ,".v......v..................v.....................v"
               ,"..v.....v....v.........v...............v......v..."
               ,".........vvv...vv.v.........v.v..................v"
               ,".....v..........v......v..v...v.......v..........."
               ,"...................vv...............v.v..v.v..v..."
               ,".v.vv.................v..............v............"
               ,"..vv.......v...vv.v............vv.....v.....v....."
               ,"....v..........v....v........v.......v.v.v........"
               ,".v.......v.............v.v..........vv......v....."
               ,"....v.v.......v........v.....v.................v.."
               ,"....v..v..v.v..............v.v.v....v..........v.."
               ,"..........v...v...................v..............v"
               ,"..v........v..........................v....v..v..."
               ,"....................v..v.........vv........v......"
               ,"..v......v...............................v.v......"
               ,"..v.v..............v........v...............vv.vv."
               ,"...vv......v...............v.v..............v....."
               ,"............................v..v.................v"
               ,".v.............v.......v.........................."
               ,"......v...v........................v.............."
               ,".........v.....v..............vv.................."
               ,"................v..v..v.........v....v.......v...."
               ,"........v.....v.............v......v.v............"
               ,"...........v....................v.v....v.v.v...v.."
               ,"...........v......................v...v..........."
               ,"..........vv...........v.v.....................v.."
               ,".....................v......v............v...v...."
               ,".....vv..........................vv.v.....v.v....."
               ,".vv.......v...............v.......v..v.....v......"
               ,"............v................v..........v....v...."
               ,"................vv...v............................"
               ,"................v...........v........v...v....v..."
               ,"..v...v...v.............v...v........v....v..v...."
               ,"......v..v.......v........v..v....vv.............."
               ,"...........v..........v........v.v................"
               ,"v.v......v................v....................v.."
               ,".v........v................................v......"
               ,"............................v...v.......v........."
               ,"........................vv.v..............v...vv.."
               ,".......................vv........v.............v.."
               ,"...v.............v.........................v......"
               ,"....v......vv...........................v........."
               ,"....vv....v................v...vv..............v.."
               ,".................................................."
               ,"vv........v...v..v.....v..v..................v...."
               ,".........v..............v.vv.v.............v......"
               ,".......v.....v......v...............v............."
               ,"..v..................v................v....v......"
               ,".....v.....v.....................v.v......v......."}, 3), 797922654);
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

