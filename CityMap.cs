// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class CityMap
{
    public string getLegend(string[] cityMap, int[] POIs)
    {
        string res = "";
        Dictionary<char, int> a = new Dictionary<char, int>();
        foreach (var item in cityMap)
        {
            foreach (var i in item)
            {
                if (i != '.')
                    a[i] = a.ContainsKey(i) ? a[i] + 1 : 1;
            }
        }
        for (int i = 0; i < POIs.Length; i++)
        {
            res += a.FirstOrDefault((x) => x.Value == POIs[i]).Key;
        }
        return res;
    }

    // BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test()
    {
        try
        {
            eq(0, (new CityMap()).getLegend(new string[] {"M....M",
                "...R.M",
                "R..R.R"}, new int[] { 3, 4 }), "MR");
            eq(1, (new CityMap()).getLegend(new string[] { "XXXXXXXZXYYY" }, new int[] { 1, 8, 3 }), "ZXY");
            eq(2, (new CityMap()).getLegend(new string[] {"...........",
                "...........",
                "...........",
                "..........T"}, new int[] { 1 }), "T");
            eq(3, (new CityMap()).getLegend(new string[] {"AIAAARRI.......GOAI.",
                ".O..AIIGI.OAAAGI.A.I",
                ".A.IAAAARI..AI.AAGR.",
                "....IAI..AOIGA.GAIA.",
                "I.AIIIAG...GAR.IIAGA",
                "IA.AOA....I....I.GAA",
                "IOIGRAAAO.AI.AA.RAAA",
                "AI.AAA.AIR.AGRIAAG..",
                "AAAAIAAAI...AAG.RGRA",
                ".J.IA...G.A.AA.II.AA"}
               , new int[] { 16, 7, 1, 35, 11, 66 }
               ), "GOJIRA");
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

