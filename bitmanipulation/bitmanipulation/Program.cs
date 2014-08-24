using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    /*
     * Complete the function below.
     */
    static int maxXor(int l, int r)
    {
        int temp = r;

        int temp2 = 1 << 31;

        int bitposition = 0;
        while ((temp & temp2) != temp2)
        {
            bitposition++;
            temp <<= 1;
        }

        bitposition = 32 - bitposition;
        int quarry = 1;
        while (bitposition > 1)
        {
            bitposition--;
            quarry <<= 1;
            quarry += 1;
        }

        var candidate = r ^ quarry;
        while (candidate < l || candidate > r)
        {
            quarry--;
            candidate = r ^ quarry;
        }

        return quarry;
    }

    static void Main(String[] args)
    {
        int res;
        int _l;
        _l = Convert.ToInt32(Console.ReadLine());

        int _r;
        _r = Convert.ToInt32(Console.ReadLine());

        int max = int.MinValue;
        while (_r > _l)
        {
            res = maxXor(_l, _r);
            if (res > max)
            {
                max = res;
            }
            _r--;
        }
        
        Console.WriteLine(max);

        Console.ReadKey();
    }
}
