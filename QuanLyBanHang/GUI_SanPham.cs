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
    public partial class GUI_SanPham : Form
    {
        BUS_SanPham bussp;
        public GUI_SanPham()
        {
            InitializeComponent();
            bussp = new BUS_SanPham();
        }

        public void ShowAllSanPham()
        {
            DataTable dt = bussp.getALLSanPham();
            dgvSanPham.DataSource = dt;
        }

        private void GUI_SanPham_Load(object sender, EventArgs e)
        {
            ShowAllSanPham();
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMasp.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMasp.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTensp.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTensp.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSoluong.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_SanPham sp = new DTO_SanPham();
                sp.Masp = txtMasp.Text;
                sp.Tensp = txtTensp.Text;
                sp.Gia = double.Parse(txtGia.Text);
                sp.Soluong = double.Parse(txtSoluong.Text);

                if (bussp.Themsp(sp))
                    ShowAllSanPham();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        int ID;

        

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_SanPham sp = new DTO_SanPham();
                sp.Id = ID;
                sp.Masp = txtMasp.Text;
                sp.Tensp = txtTensp.Text;
                sp.Gia = double.Parse(txtGia.Text);
                sp.Soluong = double.Parse(txtSoluong.Text);

                if (bussp.Suasp(sp))
                    ShowAllSanPham();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DTO_SanPham sp = new DTO_SanPham();
                sp.Id = ID;
                if (bussp.Xoasp(sp))
                    ShowAllSanPham();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                ID = Int32.Parse(dgvSanPham.Rows[index].Cells["Id"].Value.ToString());
                txtMasp.Text = dgvSanPham.Rows[index].Cells["Masp"].Value.ToString();
                txtTensp.Text = dgvSanPham.Rows[index].Cells["Tensp"].Value.ToString();
                txtGia.Text = dgvSanPham.Rows[index].Cells["Gia"].Value.ToString();
                txtSoluong.Text = dgvSanPham.Rows[index].Cells["Soluong"].Value.ToString();
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimkiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bussp.Timkiemsp(value);
                dgvSanPham.DataSource = dt;
            }
            else
                ShowAllSanPham();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            GUI_NewMenu menu = new GUI_NewMenu();
            menu.Show();
            this.Close();
        }
    }
}
