// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class MonstersValley2 {
    public int minimumPrice(int[] dread, int[] price) {
        d = dread;
        p = price;
        return rec(0, 0);
    }

    int[] d;
    int[] p;
    int rec(int i, long dr)
    {
        if (i == d.Length)
            return 0;
        int res = rec(i+1, dr+d[i]) + p[i];
        if (d[i] < dr)
            res = Math.Min(res, rec(i + 1, dr));
        return res;
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new MonstersValley2()).minimumPrice(new int[] {19999991,19999992,19999993,19999994,19999995,19999995,19999997,19999998,19999999,20000000}, new int[] {1, 1, 1,1,1,1,1,1,1,1}),2);
            eq(1,(new MonstersValley2()).minimumPrice(new int[] {1, 2, 4, 1000000000}, new int[] {1, 1, 1, 2}),5);
            eq(2,(new MonstersValley2()).minimumPrice(new int[] {200, 107, 105, 206, 307, 400}, new int[] {1, 2, 1, 1, 1, 2}),2);
            eq(3,(new MonstersValley2()).minimumPrice(new int[] {5216, 12512, 613, 1256, 66, 17202, 30000, 23512, 2125, 33333}, new int[] {2, 2, 1, 1, 1, 1, 2, 1, 2, 1}),5);
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

