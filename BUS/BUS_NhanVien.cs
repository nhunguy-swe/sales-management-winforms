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
    public class BUS_NhanVien
    {
        DAL_NhanVien dalnv;
        
        public BUS_NhanVien()
        {
            dalnv = new DAL_NhanVien();
        }

        public DataTable getALLNhanVien()
        {
            return dalnv.getALLNhanVien();
        }

        public bool Themsv(DTO_NhanVien nv)
        {
            return dalnv.Themsv(nv);
        }

        public bool Suanv(DTO_NhanVien nv)
        {
            return dalnv.Suanv(nv);
        }

        public bool Xoanv(DTO_NhanVien nv)
        {
            return dalnv.Xoanv(nv);
        }

        public DataTable Timkiemnv(string nv)
        {
            return dalnv.Timkiemnv(nv);
        }
    }
}
