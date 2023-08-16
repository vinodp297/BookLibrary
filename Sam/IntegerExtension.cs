using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sam
{
    internal static class IntegerExtension
    {
        public static string ConvertTotext(this int value)
        {

            string sam1 = string.Empty;

            switch (value)
            {
                case 1:
                    {
                        sam1 = "ONE";
                        break;
                    }
                case 2:
                    {
                        sam1 = "TWO";
                        break;
                    }
                case 3:
                    {
                        sam1 = "THREE";
                        break;
                    }
            }

            return sam1;
        }
    }
}
