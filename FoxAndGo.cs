// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class FoxAndGo
{
    public int maxKill(string[] board)
    {
        mark = new int[board.Length, board[0].Length];
        map = board;
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                mark[i, j] = -1;
            }
        }

        int label = 0;
        List<int> n = new List<int>();
        List<pair> comp = new List<pair>();
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (map[i][j] == 'o' && mark[i, j] == -1)
                {
                    int ress = dfs(i, j, label);
                    comp.Add(new pair(i, j));
                    n.Add(ress);
                    label++;
                }
            }
        }

        int[] nr = new int[comp.Count];
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (map[i][j] == '.')
                {
                    HashSet<int> h = new HashSet<int>();
                    for (int k = 0; k < 4; k++)
                    {
                        int x = i + dx[k];
                        int y = j + dy[k];
                        if (!(x < 0 || y < 0 || x >= map.Length || y >= map[0].Length) && mark[x, y] > -1)
                            h.Add(mark[x, y]);
                    }
                    foreach (var item in h)
                    {
                        nr[item] ++;
                    }
                }
            }
        }

        // BEGIN CUT HERE
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                print(mark[i, j].ToString());
            }
            print("\n");
        }
        print(n.ToArray());
        print(nr);
        print("\n");
        // END CUT HERE

        int res=0;
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (map[i][j] == '.')
                {
                    int ress = 0;
                    HashSet<int> h = new HashSet<int>();
                    for (int k = 0; k < 4; k++)
                    {
                        int x = i + dx[k];
                        int y = j + dy[k];
                        if (!(x < 0 || y < 0 || x >= map.Length || y >= map[0].Length) && mark[x, y] > -1)
                            h.Add(mark[x, y]);
                    }
                    foreach (var item in h)
                    {
                        if (nr[item] ==1)
                            ress += n[item];
                    }
                    res = Math.Max(res, ress);
                }
            }
        }
        for (int i = 0; i < n.Count; i++)
        {
            if (nr[i] == 0)
                res += n[i];
        }
        return res;
    }

    public class pair
    {
        public int cnt { get; set; }
        public int adj { get; set; }
        public pair(int a, int b)
        {
            cnt = a;
            adj = b;
        }
    }

    int[] dx = { 1, 0, -1, 0 };
    int[] dy = { 0, 1, 0, -1 };
    int[,] mark;
    string[] map;
    int dfs(int x, int y, int label)
    {
        if (x < 0 || y < 0 || x >= map.Length || y >= map[0].Length)
            return 0;
        if (mark[x, y] > -1)
            return 0;
        if (map[x][y] != 'o')
            return 0;

        mark[x, y] = label;

        int res = 0;
        for (int i = 0; i < 4; i++)
        {
            res += dfs(x + dx[i], y + dy[i], label);
        }
        return res + 1;

    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new FoxAndGo()).maxKill(new string[] {".....",
                "..x..",
                ".xox.",
                ".....",
                "....."}
               ), 1);
            eq(1, (new FoxAndGo()).maxKill(new string[] {"ooooo",
                "xxxxo",
                "xxxx.",
                "xxxx.",
                "ooooo"}
               ), 6);
            eq(2, (new FoxAndGo()).maxKill(new string[] {".xoxo",
                "ooxox",
                "oooxx",
                "xoxox",
                "oxoox"}
               ), 13);
            eq(3, (new FoxAndGo()).maxKill(new string[] {".......",
                ".......",
                ".......",
                "xxxx...",
                "ooox...",
                "ooox...",
                "ooox..."}
               ), 9);
            eq(4, (new FoxAndGo()).maxKill(new string[] {".......",
                ".xxxxx.",
                ".xooox.",
                ".xo.ox.",
                ".xooox.",
                ".xxxxx.",
                "......."}
               ), 8);
            eq(5, (new FoxAndGo()).maxKill(new string[] {"o.xox.o",
                "..xox..",
                "xxxoxxx",
                "ooo.ooo",
                "xxxoxxx",
                "..xox..",
                "o.xox.o"}
               ), 12);
            eq(6, (new FoxAndGo()).maxKill(new string[] {".......",
                "..xx...",
                ".xooox.",
                ".oxxox.",
                ".oxxxo.",
                "...oo..",
                "......."}), 4);
            eq(7, (new FoxAndGo()).maxKill(new string[] {".ox....",
                "xxox...",
                "..xoox.",
                "..xoox.",
                "...xx..",
                ".......",
                "......."}
                ), 5);
            eq(8, (new FoxAndGo()).maxKill(new string[] {"...................",
                "...................",
                "...o..........o....",
                "................x..",
                "...............x...",
                "...................",
                "...................",
                "...................",
                "...................",
                "...................",
                "...................",
                "...................",
                "...................",
                "...................",
                "................o..",
                "..x................",
                "...............x...",
                "...................",
                "..................."}
               ), 0);
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

