using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class GUI_Menu : Form
    {
        public GUI_Menu()
        {
            InitializeComponent();
        }

        

        private void btnSanpham_Click(object sender, EventArgs e)
        {
            GUI_SanPham sp = new GUI_SanPham();
            sp.Show();
            this.Hide();
        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            GUI_KhachHang kh = new GUI_KhachHang();
            kh.Show();
            this.Hide();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            GUI_NhanVien nv = new GUI_NhanVien();
            nv.Show();
            this.Hide();
        }

        private void GUI_Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
