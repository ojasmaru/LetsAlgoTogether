public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
    List<int> result = new List<int>();
    if(matrix == null || matrix.GetLength(0) == 0) return result;
    
    int startRow = 0, endRow =  matrix.GetLength(0) - 1;
    int startCol = 0, endCol = matrix[0].GetLength(0) - 1;
    int dir = 0;
    
    while(startRow <= endRow && startCol <= endCol) {
        switch(dir) {
            case 0: //RIGHT
                for(int col = startCol; col <= endCol; col++)
                    result.Add(matrix[startRow][col]);
                startRow++;
                break;
            case 1: //DOWN
                for(int row = startRow; row <=endRow; row++) 
                    result.Add(matrix[row][endCol])    ;
                endCol--;
                break;
            case 2://LEFT
                for(int col = endCol; col >= startCol; col --) 
                    result.Add(matrix[endRow][col]);
                endRow--;
                break;
            case 3://UP
                for(int row = endRow; row >= startRow; row--)
                    result.Add(matrix[row][startCol]);
                startCol++;  
                break;
        }                                   
        dir = (dir+1)%4;                                                            
        }
    
    return result;
    }
    
}
