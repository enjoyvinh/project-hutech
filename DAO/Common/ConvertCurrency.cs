using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

/*
 *  
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */

namespace DAOs.Common
{
    public static class ConvertCurrency
    {
        public static String ConvertDecimalToString(Decimal value)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"

            if (value.ToString().Equals(null) || value.ToString().Equals(String.Empty) || value.Equals(Decimal.Zero))
            {
                return AppConstraints.ZERO + AppConstraints.VND;
            }

            return (Decimal.Parse(value.ToString()).ToString("#,###.##", cultureInfo.NumberFormat)) + AppConstraints.VND;

        }
    }
}
