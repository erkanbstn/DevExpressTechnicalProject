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
    public partial class FPersonelListesi : Form
    {
        public FPersonelListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void personeller()
        {
            string a1, s1, m1, d1, a2, s2, m2, d2,a3,s3,m3,d3;
            // 1. Personel
            a1 = db.TblPersonel.First(x => x.ID == 2).Ad;
            s1 = db.TblPersonel.First(x => x.ID == 2).Soyad;
            m1 = db.TblPersonel.First(x => x.ID == 2).Mail;
            d1 = db.TblPersonel.First(x => x.ID == 2).TblDepartman.Ad;
            labelControl27.Text = m1;
            labelControl26.Text = d1;
            labelControl12.Text = a1;
            labelControl13.Text = s1;
            // 2. Personel
            a2 = db.TblPersonel.First(x => x.ID == 1).Ad;
            s2 = db.TblPersonel.First(x => x.ID == 1).Soyad;
            m2 = db.TblPersonel.First(x => x.ID == 1).Mail;
            d2 = db.TblPersonel.First(x => x.ID == 1).TblDepartman.Ad;
            labelControl29.Text = m2;
            labelControl28.Text = d2;
            labelControl23.Text = a2;
            labelControl18.Text = s2;
            // 3. Personel
            a3 = db.TblPersonel.First(x => x.ID == 8).Ad;
            s3 = db.TblPersonel.First(x => x.ID == 8).Soyad;
            m3 = db.TblPersonel.First(x => x.ID == 8).Mail;
            d3 = db.TblPersonel.First(x => x.ID == 8).TblDepartman.Ad;
            labelControl31.Text = m3;
            labelControl30.Text = d3;
            labelControl25.Text = a3;
            labelControl24.Text = s3;

        }
        void liste()
        {
            var x = from v in db.TblPersonel select new { v.ID, v.Ad, v.Soyad,v.Mail, v.Telefon };
            gridControl1.DataSource = x.ToList();
        }
        void liste2()
        {
            var x = from c in db.TblPersonel select new { c.Ad, Departman = c.TblDepartman.Ad };
            gridControl2.DataSource = x.ToList();
        }
        private void FPersonelListesi_Load(object sender, EventArgs e)
        {
            liste();
            personeller();
            liste2();
            lookUpEdit1.Properties.DataSource = (from x in db.TblDepartman select new { x.ID, x.Ad }).ToList();

          
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            textEdit6.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            textEdit1.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            textEdit2.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            
            textEdit5.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
            textEdit7.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            lookUpEdit1.Text = gridView2.GetFocusedRowCellValue("Departman").ToString();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
