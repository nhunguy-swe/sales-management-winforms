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
    public class DAL_HoaDon
    {
        DBConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public DAL_HoaDon()
        {
            dc = new DBConnection();
        }

        public DataTable getALLHoaDon()
        {
            // Tạo câu lệnh SQL để lấy toàn bộ hoa don
            string sql = "select * from HoaDon";
            //string sql = "select CTHD.Mahd, Soluong, Dongia, SanPham.Masp from CTHD, HoaDon, SanPham where CTHD.Mahd = HoaDon.Mahd and SanPham.Masp = HoaDon.Masp ";
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

        public bool Themhd(DTO_HoaDon hd)
        {
            string sql = "insert into HoaDon (Mahd,  Soluong, Dongia, Masp) values (@Mahd, @Soluong, @Dongia, @Masp)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Mahd", SqlDbType.NVarChar).Value = hd.Mahd;
                cmd.Parameters.Add("@Soluong", SqlDbType.Float).Value = hd.Soluong;
                cmd.Parameters.Add("@Dongia", SqlDbType.Float).Value = hd.Dongia;
                cmd.Parameters.Add("@Masp", SqlDbType.NVarChar).Value = hd.Masp;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Suahd (DTO_HoaDon hd)
        {
            string sql = "update HoaDon set Mahd = @Mahd, Soluong = @Soluong, Dongia = @Dongia, Masp = @Masp where Id = @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = hd.Id;
                cmd.Parameters.Add("@Mahd", SqlDbType.NVarChar).Value = hd.Mahd;
                cmd.Parameters.Add("@Soluong", SqlDbType.Float).Value = hd.Soluong;
                cmd.Parameters.Add("@Dongia", SqlDbType.Float).Value = hd.Dongia;
                cmd.Parameters.Add("@Masp", SqlDbType.NVarChar).Value = hd.Masp;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Xoahd (DTO_HoaDon hd)
        {
            string sql = "delete HoaDon where Id = @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = hd.Id;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable Timkiemhd (string hd)
        {
            string sql = " select * from HoaDon where Mahd like N'%" + hd + "%' or Masp like N'%" + hd + "%' ";
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
