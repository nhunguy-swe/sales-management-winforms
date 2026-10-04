using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SanPham
    {
        private int id;
        private string masp;
        private string tensp;
        private double gia;
        private double soluong;

        public int Id { get => id; set => id = value; }
        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public double Gia { get => gia; set => gia = value; }
        public double Soluong { get => soluong; set => soluong = value; }
    }
}
