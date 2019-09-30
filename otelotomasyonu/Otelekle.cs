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
    public partial class Otelekle : Form
    {
        public Otelekle()
        {
            InitializeComponent();
        }
        OleDbConnection cnt = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabanim.accdb");

        void baglan()
        {
            if (cnt.State == ConnectionState.Closed) { cnt.Open(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglan();
            OleDbCommand cnd = new OleDbCommand("select * from oteller where otelad = '" + textBox1.Text + "'and il= '" + comboBox1.Text + "'and ilce= '" + comboBox2.Text + "'", cnt);
            OleDbDataReader rd = cnd.ExecuteReader();
            if (rd.Read())
            {
                MessageBox.Show("böyle bir kayıt zaten mevcut");
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand("INSERT INTO oteller VALUES  ('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','"+textBox2.Text+"')", cnt);
                cmd.ExecuteNonQuery();
                MessageBox.Show("otel eklendi");
            }
        }

        private void Otelekle_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from iller ORDER BY id ASC ", cnt);
            da.Fill(dt);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "sehir";
            comboBox1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from ilceler where sehir = " + comboBox1.SelectedValue, cnt);
                da.Fill(dt);
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "ilce";
                comboBox2.DataSource = dt;
            }
        }
    }
}
