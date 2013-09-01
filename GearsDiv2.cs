using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class GearsDiv2
{
    public int getmin(string Directions)
    {
        if (Directions.Length == 1)
            return 0;
        if (Directions[0] == Directions[Directions.Length - 1])
            return Math.Min(getmin1(Directions.Substring(0, Directions.Length - 1)),
                getmin1(Directions.Substring(1, Directions.Length - 1))) + 1;
        return getmin1(Directions);
    }
    public int getmin1(string Directions)
    {
        int[] F = new int[Directions.Length];
        Array.Clear(F, 0, F.Length);
        F[0] = 0;
        F[1] = Directions[0] == Directions[1] ? 1 : 0;
        for (int i = 2; i < F.Length; i++)
        {
            if (Directions[i] != Directions[i - 1])
                F[i] = F[i - 1];
            else
                F[i] = Math.Min(F[i - 1], F[i - 2]) + 1;
        }
        return F[F.Length - 1];
    }

}



// Powered by FileEdit
// Powered by CodeProcessor
