using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  
 *  Filename:   CheckValid.cs
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */

namespace DAOs.Common
{
    public static class CheckValid
    {
        public static Boolean ValidEmailAddress(string emailAddress)
        {
            // Confirm that the e-mail address string is not empty. 
            if (emailAddress.Length == 0)
            {
                return true;
            }

            // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    return false;
                }
            }

            return true;
        }

        public static Boolean ValidIsEmpty(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return true;
            }
            if (value.Equals(String.Empty))
            {
                return true;
            }
            if (value.Length == 0)
            {
                return true;
            }
            return false;
        }

        public static Boolean ValidIsNumeric(string title, String value, out string errorMessage)
        {

            foreach (char c in value)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    errorMessage = "Vui Lòng Nhập Số.";
                    return true;
                }
            }

            errorMessage = "";
            return false;
        }
    }
}
