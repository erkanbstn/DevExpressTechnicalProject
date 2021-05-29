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
    public partial class FArızalıDetayListesi : Form
    {
        public FArızalıDetayListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FArızalıDetayListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblÜrünTakip
                                      select new
                                      {
                                          x.TakipID,                                          
                                          x.SeriNo,
                                          x.Tarih,
                                          x.Açıklama
                                      }).ToList();
        }
    }
}
