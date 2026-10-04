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
    public partial class GUI_CTHD : Form
    {
        BUS_CTHD buscthd;

        //Ham tao
        public GUI_CTHD()
        {
            InitializeComponent();
            buscthd = new BUS_CTHD();
        }

        public void ShowAllCTHD()
        {
            DataTable dt = buscthd.getALLCTHD();
            dgvCTHD.DataSource = dt;
        }

        private void GUI_CTHD_Load(object sender, EventArgs e)
        {
            ShowAllCTHD();
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
            if (string.IsNullOrEmpty(dtNgaylap.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtNgaylap.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMahd.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtManv.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDongia.Text))
            {
                MessageBox.Show("Bạn chưa nhập đơn giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDongia.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_CTHD cthd = new DTO_CTHD();
                cthd.Mahd = txtMahd.Text;
                cthd.Ngaylap = dtNgaylap.Value;
                cthd.Makh = txtMahd.Text;
                cthd.Manv = txtManv.Text;
                cthd.Dongia = double.Parse(txtDongia.Text);

                if (buscthd.Themcthd(cthd))
                    ShowAllCTHD();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_CTHD cthd = new DTO_CTHD();
                cthd.Id = ID;
                cthd.Mahd = txtMahd.Text;
                cthd.Ngaylap = dtNgaylap.Value;
                cthd.Makh = txtMakh.Text;
                cthd.Manv = txtManv.Text;
                cthd.Dongia = double.Parse(txtDongia.Text);

                if (buscthd.Suacthd(cthd))
                    ShowAllCTHD();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DTO_CTHD cthd = new DTO_CTHD();
                cthd.Id = ID;
                if (buscthd.Xoacthd(cthd))
                    ShowAllCTHD();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimkiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = buscthd.Timkiemcthd(value);
                dgvCTHD.DataSource = dt;
            }
            else
                ShowAllCTHD();
        }

        int ID;

        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                ID = Int32.Parse(dgvCTHD.Rows[index].Cells["Id"].Value.ToString());
                txtMahd.Text = dgvCTHD.Rows[index].Cells["Mahd"].Value.ToString();
                dtNgaylap.Text = dgvCTHD.Rows[index].Cells["Ngaylap"].Value.ToString();
                txtMakh.Text = dgvCTHD.Rows[index].Cells["Makh"].Value.ToString();
                txtManv.Text = dgvCTHD.Rows[index].Cells["Manv"].Value.ToString();
                txtDongia.Text = dgvCTHD.Rows[index].Cells["Dongia"].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            GUI_NewMenu menu = new GUI_NewMenu();
            menu.Show();
            this.Close();
        }
    }
}
