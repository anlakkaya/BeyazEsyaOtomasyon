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
    public partial class musteri_ekle : Form
    {
        public musteri_ekle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=beyazesya;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
            temizle();
        }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                SqlCommand ekle = new SqlCommand("insert into musteriler(musteri_no,musteri_adi,musteri_soyadi,musteri_tel,musteri_adres,urun_turu,urun_markasi,urun_model,fiyat,odenen_hesap,kalan_hesap) values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"','"+comboBox3.Text+"','"+textBox6.Text+"','"+textBox7.Text+"','"+textBox8.Text+"')", baglanti);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşlemi Başarılı");
                temizle();
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
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
        public void urunmodel()
        {
            comboBox3.Items.Clear();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM urunler where tur='" + comboBox1.Text + "' and marka='"+comboBox2.Text+"'";
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
        private void musteri_ekle_Load(object sender, EventArgs e)
        {
            urunturu();
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            urunmodel();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            urunmarka();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
