class Solution {
    public List<Integer> spiralOrder(int[][] matrix) {
        List<Integer> result = new LinkedList<Integer>();
        if(matrix == null || matrix.length == 0) return result;

        int startRow = 0, endRow = matrix.length-1;
        int startCol = 0, endCol = matrix[0].length - 1;
        int dir = 0;

        while(startRow <= endRow && startCol <= endCol) {
            switch(dir) {
                case 0: //RIGHT
                    for(int j = startCol; j <= endCol; j++)
                        result.add(matrix[startRow][j]);
                    startRow++;
                    break;
                case 1: //DOWN
                    for(int i = startRow; i <=endRow; i++) 
                        result.add(matrix[i][endCol])    ;
                    endCol--;
                    break;
                case 2://LEFT
                    for(int j = endCol; j >= startCol; j --) 
                        result.add(matrix[endRow][j]);
                    endRow--;
                    break;
                case 3://UP
                    for(int i = endRow; i >= startRow; i--)
                        result.add(matrix[i][startCol]);
                    startCol++;  
                    break;
            }                                   
            dir = (dir+1)%4;                                                            
        }

        return result;
        
    }
}