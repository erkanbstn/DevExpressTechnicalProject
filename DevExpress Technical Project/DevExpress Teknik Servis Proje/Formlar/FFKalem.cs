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
    public partial class FFKalem : Form
    {
        public FFKalem()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FFKalem_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblFaturaDetay select new { x.FaturaDetayID, x.Ürün, x.Adet, x.Fiyat, x.Tutar, x.FaturaID }).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToUInt16(textEdit3.Text);
            gridControl1.DataSource = (from x in db.TblFaturaDetay select new { x.FaturaDetayID, x.Ürün, x.Adet, x.Fiyat, x.Tutar, x.FaturaID }).Where(x=>x.FaturaID==id).ToList();
        }
    }
}
