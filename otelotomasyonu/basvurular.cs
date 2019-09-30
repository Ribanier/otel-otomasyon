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
    public partial class basvurular : Form
    {
        public basvurular()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabanim.accdb");
        void baglan()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
        }
        void listele()
        {
            baglan();
            DataTable dt = new DataTable();
            OleDbDataAdapter adb = new OleDbDataAdapter("select * from basvurular", baglanti);
            adb.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }
        private void basvurular_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            listele();
        }
    }
}
