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
    public partial class FrmÜrünListesi : Form
    {
        public FrmÜrünListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void liste()
        {
            var değer = from x in db.TblÜrün select new { x.ID, x.Ad,  x.Marka,Kategori = x.TblKategori.Ad, x.Stok, x.AlışFiyat, x.SatışFiyat };
            gridControl1.DataSource = değer.ToList();
        }
        private void FrmÜrünListesi_Load(object sender, EventArgs e)
        {

            liste();
            lookUpEdit1.Properties.DataSource = (from x in db.TblKategori select new { x.ID, x.Ad }).ToList();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Kategori").ToString();


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            TblÜrün t = new TblÜrün();
            t.Ad = textEdit1.Text;
            t.Marka = textEdit2.Text;
            t.AlışFiyat = decimal.Parse(textEdit3.Text);
            t.SatışFiyat = decimal.Parse(textEdit4.Text);
            t.Stok = short.Parse(textEdit5.Text);
            t.Durum = false;
            t.Kategori = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TblÜrün.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Ürün Başarıyla Eklendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

            liste();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textEdit6.Text);
            var x = db.TblÜrün.Find(id);
            x.Ad = textEdit1.Text;
            x.Marka = textEdit2.Text;
            x.AlışFiyat = decimal.Parse(textEdit3.Text);
            x.SatışFiyat = decimal.Parse(textEdit4.Text);
            x.Stok = short.Parse(textEdit5.Text);
            x.Kategori = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("Ürün Başarıyla Güncellendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            liste();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textEdit6.Text);
            var x = db.TblÜrün.Find(id);
            db.TblÜrün.Remove(x);
            db.SaveChanges();
            XtraMessageBox.Show("Ürün Başarıyla Silindi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            liste();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            textEdit6.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            textEdit1.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            textEdit2.Text = gridView1.GetFocusedRowCellValue("Marka").ToString();
            textEdit3.Text = gridView1.GetFocusedRowCellValue("AlışFiyat").ToString();
            textEdit4.Text = gridView1.GetFocusedRowCellValue("SatışFiyat").ToString();
            textEdit5.Text = gridView1.GetFocusedRowCellValue("Stok").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Kategori").ToString();
        }
    }
}
