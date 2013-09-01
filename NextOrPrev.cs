// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class NextOrPrev {
    public int getMinimum(int nextCost, int prevCost, string start, string goal) {
        int res=0;
        for (int i = 0; i < start.Length; i++)
        {
            for (int j = i+1; j < start.Length; j++)
            {
                if (Math.Min(start[i], goal[i]) < Math.Min(start[j], goal[j])
                && Math.Max(start[i], goal[i]) > Math.Max(start[j], goal[j])
                || Math.Max(start[i], goal[i]) < Math.Max(start[j], goal[j])
                && Math.Min(start[i], goal[i]) > Math.Min(start[j], goal[j]))
                    return -1;
                if (start[i] <= goal[j] && goal[j] < goal[i] && goal[i] <= start[j]
                || start[j] <= goal[i] && goal[i] < goal[j] && goal[j] <= start[i]
                || goal[i] <= start[j] && start[j] < start[i] && start[i] <= goal[j]
                || goal[j] <= start[i] && start[i] < start[j] && start[j] <= goal[i])
                    return -1;

            }
            if (goal[i] < start[i])
                res += prevCost * (start[i] - goal[i]);
            else
                res += nextCost * (-start[i] + goal[i]);
        }
        return res;
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new NextOrPrev()).getMinimum(5, 8, "dc", "ab"),-1);
            eq(1,(new NextOrPrev()).getMinimum(5, 8, "ae", "cb"),-1);
            eq(2,(new NextOrPrev()).getMinimum(1, 1, "srm", "srm"),0);
            eq(3,(new NextOrPrev()).getMinimum(10, 1, "acb", "bdc"),30);
            eq(4,(new NextOrPrev()).getMinimum(10, 1, "zyxw", "vuts"),16);
            eq(5,(new NextOrPrev()).getMinimum(563, 440, "ptrbgcnlaizo", "rtscedkiahul"),10295);
            eq(6,(new NextOrPrev()).getMinimum(126, 311, "yovlkwpjgsna", "zpwnkytjisob"),-1);
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

