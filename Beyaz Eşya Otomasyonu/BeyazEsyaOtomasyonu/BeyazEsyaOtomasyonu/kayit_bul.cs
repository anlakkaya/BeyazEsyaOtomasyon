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
    public partial class kayit_bul : Form
    {
        public kayit_bul()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=beyazesya;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void listele()
        {
            listView1.Columns.Add("Müşteri No", 90);//listwiew gerekli sütünları ekledik
            listView1.Columns.Add("Müşteri Adı", 100);
            listView1.Columns.Add("Müşteri Soyadı", 100);
            listView1.Columns.Add("Müşteri Tel", 100);
            listView1.Columns.Add("Müşteri Adres", 100);
            listView1.Columns.Add("Ürün Türü", 90);
            listView1.Columns.Add("Ürün Markası", 100);
            listView1.Columns.Add("Ürün Model", 90);
            listView1.Columns.Add("Fiyat", 90);
            listView1.Columns.Add("Ödenen Hesap", 100);
            listView1.Columns.Add("Kalan Hesap", 100);
            listView1.View = View.Details;
            listView1.GridLines = true;
            ListViewItem item = new ListViewItem();
            baglanti.Open();
            SqlCommand listele = new SqlCommand("select * from musteriler where musteri_no='"+textBox1.Text+"'", baglanti);
            SqlDataReader oku = listele.ExecuteReader();
            while (oku.Read())
            {
                item = listView1.Items.Add(oku.GetString(1));
                item.SubItems.Add(oku.GetString(2));
                item.SubItems.Add(oku.GetString(3));
                item.SubItems.Add(oku.GetString(4));//verileri çektik
                item.SubItems.Add(oku.GetString(5));
                item.SubItems.Add(oku.GetString(6));
                item.SubItems.Add(oku.GetString(7));
                item.SubItems.Add(oku.GetString(8));
                item.SubItems.Add(oku.GetString(9));
                item.SubItems.Add(oku.GetString(10));
                item.SubItems.Add(oku.GetString(11));
            }
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void kayit_bul_Load(object sender, EventArgs e)
        {

        }
    }
}
