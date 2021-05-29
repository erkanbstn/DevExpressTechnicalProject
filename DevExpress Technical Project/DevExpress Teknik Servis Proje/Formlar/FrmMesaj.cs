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
    public partial class FrmMesaj : Form
    {
        public FrmMesaj()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmMesaj_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblMesaj select new {x.Mail, x.Konu, x.Mesaj, }).ToList();
        }
    }
}
