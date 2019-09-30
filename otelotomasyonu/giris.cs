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


namespace otelotomasyonu
{
    
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabanim.accdb");
        void baglan()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan();
            if (radioButton1.Checked)
            {
                OleDbCommand cmd = new OleDbCommand("select * from admin where adi ='" + textBox1.Text + "' and sifre= '" + textBox2.Text + "'", baglanti);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    adminpanel qwe = new adminpanel();
                    qwe.Show();
                    this.Hide();
                }
            }
            else if (radioButton3.Checked)
            {
                OleDbCommand cmd = new OleDbCommand("select otelad,il,ilce from oteller where otelad ='" + textBox1.Text + "' and sifre= '" + textBox2.Text + "'", baglanti);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
             
                    otelpaneli qwe = new otelpaneli();
                   qwe.Show();
                    this.Hide();
                    qwe.Text = textBox1.Text;

                }
            }
            else if (radioButton2.Checked)
            {
                OleDbCommand cmd = new OleDbCommand("select * from kullanici where adi ='" + textBox1.Text + "' and sifre= '" + textBox2.Text + "'", baglanti);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    otel_arama qwe = new otel_arama();
                    qwe.Show();
                    this.Hide();
                    qwe.Text = textBox1.Text;
                }
            }
            else
                MessageBox.Show("lutfen giriş yöntemini secin");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kayit kyt = new kayit();
            kyt.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            otelbasvuru qwe = new otelbasvuru();
            qwe.Show();
        }

        private void giris_Load(object sender, EventArgs e)
        {
            
        }
    }
}
