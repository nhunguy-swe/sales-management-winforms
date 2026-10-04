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
    public class DAL_SanPham
    {
        DBConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public DAL_SanPham()
        {
            dc = new DBConnection();
        }

        public DataTable getALLSanPham()
        {
            // Tạo câu lệnh SQL để lấy toàn bộ san pham
            string sql = "select * from SanPham";
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

        public bool Themsp (DTO_SanPham sp)
        {
            string sql = "insert into SanPham (Masp, Tensp, Gia, Soluong) values (@Masp, @Tensp, @Gia, @Soluong)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Masp", SqlDbType.NVarChar).Value = sp.Masp;
                cmd.Parameters.Add("@Tensp", SqlDbType.NVarChar).Value = sp.Tensp;
                cmd.Parameters.Add("@Gia", SqlDbType.Float).Value = sp.Gia;
                cmd.Parameters.Add("@Soluong", SqlDbType.Float).Value = sp.Soluong;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Suasp (DTO_SanPham sp)
        {
            string sql = "update SanPham set Masp = @Masp, Tensp = @Tensp, Gia = @Gia, Soluong = @Soluong where Id = @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sp.Id;
                cmd.Parameters.Add("@Masp", SqlDbType.NVarChar).Value = sp.Masp;
                cmd.Parameters.Add("@Tensp", SqlDbType.NVarChar).Value = sp.Tensp;
                cmd.Parameters.Add("@Gia", SqlDbType.Float).Value = sp.Gia;
                cmd.Parameters.Add("@Soluong", SqlDbType.Float).Value = sp.Soluong;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Xoasp (DTO_SanPham sp)
        {
            string sql = "delete SanPham where Id = @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sp.Id;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable Timkiemsp(string sp)
        {
            string sql = " select * from SanPham where Tensp like N'%" + sp + "%' or Masp like N'%" + sp + "%'";
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
