import java.util.*;
public class EllysNewNickname {
    public int getLength(String nickname) {
        int res= 0;
        char[] s =nickname.toCharArray();
        char last = 0;
        for(int i=0;i<s.length;i++)
        {
            if(isv(s[i]) && isv(last))
            {
                continue;
            }
            res ++;
            last = s[i];
        }
        return res;
    }
    public boolean isv(char a)
    {
        return a == 'a' 
                    || a == 'e'
                    || a == 'i'
                    || a == 'o'
                    || a == 'u'
                    || a == 'y';
    }


}


// Powered by FileEdit
// Powered by CodeProcessor
