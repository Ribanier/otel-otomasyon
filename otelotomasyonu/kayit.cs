using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;
namespace otelotomasyonu
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabanim.accdb");
        void baglan()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglan();
            try
            {
    if (sayi.ToString() == textBox5.Text)
            {
                OleDbCommand cmd = new OleDbCommand("insert into kullanici values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')", baglanti);
                cmd.ExecuteNonQuery();
            }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }

        }
        int sayi;
        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sayi = rnd.Next(100000, 900000);
                MailMessage msj = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("onaylandiniz@gmail.com", "onaylandiniz123");
                client.Port = 587;
                client.Host = " smtp.gmail.com";
                client.EnableSsl = true;
                msj.To.Add(textBox4.Text);
                msj.From = new MailAddress("onaylandiniz@gmail.com");
                msj.Subject = "GÜVENLİK KODU";
                msj.Body = sayi.ToString();
                client.Send(msj);
                MessageBox.Show("KOD GÖNDERİLDİ E-POSTANIZI KONTROL EDİNİZ...");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
