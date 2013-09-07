// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class CuttingBitString {
    public int getmin(string S) {
        List<string> dict = new List<string>();
        Int64 p5 = 1;
        while(p5< (1L<<51))
        {
            dict.Add(Convert.ToString(p5, 2));
            p5 *= 5;
        }
        d = dict.ToArray();
        Array.Reverse(d);
        int res = isp5(S);
        return res == 51 ? -1 : res;
    }
    string[] d;
    int isp5(string s)
    {
        if (s == "")
            return 0;
        int ress = 51;
        for (int i = 0; i < d.Length; i++)
        {
            if (d[i].Length <= s.Length)
                if (s.Substring(0, d[i].Length) == d[i])
                    ress = Math.Min(ress, isp5(s.Substring(d[i].Length)) + 1);
        }
        return ress;
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0, (new CuttingBitString()).getmin("11111111111111111111111111111111111111111111111111"), 50);
            eq(1,(new CuttingBitString()).getmin("1111101"),1);
            eq(2,(new CuttingBitString()).getmin("00000"),-1);
            eq(3,(new CuttingBitString()).getmin("110011011"),3);
            eq(4,(new CuttingBitString()).getmin("1000101011"),-1);
            eq(5,(new CuttingBitString()).getmin("111011100110101100101110111"),5);
        } 
        catch( Exception exx)  {
            System.Console.WriteLine(exx);
            System.Console.WriteLine( exx.StackTrace);
        }
    }
    private static void eq( int n, object have, object need) {
        if (cases != null && cases.Count > 0)
            if (!cases.Exists((a) => a == n))
                return;
        if( eq( have, need ) ) {
            Debug.WriteLine( "Case "+n+" passed." );
        } else {
            Debug.Write( "Case "+n+" failed: expected " );
            print( need );
            Debug.Write( ", received " );
            print( have );
            Debug.WriteLine("");
        }
    }
    private static void eq( int n, Array have, Array need) {
        if (cases != null && cases.Count > 0)
            if (!cases.Exists((a) => a == n))
                return;
        if( have == null || have.Length != need.Length ) {
            Debug.WriteLine("Case "+n+" failed: returned "+have.Length+" elements; expected "+need.Length+" elements.");
            print( have );
            print( need );
            return;
        }
        for( int i= 0; i < have.Length; i++ ) {
            if( ! eq( have.GetValue(i), need.GetValue(i) ) ) {
                Debug.WriteLine( "Case "+n+" failed. Expected and returned array differ in position "+i );
                print( have );
                print( need );
                return;
            }
        }
        Debug.WriteLine("Case "+n+" passed.");
    }
    private static bool eq( object a, object b ) {
        if ( a is double && b is double ) {
            return Math.Abs((double)a-(double)b) < 1E-9;
        } else {
            return a!=null && b!=null && a.Equals(b);
        }
    }
    private static void print( object a ) {
        if ( a is string ) {
            Debug.Write(string.Format("\"{0}\"", a));
        } else if ( a is long ) {
            Debug.Write(string.Format("{0}L", a));
        } else {
            Debug.Write(a);
        }
    }
    private static void print( Array a ) {
        if ( a == null) {
            Debug.WriteLine("<NULL>");
        }
        Debug.Write('{');
        for ( int i= 0; i < a.Length; i++ ) {
            print( a.GetValue(i) );
            if( i != a.Length-1 ) {
                Debug.Write(", ");
            }
        }
        Debug.WriteLine( '}' );
    }
// END CUT HERE
}

