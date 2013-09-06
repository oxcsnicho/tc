using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class TheSquareRootDilemma {
    public int countPairs(int N, int M) {
        List<int> sql = new List<int>();
        for (int i = 1; i*i <=Math.Max(M,N); i++)
            sql.Add(i * i);
        int[] sq = sql.ToArray();

        int res= 0;
        for (int k =1; k <= N; k++)
        {
            int l = k;
            for (int i = 1; i < sq.Length && sq[i]<=l; )
            {
                if (l % sq[i] == 0)
                    l /= sq[i];
                else
                    i++;
            }

            int j = 0;
            while (j<sq.Length && sq[j] * l <= M) j++;
            res += j;
        }
	//for each k in N
	// find l
	// find nr of matching l
	// add number
        return res;
    }

}



// Powered by FileEdit
// Powered by CodeProcessor
