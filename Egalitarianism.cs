// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

public class Egalitarianism {
    public int maxDifference(string[] isFriend, int d) {
        int res = 0;
        for (int i = 0; i < isFriend.Length; i++)
        {
            for (int j = i+1; j < isFriend.Length; j++)
            {
                int dist = bfs(isFriend, i, j);
                if (dist == -1 || dist>res && res !=-1)
                    res = dist;
            } 
        }
        return res > 0 ? res * d : res;
    }

    private int bfs(string[] isFriend, int i, int j)
    {
        if (i == j)
            return 0;
        int n = isFriend.Length;
        int[] v = new int[n];
        for (int k = 0; k < n; k++)
        {
            v[k] = -1;
        }
        List<int> q = new List<int>();
        q.Add(i);
        v[i] = 0;
        while (q.Count > 0)
        {
            for (int k = 0; k < n; k++)
            {
                if (v[k] == -1 && isFriend[q[0]][k] == 'Y')
                {
                    q.Add(k);
                    v[k] = v[q[0]] + 1;
                    if (k == j)
                        return v[k];
                }
            }
            q.RemoveAt(0);
        }
        return -1;
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new Egalitarianism()).maxDifference(new string[] {"NYN",
                "YNY",
                "NYN"}, 10),20);
            eq(1,(new Egalitarianism()).maxDifference(new string[] {"NN",
                "NN"}, 1),-1);
            eq(2,(new Egalitarianism()).maxDifference(new string[] {"NNYNNN",
                "NNYNNN",
                "YYNYNN",
                "NNYNYY",
                "NNNYNN",
                "NNNYNN"}, 1000),3000);
            eq(3,(new Egalitarianism()).maxDifference(new string[] {"NNYN",
                "NNNY",
                "YNNN",
                "NYNN"}, 584),-1);
            eq(4,(new Egalitarianism()).maxDifference(new string[] {"NYNYYYN",
                "YNNYYYN",
                "NNNNYNN",
                "YYNNYYN",
                "YYYYNNN",
                "YYNYNNY",
                "NNNNNYN"}, 5),20);
            eq(5,(new Egalitarianism()).maxDifference(new string[] {"NYYNNNNYYYYNNNN",
                "YNNNYNNNNNNYYNN",
                "YNNYNYNNNNYNNNN",
                "NNYNNYNNNNNNNNN",
                "NYNNNNYNNYNNNNN",
                "NNYYNNYNNYNNNYN",
                "NNNNYYNNYNNNNNN",
                "YNNNNNNNNNYNNNN",
                "YNNNNNYNNNNNYNN",
                "YNNNYYNNNNNNNNY",
                "YNYNNNNYNNNNNNN",
                "NYNNNNNNNNNNNNY",
                "NYNNNNNNYNNNNYN",
                "NNNNNYNNNNNNYNN",
                "NNNNNNNNNYNYNNN"}
               , 747),2988);
            eq(6,(new Egalitarianism()).maxDifference(new string[] {"NY",
                "YN"}, 0),0);
            eq(7, (new Egalitarianism()).maxDifference(new string[] { "NNNYNNNNNNNNNNNNNNNNNNNNNNYNNYNNNNNNNNNNNYNNNY",
                "NNNNNNNYNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNYN", "NNNNNNNNNNYNNNYNNNNNNNNNYNNNNNNNNNNNNNNNNNNNYN", "YNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNYNNNNNNYNNYN", "NNNNNNNNNNNNNYNYNNNNYNNNNNNNNNNNYNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNYNNYNNNNNNNNYNYNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNYNNNNNNNNNNNNNNNNNNNNNN", "NYNNNNNNNNNNNYNNNNNNNYNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNYNNYNNNNNNNNNNNNNYNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNYNNNNNNNNNNNNNNNNNNYNNNNYNNNNNNNNYNNYNNNNNNN", "NNNNNNNNNNNNYNNNNNNNNNNNNNNNNNYNNNNNNYNYNNNNNN", "NNNNNNNNNNNYNNYNNNNYNNNNNNNNNNNNNNNNNNNYNNNNNN", "NNNNYNNYYNNNNNNNNNNNNNNNNNNYNNNNNNNNNNNNNNNNNN", "NNYNNNNNNNNNYNNNNNNNNNNNNNNNNNNNNNNNYNNNNNNNNN", "NNNNYNNNNNNNNNNNNNNNNNYNNNNNNNYYNNNNNNNNNNNNNN", "NNNNNNNNYNNNNNNNNNYYNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNYNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNYNNNNNNNNNNNYNNYNNNNYNNNNNNNNN", "NNNNNYNNNNNNYNNNYNNNNNNNNNNNNNYNNNNNNNNYNNNNNN", "NNNNYNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNY", "NNNNNNNYNNYNNNNNNNNNNNNNNNNNNNYNNNNNNNNNNNNNNN", "NNNNNYNNNNNNNNNYNNNNNNNNNNNNNNNNNNNNNNNNNNNYNN", "NNNNNNYNNNNNNNNNNNNNNNNNNNNNNNNYNNNYNNNNNNYNNN", "NNYNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "YNNNNNNNNNYNNNNNNNNNNNNNNNNNNNNNNYNNNNNNNNNNNN", "NNNNNNNNNNNNNYNNNNNNNNNNNNNNYNNNNNNNNNNNNNNYNN", "NNNNNNNNNNNNNNNNNNYNNNNNNNNYNYNNNNNNNNNNNNNNNN", "YNNNNNNNNNNNNNNNNYNNNNNNNNNNYNNNNNNNNNNNNNNYNN", "NNNNNNNNYNNYNNNYNNNYNYNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNYNNNNNNNNNYNNYNNNNYNNNNNNNNNNYNNNNNNNNNNN", "NNNNYNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNYNNNNNNNNNNNNNNNNNNNNYNNNNNNNNNNNNNNNYNNN", "NNNYNNNNNNNNNNNNNNNNNNNNNNNNNNNYNNNNNNNNNNNNNN", "NNNNNNNNNNYNNNNNNNNNNNNYNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNYNNNYNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNYNNNNNNNNNNNNNNNNNNNNNNNNNNNNYNNNNN", "NNNNNNNNNNYNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNYYNNNNNNYNNNNNNNNNNNNNNNNNNNNNNNNNN", "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNYNNNNNNNN", "YNNYNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNYNNN", "NNNNNNNNNNNNNNNNNNNNNNNYNNNNNNNNNYNNNNNNNYNNNN", "NNNNNNNNNNNNNNNNNNNNNNYNNNNYNYNNNNNNNNNNNNNNNN", "NYYYNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN",
                "YNNNNNNNNNNNNNNNNNNNYNNNNNNNNNNNNNNNNNNNNNNNNN" },
                931), -1 );
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

