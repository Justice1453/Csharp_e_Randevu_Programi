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

namespace DenemeProgram
{
    public partial class Randevular_Ekranı : Form
    {
        public Randevular_Ekranı()
        {
            InitializeComponent();
        }
        RandevuEkrn ran = new RandevuEkrn();
        Database db = new Database();
        SqlCommand komut;
        SqlDataAdapter adap;
        DataTable dt;

        private void Randevular_Ekranı_Load(object sender, EventArgs e)
        {
            RandevularListesi();
        }

        void RandevularListesi()
        {
            try
            {
                if (db.baglanti.State == ConnectionState.Open)
                {
                    db.baglanti.Close();
                }
                db.baglanti.Open();
                adap = new SqlDataAdapter("select RandevuTarihi, RandevuSaati, Poliklinik, Onay_Kodu from Randevular where AdSoyad= '" + label3.Text + "'", db.baglanti);
                dt = new DataTable();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
                db.baglanti.Close();
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblOnayKod.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Randevuİptal();
        }
        void Randevuİptal()
        {
            try
            {
                if (db.baglanti.State == ConnectionState.Open)
                {
                    db.baglanti.Close();
                }
                db.baglanti.Open();
                DialogResult s = MessageBox.Show("Seçili randevu'yu iptal etmek istediğinize emin misiniz ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (s == DialogResult.Yes)
                {
                    komut = new SqlCommand("delete from Randevular where Onay_Kodu='" + lblOnayKod.Text + "'", db.baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Randevu başarıyla iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Randevu iptal etme işlemi durduruldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                db.baglanti.Close();
                RandevularListesi();
            }
            catch { }
        }

        private void Randevular_Ekranı_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
