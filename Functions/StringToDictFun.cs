using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndroidAPP02.Functions
{
    public class StringToDictFun
    {
            public Dictionary<string, string> StringToDict(string str)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                string key = null, value = null;
                int flag = 0;//0 input key,1 input value
                foreach (char i in str)
                {
                    if (i == '=')
                    {
                        flag = 1;
                    }
                    else if (i == '&')
                    {
                        flag = 0;
                        dict.Add(key, value);
                        key = null;
                        value = null;
                    }
                    else
                    {
                        if (flag == 0)
                        {
                            key += i;
                        }
                        else
                        {
                            value += i;
                        }
                    }
                }
                dict.Add(key, value);

                return dict;
            }
        }
    
}