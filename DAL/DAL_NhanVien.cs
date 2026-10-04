using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_NhanVien
    {
        DBConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public DAL_NhanVien()
        {
            dc = new DBConnection();
        }

        public DataTable getALLNhanVien ()
        {
            // Tạo câu lệnh SQL để lấy toàn bộ nhân viên
            string sql = "select * from NhanVien";
            // Tạo 1 kết nối đến SQL
            SqlConnection con = dc.getConnect();
            // Khởi tạo đối tượng của lớp SqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            // Mở kết nối
            con.Open();
            // Đổ dữ liệu từ SqlDataAdapter vào Datatable
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Đóng kết nối
            con.Close();
            return dt;
        }

        public bool Themsv (DTO_NhanVien nv)
        {
            string sql = "insert into NhanVien (Manv, Tennv, Gioitinh, Sdt, Ngaylamviec) values (@Manv, @Tennv, @Gioitinh, @Sdt, @Ngaylamviec)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Manv", SqlDbType.NVarChar).Value = nv.Manv;
                cmd.Parameters.Add("@Tennv", SqlDbType.NVarChar).Value = nv.Tennv;
                cmd.Parameters.Add("@Gioitinh", SqlDbType.NVarChar).Value = nv.Gioitinh;
                cmd.Parameters.Add("@Sdt", SqlDbType.NVarChar).Value = nv.Sdt;
                cmd.Parameters.Add("@Ngaylamviec", SqlDbType.Date).Value = nv.Ngaylamviec;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Suanv (DTO_NhanVien nv)
        {
            string sql = "update NhanVien set Manv = @Manv, Tennv = @Tennv, Gioitinh = @Gioitinh, Sdt = @Sdt, Ngaylamviec = @Ngaylamviec where Id = @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = nv.Id;
                cmd.Parameters.Add("@Manv", SqlDbType.NVarChar).Value = nv.Manv;
                cmd.Parameters.Add("@Tennv", SqlDbType.NVarChar).Value = nv.Tennv;
                cmd.Parameters.Add("@Gioitinh", SqlDbType.NVarChar).Value = nv.Gioitinh;
                cmd.Parameters.Add("@Sdt", SqlDbType.NVarChar).Value = nv.Sdt;
                cmd.Parameters.Add("@Ngaylamviec", SqlDbType.Date).Value = nv.Ngaylamviec;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            { 
                return false;
            }
            return true;
        }

        public bool Xoanv (DTO_NhanVien nv)
        {
            string sql = "delete NhanVien where Id = @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = nv.Id;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable Timkiemnv (string nv)
        {
            string sql = " select * from NhanVien where Tennv like N'%" + nv + "%' or Sdt like N'%" + nv +"%' or Manv like N'%" + nv +"%' or Gioitinh like N'%" + nv +"%' ";
            // Tạo 1 kết nối đến SQL
            SqlConnection con = dc.getConnect();
            // Khởi tạo đối tượng của lớp SqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            // Mở kết nối
            con.Open();
            // Đổ dữ liệu từ SqlDataAdapter vào Datatable
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Đóng kết nối
            con.Close();
            return dt;
        }
    }
}
