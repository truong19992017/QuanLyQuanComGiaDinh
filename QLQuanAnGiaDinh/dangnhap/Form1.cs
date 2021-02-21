using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAnGiaDinh
{
    public partial class Form1 : Form
    {
        QLQuanAnGiaDinhEntities db = new QLQuanAnGiaDinhEntities();
        public Form1()
        {
            InitializeComponent();
        }

        void dangnhap()
        {
            string taikhoan = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;

            var result = from i in db.TaiKhoans
                         where i.taikhoan1 == taikhoan && i.matkhau == matkhau
                         select i;

            if(result.Count() > 0)
            {
                index.index i = new index.index();
                this.Visible = false;
                i.ShowDialog();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            dangnhap();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            dangki.dangki i = new dangki.dangki();
            this.Visible = false;
            i.ShowDialog();
            this.Visible = true;
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                dangnhap();
            }
        }
    }
}
