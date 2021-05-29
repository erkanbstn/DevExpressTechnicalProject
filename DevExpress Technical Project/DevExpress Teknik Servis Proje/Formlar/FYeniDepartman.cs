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
    public partial class FYeniDepartman : Form
    {
        public FYeniDepartman()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Length <= 50 && textEdit1.Text != "" && textEdit1.Text!="Departman Ad")
            {
                TblDepartman d = new TblDepartman();
                d.Ad = textEdit1.Text;
                d.Açıklama = "Default";
                db.TblDepartman.Add(d); 
                db.SaveChanges();
                XtraMessageBox.Show("Departman Başarıyla Eklendi", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);              
            }
            else
            {
                XtraMessageBox.Show("Eksik Bilgiler Mevcut", "Ticari Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
