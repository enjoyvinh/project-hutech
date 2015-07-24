using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DAOs;
using DAOs.Common;

/*
 *  
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */

namespace DAOs.Common
{
    public class AutoGenerateID : DBConnection
    {
        private String tableName = String.Empty;

        private String columnName = String.Empty;

        private String prefixId = String.Empty;

        private String maxID = String.Empty;

        private String nextID = String.Empty;

        public AutoGenerateID()
        {
            this.tableName = String.Empty;
            this.columnName = String.Empty;
            this.prefixId = String.Empty;
            this.maxID = String.Empty;
            this.nextID = String.Empty;
        }

        public AutoGenerateID(String tableName, String columnName, String prefixId)
        {
            this.tableName = tableName;
            this.columnName = columnName;
            this.prefixId = prefixId;
            this.maxID = String.Empty;
            this.nextID = String.Empty;
        }

        public String GenerateNewID()
        {
            //Select Max ID Từ Database dựa vào columnName và tableName
            using (SqlCommand cmd = new SqlCommand())
            {
                openConnection();
                cmd.CommandText = @"SELECT TOP 1 " + this.columnName + @"
                                    FROM	     " + this.tableName + @"
                                    ORDER BY " + this.columnName + @" DESC";

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;

                try
                {
                    this.maxID = (String)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {

                    errorTransaction();
                    throw new ApplicationException("Có Lỗi Hệ Thống :", ex);
                }
                finally
                {
                    closeConnection();
                }
            }

            //Nếu lấy được giá trị max
            if (!this.maxID.Equals(null))
            {
                //Gọi hàm tạo chuỗi ID mới
                return this.generateNextID(this.prefixId, this.maxID);
            }

            return null;
        }

        public String generateNextID(String prefix, String maxID)
        {

            //Khai báo nextID Là Id Tiếp Theo
            String nextID = String.Empty;

            //Tạo Biến Tạm Chứa Giá Trị Sau prefix
            //HD0000001 => 0000001
            String tempID = maxID;
            if (CheckValid.ValidIsEmpty(prefix))
            {
                tempID = tempID.Replace(prefix, String.Empty);
            }

            //Bỏ Số 0 Trước Giá Trị
            //0000001 => 1
            Int64 currentNumber = Convert.ToInt64(tempID) + 1;

            //Đếm Chiều Dài Chuỗi
            //0000001 => 7
            int countNumber = tempID.Length;

            //Khai Báo Ký Tự Cần Thêm Phía Bên Trái
            //1 => 0000001
            char padChar = '0';

            //Thêm Ký Tự padChar vào Bên Trái currentNumber bằng Hàm PadLeft
            // Thêm 0 Trước 1 với số lượng là 7
            // => 0000002
            nextID = currentNumber.ToString().PadLeft(countNumber, padChar);

            //Thêm lại prefix cho Id Mới
            // 0000002 => HD0000001
            nextID = prefix + nextID;

            return nextID;
        }
    }
}
