// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class UndoHistory {
    public int minPresses(string[] lines) {
        int[] px = new int[lines.Length];
        Array.Clear(px, 0, px.Length);
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int k = 0;
                while (k < lines[i].Length && k < lines[j].Length && lines[i][k] == lines[j][k]) k++;
                px[i] = Math.Max(px[i], k);
            }
        }
        int res = lines[0].Length+1;
        //for each of the rest, either continue typing or select and continue
        for (int i = 1; i < lines.Length; i++)
        {
            int ress = lines[i].Length + 3 - px[i];
            if (lines[i].Length >= lines[i - 1].Length
                && lines[i].Substring(0, lines[i - 1].Length) == lines[i - 1])
                ress = Math.Min(ress, lines[i].Length - lines[i - 1].Length + 1);
            res += ress;
        }
        return res;
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new UndoHistory()).minPresses(new string[] {"tomorrow", "topcoder"}),18);
            eq(1,(new UndoHistory()).minPresses(new string[] {"a","b"}),6);
            eq(2,(new UndoHistory()).minPresses(new string[] {"a", "ab", "abac", "abacus" }),10);
            eq(3,(new UndoHistory()).minPresses(new string[] {"pyramid", "sphinx", "sphere", "python", "serpent"}),39);
            eq(4,(new UndoHistory()).minPresses(new string[] {"ba","a","a","b","ba"}
               ),13);
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

