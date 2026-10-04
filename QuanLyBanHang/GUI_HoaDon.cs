using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QuanLyBanHang
{
    public partial class GUI_HoaDon : Form
    {
        BUS_HoaDon bushd;

        //Ham tao
        public GUI_HoaDon()
        {
            InitializeComponent();
            bushd = new BUS_HoaDon();
        }

        public void ShowAllHoaDon()
        {
            DataTable dt = bushd.getALLHoaDon();
            dgvHoaDon.DataSource = dt;
        }

        private void GUI_HoaDon_Load(object sender, EventArgs e)
        {
            ShowAllHoaDon();
        }

        //Phuong thuc
        //Kiem tra
        public bool CheckData()
        {
            //KT từng dữ liệu xem người dùng đã nhập hay chưa
            if (string.IsNullOrEmpty(txtMahd.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSoluong.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDongia.Text))
            {
                MessageBox.Show("Bạn chưa nhập đơn giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDongia.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMasp.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMasp.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                //Khoi tao doi tượng lớp DTO_CTHD để them dữ liệu cthd
                DTO_HoaDon hd = new DTO_HoaDon();
                hd.Mahd = txtMahd.Text;
                hd.Soluong = double.Parse(txtSoluong.Text);
                hd.Dongia = double.Parse(txtDongia.Text);
                hd.Masp = txtMasp.Text;

                if (bushd.Themhd(hd))
                    ShowAllHoaDon();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        int ID;
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_HoaDon hd = new DTO_HoaDon();
                hd.Id = ID;
                hd.Mahd = txtMahd.Text;
                hd.Soluong = double.Parse(txtSoluong.Text);
                hd.Dongia = double.Parse(txtDongia.Text);
                hd.Masp = txtMasp.Text;
                if (bushd.Suahd(hd))
                    ShowAllHoaDon();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DTO_HoaDon hd = new DTO_HoaDon();
                hd.Id = ID;
                if (bushd.Xoahd(hd))
                    ShowAllHoaDon();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //Phuong thuc xu lý sự kiên
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                //Khai báo biến ID
                ID = Int32.Parse(dgvHoaDon.Rows[index].Cells["Id"].Value.ToString());
                txtMahd.Text = dgvHoaDon.Rows[index].Cells["Mahd"].Value.ToString();
                txtSoluong.Text = dgvHoaDon.Rows[index].Cells["Soluong"].Value.ToString();
                txtDongia.Text = dgvHoaDon.Rows[index].Cells["Dongia"].Value.ToString();
                txtMasp.Text = dgvHoaDon.Rows[index].Cells["Masp"].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            GUI_NewMenu menu = new GUI_NewMenu();
            menu.Show();
            this.Close();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimkiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bushd.Timkiemhd(value);
                dgvHoaDon.DataSource = dt;
            }
            else
                ShowAllHoaDon();
        }
    }
}
