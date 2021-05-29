using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DevExpress_Teknik_Servis_Proje.Formlar
{
    public partial class FrmCariİller : Form
    {
        public FrmCariİller()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void FrmCariİller_Load(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand g = new SqlCommand("select il,count(*) from Tblcari  group by il  ",bgl);
            SqlDataReader dr = g.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString( dr[0]),int.Parse(dr[1].ToString()));
            }
            gridControl1.DataSource = db.TblCari.OrderBy(x => x.İl).GroupBy(y => y.İl).Select(z => new { İL = z.Key, Toplam = z.Count() }).ToList();
            
        }
    }
}
