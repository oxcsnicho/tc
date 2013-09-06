// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class TomekPhone {
    public int minKeystrokes(int[] f, int[] ks) {
        int res = 0;
        // sort
        // find the key
        // increase res
        Array.Sort(f);
        Array.Reverse(f);
        Array.Sort(ks);
        Array.Reverse(ks);
        int[] k = new int[ks.Length];
        int j = 0;
        for (int i = 0; i < f.Length; )
        {
            if(j>=ks.Length)
                j = 0;
            if (k[j] < ks[j])
            {
                k[j]++;
                res += k[j] * f[i];
                i++;
                j++;
            }
            else
                if (j == 0)
                    return -1;
                else
                    j++;
        }
        return res;
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new TomekPhone()).minKeystrokes(new int[] {7,3,4,1}, new int[] {2,3}),19);
            eq(1,(new TomekPhone()).minKeystrokes(new int[] {13,7,4,20}, new int[] {2,1}),-1);
            eq(2,(new TomekPhone()).minKeystrokes(new int[] {11,23,4,50,1000,7,18}, new int[] {3,1,4}),1164);
            eq(3,(new TomekPhone()).minKeystrokes(new int[] {100,1000,1,10}, new int[] {50}),1234);
            eq(4,(new TomekPhone()).minKeystrokes(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50}, new int[] {10,10,10,10,10,10,10,10}),3353);
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

