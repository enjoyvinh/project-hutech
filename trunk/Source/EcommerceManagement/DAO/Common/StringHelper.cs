using DAOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 *  
 *  Filename:   StringHelper.cs
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */

namespace DAOs.Common
{
    public static class StringHelper
    {
        #region Xu ly dau Tieng Viet

        public static string RemoveMark(string title)
        {
            title = title.ToLower().Trim();
            title = title.Replace("!", "").Replace("_", "-").Replace("'", "").Replace(",-", ",").Replace("-,", ",").Replace("%", "").Replace("^", "").Replace("&", "").Replace("*", "").Replace("+", "").Replace("=", "").Replace("$", "").Replace("#", "").Replace(":", "");
            title = title.Replace("áº¯", "a").Replace("áº±", "a").Replace("áº³", "a").Replace("áºµ", "a").Replace("áº·", "a").Replace("Äƒ", "a");
            title = title.Replace("áº¥", "a").Replace("áº§", "a").Replace("áº©", "a").Replace("áº«", "a").Replace("áº­", "a").Replace("Ã¢", "a");
            title = title.Replace("Ã¡", "a").Replace("Ã ", "a").Replace("áº£", "a").Replace("Ã£", "a").Replace("áº¡", "a");

            title = title.Replace("Ã©", "e").Replace("Ã¨", "e").Replace("áº»", "e").Replace("áº½", "e").Replace("áº¹", "e");
            title = title.Replace("áº¿", "e").Replace("á»", "e").Replace("á»ƒ", "e").Replace("á»…", "e").Replace("á»‡", "e").Replace("Ãª", "e");
            title = title.Replace("Ã­", "i").Replace("Ã¬", "i").Replace("á»‰", "i").Replace("Ä©", "i").Replace("á»‹", "i");

            title = title.Replace("Ã³", "o").Replace("Ã²", "o").Replace("á»", "o").Replace("Ãµ", "o").Replace("á»", "o");
            title = title.Replace("á»‘", "o").Replace("á»“", "o").Replace("á»•", "o").Replace("á»—", "o").Replace("á»™", "o").Replace("Ã´", "o");
            title = title.Replace("á»›", "o").Replace("á»", "o").Replace("á»Ÿ", "o").Replace("á»¡", "o").Replace("á»£", "o").Replace("Æ¡", "o");
            title = title.Replace("Ãº", "u").Replace("Ã¹", "u").Replace("á»§", "u").Replace("Å©", "u").Replace("á»¥", "u");
            title = title.Replace("á»©", "u").Replace("á»«", "u").Replace("á»­", "u").Replace("á»¯", "u").Replace("á»±", "u").Replace("Æ°", "u");
            title = title.Replace("Ã½", "y").Replace("á»³", "y").Replace("á»·", "y").Replace("á»¹", "y").Replace("á»µ", "y");
            title = title.Replace("Ä‘", "d");

            const string TextToFind = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string TextToReplace = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";

            int index = -1;
            while ((index = title.IndexOfAny(TextToFind.ToCharArray())) != -1)
            {
                int index2 = TextToFind.IndexOf(title[index]);
                title = title.Replace(title[index], TextToReplace[index2]);
            }

            return title;
        }

        public static string RemoveSpace(string title)
        {
            title = title.ToLower().Trim();
            title = title.Replace(" ", "_");
            return title;
        }

        public static string StringHandle(string title)
        {
            if (CheckValid.ValidIsEmpty(title))
            {
                return null;
            }

            title = RemoveSpace(title);
            title = RemoveMark(title);

            return title;
        }


        #endregion
    }
}
