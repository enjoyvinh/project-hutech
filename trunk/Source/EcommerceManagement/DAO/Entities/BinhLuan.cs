using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Entities
{
    public class BinhLuan
    {
        public Int32 MABINHLUAN { get; set; }
        public Int32 MABANTIN { get; set; }
        public String HOTEN { get; set; }
        public String EMAIL { get; set; }
        public String DIENTHOAI { get; set; }
        public String TIEUDE { get; set; }
        public String NOIDUNG { get; set; }
        public String NGAYTAO { get; set; }
    }
}
