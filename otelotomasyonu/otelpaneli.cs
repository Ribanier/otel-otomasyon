using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otelotomasyonu
{
    public partial class otelpaneli : Form
    {
        public otelpaneli()
        {
            InitializeComponent();
        }

        private void odaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oda_ekle frm = new oda_ekle();
            frm.Show();
            this.Hide();
            frm.comboBox1.Text = this.Text;
            //oda_ekle formunun combobox ına otel paneli formunun textini gönderdik
            //ama ilk comboboxın modifiersini public yaptık
            frm.comboBox1.Enabled = false;
        }

        private void cıkısToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("çıkmak istediğinize eminmisiniz?", "", MessageBoxButtons.YesNo);
            if(dr==DialogResult.Yes)
            {
                giris qwe = new giris();
                qwe.Show();
                this.Hide();
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rezervasyonlar qwe = new rezervasyonlar();
            qwe.Show();
            this.Hide();
            qwe.label1.Text = this.Text;
        }
    }
}
