using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BeyazEsyaOtomasyonu
{
    public partial class urun_Listele : Form
    {
        public urun_Listele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=beyazesya;Integrated Security=True");
        public void listele()
        {
            listView1.Columns.Add("Tür",150);//listwiew gerekli sütünları ekledik
            listView1.Columns.Add("Marka", 120);
            listView1.Columns.Add("Ürün Kodu", 100);
            listView1.Columns.Add("Model", 150);
            listView1.Columns.Add("Fiyat", 100);

            listView1.View = View.Details;
            listView1.GridLines = true;
            ListViewItem item = new ListViewItem();
            baglanti.Open();
            SqlCommand listele = new SqlCommand("select * from urunler ",baglanti);
            SqlDataReader oku = listele.ExecuteReader();
            while (oku.Read())
            {
                item = listView1.Items.Add(oku.GetString(1));
                item.SubItems.Add(oku.GetString(2));
                item.SubItems.Add(oku.GetString(3));
                item.SubItems.Add(oku.GetString(4));//verileri çektik
                item.SubItems.Add(oku.GetString(5));
            }
            baglanti.Close();
        }

        private void urun_Listele_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();//listeledik
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
