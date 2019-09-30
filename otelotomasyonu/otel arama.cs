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
    public partial class otel_arama : Form
    {
        public otel_arama()
        {
            InitializeComponent();
        }
        OleDbConnection cnt = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabanim.accdb");

        void baglan()
        {
            if (cnt.State == ConnectionState.Closed)
                cnt.Open();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void otel_arama_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from iller ORDER BY id ASC ", cnt);
            da.Fill(dt);
            comboBox7.ValueMember = "id";
            comboBox7.DisplayMember = "sehir";
            comboBox7.DataSource = dt;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            listele2();
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
            DataTable dt = new DataTable();
            OleDbDataAdapter adb = new OleDbDataAdapter("select oteladi,odano,durum,bosalmatarihi from odalar where odasayisi = '" + comboBox1.Text + "' and tuvaletsayisi = '" + comboBox2.Text + "'and katno = '" + comboBox3.Text + "'and havuz = '" + comboBox4.Text + "'and masajsalonu = '" + comboBox5.Text + "'and deniz = '" + comboBox6.Text + "'and bulunduguil = '" + comboBox7.Text + "'and bulunduguilce = '" + comboBox8.Text + "'", cnt);
            //secilen kriterleri ara varsa oteladi,odano,durum,bosalmatarihi... verilerini yolla

            adb.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }
         void listele()
        {
            baglan();
            DataTable dt = new DataTable();
            OleDbDataAdapter adb = new OleDbDataAdapter("select oteladi,odano,durum,bosalmatarihi,odasayisi,katno,havuz,deniz,masajsalonu,bulunduguil,bulunduguilce from odalar where odasayisi = '" + comboBox1.Text + "' and tuvaletsayisi = '" + comboBox2.Text + "'and katno = '" + comboBox3.Text + "'and havuz = '" + comboBox4.Text + "'and masajsalonu = '" + comboBox5.Text + "'and deniz = '" + comboBox6.Text + "'and bulunduguil = '" + comboBox7.Text + "'and bulunduguilce = '" + comboBox8.Text + "'", cnt);
            adb.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }
         void listele2()
         {
             baglan();
             DataTable dt = new DataTable();
             OleDbDataAdapter adb = new OleDbDataAdapter("select oteladi,odano,durum,bosalmatarihi,odasayisi,katno,havuz,deniz,masajsalonu,bulunduguil,bulunduguilce from odalar ", cnt);
             //tabloyu listelemek için olusturduk

             adb.Fill(dt);
             dataGridView1.DataSource = dt;
             dataGridView1.Visible = true;
         }
         private void button2_Click(object sender, EventArgs e)
         {
             baglan();
             OleDbCommand cnd = new OleDbCommand("select oteladi,odano,alinmatarihi,bosalmatarihi from odalar where oteladi = '" + textBox2.Text + "'and odano = '" + textBox1.Text + "' and durum = '" + "BOŞ" + "'", cnt);
             OleDbDataReader dr = cnd.ExecuteReader();
             if (dr.Read())
             {
                 OleDbCommand cmd = new OleDbCommand("update odalar set bosalmatarihi = '" + dateTimePicker2.Text + "' ,alinmatarihi = '" + dateTimePicker1.Text + "',durum = '" + "DOLU" + "' where durum = '" + "BOŞ" + "' and odano = '" + textBox1.Text + "'and oteladi = '" + textBox2.Text + "'", cnt); //verileri eğer durum boşsa ve oda no textbox 1 dekiyse güncelle
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Rezervasyon başarılı. ");
                 
                 OleDbCommand cdm = new OleDbCommand("insert into rezervasyonlar values ('" + dr["oteladi"] + "','" + dr["odano"] + "','" + dr["alinmatarihi"] + "','" + dr["bosalmatarihi"] + "','" + this.Text + "') ", cnt);
                 cdm.ExecuteNonQuery();
             }
             else
             {
                 MessageBox.Show("bu oda zaten alınmıs");
             }



             listele2();
         }

         private void button3_Click(object sender, EventArgs e)
         {
             comboBox1.Text="1";
             comboBox2.Text = "1";
             comboBox3.Text = "1";
             comboBox4.Text = "var";
             comboBox5.Text = "var";
             comboBox6.Text = "var";
             comboBox7.Text = "ADANA";
             comboBox8.Text = "SEYHAN";
             listele2();
         }
    }
}
