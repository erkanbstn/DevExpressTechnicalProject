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
    public partial class FrmYeniÜrün : Form
    {
        public FrmYeniÜrün()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TblÜrün t = new TblÜrün();
            t.Ad = textEdit1.Text;
            t.Marka = textEdit2.Text;
            t.Kategori = byte.Parse(textEdit3.Text);
            t.AlışFiyat = decimal.Parse(textEdit4.Text);
            t.SatışFiyat = decimal.Parse(textEdit5.Text);
            t.Stok = short.Parse(textEdit7.Text);
            db.TblÜrün.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Ürün Başarıyla Eklendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
