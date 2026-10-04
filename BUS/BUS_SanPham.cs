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
    public class BUS_SanPham
    {
        DAL_SanPham dalsp;

        public BUS_SanPham ()
        {
            dalsp = new DAL_SanPham();
        }

        public DataTable getALLSanPham()
        {
            return dalsp.getALLSanPham();
        }

        public bool Themsp (DTO_SanPham sp)
        {
            return dalsp.Themsp(sp);
        }

        public bool Suasp (DTO_SanPham sp)
        {
            return dalsp.Suasp(sp);
        }

        public bool Xoasp(DTO_SanPham sp)
        {
            return dalsp.Xoasp(sp);
        }

        public DataTable Timkiemsp(string sp)
        {
            return dalsp.Timkiemsp(sp);
        }
    }
}
