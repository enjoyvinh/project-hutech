using Services.Modules;
using System.Collections;
using System.Web.Http;
using DAOs.DTO;
using System;

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
            result.Add("SUCCESS", "Thành Công");

            result.Add("tongcuahang", 1987654230);
            result.Add("tongsanpham", 54321863);
            result.Add("tongkhachhang", 1852054);
            result.Add("tongluotdanhgiabinhluan", 98754231);

            Int64[] chartGiaoDichThangCong = new Int64[12];
            Int64[] chartGiaoDichThatBai = new Int64[12];

            for (Int16 i = 0; i < 12; i++)
            {
                Int16 thang = i;
                Int64 value = dashboardService.getTongHoaDonTheoThang(++thang, 1);

                chartGiaoDichThangCong[i] = value;
            }

            for (Int16 i = 0; i < 12; i++)
            {
                Int16 thang = i;
                Int64 value = dashboardService.getTongHoaDonTheoThang(++thang, 2);

                chartGiaoDichThatBai[i] = value;
            }

            result.Add("chartGiaoDichThangCong", "550,440,600,800,700,1080,1900,2100");
            result.Add("chartGiaoDichThatBai", "200,600,900,300,3000,2000,1500,1700");

            return result;
        }
    }
}