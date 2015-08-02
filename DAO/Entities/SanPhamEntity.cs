using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Entities
{
    public class SanPhamEntity
    {
        public string MASANPHAM { get; set; }
        public string MACHUYENMUC { get; set; }
        public string MADONVITINH { get; set; }
        public string MACUAHANG { get; set; }
        public string TENSANPHAM { get; set; }
        public decimal DONGIACU { get; set; }
        public Nullable<decimal> DONGIAMOI { get; set; }
        public Nullable<int> LUOTXEM { get; set; }
        public Nullable<byte> TINHTRANG { get; set; }
        public string MOTA { get; set; }
        public Nullable<byte> LUUNHAP { get; set; }
        public Nullable<System.DateTime> NGAYTAO { get; set; }
        public int SOLUONGTONKHO { get; set; }
        public int SOLUONG { get; set; }
        public string HASP { get; set; }
        public string TENCUAHANG { get; set; }
    }
}
