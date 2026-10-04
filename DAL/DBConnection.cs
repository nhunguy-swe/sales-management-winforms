using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBConnection
    {
        string constr;
        public DBConnection()
        {
            //Gan chuoi ket noi bang chuoi ket noi den database
            constr = @"Data Source=DESKTOP-JJQI5N3\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True";
        }

        public SqlConnection getConnect() //Ham lay chuoi ket noi de tra ve  sqlconnection
        {
            return new SqlConnection(constr); //(constr) truyen chuoi ket noi
        }
    }
}
