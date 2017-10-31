using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndroidAPP02.Functions
{
    public class IntToStringFun
    {
        public string IntToString(int num)
        {
            string str = null;
            int n = 0, i = 0;
            while(i<6)
            {
                n = n * 10 + num % 10;
                num = num / 10;
                i++;
            }
            i = 0;
            while(n>0)
            {
                str += (char)(n % 10 + 48);
                n = n / 10;
            }
            str += (char)0;
            return str;
        }
    }
}