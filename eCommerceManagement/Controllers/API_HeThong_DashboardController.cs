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

            try
            {
                for (Int16 i = 0; i < 12; i++)
                {
                    Int16 thang = i;
                    Int64 value = dashboardService.getTongHoaDonTheoThang(++thang, 1);
                    if (!value.Equals(0))
                    {
                        chartGiaoDichThangCong[i] = value;
                    }
                }

                for (Int16 i = 0; i < 12; i++)
                {
                    Int16 thang = i;
                    Int64 value = dashboardService.getTongHoaDonTheoThang(++thang, 2);
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
                result.Add("tongluotdanhgiabinhluan", dashboardService.getTongDanhGia());

                result.Add("phantramtonggiatritoansan", dashboardService.getTongDanhGia());
                result.Add("tonggiatritoansan", dashboardService.getTongDanhGia());
                result.Add("phantramkhoiluonggiaodich", dashboardService.getTongDanhGia());
                result.Add("khoiluonggiaodich", dashboardService.getTongDanhGia());
                result.Add("phantramtonggiatrigiaodich", dashboardService.getTongDanhGia());
                result.Add("tonggiatrigiaodich", dashboardService.getTongDanhGia());
                result.Add("phantram", dashboardService.getTongDanhGia());
                result.Add("tonggiatri", dashboardService.getTongDanhGia());

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