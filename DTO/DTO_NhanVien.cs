using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        private int id;
        private string manv;
        private string tennv;
        private string gioitinh;
        private string sdt;
        private DateTime ngaylamviec;

        public int Id { get => id; set => id = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public DateTime Ngaylamviec { get => ngaylamviec; set => ngaylamviec = value; }
    }
}
