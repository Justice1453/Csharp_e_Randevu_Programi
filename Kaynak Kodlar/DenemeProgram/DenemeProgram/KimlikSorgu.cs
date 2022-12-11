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
    public partial class KimlikSorgu : Form
    {
        public KimlikSorgu()
        {
            InitializeComponent();
        }
        Database db = new Database();
        SqlCommand komut;
        SqlDataReader dr;
        SqlDataReader dr1;
        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.baglanti.State == ConnectionState.Open)
                {
                    db.baglanti.Close();
                }
                db.baglanti.Open();
                komut = new SqlCommand("select * from KimlikBilgileri where TC=@tc and Ad=@ad and Soyad=@soyad and DT=@dt and Tel_No=@tel", db.baglanti);
                komut.Parameters.AddWithValue("@tc", tcText.Text);
                komut.Parameters.AddWithValue("@ad", adText.Text);
                komut.Parameters.AddWithValue("@soyad", soyadText.Text);
                komut.Parameters.AddWithValue("@dt", dtText.Text);
                komut.Parameters.AddWithValue("@tel", telText.Text);
                dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    RandevuEkrn f1 = new RandevuEkrn();
                    string adsoyad = adText.Text + " " + soyadText.Text;
                    f1.lblHosgeldiniz.Text = "Sn. " + adsoyad + "\n" + "e-Randevu sistemimize hoşgeldiniz.";
                    f1.lblTc.Text = tcText.Text;
                    f1.lblAd.Text = adText.Text + " " + soyadText.Text;
                    f1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bu bilgilerde kayıtlı bir hasta bulunamadı." + "\n" + "Hasta kaydınız yok ise 'Hasta Kayıt' butonuna basınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnKayit.Enabled = true;
                }
                db.baglanti.Close();
            }
            catch (Exception hata) { MessageBox.Show(hata.ToString()); }
        }

        private void adText_TextChanged(object sender, EventArgs e)
        {
            adText.CharacterCasing = CharacterCasing.Upper;

        }

        private void soyadText_TextChanged(object sender, EventArgs e)
        {
            soyadText.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            db.baglanti.Open();
            komut = new SqlCommand("insert into KimlikBilgileri(TC, Ad, Soyad, DT, Tel_No) values(@tc, @ad, @soyad, @dt, @tel)", db.baglanti);
            komut.Parameters.AddWithValue("@tc", tcText.Text);
            komut.Parameters.AddWithValue("@ad", adText.Text);
            komut.Parameters.AddWithValue("@soyad", soyadText.Text);
            komut.Parameters.AddWithValue("@dt", dtText.Text);
            komut.Parameters.AddWithValue("@tel", telText.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı" + "\n" + "'Giriş Yap' butonuna basarak giriş yapabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            db.baglanti.Close();
        }

        private void KimlikSorgu_Load(object sender, EventArgs e)
        {
        }

        private void KimlikSorgu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void telText_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (telText.TextLength >= 14) { }
        }
    }
}
