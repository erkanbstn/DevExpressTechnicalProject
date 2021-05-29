using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace DevExpress_Teknik_Servis_Proje.Formlar
{
    public partial class FrmYeniMesaj : Form
    {
        public FrmYeniMesaj()
        {
            InitializeComponent();
        }     
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            string alici = textEdit5.Text;
            string gonderen = "gonderen";
            string sifre = "sifre";
            string konu = textEdit1.Text;
            string icerik = textEdit6.Text;
            mail.From = new MailAddress(gonderen);
            mail.To.Add(alici);
            mail.Subject = konu;
            mail.Body = icerik;
            mail.IsBodyHtml = true;
            SmtpClient smp = new SmtpClient("smtp.gmail.com",587);
            smp.Credentials = new NetworkCredential(gonderen,sifre);
            smp.EnableSsl = true;
            smp.Send(mail);
            MessageBox.Show("Mail Gönderildi");
                

        }
    }
}
