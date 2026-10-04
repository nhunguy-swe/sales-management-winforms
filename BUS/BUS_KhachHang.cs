using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalkh;

        public BUS_KhachHang ()
        {
            dalkh = new DAL_KhachHang();
        }

        public DataTable getALLKhachHang()
        {
            return dalkh.getALLKhachHang();
        }

        public bool Themkh(DTO_KhachHang kh)
        {
            return dalkh.Themkh(kh);
        }

        public bool Suakh (DTO_KhachHang kh)
        {
            return dalkh.Suakh(kh);
        }

        public bool Xoakh (DTO_KhachHang kh)
        {
            return dalkh.Xoakh(kh);
        }

        public DataTable Timkiemkh(string kh)
        {
            return dalkh.Timkiemkh(kh);
        }
    }
}
