using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logistics.Extensions
{
    public static class MyExtensions
    {
        public static bool IsNumber(this String str)
        {
            int result;

           return int.TryParse(str, out result);
        }
    }   
}
