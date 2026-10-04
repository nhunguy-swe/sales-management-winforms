using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuanLyBanHang
{
    public partial class GUI_NhanVien : Form
    {
        BUS_NhanVien busnv;
        public GUI_NhanVien()
        {
            InitializeComponent();
            busnv = new BUS_NhanVien();
        }

        public void ShowAllNhanVien ()
        {
            DataTable dt = busnv.getALLNhanVien();
            dgvNhanVien.DataSource = dt;
        }

        private void GUI_NhanVien_Load(object sender, EventArgs e)
        {
            ShowAllNhanVien();
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtManv.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTennv.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTennv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGioitinh.Text)) 
            {
                MessageBox.Show("Bạn chưa nhập giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGioitinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSdt.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSdt.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtNgaylamviec.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày làm việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtNgaylamviec.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.Manv = txtManv.Text;
                nv.Tennv = txtTennv.Text;
                nv.Gioitinh = txtGioitinh.Text;
                nv.Sdt = txtSdt.Text;
                nv.Ngaylamviec = dtNgaylamviec.Value;

                if (busnv.Themsv(nv))
                    ShowAllNhanVien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        int ID;

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                ID = Int32.Parse(dgvNhanVien.Rows[index].Cells["Id"].Value.ToString());
                txtManv.Text = dgvNhanVien.Rows[index].Cells["Manv"].Value.ToString();
                txtTennv.Text = dgvNhanVien.Rows[index].Cells["Tennv"].Value.ToString();
                txtGioitinh.Text = dgvNhanVien.Rows[index].Cells["Gioitinh"].Value.ToString();
                txtSdt.Text = dgvNhanVien.Rows[index].Cells["Sdt"].Value.ToString();
                dtNgaylamviec.Text = dgvNhanVien.Rows[index].Cells["Ngaylamviec"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.Id = ID;
                nv.Manv = txtManv.Text;
                nv.Tennv = txtTennv.Text;
                nv.Gioitinh = txtGioitinh.Text;
                nv.Sdt = txtSdt.Text;
                nv.Ngaylamviec = dtNgaylamviec.Value;

                if (busnv.Suanv(nv))
                    ShowAllNhanVien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.Id = ID;
                if (busnv.Xoanv(nv))
                    ShowAllNhanVien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimkiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = busnv.Timkiemnv(value);
                dgvNhanVien.DataSource = dt;
            }
            else
                ShowAllNhanVien();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            GUI_NewMenu menu = new GUI_NewMenu();
            menu.Show();
            this.Close();
        }
    }
}
