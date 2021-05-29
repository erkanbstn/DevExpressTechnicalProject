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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            
            var değer = db.TblÜrün.OrderBy(x => x.Marka).GroupBy(c => c.Marka).Select(v => new { Marka = v.Key, Toplam = v.Count() });
            gridControl1.DataSource = değer.ToList();
            // Yukarıdaki değer değişkenine atanan Select new kısmı anonimus tipindeki kodlamadır      
            labelControl3.Text = (from x in db.TblÜrün select x.Marka).Distinct().Count().ToString();
            labelControl5.Text = (from c in db.TblÜrün orderby c.SatışFiyat descending select c.Marka).FirstOrDefault();


            chartControl1.Series["Series 1"].Points.AddPoint("Siemens",4);
            chartControl1.Series["Series 1"].Points.AddPoint("ARÇELİK", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("ACER", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("MONSTER", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("LG", 1);

            chartControl2.Series["Ürün Kategori"].Points.AddPoint("Beyaz Eşya", 3);
            chartControl2.Series["Ürün Kategori"].Points.AddPoint("Bilgisayar", 4);
            chartControl2.Series["Ürün Kategori"].Points.AddPoint("Tv", 1);
            chartControl2.Series["Ürün Kategori"].Points.AddPoint("Küçük Ev Aleti", 4);
            chartControl2.Series["Ürün Kategori"].Points.AddPoint("Bilgisayar Parçaları", 5);
          

        }
    }
}
