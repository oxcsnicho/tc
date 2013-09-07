// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class ColorfulChocolates {
    public int maximumSpread(string c, int m) {
        int res = 0;
        for (int i = 0; i < c.Length; i++)
        {
            for (int n = 0; n <=m; n++)
            {
                // find max spread from left with n swaps
                int edge = i;
                int nr = n;
                for (int j = i-1; j >= 0; j--)
                {
                    if (c[j] == c[i])
                    {
                        nr -= edge-j-1;
                        if (nr <0)
                            break;
                        edge--;
                    }
                }
                int a = i - edge;
                // find max spread from rigth with m-n swaps
                edge = i;
                nr = m-n;
                for (int j = i+1; j <c.Length; j++)
                {
                    if (c[j] == c[i])
                    {
                        nr -= j-edge-1;
                        if (nr <0)
                            break;
                        edge++;
                    }
                }
                int b = edge-i;
                // a+b+1
                res = Math.Max(res, a + b + 1);
            }
        }
        return res;
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new ColorfulChocolates()).maximumSpread("ABCDCBC", 1),2);
            eq(1,(new ColorfulChocolates()).maximumSpread("ABCDCBC", 2),3);
            eq(2,(new ColorfulChocolates()).maximumSpread("ABBABABBA", 3),4);
            eq(3,(new ColorfulChocolates()).maximumSpread("ABBABABBA", 4),5);
            eq(4,(new ColorfulChocolates()).maximumSpread("QASOKZNHWNFODOQNHGQKGLIHTPJUVGKLHFZTGPDCEKSJYIWFOO", 77),5);
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

