using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BeyazEsyaOtomasyonu
{
    public partial class kayit_sil : Form
    {
        public kayit_sil()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=beyazesya;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kayit_bul bul = new kayit_bul();
            bul.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                SqlCommand sil = new SqlCommand("delete from musteriler where musteri_no='" + textBox2.Text + "'and musteri_adi='"+textBox2.Text+"' and musteri_soyadi='"+textBox3.Text+"'", baglanti);
                sil.ExecuteNonQuery();
                MessageBox.Show("Silme İşlemi Başarılı");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
