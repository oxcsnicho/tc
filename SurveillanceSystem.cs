// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class SurveillanceSystem {
    public string getContainerInfo(string containers, int[] reports, int L) {
        char[] res = new char[containers.Length];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = '-';
        }
        int[] pos = new int[containers.Length - L + 1];
        for (int i = 0; i < pos.Length; i++)
        {
            for (int j = 0; j < L; j++)
            {
                pos[i] += containers[i + j] == 'X' ? 1 : 0;
            }
        }
        // BEGIN CUT HERE
        print(pos);
        // END CUT HERE
        Dictionary<int, int> d = new Dictionary<int, int>();
        for (int i = 0; i < reports.Length; i++)
        {
            if (d.ContainsKey(reports[i]))
                d[reports[i]]++;
            else
                d[reports[i]] = 1;
        }
        foreach (var item in d)
        {
            List<int> ind = new List<int>();
            for (int i = 0; i < pos.Length; i++)
            {
                if (pos[i] == item.Key)
                    ind.Add(i);
            }
            //find all occurances
            int[] tmp = new int[containers.Length];
            Array.Clear(tmp, 0, tmp.Length);
            for (int i = 0; i < ind.Count; i++)
            {
                for (int j = 0; j < L; j++)
                {
                    tmp[ind[i] + j]++;
                }
            }
            // BEGIN CUT HERE
            print(tmp);
            // END CUT HERE
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] >= ind.Count - item.Value + 1)
                {
                    if (res[i] != '+')
                        res[i] = '+';
                }
                else if (tmp[i] > 0)
                {
                    if (res[i] == '-')
                        res[i] = '?';
                }
            }
            // BEGIN CUT HERE
            print(res);
            // END CUT HERE
            // reflect to temp map
            // calculate temp result
            // consolidate into all result
        }
        return new string(res);
    }

// BEGIN CUT HERE
    static List<int> cases = new List<int> { };
    public static void Test() {
        try  {
            eq(0,(new SurveillanceSystem()).getContainerInfo("-X--XX", new int[] {1, 2}, 3),"??++++");
            eq(1,(new SurveillanceSystem()).getContainerInfo("-XXXXX-", new int[] {2}, 3),"???-???");
            eq(2,(new SurveillanceSystem()).getContainerInfo("------X-XX-", new int[] {3, 0, 2, 0}, 5),"++++++++++?");
            eq(3,(new SurveillanceSystem()).getContainerInfo("-XXXXX---X--", new int[] {2, 1, 0, 1}, 3),"???-??++++??");
            eq(4,(new SurveillanceSystem()).getContainerInfo("-XX--X-XX-X-X--X---XX-X---XXXX-----X", new int[] {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}, 7),"???++++?++++++++++++++++++++??????--");
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

