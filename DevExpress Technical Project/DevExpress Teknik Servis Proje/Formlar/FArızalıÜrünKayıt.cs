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
    public partial class FArızalıÜrünKayıt : Form
    {
        public FArızalıÜrünKayıt()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TblÜrünKabul d = new TblÜrünKabul();
            d.Cari = int.Parse(textEdit1.Text);
            d.GelişTarih = DateTime.Parse(textEdit4.Text);
            d.Personel = short.Parse(textEdit3.Text);
            d.ÜrünSeriNo = textEdit8.Text;
            db.TblÜrünKabul.Add(d);
            db.SaveChanges();
            XtraMessageBox.Show("Arıza Kaydı Başarılı", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var d = db.TblÜrünHareket.SingleOrDefault(x => x.ÜrünSeriNo == textEdit8.Text);

            if (d != null)

            {
                textEdit1.Text = d.TblCari.Ad + " " + d.TblCari.Soyad;
                textEdit3.Text = d.TblPersonel.Ad + " " + d.TblPersonel.Soyad;
            }
            else
            {
                XtraMessageBox.Show("Eksik Veya Geçersiz Kod", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
