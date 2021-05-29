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
    public partial class FFatura : Form
    {
        public FFatura()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void list()
        {
            var d = from x in db.TblFaturaBilgi
                    select new
                    {
                        x.ID,
                        x.Seri,
                        x.SıraNo,
                        x.Tarih,
                        x.Saat,
                        x.VergiDaire,
                        Cari = x.TblCari.Ad + x.TblCari.Soyad,
                        Personel = x.TblPersonel.Ad + x.TblPersonel.Soyad

                    };

            gridControl1.DataSource = d.ToList();
        }
        private void FFatura_Load(object sender, EventArgs e)
        {

            list();
            lookUpEdit1.Properties.DataSource = (from g in db.TblCari select new { g.ID, Ad = g.Ad +" "+ g.Soyad }).ToList();
            lookUpEdit2.Properties.DataSource = (from g in db.TblPersonel select new { g.ID, Ad = g.Ad +" "+  g.Soyad }).ToList();


        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            list();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            TblFaturaBilgi f = new TblFaturaBilgi();
            f.Seri = textEdit1.Text;
            f.SıraNo = textEdit4.Text;
            f.Tarih = Convert.ToDateTime(textEdit3.Text);
            f.Saat = textEdit7.Text;
            f.VergiDaire = textEdit5.Text;
            f.Cari = int.Parse(lookUpEdit1.EditValue.ToString());
            f.Personel = short.Parse(lookUpEdit2.EditValue.ToString());
            db.TblFaturaBilgi.Add(f);
            db.SaveChanges();
            XtraMessageBox.Show("Fatura Başarıyla Eklendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
