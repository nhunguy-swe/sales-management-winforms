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
    public class DAL_CTHD
    {
        //Khai bao bien
        DBConnection dc; //Lay lai ket noi trong data connection
        SqlDataAdapter da;
        SqlCommand cmd;

        //Ham tao
        public DAL_CTHD ()
        {
            dc = new DBConnection();//Khoi tao bien cua dataconnection
        }

        //Phuong thuc 
        public DataTable getALLCTHD()
        {
            // Tạo câu lệnh SQL để lấy toàn bộ CTHD
            string sql = "select Mahd, Ngaylap, KhachHang.Makh, NhanVien.Manv, Dongia from CTHD, KhachHang, NhanVien where CTHD.Makh = KhachHang.Makh and CTHD.Manv = NhanVien.Manv";
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

        public bool Themcthd(DTO_CTHD cthd)
        {
            //Tao chuoi sql de them duoc CTHD 
            string sql = "insert into CTHD (Mahd, Ngaylap, Makh, Manv, Dongia) values (@Mahd, @Ngaylap, @Makh, @Manv, @Dongia)";
            SqlConnection con = dc.getConnect(); //Lay chuoi ket noi
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Mahd", SqlDbType.NVarChar).Value = cthd.Mahd;
                cmd.Parameters.Add("@Ngaylap", SqlDbType.Date).Value = cthd.Ngaylap;
                cmd.Parameters.Add("@Makh", SqlDbType.NVarChar).Value = cthd.Makh;
                cmd.Parameters.Add("@Manv", SqlDbType.NVarChar).Value = cthd.Manv;
                cmd.Parameters.Add("@Dongia", SqlDbType.Float).Value = cthd.Dongia;
                cmd.ExecuteNonQuery();// ExecuteNonQuery() de thuc thi 
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Suacthd (DTO_CTHD cthd)
        {
            string sql = "update CTHD set Mahd = @Mahd, Ngaylap = @Ngaylap, Makh = @Makh, Manv = @Manv, Dongia = @Dongia where Id = @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = cthd.Id;
                cmd.Parameters.Add("@Mahd", SqlDbType.NVarChar).Value = cthd.Mahd;
                cmd.Parameters.Add("@Ngaylap", SqlDbType.Date).Value = cthd.Ngaylap;
                cmd.Parameters.Add("@Makh", SqlDbType.NVarChar).Value = cthd.Makh;
                cmd.Parameters.Add("@Manv", SqlDbType.NVarChar).Value = cthd.Manv;
                cmd.Parameters.Add("@Dongia", SqlDbType.Float).Value = cthd.Dongia;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Xoacthd (DTO_CTHD cthd)
        {
            string sql = "delete CTHD where Id = @Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = cthd.Id;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable Timkiemcthd (string cthd)
        {
            string sql = " select * from CTHD where Mahd like N'%" + cthd + "%' or Makh like N'%" + cthd + "%' or Manv like N'%" + cthd + "%'";
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
