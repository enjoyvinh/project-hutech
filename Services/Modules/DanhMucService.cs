using DAOs.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyXuatDB.Entities;

namespace Servies.Modules
{
    public interface DanhMucService
    {
        List<View_DanhMucDTO> getDanhSachDanhMuc(Request_TimKiem_DanhMucDTO param);

        Hashtable xoaDanhMuc(Request_Xoa_DanhMucDTO param);

        Hashtable themDanhMuc(Request_Them_DanhMucDTO param);
    }
}
