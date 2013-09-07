// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class FoxPaintingBalls {
    public long theMax(long R, long G, long B, int N) {
        long mm = ((long)N * (N + 1) / 2);
        long m = mm / 3;
        if (m == 0)
            return R + G + B;

        long l = mm % 3;
        long sm = Math.Min(R, Math.Min(G, B));
        if (l > 0)
        {
            long k = sm / m;
            long d = R + G + B - k*m * 3;
            if (d < k)
            {
                return k - (k - d + mm-1) / mm;
            }
            else
                return k;
        }
        else
        {
            return sm / m;
        }
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new FoxPaintingBalls()).theMax(2L, 2L, 2L, 3),1L);
            eq(1,(new FoxPaintingBalls()).theMax(1L, 2L, 3L, 3),0L);
            eq(2,(new FoxPaintingBalls()).theMax(8L, 6L, 6L, 4),2L);
            eq(3,(new FoxPaintingBalls()).theMax(7L, 6L, 7L, 4),2L);
            eq(4,(new FoxPaintingBalls()).theMax(105L, 104L, 101L, 4),30L);
            eq(5,(new FoxPaintingBalls()).theMax(19330428391852493L, 48815737582834113L, 11451481019198930L, 3456),5750952686L);
            eq(6,(new FoxPaintingBalls()).theMax(1L, 1L, 1L, 1),3L);
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

