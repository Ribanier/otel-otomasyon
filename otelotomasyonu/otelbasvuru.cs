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
    public partial class otelbasvuru : Form
    {
        public otelbasvuru()
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
            try
            {
                OleDbCommand cmd = new OleDbCommand("insert into basvurular values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + maskedTextBox1.Text + "')", baglanti);
                cmd.ExecuteNonQuery();
                MessageBox.Show("kaydınız alınmıstır otelinizin eklenmesi yogunluga baglı olarak 1-2 gün sürebilir");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
