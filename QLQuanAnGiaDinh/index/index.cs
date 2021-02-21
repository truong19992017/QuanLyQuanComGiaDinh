using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAnGiaDinh.index
{
    public partial class index : Form
    {
        QLQuanAnGiaDinhEntities db = new QLQuanAnGiaDinhEntities();
        BindingSource listthucan = new BindingSource();
        BindingSource listdsdakeu = new BindingSource();
        public index()
        {
            InitializeComponent();
            dgvThucAn.DataSource = listthucan;
            dgvDsMonDaGoi.DataSource = listdsdakeu;
            ktban();
        }

        void showdsgoimoncuaban(int a)
        {
            var result = from i in db.BanAns
                         where i.trangthai == "tróng" && i.mabanan == a
                         select i;

            listdsdakeu.Clear();

            if (result.Count() == 0)
            {
                var result1 = from i in db.PhieuGoiMons
                              from j in db.CTPhieuGoiMons
                              from c in db.ThucAns
                              where i.maphieugoimon == j.maphieugoimon && i.mabanan == a && j.mathucan == c.mathucan && i.tinhtrang == "Chưa tính"
                              select new { c.mathucan, c.tenthucan, j.soluong, j.giaban };
                listdsdakeu.DataSource = result1.ToList();
            }

            double tong = 0;
            
            if (dgvDsMonDaGoi.RowCount > 0)
            {
                for (int i = 0; i < dgvDsMonDaGoi.RowCount; i++)
                {
                    double c = Convert.ToDouble(dgvDsMonDaGoi[3, i].Value.ToString()) * Convert.ToDouble(dgvDsMonDaGoi[2, i].Value.ToString());
                    tong = tong + c;
                }
            }

            txtTienPhaiThanhToan.Text = tong.ToString();
        }


        void ktban()
        {
            var result = from i in db.BanAns
                         select i;

            int stt = 1;

            foreach(var i in result)
            {
                if(i.trangthai == "có người")
                {
                    if(stt == 1)
                    {
                        btnBan1.BackColor = Color.Red;
                    }
                    else if (stt == 2)
                    {
                        btnBan2.BackColor = Color.Red;
                    }
                    else if (stt == 3)
                    {
                        btnBan3.BackColor = Color.Red;
                    }
                    else if (stt == 4)
                    {
                        btnBan4.BackColor = Color.Red;
                    }
                    else if (stt == 5)
                    {
                        btnBan5.BackColor = Color.Red;
                    }
                    else if (stt == 6)
                    {
                        btnBan6.BackColor = Color.Red;
                    }
                    else if (stt == 7)
                    {
                        btnBan7.BackColor = Color.Red;
                    }
                    else if (stt == 8)
                    {
                        btnBan8.BackColor = Color.Red;
                    }
                }
                if (i.trangthai == "tróng")
                {
                    if (stt == 1)
                    {
                        btnBan1.BackColor = Color.Aqua;
                    }
                    else if (stt == 2)
                    {
                        btnBan2.BackColor = Color.Aqua;
                    }
                    else if (stt == 3)
                    {
                        btnBan3.BackColor = Color.Aqua;
                    }
                    else if (stt == 4)
                    {
                        btnBan4.BackColor = Color.Aqua;
                    }
                    else if (stt == 5)
                    {
                        btnBan5.BackColor = Color.Aqua;
                    }
                    else if (stt == 6)
                    {
                        btnBan6.BackColor = Color.Aqua;
                    }
                    else if (stt == 7)
                    {
                        btnBan7.BackColor = Color.Aqua;
                    }
                    else if (stt == 8)
                    {
                        btnBan8.BackColor = Color.Aqua;
                    }
                }
                stt++;
            }    
        }


        void HienThiThucAn(int a)
        {
            listthucan.Clear();

            var result = from i in db.ThucAns
                         where i.maloaithucan == a
                         select new { i.mathucan, i.tenthucan, i.giathucan };

            listthucan.DataSource = result.ToList();
        }


        // button loại đồ ăn //
        private void btnCom_Click(object sender, EventArgs e)
        {
            HienThiThucAn(1);
        }

        private void btnCa_Click(object sender, EventArgs e)
        {
            HienThiThucAn(2);
        }

        private void btnHeoBo_Click(object sender, EventArgs e)
        {
            HienThiThucAn(3);
        }

        private void btnGa_Click(object sender, EventArgs e)
        {
            HienThiThucAn(4);
        }

        private void btnCanh_Click(object sender, EventArgs e)
        {
            HienThiThucAn(5);
        }

        private void btnNuoc_Click(object sender, EventArgs e)
        {
            HienThiThucAn(6);
        }

        

        // button bàn ăn //
        private void btnBan1_Click(object sender, EventArgs e)
        {
            txtSoBan.Text = "1";
            showdsgoimoncuaban(1);
        }

        private void btnBan2_Click(object sender, EventArgs e)
        {
            txtSoBan.Text = "2";
            showdsgoimoncuaban(2);
        }

        private void btnBan3_Click(object sender, EventArgs e)
        {
            txtSoBan.Text = "3";
            showdsgoimoncuaban(3);
        }

        private void btnBan4_Click(object sender, EventArgs e)
        {
            txtSoBan.Text = "4";
            showdsgoimoncuaban(4);
        }

        private void btnBan5_Click(object sender, EventArgs e)
        {
            txtSoBan.Text = "5";
            showdsgoimoncuaban(5);
        }

        private void btnBan6_Click(object sender, EventArgs e)
        {
            txtSoBan.Text = "6";
            showdsgoimoncuaban(6);
        }

        private void btnBan7_Click(object sender, EventArgs e)
        {
            txtSoBan.Text = "7";
            showdsgoimoncuaban(7);
        }

        private void btnBan8_Click(object sender, EventArgs e)
        {
            txtSoBan.Text = "8";
            showdsgoimoncuaban(8);
        }

        // binding dgv
        void bindingdgvthucan()
        {
            //txtMaThucAn.DataBindings.Add(new Binding("Text", dgvThucAn.DataSource, "mathucan", false, DataSourceUpdateMode.Never));
            //txtMA.DataBindings.Add(new Binding("Text", dgvThucAn.DataSource, "tenthucan", false, DataSourceUpdateMode.Never));
        }


        private void dgvThucAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dgvThucAn.CurrentCell.RowIndex;
            txtMaThucAn.Text = dgvThucAn[0, a].Value.ToString();
            txtMA.Text = dgvThucAn[1, a].Value.ToString();
            txtGiaBan.Text = dgvThucAn[2, a].Value.ToString();
        }

        private void dgvDsMonDaGoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dgvDsMonDaGoi.CurrentCell.RowIndex;
            txtMaTA.Text = dgvDsMonDaGoi[0, a].Value.ToString();
            txtTen.Text = dgvDsMonDaGoi[1, a].Value.ToString();
            txtsl.Text = dgvDsMonDaGoi[2, a].Value.ToString();
            txtgia.Text = dgvDsMonDaGoi[3, a].Value.ToString();

            double tong = Convert.ToDouble(txtsl.Text) * Convert.ToDouble(txtgia.Text);
            txttonggia.Text = tong.ToString();
        }


        // goi them thuc an
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if(txtSoBan.Text == "")
            {
                MessageBox.Show("Chưa chọn bàn để thêm, vui lòng chọn lại");
                return;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng, vui lòng nhập lại");
                return;
            }

            int maban = Convert.ToInt32(txtSoBan.Text);

            var result = from i in db.PhieuGoiMons
                         where i.mabanan == maban && i.tinhtrang == "Chưa tính"
                         select i;

            var slphieugoi = from i in db.PhieuGoiMons
                             select i;
            var slctphieugoi = from i in db.CTPhieuGoiMons
                               select i;

            if (result.Count() == 0)
            {
                PhieuGoiMon pgoi = new PhieuGoiMon()
                {
                    mabanan = Convert.ToInt32(txtSoBan.Text),
                    tinhtrang = "Chưa tính",
                    maphieugoimon = (slphieugoi.Count() + 1),
                };

                CTPhieuGoiMon ctpgoi = new CTPhieuGoiMon()
                {
                    mactphieugoimon = (slctphieugoi.Count() + 1),
                    maphieugoimon = (slphieugoi.Count() + 1),
                    mathucan = Convert.ToInt32(txtMaThucAn.Text),
                    giaban = Convert.ToDouble(txtGiaBan.Text),
                    soluong = Convert.ToInt32(txtSoLuong.Text),
                };
                BanAn ba = db.BanAns.Find(Convert.ToInt32(txtSoBan.Text));
                ba.trangthai = "có người";

                db.PhieuGoiMons.Add(pgoi);
                db.CTPhieuGoiMons.Add(ctpgoi);
                db.SaveChanges();
                showdsgoimoncuaban(maban);
                ktban();
            }
            else if (result.Count() == 1)
            {
                
                for(int i = 0; i < dgvDsMonDaGoi.RowCount; i++)
                {
                    if (dgvDsMonDaGoi[1, i].Value.ToString() == txtMA.Text)
                    {
                        var them = from ct in db.CTPhieuGoiMons
                                   from pg in db.PhieuGoiMons
                                   from ta in db.ThucAns
                                   where ct.maphieugoimon == pg.maphieugoimon && pg.mabanan == maban && pg.tinhtrang == "Chưa tính"
                                   && ct.mathucan == ta.mathucan && ta.tenthucan == txtMA.Text
                                   select ct;
                        foreach(var f in them)
                        {
                            f.soluong = f.soluong + Convert.ToInt32(txtSoLuong.Text);
                        }

                        db.SaveChanges();

                        showdsgoimoncuaban(maban);
                        return;
                    }    
                }    

                var themmon = from i in db.PhieuGoiMons
                              where i.mabanan == maban && i.tinhtrang == "Chưa tính"
                              select i;
                

                foreach (var i in themmon)
                {
                    var slctphieugoi1 = from c in db.CTPhieuGoiMons
                                        select c;

                    CTPhieuGoiMon ctpgoi1 = new CTPhieuGoiMon()
                    {
                        mactphieugoimon = (slctphieugoi1.Count() + 1),
                        maphieugoimon = i.maphieugoimon,
                        mathucan = Convert.ToInt32(txtMaThucAn.Text),
                        giaban = Convert.ToDouble(txtGiaBan.Text),
                        soluong = Convert.ToInt32(txtSoLuong.Text),
                    };

                    db.CTPhieuGoiMons.Add(ctpgoi1);
                }
                
                db.SaveChanges();

                showdsgoimoncuaban(maban);
                return;
            }
        }

        // Thanh toan
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int maban = Convert.ToInt32(txtSoBan.Text);
            var tonghoadon = from i in db.HoaDons
                             select i;

            var phieugoimon = from i in db.PhieuGoiMons
                              where i.mabanan == maban && i.tinhtrang == "Chưa tính"
                              select i;

            foreach(var i in phieugoimon)
            {

                HoaDon hd = new HoaDon()
                {
                    mahoadon = (tonghoadon.Count() + 1),
                    ngaythanhtoan = DateTime.Now,
                    maphieugoimon = i.maphieugoimon,
                    tongtien = Convert.ToDouble(txtTienPhaiThanhToan.Text),
                };

                db.HoaDons.Add(hd);

                PhieuGoiMon pg = db.PhieuGoiMons.Find(i.maphieugoimon);
                pg.tinhtrang = "Đã tính";
            }

            BanAn ba = db.BanAns.Find(maban);
            ba.trangthai = "tróng";

            

            db.SaveChanges();

            ktban();
            listdsdakeu.Clear();

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
