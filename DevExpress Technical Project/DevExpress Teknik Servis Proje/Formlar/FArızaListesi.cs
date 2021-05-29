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
    public partial class FArızaListesi : Form
    {
        public FArızaListesi()
        {
            InitializeComponent();
        }
        void lista()
        {
            var değer = from x in db.TblÜrünKabul
                        select new
                        {
                            x.İşlemID,                          
                            Cari = x.TblCari.Ad + x.TblCari.Soyad,
                            Personel = x.TblPersonel.Ad + x.TblPersonel.Soyad,
                            x.GelişTarih,
                            x.ÇıkışTarih,
                            x.ÜrünSeriNo

                        };
            gridControl1.DataSource = değer.ToList();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FArızaListesi_Load(object sender, EventArgs e)
        {
            lista();
        }
    }
}
