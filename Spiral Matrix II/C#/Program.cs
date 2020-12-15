public class Solution {
    public int[][] GenerateMatrix(int n) 
    {
        var result = new int[n][];
        
        for(int i=0; i<n; i++)
            result[i] = new int[n];
        
        var rowmin = 0;
        var colmin = 0;
        var rowmax = n-1;
        var colmax = n-1;
        
        var dir = new int[] {};
        var num = 1;
        
        while(rowmin <= rowmax || colmin <= colmax)
        {
            //Fill the row from left to right
            for(int i=colmin; i<=colmax; i++)
                result[rowmin][i] = num++;
            rowmin++;
            
            //Fill the column from top to bottom
            for(int j=rowmin; j<=rowmax; j++)
                result[j][colmax] = num++;
            colmax--;
            
            //Fill the row from right to left
            for(int i=colmax; i>=colmin; i--)
                result[rowmax][i] = num++;
            rowmax--;
            
            //Fill the column from bottom to top
            for(int j=rowmax; j>=rowmin; j--)
                result[j][colmin] = num++;
            colmin++;
        }
        
        return result;
    }
}