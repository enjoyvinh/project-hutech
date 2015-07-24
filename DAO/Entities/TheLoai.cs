using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Entities
{
    public class TheLoai
    {
        public Int32 MATHELOAI { get; set; }
        public String TENTHELOAI { get; set; }
        public String MOTA { get; set; }
        public Int32 SAPXEP { get; set; }
        public String SLUG { get; set; }
        public DateTime NGAYTAO { get; set; }
        public Int32 XOA { get; set; }
    }
}
