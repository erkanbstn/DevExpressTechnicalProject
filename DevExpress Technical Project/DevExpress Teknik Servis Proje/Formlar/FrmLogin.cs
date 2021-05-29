using DevExpress.XtraEditors;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var x = from d in db.TblAdmin where d.KullanıcıAd == textEdit1.Text & d.Şifre == textEdit2.Text select d;
            if (x.Any())
            {
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre ! ","Teknik Servis Otomasyonu",MessageBoxButtons.OK,MessageBoxIcon.Warning) ;
            }

        }
    }
}
