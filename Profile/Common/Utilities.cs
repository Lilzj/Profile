using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileManager.Common
{
    public static class Utilities
    {
        public static string GenerateTransactionNumber()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 16;
            var TN = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                TN.Append(c);
            }
            return TN.ToString();
        }
    }
}
