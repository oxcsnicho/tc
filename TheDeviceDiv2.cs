// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class TheDeviceDiv2 {
    public string identify(string[] plates) {
        for (int i = 0; i < plates[0].Length; i++)
        {
            int a = 0, b = 0;
            for (int j = 0; j < plates.Length; j++)
            {
                if (plates[j][i] == '0')
                    a++;
                else
                    b++;
            }
            if (a < 1 || b < 2)
                return "NO";
        }
        return "YES";
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new TheDeviceDiv2()).identify(new string[] {"010",
                "011",
                "000"}),"NO");
            eq(1,(new TheDeviceDiv2()).identify(new string[] {"1",
                "0",
                "1",
                "0"}),"YES");
            eq(2,(new TheDeviceDiv2()).identify(new string[] {"11111"}
               ),"NO");
            eq(3,(new TheDeviceDiv2()).identify(new string[] {"0110011",
                "0101001",
                "1111010",
                "1010010"}),"NO");
            eq(4,(new TheDeviceDiv2()).identify(new string[] {"101001011",
                "011011010",
                "010110010",
                "111010100",
                "111111111"}),"YES");
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

