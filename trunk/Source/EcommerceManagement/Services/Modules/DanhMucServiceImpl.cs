using DAOs.Common;
using DAOs.DAO;
using DAOs.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyXuatDB.Entities;

namespace Services.Modules
{
    public class DanhMucServiceImpl : DanhMucService
    {
        private DanhMucDAO danhMucDAO = new DanhMucDAO();

        private ItemSaleDAO itemSaleDAO = new ItemSaleDAO();

        private ItemStoreDAO itemStoreDAO = new ItemStoreDAO();

        //public List<View_DanhMucDTO> getDanhSachDanhMuc(Request_TimKiem_DanhMucDTO param)
        //{
        //    List<View_DanhMucDTO> result = danhMucDAO.getDanhSachDanhMuc(param);

        //    return result;
        //}

        public Hashtable xoaDanhMuc(Request_Xoa_DanhMucDTO param)
        {
            Hashtable result = new Hashtable();
            result.Add(AppConstraints.SUCCESS, String.Empty);
            result.Add(AppConstraints.WARNING, String.Empty);
            result.Add(AppConstraints.ERROR, String.Empty);

            Int32 countItemSale = itemSaleDAO.demDanhSach(param.DanhMucGuid);

            Int32 countItemStore = itemStoreDAO.demDanhSach(param.DanhMucGuid);

            if (countItemSale <= 0 && countItemStore <= 0)
            {
                result[AppConstraints.WARNING] = "Không Thể Xóa Danh Mục Này.";
                return result;
            }

            return result;
        }

        public Hashtable themDanhMuc(Request_Them_DanhMucDTO param)
        {
            Hashtable result = new Hashtable();
            result.Add(AppConstraints.SUCCESS, String.Empty);
            result.Add(AppConstraints.WARNING, String.Empty);
            result.Add(AppConstraints.ERROR, String.Empty);

            if(CheckValid.ValidIsEmpty(param.DanhMucName))
            {
                result[AppConstraints.WARNING] = "Vui Lòng Nhập Tên Danh Mục.";
                return result;
            }

            return result;
        }
    }
}
