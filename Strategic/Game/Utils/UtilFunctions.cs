using System;
using System.Collections.Generic;

namespace Game.Utils
{
    public static class UtilFunctions
    {
        public  static byte[] StringToBytes(string str)
        {
            var bs = new List<byte>();
            for (int i = 0; i < str.Length / 2; i++)
            {
                bs.Add(Convert.ToByte(str.Substring(i * 2, 2), 16));
            }

            return bs.ToArray();
        }
    }
}
