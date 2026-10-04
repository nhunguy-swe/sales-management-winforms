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
    public class BUS_HoaDon
    {
        DAL_HoaDon dalhd;

        public BUS_HoaDon ()
        {
            dalhd = new DAL_HoaDon();
        }

        public DataTable getALLHoaDon()
        {
            return dalhd.getALLHoaDon();
        }

        public bool Themhd(DTO_HoaDon hd)
        {
            return dalhd.Themhd(hd);
        }

        public bool Suahd(DTO_HoaDon hd)
        {
            return dalhd.Suahd(hd);
        }

        public bool Xoahd(DTO_HoaDon hd)
        {
            return dalhd.Xoahd(hd);
        }

        public DataTable Timkiemhd(string hd)
        {
            return dalhd.Timkiemhd(hd);
        }
    }
}
