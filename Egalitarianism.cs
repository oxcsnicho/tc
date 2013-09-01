// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Egalitarianism {
    public int maxDifference(string[] isFriend, int d) {
        map = isFriend;
        int res = 0;
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = i+1; j < map.Length; j++)
            {
                res = Math.Max(res, bfs(i, j));
            }
        }
        return res == map.Length + 3 ? -1 : res * d;
    }

    string[] map;
    int bfs(int i, int j)
    {
        int[] mark = new int[map.Length];
        for (int k = 0; k < mark.Length; k++)
        {
            mark[k] = -1;
        }
        List<int> q = new List<int>();
        q.Add(i);
        mark[i] = 0;
        while (q.Count > 0)
        {
            for (int k = 0; k < map[q[0]].Length; k++)
            {
                if (q[0]!=k && map[q[0]][k] == 'Y' && mark[k] == -1)
                {
                    if (k == j)
                        return mark[q[0]]+1;
                    q.Add(k);
                    mark[k] = mark[q[0]]+1;
                }
            }
            q.RemoveAt(0);
        }
        return map.Length+3;
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

