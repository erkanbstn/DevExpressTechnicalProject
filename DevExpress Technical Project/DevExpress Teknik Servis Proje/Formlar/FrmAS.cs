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
    public partial class FrmAS : Form
    {
        public FrmAS()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmAS_Load(object sender, EventArgs e)
        {



            gridControl1.DataSource = (from d in db.TblÜrün select new { d.Ad, d.Marka, d.Stok }).Where(x => x.Stok < 70).ToList();
            gridControl2.DataSource = (from y in db.TblCari select new { y.Ad, y.Soyad, y.Telefon, y.İl }).ToList();
            gridControl3.DataSource = db.adets().ToList();
            DateTime bugün = DateTime.Today;
            var deger = (from x in db.TblNot.OrderBy(y => y.Tarih) where (x.Tarih == bugün) select new { x.Başlık,x.İçerik, x.Tarih });
            gridControl4.DataSource = deger.ToList();
            
        }
    }
}
