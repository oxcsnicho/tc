// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class TheJediTestDiv2 {
    public int countSupervisors(int[] students, int Y, int J) {
        int res = 1000000;
        for (int i = 0; i < students.Length; i++)
        {
	    int ress = 0;
            for (int j = 0; j < students.Length; j++)
            {
                if (j != i)
                    ress += (students[j] + J - 1) / J;
                else
                    ress += Math.Max((students[j] - Y + J - 1) / J, 0);
            }
            if (ress < res)
                res = ress;
        }
        return res;
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new TheJediTestDiv2()).countSupervisors(new int[] {10, 15}, 12, 5),3);
            eq(1,(new TheJediTestDiv2()).countSupervisors(new int[] {11, 13, 15}, 9, 5),7);
            eq(2,(new TheJediTestDiv2()).countSupervisors(new int[] {10}, 100, 2),0);
            eq(3,(new TheJediTestDiv2()).countSupervisors(new int[] {0, 0, 0, 0, 0}, 145, 21),0);
            eq(4,(new TheJediTestDiv2()).countSupervisors(new int[] {4, 7, 10, 5, 6, 55, 2}, 20, 3),26);
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

