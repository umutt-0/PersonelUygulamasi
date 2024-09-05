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

namespace PersonelUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-28LO0IF\\SQLEXPRESS;Initial Catalog=PersonelVeritabani;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeritabaniDataSet.Tbl_Personel);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeritabaniDataSet.Tbl_Personel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PersonelAd, PersonelSoyad, PersonelSehir, PersonelMaas, PersonelMeslek) " +
                "values (@p1, @p2, @p3, @p4, @p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtsehir.Text);
            komut.Parameters.AddWithValue("@p4", txtmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi.");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            txtsehir.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            txtmaas.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text == "False")
            {
                radioButton2.Checked = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From Tbl_Personel Where PersonelId=@p1", baglanti);
            sil.Parameters.AddWithValue("@p1", txtid.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update Tbl_Personel Set PersonelAd=@p1, PersonelSoyad=@p2, PersonelSehir=@p3, PersonelMaas=@p4, " +
                "PersonelDurum=@p5, PersonelMeslek=@p6 where PersonelId=@p7", baglanti);
            guncelle.Parameters.AddWithValue("p1", txtad.Text);
            guncelle.Parameters.AddWithValue("p2", txtsoyad.Text);
            guncelle.Parameters.AddWithValue("p3", txtsehir.Text);
            guncelle.Parameters.AddWithValue("p4", txtmaas.Text);
            guncelle.Parameters.AddWithValue("p5", label8.Text);
            guncelle.Parameters.AddWithValue("p6", txtmeslek.Text);
            guncelle.Parameters.AddWithValue("p7", txtid.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Güncellemesi Tamamlandı.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtsehir.Text = "";
            txtmaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtmeslek.Text = "";
            txtad.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }
    }
}
