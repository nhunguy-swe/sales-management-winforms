
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CTHD
    {
        private int id;
        private string mahd;
        private DateTime ngaylap;
        private string makh;
        private string manv;
        private double dongia;

        public int Id { get => id; set => id = value; }
        public string Mahd { get => mahd; set => mahd = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public string Makh { get => makh; set => makh = value; }
        public string Manv { get => manv; set => manv = value; }
        public double Dongia { get => dongia; set => dongia = value; }

    }
}
