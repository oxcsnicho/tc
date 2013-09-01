// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class SpaceWarDiv2 {
    public int minimalFatigue(int[] mg, int[] es, int[] ec) {
        int[] fg = new int[mg.Length];
        Array.Clear(fg,0,fg.Length);
        // sort es
        Array.Sort(es, ec);
        Array.Sort(mg);
        Array.Reverse(mg);
        Array.Reverse(es);
        Array.Reverse(ec);
        // BEGIN CUT HERE
        print(mg);
        print(es);
        print(ec);
        // END CUT HERE
        // foreach es
        for (int i = 0; i < es.Length; i++)
        {
            int k=-1;
            int t =0;
            for (int j = 0; j < mg.Length; j++)
            {
                if (mg[j] >=es[i])
                {
                    k = j;
                    t+=fg[j];
                }
            }
            if(k==-1)
                return -1;
            int tt = (t + ec[i] + k) / (k + 1);
            for (int j = 0; j <= k; j++)
            {
                if (ec[i] > 0 && tt>=fg[j])
                {
                    int del = Math.Min(ec[i], tt - fg[j]);
                    ec[i] -= del;
                    fg[j] += del;
                }
            }
            // BEGIN CUT HERE
            print(fg);
            // END CUT HERE
        }
        // find applicable mg
        // distribute gf
        //find max fatigue
        int res = 0;
        for (int i = 0; i < fg.Length; i++)
        {
            res = Math.Max(res, fg[i]);
        }
        return res;
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new SpaceWarDiv2()).minimalFatigue(new int[] {1, 1,1}, new int[] {1, 1, 1}, new int[] {100, 9, 4}),37);
            eq(1,(new SpaceWarDiv2()).minimalFatigue(new int[] {2, 3, 5}, new int[] {1, 1, 2}, new int[] {2, 9, 4}),5);
            eq(2,(new SpaceWarDiv2()).minimalFatigue(new int[] {14, 6, 22}, new int[] {8, 33}, new int[] {9, 1}),-1);
            eq(3,(new SpaceWarDiv2()).minimalFatigue(new int[] {17, 10, 29, 48, 92, 60, 80, 100, 15, 69, 36, 43, 70, 14, 88, 12, 14, 29, 9, 40}, new int[] {93, 59, 27, 68, 48, 82, 15, 95, 61, 49, 68, 15, 16, 26, 64, 82, 7, 8, 92, 15}, new int[] {56, 26, 12, 52, 5, 19, 93, 36, 69, 61, 68, 66, 55, 28, 49, 55, 63, 57, 33, 45}),92);
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

