using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpress_Teknik_Servis_Proje.Formlar
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.TblÜrün.Count().ToString();
            labelControl3.Text = db.TblKategori.Count().ToString();
            labelControl5.Text = db.TblÜrün.Sum(x => x.Stok).ToString();
            labelControl9.Text = (from x in db.TblÜrün orderby x.Stok descending select x.Ad).FirstOrDefault();
            labelControl11.Text = (from z in db.TblÜrün orderby z.Stok ascending select z.Ad).FirstOrDefault();
           
            labelControl17.Text = (from x in db.TblÜrün orderby x.SatışFiyat descending select x.Ad).FirstOrDefault();
            labelControl19.Text = (from x in db.TblÜrün orderby x.SatışFiyat ascending select x.Ad).FirstOrDefault();


        }
    }
}
