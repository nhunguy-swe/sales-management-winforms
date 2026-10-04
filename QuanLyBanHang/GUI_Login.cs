using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanHang
{
    public partial class GUI_Login : Form
    {
        public GUI_Login()
        {
            InitializeComponent();
        }


        private void btnSignin_Click(object sender, EventArgs e)
        {
            bool Login = false;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JJQI5N3\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True");
            SqlDataReader rdr = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Login", con);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if ((txtUsername.Text.Trim() == rdr["Tendangnhap"].
                        ToString().Trim()) && txtPassword.Text.Trim() ==
                        rdr["Matkhau"].ToString().Trim())
                        Login = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối!");
                return;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (con != null)
                {
                    con.Close();
                }
            }

            if (Login == true)
            {
                GUI_NewMenu menu = new GUI_NewMenu();
                menu.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Tên đăng nhập/ mật khẩu không hợp lệ!");
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            txtUsername.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            txtPassword.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
