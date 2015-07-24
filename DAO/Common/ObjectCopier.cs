using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static void copyProperties(this Object dst, object src)
        {
            var srcT = src.GetType();
            var dstT = dst.GetType();
            foreach (var f in srcT.GetFields())
            {
                var dstF = dstT.GetField(f.Name);
                if (dstF == null)
                    continue;
                dstF.SetValue(dst, f.GetValue(src));
            }

            foreach (var f in srcT.GetProperties())
            {
                var dstF = dstT.GetProperty(f.Name);
                if (dstF == null)
                    continue;

                dstF.SetValue(dst, f.GetValue(src, null), null);
            }
        }
    }
}
