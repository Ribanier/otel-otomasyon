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
    public partial class rezervasyonlar : Form
    {
        public rezervasyonlar()
        {
            InitializeComponent();
        }
        OleDbConnection cnt = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabanim.accdb");

        void baglan()
        {
            if (cnt.State == ConnectionState.Closed)
                cnt.Open();
        }
        void listele2()
        {
          
        }
        private void rezervasyonlar_Load(object sender, EventArgs e)
        {
            listele2();  baglan();
            DataTable dt = new DataTable();
            OleDbDataAdapter adb = new OleDbDataAdapter("select * from rezervasyonlar where oteladi = '" + label1.Text + "'", cnt);
            adb.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }

        private void rezervasyonlar_MouseMove(object sender, MouseEventArgs e)
        {
            listele2();
        }
    }
}
