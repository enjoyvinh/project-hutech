using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 *  
 *  Filename:   globalApp.cs
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */

namespace DAOs.Common
{
    public static class globalApp
    {
        static Guid _MaBan;

        public static Guid MaBan
        {
            get { return _MaBan; }
            set { _MaBan = value; }
        }

        static String _UserID;

        static float _VAT = 0.1F;

        public static String UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        public static float VAT
        {
            get
            {
                return _VAT;
            }
            set
            {
                _VAT = value;
            }
        }


    }
}
