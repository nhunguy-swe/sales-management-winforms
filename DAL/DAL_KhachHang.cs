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
    public class DAL_KhachHang
    {
        DBConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public DAL_KhachHang()
        {
            dc = new DBConnection();
        }
        public DataTable getALLKhachHang()
        {
            // Tạo câu lệnh SQL để lấy toàn bộ khach hang
            string sql = "select * from KhachHang";
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

        public bool Themkh (DTO_KhachHang kh)
        {
            string sql = "insert into KhachHang (Makh, Tenkh, Sdt, Sinhnhat, Diem) values (@Makh, @TenKh, @Sdt, @Sinhnhat, @Diem)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Makh", SqlDbType.NVarChar).Value = kh.Makh;
                cmd.Parameters.Add("@Tenkh", SqlDbType.NVarChar).Value = kh.Tenkh;
                cmd.Parameters.Add("@Sdt", SqlDbType.NVarChar).Value = kh.Sdt;
                cmd.Parameters.Add("@Sinhnhat", SqlDbType.Date).Value = kh.Sinhnhat;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = kh.Diem;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Suakh (DTO_KhachHang kh)
        {
            string sql = "update KhachHang set Makh = @Makh, Tenkh = @Tenkh, Sdt = @Sdt, Sinhnhat = @Sinhnhat, Diem = @Diem where Id = @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = kh.Id;
                cmd.Parameters.Add("@Makh", SqlDbType.NVarChar).Value = kh.Makh;
                cmd.Parameters.Add("@Tenkh", SqlDbType.NVarChar).Value = kh.Tenkh;
                cmd.Parameters.Add("@Sdt", SqlDbType.NVarChar).Value = kh.Sdt;
                cmd.Parameters.Add("@Sinhnhat", SqlDbType.Date).Value = kh.Sinhnhat;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = kh.Diem;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Xoakh (DTO_KhachHang kh)
        {
            string sql = "delete KhachHang where Id = @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = kh.Id;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable Timkiemkh (string kh)
        {
            string sql = " select * from KhachHang where Tenkh like N'%" + kh + "%' or Sdt like N'%" + kh + "%' or Makh like N'%" + kh +"%' ";
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
