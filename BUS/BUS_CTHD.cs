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
    public class BUS_CTHD
    {
        DAL_CTHD dalcthd;

        //Ham tao
        public BUS_CTHD ()
        {
            //Khoi tao doi tuong dal
            dalcthd = new DAL_CTHD();
        }

        public DataTable getALLCTHD()
        {
            //Goi lai phuong thuc cua DAL
            return dalcthd.getALLCTHD();
        }

        public bool Themcthd(DTO_CTHD cthd)
        {
            return dalcthd.Themcthd(cthd);
        }

        public bool Suacthd(DTO_CTHD cthd)
        {
            return dalcthd.Suacthd(cthd);
        }

        public bool Xoacthd(DTO_CTHD cthd)
        {
            return dalcthd.Xoacthd(cthd);
        }

        public DataTable Timkiemcthd(string cthd)
        {
            return dalcthd.Timkiemcthd(cthd);
        }
    }
}
