class QuickStart {
    public static void main(String[] args) {
        String[] strs = new String[]{"horse","honk","hope"};
        String prefix = LongestCommonPrefix(strs);
        System.out.println("Longest Common Prefix = " + prefix);
    }

    public static String LongestCommonPrefix(String[] strs)
    {
        if (strs.length == 0)
            return "";

        /*************************************************************/
        //Start from first char and keep increasing the index 
        //  as long as all the other string match the character
        //  or no strings lenth is smaller than that
        /*************************************************************/
        ///*
        for(int i=0; i<strs[0].length(); i++) {
            char ch = strs[0].charAt(i);
            for(int j=1; j<strs.length; j++) {
                if (i >= strs[j].length() || ch != strs[j].charAt(i))
                    return strs[0].substring(0, i);
                
                //System.out.println(i + " - " + strs[0].substring(0, i+1) + ", check - " + strs[j]);
            }
        }
        return strs[0];

        //*/
        
        /*************************************************************/
        //Start with first string as the prefix
        //Now keep matching the prefix with each string 
        //  and keep reducing the prefix length if they dont match with other strings
        /*************************************************************/
        /*
        String prefix = strs[0];
        for(int i=1; i<strs.length; i++) {
            while(strs[i].indexOf(prefix) != 0)
                prefix = prefix.substring(0, prefix.length()-1);
            
            if (prefix.length() == 0)
                return "";
        }

        return prefix;
        */
        
    }
}