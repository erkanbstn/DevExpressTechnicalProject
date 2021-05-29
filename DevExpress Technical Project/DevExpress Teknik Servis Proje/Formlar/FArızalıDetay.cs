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
    public partial class FArızalıDetay : Form
    {
        public FArızalıDetay()
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
            TblÜrünTakip d = new TblÜrünTakip();
            d.Açıklama = richTextBox1.Text;
            d.SeriNo = textEdit1.Text;
            d.Tarih = DateTime.Parse(textEdit2.Text);
            db.TblÜrünTakip.Add(d);
            db.SaveChanges();
            XtraMessageBox.Show("Arıza Detayları Başarıyla Güncellendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
