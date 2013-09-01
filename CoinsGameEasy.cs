// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class CoinsGameEasy
{
    public int minimalSteps(string[] board)
    {
        b = board;
        int x1 = -1, x2 = -1, y1 = -1, y2 = -1;
        for (int i = 0; i < b.Length; i++)
        {
            for (int j = 0; j < b[i].Length; j++)
            {
                if (b[i][j] == 'o')
                    if (x1 == -1)
                    {
                        x1 = i;
                        y1 = j;
                    }
                    else
                    {
                        x2 = i;
                        y2 = j;
                    }
            }
        }
        int res = 11;
        for (int i = 0; i < 4; i++)
        {
            int ress = rec(x1 , y1 , x2 , y2 , 0, i);
            res = Math.Min(res, ress);
        }
        return res == 11 ? -1 : res;
    }

    string[] b;
    int[] dx = { 1, 0, -1, 0 };
    int[] dy = { 0, 1, 0, -1 };
    int rec(int x1, int y1, int x2, int y2, int steps, int d)
    {
        if (steps > 10)
            return 11;
        // check
        if (((x1 < 0 || y1 < 0 || x1 >= b.Length || y1 >= b[0].Length) &&
 (x2 < 0 || y2 < 0 || x2 >= b.Length || y2 >= b[0].Length)))
            return 11;
        if (((x1 < 0 || y1 < 0 || x1 >= b.Length || y1 >= b[0].Length) &&
 !(x2 < 0 || y2 < 0 || x2 >= b.Length || y2 >= b[0].Length)) ||
        !(x1 < 0 || y1 < 0 || x1 >= b.Length || y1 >= b[0].Length) &&
 (x2 < 0 || y2 < 0 || x2 >= b.Length || y2 >= b[0].Length))
            return steps;
        else if (((x1 < 0 || y1 < 0 || x1 >= b.Length || y1 >= b[0].Length) &&
 !(x2 < 0 || y2 < 0 || x2 >= b.Length || y2 >= b[0].Length)) &&
        !(x1 < 0 || y1 < 0 || x1 >= b.Length || y1 >= b[0].Length) &&
 (x2 < 0 || y2 < 0 || x2 >= b.Length || y2 >= b[0].Length))
            return steps;
        else if (b[x1][y1] == '#' && b[x2][y2] == '#')
            return 11;
        else if (b[x1][y1] == '#')
        {
            x1 -= dx[d];
            y1 -= dy[d];
        }
        else if (b[x2][y2] == '#')
        {
            x2 -= dx[d];
            y2 -= dy[d];
        }

        // move
        int res = 11;
        for (int i = 0; i < 4; i++)
        {
            int ress = rec(x1 + dx[i], y1 + dy[i], x2 + dx[i], y2 + dy[i], steps + 1, i);
            res = Math.Min(res, ress);
        }
        return res;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            //eq(0, (new CoinsGameEasy()).minimalSteps(new string[] { "oo" }), 1);
            eq(1, (new CoinsGameEasy()).minimalSteps(new string[] {".#", 
                ".#", 
                ".#",
                "o#",
                "o#",
                "##"}), 4);
            eq(2, (new CoinsGameEasy()).minimalSteps(new string[] {"..",
                "..",
                "..",
                "o#",
                "o#",
                "##"}), 3);
            eq(3, (new CoinsGameEasy()).minimalSteps(new string[] {"###",
                ".o.",
                "###",
                ".o.",
                "###"}), -1);
            eq(4, (new CoinsGameEasy()).minimalSteps(new string[] {"###",
                ".o.",
                "#.#",
                ".o.",
                "###"}), 3);
            eq(5, (new CoinsGameEasy()).minimalSteps(new string[] {"###########",
                "........#o#",
                "###########",
                ".........o#",
                "###########"}), 10);
            eq(6, (new CoinsGameEasy()).minimalSteps(new string[] {"############",
                ".........#o#",
                "############",
                "..........o#",
                "############"}), -1);
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

