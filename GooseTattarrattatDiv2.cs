// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class GooseTattarrattatDiv2 {
    public int getmin(string S) {
        var a = S.ToCharArray();
        Dictionary<char, int> b = new Dictionary<char, int>();
        foreach (var item in a)
        {
            if (b.ContainsKey(item))
                b[item]++;
            else
                b[item] = 1;
        }
        int res = 0;
        foreach (var item in b)
        {
            if (res < item.Value)
                res = item.Value;
        }

        return S.Length - res;
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new GooseTattarrattatDiv2()).getmin("geese"),2);
            eq(1,(new GooseTattarrattatDiv2()).getmin("tattarrattat"),6);
            eq(2,(new GooseTattarrattatDiv2()).getmin("www"),0);
            eq(3,(new GooseTattarrattatDiv2()).getmin("topcoder"),6);
            eq(4,(new GooseTattarrattatDiv2()).getmin("xrepayuyubctwtykrauccnquqfuqvccuaakylwlcjuyhyammag"),43);
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

