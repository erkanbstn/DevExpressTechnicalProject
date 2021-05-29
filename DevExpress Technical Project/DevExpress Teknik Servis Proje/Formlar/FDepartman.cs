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
    public partial class FDepartman : Form
    {
        public FDepartman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FDepartman_Load(object sender, EventArgs e)
        {
            labelControl12.Text = db.TblDepartman.Count().ToString();
            labelControl14.Text = db.TblPersonel.Count().ToString();
            liste();
        }
        void liste()
        {
            var d = from x in db.TblDepartman select new { x.ID, x.Ad, x.Açıklama };
            gridControl1.DataSource = d.ToList();
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            textEdit6.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            textEdit1.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            richTextBox1.Text = gridView1.GetFocusedRowCellValue("Açıklama").ToString();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Length<=50 && textEdit1.Text!="" && richTextBox1.Text.Length>=1)
            {
                TblDepartman d = new TblDepartman();
                d.Ad = textEdit1.Text;
                d.Açıklama = richTextBox1.Text;
                db.TblDepartman.Add(d);
                db.SaveChanges();
                XtraMessageBox.Show("Departman Başarıyla Eklendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                liste();
            }
            else
            {
                XtraMessageBox.Show("Eksik Bilgiler Mevcut", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        { 
                int id = Convert.ToInt16(textEdit6.Text);
                var x = db.TblDepartman.Find(id);
                x.Ad = textEdit1.Text;              
                db.SaveChanges();
                XtraMessageBox.Show("Departman Başarıyla Güncellendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                liste();         
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
                int id = Convert.ToInt32(textEdit6.Text);
                var x = db.TblDepartman.Find(id);
                db.TblDepartman.Remove(x);
                db.SaveChanges();
                XtraMessageBox.Show("Departman Başarıyla Silindi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                liste();
           
        }
    }
}
