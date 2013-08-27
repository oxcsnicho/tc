import java.util.*;
public class TheExperimentDiv2 {
    public int[] determineHumidity(int[] intensity, int L, int[] leftEnd) {
        int[] res = new int[leftEnd.length];

        for(int i=0;i<leftEnd.length;i++)
            res[i] = 0;
        for(int i=0;i<leftEnd.length;i++)
        {
            for(int j=0;j<L;j++)
            {
                res[i] += intensity[leftEnd[i]+j];
                intensity[leftEnd[i]+j] = 0;
            }
        }
        return res;
    }

}


// Powered by FileEdit
// Powered by CodeProcessor
