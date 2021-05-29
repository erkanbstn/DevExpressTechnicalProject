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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textEdit6.Text);
            var x = db.TblCari.Find(id);
            db.TblCari.Remove(x);
            db.SaveChanges();
            XtraMessageBox.Show("Cari Başarıyla Silindi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            liste();
        }

        void liste()
        {
            var g = from x in db.TblCari select new { x.ID, x.Ad, x.Soyad, x.Telefon, x.Mail, x.İl, x.İlçe, x.Banka, x.VergiDairesi, x.VergiNo, x.Statü, x.Adres };
            gridControl1.DataSource = g.ToList();

            labelControl12.Text = db.TblCari.Count().ToString();
        }
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            liste();
            lookUpEdit2.Properties.DataSource = (from v in db.TblCari select new { v.ID, v.İl }).ToList();
            lookUpEdit1.Properties.DataSource = (from v in db.TblCari select new { v.ID, v.İlçe }).ToList();
       
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            TblCari d = new TblCari();
            d.Ad = textEdit1.Text;
            d.Soyad = textEdit2.Text;
            d.İl = lookUpEdit2.Text;
            d.İlçe = lookUpEdit1.Text;
            db.TblCari.Add(d);
            db.SaveChanges();
            XtraMessageBox.Show("Cari Başarıyla Eklendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textEdit6.Text);
            var x = db.TblCari.Find(id);
            x.Ad = textEdit1.Text;
            x.Soyad = textEdit2.Text;
            x.İl = lookUpEdit2.Text;
            x.İlçe = lookUpEdit1.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Cari Başarıyla Güncellendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            textEdit1.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            textEdit2.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("İl").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("İlçe").ToString();
            textEdit3.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
            textEdit5.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            textEdit6.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
        }
    }
}
