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
    public partial class FSatışlar : Form
    {
        public FSatışlar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void lists()
        {
            var değer = from x in db.TblÜrünHareket
                        select new
                        {
                            x.HareketID,
                            x.TblÜrün.Ad,
                            Müşteri = x.TblCari.Ad + " " +  x.TblCari.Soyad,
                            Personel = x.TblPersonel.Ad + " " + x.TblPersonel.Soyad,
                            x.Tarih,
                            x.Adet,
                            x.Fiyat,
                            x.ÜrünSeriNo
                        };
            gridControl1.DataSource = değer.ToList();
        }
        private void FSatışlar_Load(object sender, EventArgs e)
        {
            lists();
        }
    }
}
