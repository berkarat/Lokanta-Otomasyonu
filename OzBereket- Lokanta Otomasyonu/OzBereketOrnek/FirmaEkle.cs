using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzBereketOrnek
{
    public partial class FirmaEkle : Form
    {
        Genel gnl = new Genel();
        public FirmaEkle()
        {
            InitializeComponent();
            YemekAdiGetir();
            cbYemekFiyat.SelectedIndex = 0;

            lblGuncelle.Visible = false;
            lblid.Visible = false;
        }

        //Veritabanındaki yemek fiyatlarının bulunduğu tabloyu YemekAdiGetir() ile comcoboxa aktardık
        public void YemekAdiGetir()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM yemekFiyat", conn);

            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                cbYemekFiyat.Items.Add(dr["yemekadi"].ToString().Trim());
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtFirmaAd.Text=="")
            {
                MessageBox.Show("Lütfen Firma Adını Giriniz.");
            }
            else
            { 
                if(lblGuncelle.Text=="guncelle")
                {
                    FirmaGuncelle();
                    Temizle();
                }
                else
                {
                    YeniFirma();
                    Temizle();
                }

                
            }

        }


        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 

            public void Temizle()
        {
            txtFirmaAd.Text = "";
            txtYetkili.Text = "";
            txtAdres.Text = "";
            txtTel1.Text = "";
            txtTel2.Text = "";
            txtGsm.Text = "";
            txtMail.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
            txtAciklama.Text = "";
            lblid.Text = "";
            lblGuncelle.Text = "";
           
        }

        public void YeniFirma()
        {
            //Bağlantı oluşturduk
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            //Seçili yemekfiyat isminin ücretini aldık ve datatable aktardık
            SqlCommand cmd2 = new SqlCommand("SELECT yemekucret FROM YemekFiyat WHERE yemekadi='" + cbYemekFiyat.Text + "'", conn);
            decimal yemekFiyat = Convert.ToDecimal(cmd2.ExecuteScalar());



            //firma eklemeye kayotları girdik
            string kayitgir = "INSERT INTO firma(firmaadi, yetkili, adres, tel1, tel2, gsm, mail, vdairesi, vno, yemekfiyat, aciklama) VALUES(@firmaadi, @yetkili, @adres, @tel1, @tel2, @gsm, @mail, @vdairesi, @vno, @yemekfiyat, @aciklama)";

            SqlCommand cmd = new SqlCommand(kayitgir, conn);

            cmd.Parameters.AddWithValue("@firmaadi", txtFirmaAd.Text);
            cmd.Parameters.AddWithValue("@yetkili",  txtYetkili.Text);
            cmd.Parameters.AddWithValue("@adres",    txtAdres.Text);
            cmd.Parameters.AddWithValue("@tel1",     txtTel1.Text);
            cmd.Parameters.AddWithValue("@tel2",     txtTel2.Text);
            cmd.Parameters.AddWithValue("@gsm",      txtGsm.Text);
            cmd.Parameters.AddWithValue("@mail",     txtMail.Text);
            cmd.Parameters.AddWithValue("@vdairesi", txtVergiDairesi.Text);
            cmd.Parameters.AddWithValue("@vno",      txtVergiNo.Text);
            cmd.Parameters.AddWithValue("@yemekfiyat", yemekFiyat);
            cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);


            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();

            //Firmanın id sini alıyoruz

            SqlCommand cmd3 = new SqlCommand("SELECT id FROM firma WHERE firmaadi=@firmaadi", conn);
            cmd3.Parameters.AddWithValue("@firmaadi", txtFirmaAd.Text);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            int id = Convert.ToInt32(dt3.Rows[0][0]);
            DateTime tarih = DateTime.Now;


            // string borcgir = "INSERT INTO firma_detay(firma_id, tarih, fis, tutar, aciklama, toplamborc, fisdurum) VALUES(@firma_id, @tarih, @fis, @tutar, @aciklama, @toplamborc, @fisdurum)";

            /*string borcgir = "INSERT INTO toplambakiye(firma_id, toplambakiye)VALUES(@firma_id, @toplambakiye)";

            SqlCommand cmdBorc = new SqlCommand(borcgir, conn);

            cmdBorc.Parameters.AddWithValue("@firma_id", id.ToString());
           // cmdBorc.Parameters.AddWithValue("@toplambakiye", Math.Round(float.Parse(txtOncekiBorcu.Text),2));


            cmdBorc.ExecuteNonQuery();*/

            conn.Close();

            Firmalar frmlr = new Firmalar();
            //frmlr.panel2.Controls.Contains()
            frmlr.FirmaGoser();

            MessageBox.Show("Kayıt Tamam");

        }
        public void FirmaGuncelle()
        {
            //Bağlantı oluşturduk
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            //Seçili yemekfiyat isminin ücretini aldık ve datatable aktardık
            SqlCommand cmd2 = new SqlCommand("SELECT yemekucret FROM YemekFiyat WHERE yemekadi='" + cbYemekFiyat.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);


            int gelenid = Convert.ToInt32(lblid.Text);
            //firma eklemeye kayotları girdik
            string kayitgir = "UPDATE firma SET firmaadi=@firmaadi, yetkili=@yetkili, adres=@adres, tel1=@tel1, tel2=@tel2, gsm=@gsm, mail=@mail, vdairesi=@vdairesi, vno=@vno, yemekfiyat=@yemekfiyat, aciklama=@aciklama WHERE id=@id";

            SqlCommand cmd = new SqlCommand(kayitgir, conn);

            cmd.Parameters.AddWithValue("@firmaadi", txtFirmaAd.Text);
            cmd.Parameters.AddWithValue("@yetkili", txtYetkili.Text);
            cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
            cmd.Parameters.AddWithValue("@tel1", txtTel1.Text);
            cmd.Parameters.AddWithValue("@tel2", txtTel2.Text);
            cmd.Parameters.AddWithValue("@gsm", txtGsm.Text);
            cmd.Parameters.AddWithValue("@mail", txtMail.Text);
            cmd.Parameters.AddWithValue("@vdairesi", txtVergiDairesi.Text);
            cmd.Parameters.AddWithValue("@vno", txtVergiNo.Text);
            cmd.Parameters.AddWithValue("@yemekfiyat", dt.Rows[0][0].ToString());
            cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
            cmd.Parameters.AddWithValue("@id", gelenid);


            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();

            //Firmanın id sini alıyoruz

            //SqlCommand cmd3 = new SqlCommand("SELECT id FROM firma WHERE firmaadi='" + txtFirmaAd.Text + "'", conn);
            //SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            //DataTable dt3 = new DataTable();
            //da3.Fill(dt3);

            //int id = Convert.ToInt32(dt3.Rows[0][0]);
           // DateTime tarih = DateTime.Now;


            // string borcgir = "INSERT INTO firma_detay(firma_id, tarih, fis, tutar, aciklama, toplamborc, fisdurum) VALUES(@firma_id, @tarih, @fis, @tutar, @aciklama, @toplamborc, @fisdurum)";

            //string borcgir = "INSERT INTO toplambakiye(firma_id, toplambakiye)VALUES(@firma_id, @toplambakiye)";

            //SqlCommand cmdBorc = new SqlCommand(borcgir, conn);

            //cmdBorc.Parameters.AddWithValue("@firma_id", gelenid.ToString());
            //cmdBorc.Parameters.AddWithValue("@toplambakiye", txtOncekiBorcu.Text);


            //cmdBorc.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Güncellendi");
        }

        private void FirmaEkle_Shown(object sender, EventArgs e)
        {
            txtFirmaAd.Focus();
        }

        private void txtTel1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVeSilme(e);
        }

        private void txtTel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVeSilme(e);
        }

        private void txtGsm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVeSilme(e);
        }

        private void txtVergiNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVeSilme(e);
        }

        private void txtOncekiBorcu_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVirgulVeSilme(e);
        }
    }
}
