using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DenemeProgram
{
    public partial class RandevuEkrn : Form
    {
        public RandevuEkrn()
        {
            InitializeComponent();
        }

        KimlikSorgu kimlik = new KimlikSorgu();
        private void button1_Click(object sender, EventArgs e)
        {
            /*pCizgi.Location = new Point(38, 63);
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            pONAY.Visible = false;


            DialogResult sual = MessageBox.Show("Seçtiğiniz branşı düzenlemek ister misiniz ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sual == DialogResult.Yes)
            {
                btnBrans.BackColor = Color.DarkOrange;
                tik = 0;
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            /*panel2.Visible = false;
            panel1.Visible = false;
            pCizgi.Location = new Point(336, 63);
            panel3.Visible = true;*/
        }

        private void button24_Click(object sender, EventArgs e)
        {
            pCizgi.Location = new Point(485, 63);
        }

        private void RandevuEkrn_Load(object sender, EventArgs e)
        {
            KimlikSorgu kim = new KimlikSorgu();
            btnBrans.BackColor = Color.DarkOrange;
            timer1.Start();
            if (branslar == null)
            {
                btnIleri.Visible = false;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            DialogResult s = MessageBox.Show("e-Randevu Programından çıkmak istediğinize emin misiniz ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (s == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        bool tasi = false;
        Point bn = new Point(0, 0);
        private void pBaslik_MouseDown(object sender, MouseEventArgs e)
        {
            tasi = true;
            bn = new Point(e.X, e.Y);
        }

        private void pBaslik_MouseUp(object sender, MouseEventArgs e)
        {
            tasi = false;
        }

        private void pBaslik_MouseMove(object sender, MouseEventArgs e)
        {
            if (tasi)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.bn.X, p.Y - this.bn.Y);

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
        }

        private void btnKar_Click(object sender, EventArgs e)
        {
        }

        private void btnNor_Click(object sender, EventArgs e)
        {
        }

        private void btnPsi_Click(object sender, EventArgs e)
        {
        }

        private void btnGoz_Click(object sender, EventArgs e)
        {
        }

        private void btnKBB_Click(object sender, EventArgs e)
        {
        }

        private void btnGogus_Click(object sender, EventArgs e)
        {
        }

        private void btnKDC_Click(object sender, EventArgs e)
        {
        }

        private void btnPEC_Click(object sender, EventArgs e)
        {
        }

        private void btnKHD_Click(object sender, EventArgs e)
        {
        }

        private void btnEndok_Click(object sender, EventArgs e)
        {
        }

        private void btnDer_Click(object sender, EventArgs e)
        {
        }

        private void btnFTR_Click(object sender, EventArgs e)
        {
        }

        private void btnNefr_Click(object sender, EventArgs e)
        {
        }

        private void btnHer_Click(object sender, EventArgs e)
        {
        }

        private void btnRom_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void btnGas_Click(object sender, EventArgs e)
        {
        }

        private void btnOrto_Click(object sender, EventArgs e)
        {
        }

        private void btnÜro_Click(object sender, EventArgs e)
        {
        }
        public int tik = 0;
        private void btnIleri_Click(object sender, EventArgs e)
        {
            string tarih = dTarih.SelectionStart.ToString("d");
            tik++;
            if (tik == 1)
            {
                if (panel2.Visible == true)
                {
                    DialogResult s = MessageBox.Show("'" + tarih + "' " + "Tarihi için " + branslar + " branşından randevu almak istediğinize emin misiniz ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (s == DialogResult.Yes)
                    {
                        btnPol.BackColor = Color.DarkOrange;
                        btnPol.Enabled = true;
                        btnBrans.BackColor = Color.Green;
                        pCizgi.Location = new Point(187, 63);
                        panel1.Visible = true;
                        lblTarih.Text = tarih;
                        lblTarih2.Text = tarih;
                        btnPoliklinik.Text = branslar.ToString();
                        btnGeri.Visible = true;
                        btnGeri.BringToFront();
                        btnIleri.Visible = false;
                    }
                    else
                    {
                        tik = 0;
                    }
                }
            }

            if (tik == 2)
            {
                if (panel1.Visible == true)
                {
                    btnIleri.BringToFront();
                    DialogResult s = MessageBox.Show("" + branslar + " polikliniğini seçmek istediğinize emin misiniz ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (s == DialogResult.Yes)
                    {
                        btnRanSaat.Enabled = true;
                        btnPol.BackColor = Color.Green;
                        btnRanSaat.BackColor = Color.DarkOrange;
                        pCizgi.Location = new Point(336, 63);
                        panel3.Visible = true;
                        lblTarih2.BringToFront();
                        btnGeri.Visible = true;
                        btnGeri.BringToFront();
                        btnIleri.Visible = false;
                    }
                    else
                    {
                        tik = 1;
                    }
                }
            }

            if (tik == 3)
            {
                DialogResult s = MessageBox.Show("Randevunuzu " + saat + " saatine almak istediğinize emin misiniz ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (s == DialogResult.Yes)
                {
                    btnRanSaat.BackColor = Color.Green;
                    btnRanOnay.BackColor = Color.DarkOrange;
                    btnRanOnay.Enabled = true;
                    pCizgi.Location = new Point(485, 63);
                    pONAY.Visible = true;
                    lblSube.Text = branslar + " Şubesi";
                    lblPol.Text = btnPoliklinik.Text;
                    lblRanTarih.Text = lblTarih.Text;
                    btnBrans.Enabled = false;
                    btnPol.Enabled = false;
                    btnRanSaat.Enabled = false;
                    btnGeri.Visible = true;
                    btnGeri.BringToFront();
                    onaykodu();
                    RandevuKayit();
                }
                else
                {
                    tik = 2;
                }
            }
        }

        Database db = new Database();
        SqlCommand komut;
        void RandevuKayit()
        {
            try
            {
                if (db.baglanti.State == ConnectionState.Open)
                {
                    db.baglanti.Close();
                }
                db.baglanti.Open();
                komut = new SqlCommand("insert into Randevular(R_Tarih, Onay_Kodu, Sube, Poliklinik, RandevuTarihi, RandevuSaati, TC, AdSoyad) values(@tarih, @onaykodu, @sube, @polik, @rtarih, @rsaati, @tc, @adsoyad)", db.baglanti);
                komut.Parameters.AddWithValue("@tarih", lblNTarih.Text);
                komut.Parameters.AddWithValue("@onaykodu", lblOnayKodu.Text);
                komut.Parameters.AddWithValue("@sube", lblSube.Text);
                komut.Parameters.AddWithValue("@polik", lblPol.Text);
                komut.Parameters.AddWithValue("@rtarih", lblRanTarih.Text);
                komut.Parameters.AddWithValue("@rsaati", lblRanSaat.Text);
                komut.Parameters.AddWithValue("@tc", lblTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", lblAd.Text);
                komut.ExecuteNonQuery();
                db.baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Randevunuz bilinmeyen bir sebepden mütevellit kaydedilememiştir." + "\n" + "e-Randevu sistemi kapatılıyor..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void btnPoliklinik_Click(object sender, EventArgs e)
        {
            btnIleri.BringToFront();
            btnIleri.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }
        Random kod = new Random();
        StringBuilder s = new StringBuilder();
        void onaykodu()
        {
            for (int i = 0; i < 5; i++)
            {
                int ascii = kod.Next(48, 57);
                char karakter = Convert.ToChar(ascii);
                s.Append(karakter);
            }
            lblOnayKod.Text = "0" + s;
            lblOnayKodu.Text = lblOnayKod.Text;
        }

        public static string saat;
        private void btn19_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            saat = btn.Text;
            lblRanSaat.Text = btn.Text;
            btnIleri.Visible = true;
        }

        public static string branslar;
        public static int dolu;
        public static int bos;
        private void btnBranslar_Click(object sender, EventArgs e)
        {
            Button brans = (Button)sender;
            branslar = brans.Text;
            btnIleri.Visible = true;
            VeriGetir();
        }
        public void VeriGetir()
        {
            try
            {
                if (db.baglanti.State == ConnectionState.Open)
                {
                    db.baglanti.Close();
                }
                db.baglanti.Open();
                komut = new SqlCommand("select count(*) from Randevular where Poliklinik=@pol", db.baglanti);
                komut.Parameters.AddWithValue("@pol", branslar);
                dolu = (int)komut.ExecuteScalar();
                db.baglanti.Close();
                bos = 20 - dolu;
                if (dolu == 20)
                {
                    MessageBox.Show("Seçtiğiniz branş için hasta sayısı sınırı dolu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else { MessageBox.Show("Dolu : " + dolu + "\n" + "Boş : " + bos, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNTarih.Text = DateTime.Now.ToLongDateString();
            lblSaaaat.Text = DateTime.Now.ToLongTimeString();
            lblGün.Text = DateTime.Now.ToLongDateString();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            if (tik == 1)
            {
                pCizgi.Location = new Point(38, 63);
                panel2.Visible = true;
                panel1.Visible = false;
                panel3.Visible = false;
                pONAY.Visible = false;
                tik = 0;
            }
            if (btnPol.BackColor==Color.Green && tik == 2)
            {
                pCizgi.Location = new Point(187, 63);
                panel2.Visible = true;
                panel3.Visible = false;
                pONAY.Visible = false;
                /*btnBrans.BackColor = Color.DarkOrange;
                btnPol.BackColor = Color.DimGray;
                btnRanSaat.BackColor = Color.DimGray;*/
                tik = 1;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult s = MessageBox.Show("DİKKAT!" + "\n" + "Tekrar randevu almak için, kimlik bilgilerinizi tekrar girmeniz gerekmektedir.", "Bilgi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (s == DialogResult.OK)
            {
                MessageBox.Show("Kimlik Sorgulama ekranına yönlendiriliyorsunuz..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                KimlikSorgu kimlik = new KimlikSorgu();
                kimlik.Show();
            }
        }

        private void RandevuEkrn_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Randevular_Ekranı randevu = new DenemeProgram.Randevular_Ekranı();
            randevu.label3.Text = lblAd.Text;
            randevu.Show();
        }

        private void lblADs_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
