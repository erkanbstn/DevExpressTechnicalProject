using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DevExpress_Teknik_Servis_Proje.Formlar
{
    public partial class FYoutube : Form
    {
        public FYoutube()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void listt()
        {
            gridControl2.DataSource = db.TblNot.Where(x => x.Durum == true).ToList();
        }
        void listf()
        {
            gridControl1.DataSource = db.TblNot.Where(x => x.Durum == false).ToList();
        }
        void lists()
        {
            gridControl3.DataSource =  db.TblNot.OrderBy(a => a.Durum).GroupBy(c => c.Durum).Select(v => new { Durum = v.Key, Toplam = v.Count() }).ToList();
          
        }
        private void FYoutube_Load(object sender, EventArgs e)
        {
            listf();
            listt();
            lists();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            TblNot d = new TblNot();
            d.Başlık = textEdit1.Text;
            d.İçerik = textEdit2.Text;
            if (checkEdit1.Checked == true)
            {
                d.Durum = true;
            }
            else
            {
                d.Durum = false;
            }
            db.TblNot.Add(d);
            db.SaveChanges();  
            XtraMessageBox.Show("Not Başarıyla Eklendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listf();
            listt();
            lists();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
         
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
       
            textEdit6.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            textEdit1.Text = gridView1.GetFocusedRowCellValue("Başlık").ToString();
            textEdit2.Text = gridView1.GetFocusedRowCellValue("İçerik").ToString();
         
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                int id = Convert.ToInt32(textEdit6.Text);
                var x = db.TblNot.Find(id);
                x.Durum = true;
                db.SaveChanges();
                XtraMessageBox.Show("Not Durumu Başarıyla Güncellendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listf();
                listt();
                lists();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            listf();
            listt();
            lists();
        }
    }
}
