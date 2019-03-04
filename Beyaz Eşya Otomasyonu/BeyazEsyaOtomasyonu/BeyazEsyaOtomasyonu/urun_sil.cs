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
    public partial class urun_sil : Form
    {
        public urun_sil()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=beyazesya;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                SqlCommand sil = new SqlCommand("delete from urunler where urun_kodu='"+textBox2.Text+"'",baglanti);
                sil.ExecuteNonQuery();
                MessageBox.Show("Silme İşlemi Başarılı");
                textBox2.Text = "";
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
