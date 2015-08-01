using Services.Modules;
using System.Collections;
using System.Web.Http;
using DAOs.DTO;
using System;
using DAOs.Common;

namespace eCommerceManagement.Controllers
{
    public class API_HeThong_DashboardController : ApiController
    {
        DashboardService dashboardService = new DashboardService();

        // POST api/<controller>
        [HttpPost]
        [AllowAnonymous]
        public Hashtable doDashboard()
        {
            Hashtable result = new Hashtable();
            Int64[] chartGiaoDichThangCong = new Int64[12];
            Int64[] chartGiaoDichThatBai = new Int64[12];
            Int16 trangThaiHoaDon =Convert.ToInt16(AppConstraints.ONE);
            try
            {
                for (Int16 i = 0; i < 12; i++)
                {
                    Int16 thang = i;
                    Int64 value = dashboardService.getTongHoaDonTheoThang(++thang, trangThaiHoaDon);
                    if (!value.Equals(0))
                    {
                        chartGiaoDichThangCong[i] = value;
                    }
                }

                trangThaiHoaDon = Convert.ToInt16(AppConstraints.ZERO);
                for (Int16 i = 0; i < 12; i++)
                {
                    Int16 thang = i;
                    Int64 value = dashboardService.getTongHoaDonTheoThang(++thang, trangThaiHoaDon);
                    if (!value.Equals(0))
                    {
                        chartGiaoDichThatBai[i] = value;
                    }
                }

                result.Add("chartGiaoDichThangCong", chartGiaoDichThangCong);
                result.Add("chartGiaoDichThatBai", chartGiaoDichThatBai);

                result.Add("tongcuahang", dashboardService.getTongCuaHang());
                result.Add("tongsanpham", dashboardService.getTongSanPham());
                result.Add("tongkhachhang", dashboardService.getTongKhachHang());
                result.Add("tongluotdanhgiabinhluan", 0);

                result.Add("phantramtonggiatritoansan", dashboardService.getPhanTramTongGiaTri());
                result.Add("tonggiatritoansan", dashboardService.getTongGiaTri());
                result.Add("phantramkhoiluonggiaodich", dashboardService.getPhanTramKhoiLuong());
                result.Add("khoiluonggiaodich", dashboardService.getTongKhoiLuong());
                result.Add("phantramtonggiatrigiaodich", dashboardService.getPhanTramGiaoDich());
                result.Add("tonggiatrigiaodich", dashboardService.getTongGiaTriGiaoDich());

                result.Add(AppConstraints.SUCCESS, AppConstraints.SUCCESS);
            }
            catch(Exception ex)
            {
                result.Add(AppConstraints.ERROR, ex.ToString());
            }

            return result;
        }
    }
}