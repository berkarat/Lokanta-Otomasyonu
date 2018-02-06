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
    public partial class Senet : Form
    {
        Genel gnl = new Genel();

        public void firmaAdiGetir()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM firma", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbFirma.Items.Add(dr["firmaadi"].ToString().Trim());
            }

            conn.Close();
        }

        public Senet()
        {
            InitializeComponent();
            firmaAdiGetir();
           lblGuncelle.Visible = false;
            lblid.Visible = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cbFirma.Text == "" || txtTutar.Text == "")
            {
                MessageBox.Show("Lütfen Firma Adı ve Tutar Alanlarını Boş Bırakmayın.");
            }
            else
            {
                if (lblGuncelle.Text == "guncelle")
                {
                    Guncelle();
                }
                else
                {
                    Kaydet();
                }

                lblGuncelle.Text = "";
                lblid.Text = "";
            }
        }

        public void Kaydet()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT id FROM firma WHERE firmaadi=@firmaadi", conn);
            cmd3.Parameters.AddWithValue("@firmaadi", cbFirma.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd3);

            DataTable dt = new DataTable();

            da.Fill(dt);

            int id = Convert.ToInt32(dt.Rows[0][0]);


            SqlCommand cmd2 = new SqlCommand("INSERT INTO senet(firma_id,islemtipi,tarih,senetno,vade,odemeyeri,kefil,tutar,aciklama) VALUES(@firma_id,@islemtipi,@tarih,@senetno,@vade,@odemeyeri,@kefil,@tutar,@aciklama)", conn);

           // int tutar = Convert.ToInt32(txtTutar.Text);
            cmd2.Parameters.AddWithValue("@firma_id", id);
            cmd2.Parameters.AddWithValue("@islemtipi", "Senet");
            cmd2.Parameters.AddWithValue("@tarih", dtTarih.Value);
            cmd2.Parameters.AddWithValue("@senetno", txtSenetno.Text);
            cmd2.Parameters.AddWithValue("@vade", dtVade.Value);
            cmd2.Parameters.AddWithValue("@odemeyeri", txtOdemeyeri.Text);
            cmd2.Parameters.AddWithValue("@kefil", txtKefil.Text);
            cmd2.Parameters.AddWithValue("@tutar", Math.Round(float.Parse(txtTutar.Text),2));
            cmd2.Parameters.AddWithValue("@aciklama", txtAciklama.Text);

            cmd2.ExecuteNonQuery();

            //firma_detay daki toplam borç kolonundaki en son veriyi alıp ödeme yapıldığında güncelleyeceğiz
            SqlCommand cmd4 = new SqlCommand("SELECT toplambakiye FROM toplambakiye WHERE firma_id='" + id + "'", conn);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            //firmanın son toplam borcu
            float sontoplamborc = (float)Convert.ToDouble(dt4.Rows[0][0]);

            //girilen tutarı son toplam borçdan düşüp yeni toplam borcu bulacağız
            float yenitoplamborc = (float)(sontoplamborc - (float)Convert.ToDouble(txtTutar.Text));

            string guncelle = "UPDATE toplambakiye SET toplambakiye =@yenitoplamborc WHERE firma_id=@id";

            SqlCommand cmd5 = new SqlCommand(guncelle, conn);
            cmd5.Parameters.AddWithValue("@yenitoplamborc", Math.Round(yenitoplamborc,2));
            cmd5.Parameters.AddWithValue("@id", id);
            cmd5.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Kaydedildi");
        }
        public void Guncelle()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT id FROM firma WHERE firmaadi=@firmaadi", conn);
            cmd3.Parameters.AddWithValue("@firmaadi", cbFirma.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd3);

            DataTable dt = new DataTable();

            da.Fill(dt);

            int id = Convert.ToInt32(dt.Rows[0][0]);

            int senetid = Convert.ToInt32(lblid.Text.ToString());

            SqlCommand cmd2 = new SqlCommand("UPDATE senet SET firma_id=@firma_id, islemtipi=@islemtipi,"+
                "tarih=@tarih, senetno=@senetno, vade=@vade, odemeyeri=@odemeyeri, kefil=@kefil, tutar=@tutar, aciklama=@aciklama WHERE id=@senetid", conn);
            
            int tutar = Convert.ToInt32(txtTutar.Text);
            cmd2.Parameters.AddWithValue("@firma_id", id);
            cmd2.Parameters.AddWithValue("@islemtipi", "Senet");
            cmd2.Parameters.AddWithValue("@tarih", dtTarih.Value);
            cmd2.Parameters.AddWithValue("@senetno", txtSenetno.Text);
            cmd2.Parameters.AddWithValue("@vade", dtVade.Value);
            cmd2.Parameters.AddWithValue("@odemeyeri", txtOdemeyeri.Text);
            cmd2.Parameters.AddWithValue("@kefil", txtKefil.Text);
            cmd2.Parameters.AddWithValue("@tutar", Math.Round(float.Parse(txtTutar.Text),2));
            cmd2.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
            cmd2.Parameters.AddWithValue("@senetid", senetid);

            cmd2.ExecuteNonQuery();

            //firma_detay daki toplam borç kolonundaki en son veriyi alıp ödeme yapıldığında güncelleyeceğiz
            SqlCommand cmd4 = new SqlCommand("SELECT toplambakiye FROM toplambakiye WHERE firma_id=@firma_id", conn);
            cmd4.Parameters.AddWithValue("@firma_id", id);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            //firmanın son toplam borcu
            float sontoplamborc = (float)Convert.ToDouble(dt4.Rows[0][0]);

            //girilen tutarı son toplam borçdan düşüp yeni toplam borcu bulacağız
            float yenitoplamborc = (float)(sontoplamborc - Convert.ToDouble(txtTutar.Text));

            string guncelle = "UPDATE toplambakiye SET toplambakiye =@toplambakiye WHERE firma_id=@firma_id";

            SqlCommand cmd5 = new SqlCommand(guncelle, conn);
            cmd5.Parameters.AddWithValue("@toplambakiye", Math.Round(yenitoplamborc, 2));
            cmd5.Parameters.AddWithValue("@firma_id", id);
            cmd5.ExecuteNonQuery();

            conn.Close();
        }

        private void txtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVirgulVeSilme(e);
        }
    }
}
