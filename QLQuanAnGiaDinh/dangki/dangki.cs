using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAnGiaDinh.dangki
{
    public partial class dangki : Form
    {
        QLQuanAnGiaDinhEntities db = new QLQuanAnGiaDinhEntities();
        public dangki()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if(txtTen.Text == "" || txtTenNguoi.Text == "" || txtMatKhau.Text == "" || txtSDT.Text == "" )
            {
                MessageBox.Show("Nhập thiếu thông tin, vui lòng kiểm tra lại!!!");
                return;
            }    

            TaiKhoan ktsdt = db.TaiKhoans.Find(txtSDT.Text);
            if(ktsdt != null)
            {
                MessageBox.Show("Số điện thoại này đã được dùng, vui lòng nhập lại!!!");
                return;
            }

            var kttentaikhoan = from i in db.TaiKhoans
                                where i.taikhoan1 == txtTen.Text
                                select i;

            if(kttentaikhoan.Count() > 0)
            {
                MessageBox.Show("Tên tài khoản này đã được dùng, vui lòng nhập lại!!!");
                return;
            }
            
            if(txtMatKhau.Text != txtLapLaiMK.Text)
            {
                MessageBox.Show("Lập lại mật khẩu không chính xác, vui lòng kiểm tra lại!!!");
                return;
            }

            TaiKhoan tk = new TaiKhoan()
            {
                taikhoan1 = txtTen.Text,
                matkhau = txtMatKhau.Text,
                sdt = txtSDT.Text,
                ten = txtTenNguoi.Text,
            };

            db.TaiKhoans.Add(tk);
            db.SaveChanges();

            if(db.SaveChanges() == 0)
            {
                MessageBox.Show("Tạo tài khoản thành công !!!");
                this.Close();
            }    
            
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) )
            {
                e.Handled = true;
            }    
        }
    }
}
