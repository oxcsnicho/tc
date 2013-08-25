// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

public class IDNumberVerification
{
    public string verify(string id, string[] regionCodes)
    {
        string r = id.Substring(0, 6);
        List<string> rr = new List<string>(regionCodes);
        if (!rr.Exists((a) => a == r))
            return "Invalid";

        DateTime dt;
        try
        {
            dt = DateTime.ParseExact(id.Substring(6, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
            if (dt < DateTime.Parse("1900-1-1") || dt >= DateTime.Parse("2012-1-1"))
                return "Invalid";
        }
        catch
        {
            return "Invalid";
        }

        string res;
        string s = id.Substring(14, 3);
        if (s == "000")
            return "Invalid";
        if ((s[2] - '0') % 2 == 0)
            res = "Female";
        else
            res = "Male";

        int sum = 0;
        for (int i = 0; i < 17; i++)
        {
            sum += (id[i] - '0') % 11;
            sum *= 2;
            sum %= 11;
        }
        sum = 12 - sum;
        sum %= 11;
        if (sum == 10 && id[17] == 'X')
            return res;
        else if (id[17] == '0' + sum)
            return res;
        else
            return "Invalid";
    }

    // BEGIN CUT HERE
    public static void Test()
    {
        try
        {
            eq(0, (new IDNumberVerification()).verify("441323200312060636", new string[] { "441323" }), "Male");
            eq(1, (new IDNumberVerification()).verify("62012319240507058X", new string[] { "620123" }), "Female");
            eq(2, (new IDNumberVerification()).verify("321669197204300886", new string[] { "610111", "659004" }), "Invalid");
            eq(3, (new IDNumberVerification()).verify("230231198306900162", new string[] { "230231" }), "Invalid");
            eq(4, (new IDNumberVerification()).verify("341400198407260005", new string[] { "341400" }), "Invalid");
            eq(5, (new IDNumberVerification()).verify("520381193206090891", new string[] { "532922", "520381" }), "Invalid");
        }
        catch (Exception exx)
        {
            System.Console.WriteLine(exx);
            System.Console.WriteLine(exx.StackTrace);
        }
    }
    private static void eq(int n, object have, object need)
    {
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

