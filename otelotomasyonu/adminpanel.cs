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
    public partial class adminpanel : Form
    {
        public adminpanel()
        {
            InitializeComponent();
        }

        private void otelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Otelekle qwe = new Otelekle();
            qwe.Show();
           
        }

        private void adminKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminkayit qwe = new adminkayit();
            qwe.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void odaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oda_ekle qwe = new oda_ekle();
            qwe.Show();
          
        }

      
    }
}
