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
    public partial class oda_ekle : Form
    {
        public oda_ekle()
        {
            InitializeComponent();
        }
        OleDbConnection cnt = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabanim.accdb");

        void baglan()
        {
            if (cnt.State == ConnectionState.Closed)
                cnt.Open();
        }

        private void oda_ekle_Load(object sender, EventArgs e)
        {
            baglan();
            OleDbCommand cmd = new OleDbCommand("select * from oteller", cnt);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd["otelad"]);
                comboBox7.Text = rd["il"].ToString();
                comboBox8.Text = rd["ilce"].ToString();
            }
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from iller ORDER BY id ASC ", cnt);
            da.Fill(dt);
            comboBox7.ValueMember = "id";
            comboBox7.DisplayMember = "sehir";
            comboBox7.DataSource = dt;
            textBox2.Focus();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from ilceler where sehir = " + comboBox7.SelectedValue, cnt);
                da.Fill(dt);
                comboBox8.ValueMember = "id";
                comboBox8.DisplayMember = "ilce";
                comboBox8.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan();
            OleDbCommand cmd = new OleDbCommand("select * from odalar where odano ='" + textBox5.Text + "' and oteladi = '" + comboBox1.Text + "'", cnt);//odalar tablosunda oda no ve otel adı aynı olan varmı diye kontrol ettik
            OleDbDataReader rd = cmd.ExecuteReader();
            if (rd.Read())//eğer varsa mesaj yazdır
            {
                MessageBox.Show("böyle bir oda mevcut");
            }
            else//yoksa verileri kaydet
            {
                OleDbCommand cnd = new OleDbCommand("INSERT INTO odalar VALUES  ('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + comboBox6.Text + "','" + comboBox7.Text + "','" + comboBox8.Text + "','" + "BOŞ" + "','" + textBox5.Text + "','" + "BOŞ" + "','" + "BOŞ" + "')", cnt);//sırasıyla tüm verileri odalar tablosuna kaydettik
                cnd.ExecuteNonQuery();
                MessageBox.Show("oda eklendi");
            }

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("select il,ilce from oteller where otelad='"+comboBox1.Text+"'", cnt);// oteller tablosunda otel adı varsa il ve ilçeyi gönder?
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())//varsa
            {
            
                comboBox7.Text = rd["il"].ToString();//combobox7e ili ata
                comboBox8.Text = rd["ilce"].ToString();//comboBox8 e ilceyi ata
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
            }
          

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox7.Enabled = true;
                comboBox8.Enabled = true;
            }
        }
    }
}
