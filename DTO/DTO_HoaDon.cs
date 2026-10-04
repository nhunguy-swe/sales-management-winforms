using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDon
    {
        private int id;
        private string mahd;
        private double soluong;
        private double dongia;
        private string masp;

        public int Id { get => id; set => id = value; }
        public string Mahd { get => mahd; set => mahd = value; }
        public double Soluong { get => soluong; set => soluong = value; }
        public double Dongia { get => dongia; set => dongia = value; }
        public string Masp { get => masp; set => masp = value; }
    }
}
