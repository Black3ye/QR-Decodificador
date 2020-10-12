using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decodificador_de_QR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            {
                ofd.Filter = "Imagen png|*.png";
                ofd.InitialDirectory = @"C:\Users\Jose A Garcia Osorio\Downloads";
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               pictureBox1.Image = Image.FromFile(ofd.FileName);
                label2.Text = Path.GetFileName(ofd.FileName);
               QRCodeDecoder decoder = new QRCodeDecoder();
               textBox1.Text = decoder.Decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
                if(textBox1.Text.StartsWith("http")|textBox1.Text.StartsWith("https")|textBox1.Text.StartsWith("www")|textBox1.Text.EndsWith(".com"))
                {
                    btnredirect.Visible = true;
                }
                else
                {
                    if(btnredirect.Visible = true)
                    {
                        btnredirect.Visible = false;
                    }
                }
            }
        }

        private void btnredirect_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox1.Text);
        }
    }
}
