import java.util.*;
public class GUMIAndSongsDiv2 {
    public int maxSongs(int[] duration, int[] tone, int T) {
        for(int i=0;i<tone.length;i++)
            for(int j=tone.length-1;j>i;j--)
                if(tone[i]>tone[j])
                {
                    int a = tone[i];
                    tone[i] = tone[j];
                    tone[j] = a;
                    a = duration[i];
                    duration[i] = duration[j];
                    duration[j] = a;
                }
        int res= 0;
        for(int i=0;i<tone.length;i++)
            for(int j=i;j<tone.length;j++)
            {
                int avail = T-tone[j]+tone[i];
                int[] dd = new int[j-i+1];
                System.arraycopy(duration, i, dd, 0, j-i+1);
                Arrays.sort(dd);
                int ress = 0;
                for(ress = 0;ress<dd.length;ress++)
                    if(avail>=dd[ress])
                        avail -= dd[ress];
                    else
                        break;
                if(ress > res)
                    res = ress;
            }
        return res;
    }

}


// Powered by FileEdit
// Powered by CodeProcessor
