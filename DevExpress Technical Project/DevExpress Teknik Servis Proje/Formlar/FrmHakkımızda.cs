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
    public partial class FrmHakkımızda : Form
    {
        public FrmHakkımızda()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmHakkımızda_Load(object sender, EventArgs e)
        {
            var x = db.TblHakkımızda.First(c => c.ID==1).Hakkımızda;
            var x2 = db.TblHakkımızda.First(c => c.ID==2).Hakkımızda;
            richTextBox1.Text = x;
            richTextBox2.Text = x2;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
