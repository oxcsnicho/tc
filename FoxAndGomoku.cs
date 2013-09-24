// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class FoxAndGomoku
{
    int[] dx = { 1, 1, 0, -1 };
    int[] dy = { 0, 1, 1, 1 };
    public string win(string[] board)
    {
        map = board;
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (getb(i, j) == 'o')
                {
                    for (int l = 0; l < 4; l++)
                    {
                        int k;
                        for (k = 1; k < 5; k++)
                        {
                            if (getb(i + k * dx[l], j + k * dy[l]) != 'o')
                                break;
                        }
                        if (k == 5)
                            return "found";
                    }

                }
            }
        }
        return "not found";

    }

    string[] map;
    private char getb(int x, int y)
    {
        if (x < 0 || y < 0 || x >= map.Length || y >= map[0].Length)
            return 'x';
        else
            return map[x][y];
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new FoxAndGomoku()).win(new string[] {"....o.",
                "...o..",
                "..o...",
                ".o....",
                "o.....",
                "......"}), "found");
            eq(1, (new FoxAndGomoku()).win(new string[] {"oooo.",
                ".oooo",
                "oooo.",
                ".oooo",
                "....."}
                ), "not found");
            eq(2, (new FoxAndGomoku()).win(new string[] {"oooo.",
                ".oooo",
                "oooo.",
                ".oooo",
                "....o"}
                ), "found");
            eq(3, (new FoxAndGomoku()).win(new string[] {"o.....",
                ".o....",
                "..o...",
                "...o..",
                "....o.",
                "......"}), "found");
            eq(4, (new FoxAndGomoku()).win(new string[] {"o....",
                "o.o..",
                "o.o.o",
                "o.o..",
                "o...."}), "found");
            eq(5, (new FoxAndGomoku()).win(new string[] {"..........",
                "..........",
                "..oooooo..",
                "..o.......",
                "..o.......",
                "..oooooo..",
                ".......o..",
                ".......o..",
                "..oooooo..",
                ".........."}

               ), "found");
            eq(6, (new FoxAndGomoku()).win(new string[] {"..........",
                "..........",
                "..oooo.o..",
                "..o.......",
                "..o.......",
                "..o.oooo..",
                ".......o..",
                ".......o..",
                "..oooo.o..",
                ".........."}
               ), "not found");
            eq(7, (new FoxAndGomoku()).win(new string[] {"ooooo",
                "ooooo",
                "ooooo",
                "ooooo",
                "ooooo"}), "found");
            eq(8, (new FoxAndGomoku()).win(new string[] {".....",
                ".....",
                ".....",
                ".....",
                "....."}), "not found");
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

