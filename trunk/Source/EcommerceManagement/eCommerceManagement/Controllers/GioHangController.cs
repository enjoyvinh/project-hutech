using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerceManagement.Models;
using System.Data;
using DAOs.DAO;
using DAOs.Entities;
namespace eCommerceManagement.Controllers
{
    public class GioHangController : Controller
    {
        TMDTDB11Entities ql = new TMDTDB11Entities();
        SanPhamDAO _SanPhamDAO1 = new SanPhamDAO();
        CuaHangDAO _CuaHangDAO1 = new CuaHangDAO();
        // GET: GioHang
        public ActionResult GioHangIndex()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CapNhatGioHang(FormCollection fc)
        {
            int isnum = 0;
            var CartList = new List<SanPhamEntity>();
            CartList = (List<SanPhamEntity>)Session["Cart"];// load session vao Bien Gio Hang
            var CartListDel = new List<SanPhamEntity>();
            var CartListAdd = new List<SanPhamEntity>();
            for (int i = 0; i < CartList.Count; i++)
            {
                string txtSLMoi = fc[CartList[i].MASANPHAM.ToString()];
                var OldCart = CartList.Find(m => m.MASANPHAM == CartList[i].MASANPHAM);
                try { Convert.ToInt32(txtSLMoi.Trim()); }
                catch { isnum = 1; }
                if (isnum == 1)
                {
                    Session["NumErr"] = "vui lòng nhập số";
                    return RedirectToAction("GioHangIndex");
                }
                else if (OldCart != null && txtSLMoi.Trim() == "0")
                {
                    CartListDel.Add(OldCart);
                }
                else if (OldCart != null && txtSLMoi.Trim() != "0")
                {
                    var SanPhamCapNhat = new SanPhamEntity
                    {
                        MASANPHAM = CartList[i].MASANPHAM,
                        TENSANPHAM = CartList[i].TENSANPHAM,
                        DONGIAMOI = (decimal)CartList[i].DONGIAMOI,
                        SOLUONG = Convert.ToInt32(txtSLMoi.Trim()),
                        HASP = CartList[i].HASP,
                        MACUAHANG = CartList[i].MACUAHANG,
                        TENCUAHANG = CartList[i].TENCUAHANG
                    };
                    CartListDel.Add(OldCart);
                    CartListAdd.Add(SanPhamCapNhat);

                }
            }

            for (int i = 0; i < CartListDel.Count; i++)
            {
                CartList.Remove(CartListDel[i]);
            }
            for (int i = 0; i < CartListAdd.Count; i++)
            {
                CartList.Add(CartListAdd[i]);
            }
            Session["Cart"] = CartList;
            return RedirectToAction("GioHangIndex");
        }
        public ActionResult ThemVaoGioHang(string id)
        {
            var _Product = ql.SF_SANPHAM.Find(id);
            //tạo danh sách giỏ hàng
            var CartList = new List<SanPhamEntity>();
            //nếu giỏ hàng trống
            if (Session["Cart"] != null)// neu gio hang da co sp
            {
                CartList = (List<SanPhamEntity>)Session["Cart"];
                var OldCart = CartList.Find(m => m.MASANPHAM.ToString().Trim() == id.ToString().Trim());// tim sp id co trong gio hang
                //nếu đã tồn tại sản phẩm trong giỏ hàng thì cho số lượng +1
                if (OldCart != null)
                {
                    DataTable tbl_hasp = new DataTable();
                    tbl_hasp = _SanPhamDAO1.HinhAnhTheoMaSanPham(_Product.MASANPHAM.ToString());
                    DataTable tbl_ttch = new DataTable();
                    tbl_ttch = _CuaHangDAO1.ThongTinCuaHangTheoMaSanPham(_Product.MASANPHAM.ToString());
                    var NewCart = new SanPhamEntity
                    {
                        MASANPHAM = _Product.MASANPHAM,
                        TENSANPHAM = _Product.TENSANPHAM,
                        DONGIAMOI = (decimal)_Product.DONGIAMOI,
                        SOLUONG = OldCart.SOLUONG + 1,
                        HASP = tbl_hasp.Rows[0]["TENHINHANH"].ToString(),
                        MACUAHANG = tbl_ttch.Rows[0]["MACUAHANG"].ToString(),
                        TENCUAHANG = tbl_ttch.Rows[0]["TENCUAHANG"].ToString()
                    };
                    CartList.Remove(OldCart);
                    CartList.Add(NewCart);
                }
                // nếu không có sản phẩm đó trong giỏ hàng thì
                else
                {
                    DataTable tbl_hasp = new DataTable();
                    tbl_hasp = _SanPhamDAO1.HinhAnhTheoMaSanPham(_Product.MASANPHAM.ToString());
                    DataTable tbl_ttch = new DataTable();
                    tbl_ttch = _CuaHangDAO1.ThongTinCuaHangTheoMaSanPham(_Product.MASANPHAM.ToString());
                    CartList.Add(new SanPhamEntity
                    {
                        MASANPHAM = _Product.MASANPHAM,
                        TENSANPHAM = _Product.TENSANPHAM,
                        DONGIAMOI = (decimal)_Product.DONGIAMOI,
                        SOLUONG = 1,
                        HASP = tbl_hasp.Rows[0]["TENHINHANH"].ToString(),
                        MACUAHANG = tbl_ttch.Rows[0]["MACUAHANG"].ToString(),
                        TENCUAHANG = tbl_ttch.Rows[0]["TENCUAHANG"].ToString()
                    });
                }
            }
            else// neu gio hang trong
            {
                DataTable tbl_hasp = new DataTable();
                tbl_hasp = _SanPhamDAO1.HinhAnhTheoMaSanPham(_Product.MASANPHAM.ToString());
                DataTable tbl_ttch = new DataTable();
                tbl_ttch = _CuaHangDAO1.ThongTinCuaHangTheoMaSanPham(_Product.MASANPHAM.ToString());
                CartList.Add(new SanPhamEntity
                {
                    MASANPHAM = _Product.MASANPHAM,
                    TENSANPHAM = _Product.TENSANPHAM,
                    DONGIAMOI = (decimal)_Product.DONGIAMOI,
                    SOLUONG = 1,
                    HASP = tbl_hasp.Rows[0]["TENHINHANH"].ToString(),
                    MACUAHANG = tbl_ttch.Rows[0]["MACUAHANG"].ToString(),
                    TENCUAHANG = tbl_ttch.Rows[0]["TENCUAHANG"].ToString()
                });
            }
            Session["Cart"] = CartList;
            return RedirectToAction("GioHangIndex");
        }
    }
}