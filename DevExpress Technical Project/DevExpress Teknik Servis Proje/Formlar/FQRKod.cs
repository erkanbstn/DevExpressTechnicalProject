using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace DevExpress_Teknik_Servis_Proje.Formlar
{
    public partial class FQRKod : Form
    {
        public FQRKod()
        {
            InitializeComponent();
        }

        private void FQRKod_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            QRCodeEncoder enc = new QRCodeEncoder();
            pictureEdit1.Image = enc.Encode(textEdit1.Text);  
        }

       

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
