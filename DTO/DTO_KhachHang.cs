using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        private int id;
        private string makh;
        private string tenkh;
        private string sdt;
        private DateTime sinhnhat;
        private double diem;

        public int Id { get => id; set => id = value; }
        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public DateTime Sinhnhat { get => sinhnhat; set => sinhnhat = value; }
        public double Diem { get => diem; set => diem = value; }
    }
}
