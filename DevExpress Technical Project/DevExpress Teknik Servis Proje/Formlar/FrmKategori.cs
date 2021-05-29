using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DevExpress_Teknik_Servis_Proje.Formlar
{
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void liste()
        {
            var x = from v in db.TblKategori select new { v.ID, v.Ad };
            gridControl1.DataSource = x.ToList();
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            liste();
                  
        }

        private void FrmKategori_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if(textEdit1.Text!=null || textEdit1.Text.Length <= 30)
            {
                TblKategori b = new TblKategori();
                b.Ad = textEdit1.Text;
                db.TblKategori.Add(b);
                db.SaveChanges();
                XtraMessageBox.Show("Kategori Başarıyla Eklendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                liste();
            }
            else
            {
                XtraMessageBox.Show("Kategori Adı Boş Geçilemez Veya 30 Karakterden Fazla Girilemez", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            textEdit1.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            textEdit6.Text = gridView1.GetFocusedRowCellValue("ID").ToString();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textEdit6.Text);
            var x = db.TblKategori.Find(id);
            db.TblKategori.Remove(x);
            db.SaveChanges();
            XtraMessageBox.Show("Kategori Başarıyla Silindi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textEdit6.Text);
            var x = db.TblKategori.Find(id);
            x.Ad = textEdit1.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Kategori Başarıyla Güncellendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            textEdit1.Text = "";
            textEdit6.Text = "";
        }
    }
}
