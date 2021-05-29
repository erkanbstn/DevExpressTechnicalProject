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
    public partial class FKalem : Form
    {
        public FKalem()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void list()
        {
            gridControl1.DataSource = (from x in db.TblFaturaDetay select new { x.FaturaDetayID, x.Ürün, x.Adet, x.Fiyat, x.Tutar,x.FaturaID }).ToList();
        }
        private void FKalem_Load(object sender, EventArgs e)
        {
            list();

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            list();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            TblFaturaDetay f = new TblFaturaDetay();
            f.Ürün = textEdit1.Text;
            f.Adet =short.Parse( textEdit4.Text);
            f.Fiyat = decimal.Parse(textEdit3.Text);
            f.Tutar = decimal.Parse(textEdit7.Text);
            f.FaturaID = int.Parse(textEdit5.Text);
            db.TblFaturaDetay.Add(f);
            db.SaveChanges();
            XtraMessageBox.Show("Fatura Başarıyla Eklendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();


        }
    }
}
