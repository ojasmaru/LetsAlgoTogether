public class Solution {
    public uint reverseBits1(uint n) {
        uint result = 0;
        //************************************
        //Loop for each of the 32 bit
        //left shift result (multiply by 2)
        //If bit in n is set then do same in result (add 1)
        //left shift n (divide by 2)
        //************************************/
        for(int i=0; i<32; i++)
        {
            result <<= 1;
            if ((n & 1) == 1)
                result++;
            
            n >>=1;
        }
        return result;
    }
    
    public uint reverseBits(uint n) {
        n = ((n & 0xffff0000) >> 16) | ((n & 0x0000ffff) << 16);
        n = ((n & 0xff00ff00) >> 8) | ((n & 0x00ff00ff) << 8);
        n = ((n & 0xf0f0f0f0) >> 4) | ((n & 0x0f0f0f0f) << 4);
        n = ((n & 0xcccccccc) >> 2) | ((n & 0x33333333) << 2);
        n = ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);
        return n;
    }
}