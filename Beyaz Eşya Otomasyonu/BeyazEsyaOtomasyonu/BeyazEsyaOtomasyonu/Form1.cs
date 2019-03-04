using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeyazEsyaOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ürünlerToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void kayıtBulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kayit_sil sil = new kayit_sil();
            sil.Show();
            this.Hide();
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urun_Listele urun = new urun_Listele();
            urun.Show();
            
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urun_ekle ekle = new urun_ekle();
            ekle.Show();
        }

        private void ürünSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urun_sil sil = new urun_sil();
            sil.Show();
        }

        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musteri_ekle musteri = new musteri_ekle();
            musteri.Show();
        }

        private void kayıtDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musteri_duzenle duzenlee = new musteri_duzenle();
            duzenlee.Show();
        }

        private void kayıtSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kayit_bul listele = new kayit_bul();
            listele.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
