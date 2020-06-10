using System;
namespace Longest_Common_Prefix
{
    class Program
    {
        static void Main(string[] args)
        {
            var strs = new string[]{"horse","honk","hope"};
            var prefix = LongestCommonPrefix(strs);
            Console.WriteLine($"Longest Common Prefix = {prefix}");
        }

        public static string LongestCommonPrefix(string[] strs) 
        {
            if (strs.Length == 0)
                return string.Empty;
            
            /*************************************************************/
            //Start from first char and keep increasing the index 
            //  as long as all the other string matches the character
            //  and no strings lenth is smaller than that
            /*************************************************************/
            for(int i=0; i<strs[0].Length; i++)
            {
                var checkChar = strs[0][i];
                for (int j=1; j<strs.Length; j++)
                {
                    if (i + 1 > strs[j].Length || checkChar != strs[j][i])
                        return strs[0].Substring(0, i);
                    
                }
            }
            return strs[0];
            
            /*************************************************************/
            //Start with first string as the prefix
            //Now keep matching the prefix with each string 
            //  and keep reducing the prefix length if they dont match with other strings
            /*************************************************************/
            /*
            var prefix = strs[0];
            for(int i=1; i<strs.Length; i++)
            {
                while(strs[i].IndexOf(prefix) != 0)
                    prefix = prefix.Substring(0, prefix.Length - 1);
                
                if (prefix.Length == 0)
                    return "";
            }
            
            return prefix;
            */
        }
    }
}
