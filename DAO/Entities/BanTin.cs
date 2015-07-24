using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Entities
{
    public class BanTin
    {
        public Int32 MABANTIN { get; set; }
        public Int32 MATHELOAI { get; set; }
        public String TIEUDE { get; set; }
        public String NOIDUNGTOMTAT { get; set; }
        public String NOIDUNG { get; set; }
        public DateTime NGAYDANG { get; set; }
        public String HINHANH { get; set; }
        public String TENTACGIA { get; set; }
        public String SLUG { get; set; }
        public Int32 LIKES { get; set; }
        public Int32 XOA { get; set; }
    }
}
