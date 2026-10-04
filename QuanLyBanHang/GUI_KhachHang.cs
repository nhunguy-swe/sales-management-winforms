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
    public partial class GUI_KhachHang : Form
    {
        BUS_KhachHang buskh;

        public GUI_KhachHang()
        {
            InitializeComponent();
            buskh = new BUS_KhachHang();
        }

        public void ShowAllKhachHang()
        {
            DataTable dt = buskh.getALLKhachHang();
            dgvKhachHang.DataSource = dt;
        }

        private void GUI_KhachHang_Load(object sender, EventArgs e)
        {
            ShowAllKhachHang();
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMakh.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenkh.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSdt.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSdt.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtSinhnhat.Text))
            {
                MessageBox.Show("Bạn chưa nhập sinh nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtSinhnhat.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiem.Text))
            {
                MessageBox.Show("Bạn chưa nhập điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_KhachHang kh = new DTO_KhachHang();
                kh.Makh = txtMakh.Text;
                kh.Tenkh = txtTenkh.Text;
                kh.Sdt = txtSdt.Text;
                kh.Sinhnhat = dtSinhnhat.Value;
                kh.Diem = double.Parse(txtDiem.Text);

                if (buskh.Themkh(kh))
                    ShowAllKhachHang();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        int ID;

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                ID = Int32.Parse(dgvKhachHang.Rows[index].Cells["Id"].Value.ToString());
                txtMakh.Text = dgvKhachHang.Rows[index].Cells["Makh"].Value.ToString();
                txtTenkh.Text = dgvKhachHang.Rows[index].Cells["Tenkh"].Value.ToString();
                txtSdt.Text = dgvKhachHang.Rows[index].Cells["Sdt"].Value.ToString();
                dtSinhnhat.Text = dgvKhachHang.Rows[index].Cells["Sinhnhat"].Value.ToString();
                txtDiem.Text = dgvKhachHang.Rows[index].Cells["Diem"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_KhachHang kh = new DTO_KhachHang();
                kh.Id = ID;
                kh.Makh = txtMakh.Text;
                kh.Tenkh = txtTenkh.Text;
                kh.Sdt = txtSdt.Text;
                kh.Sinhnhat = dtSinhnhat.Value;
                kh.Diem = double.Parse(txtDiem.Text);

                if (buskh.Suakh(kh))
                    ShowAllKhachHang();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DTO_KhachHang kh = new DTO_KhachHang();
                kh.Id = ID;
                if (buskh.Xoakh(kh))
                    ShowAllKhachHang();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimkiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = buskh.Timkiemkh(value);
                dgvKhachHang.DataSource = dt;
            }
            else
                ShowAllKhachHang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            GUI_NewMenu menu = new GUI_NewMenu();
            menu.Show();
            this.Close();
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
