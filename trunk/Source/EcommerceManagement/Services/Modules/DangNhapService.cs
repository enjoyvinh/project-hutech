using DAOs.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOs;
using DAOs.DAO;
using DAOs.DTO;
using WebMatrix.WebData;
using System.Web.Security;

/*
 *  
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */

namespace Services.Modules
{
    public class DangNhapService
    {

        public Hashtable doLogin(DtoControllerDangNhap param)
        {
            Hashtable result = new Hashtable();

            result.Add(AppConstraints.SUCCESS, String.Empty);
            result.Add(AppConstraints.WARNING, String.Empty);
            result.Add(AppConstraints.ERROR, String.Empty);

            String username = param.MaNhanVien;
            String password = param.MatKhau;

            try
            {
                if (CheckValid.ValidIsEmpty(username) || CheckValid.ValidIsEmpty(password))
                {
                    result[AppConstraints.WARNING] = "Chưa Nhập Tài Khoản Hoặc Mật Khẩu.";
                }
                else
                {
                    if (!WebSecurity.Initialized)
                    {
                        WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "Email", autoCreateTables: true);
                    }

                    if (WebSecurity.IsAuthenticated)
                    {
                        WebSecurity.Logout();
                    }

                    //WebSecurity.Login(username, password,persistCookie:false);

                    if (WebSecurity.Login(username, password, persistCookie: false))
                    {
                        result["MaNhanVien"] = username;
                        result["TenNhanVien"] = username;
                        result["PhanQuyen"] = System.Web.Security.Roles.GetRolesForUser(username)[0];

                        result[AppConstraints.SUCCESS] = "Đăng Nhập Thành Công.";
                    }
                    else
                    {
                        result[AppConstraints.WARNING] = "Sai Tài Khoản Hoặc Mật Khẩu.";
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                result[AppConstraints.ERROR] = "Có Lỗi Hệ Thống: " + e.Message.ToString();
                return result;
            }
        }

        public Hashtable doLogout()
        {
            Hashtable result = new Hashtable();

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "Email", autoCreateTables: true);
            }

            if (WebSecurity.IsAuthenticated)
            {
                WebSecurity.Logout();
                result.Add("url", "Login");
            }

            return result;
        }
    }
}
