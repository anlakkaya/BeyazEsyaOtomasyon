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
    public partial class musteri_duzenle : Form
    {
        public musteri_duzenle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=beyazesya;Integrated Security=True");
        public void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void urunturu()
        {

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM urunler";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["tur"]);
            }


            baglanti.Close();
        }
        public void urunmodel()
        {
            comboBox3.Items.Clear();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM urunler where tur='" + comboBox1.Text + "' and marka='" + comboBox2.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["model"]);
            }


            baglanti.Close();
        }
        public void urunmarka()
        {
            comboBox2.Items.Clear();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM urunler where tur='" + comboBox1.Text + "'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["marka"]);
            }


            baglanti.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            urunmarka();
        }

        private void musteri_duzenle_Load(object sender, EventArgs e)
        {

            urunturu();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            urunmodel();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                SqlCommand ekle = new SqlCommand("update musteriler set musteri_no ='"+textBox1.Text+ "',musteri_adi='"+textBox2.Text+ "',musteri_soyadi='"+textBox3.Text+ "',musteri_tel='"+textBox4.Text+ "',musteri_adres='"+textBox5.Text+ "',urun_turu='"+comboBox1.Text+ "',urun_markasi='"+comboBox2.Text+ "',urun_model='"+comboBox3.Text+"',fiyat='"+textBox6.Text+ "',odenen_hesap='"+textBox7.Text+ "',kalan_hesap='"+textBox8.Text+"' where musteri_no='"+textBox1.Text+"'", baglanti);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Güncelleme İşlemi Başarılı");
                temizle();
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kayit_bul bul = new kayit_bul();
            bul.Show();
            this.Hide();
        }
    }
}
