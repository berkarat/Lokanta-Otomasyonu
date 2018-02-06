using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzBereketOrnek
{
    public partial class FaturaEkle : Form
    {
        Genel gnl = new Genel();
        public FaturaEkle()
        {
            InitializeComponent();

            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM firma", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbFirmaAdi.Items.Add(dr["firmaadi"].ToString().Trim());
            }

            lblGuncelle.Visible = false;
            lblid.Visible = false;
            lblOncekiBorcu.Visible = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(cbFirmaAdi.Text=="" || txtFaturaTutar.Text=="")
            {
                MessageBox.Show("Lütfen Firma Adı ve Tutar Alanlarını Boş Bırakmayınız");
            }
            else
            {
                YeniFatura();
            }
            
        }


        public void YeniFatura()
        {
            //Bağlantı oluşturduk
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            
            SqlCommand cmd3 = new SqlCommand("SELECT id FROM firma WHERE firmaadi=@firmaadi", conn);
            cmd3.Parameters.AddWithValue("@firmaadi", cbFirmaAdi.Text);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            int id = Convert.ToInt32(dt3.Rows[0][0]);



            //fatura eklemeye kayotları girdik
            string kayitgir = "INSERT INTO fatura(firma_id, tarih, tutar, kdvtutar, toplam) VALUES(@firma_id, @tarih, @tutar, @kdvtutar, @toplam)";

            SqlCommand cmd = new SqlCommand(kayitgir, conn);

            float kdvtutar = (float)((Convert.ToDouble(txtFaturaTutar.Text) * 8) / 100);

            float toplam = (float)(Convert.ToDouble(txtFaturaTutar.Text) + kdvtutar);

            cmd.Parameters.AddWithValue("@firma_id", id);
            cmd.Parameters.AddWithValue("@tarih", DbType.DateTime).Value=dtFaturaTarih.Value;
            cmd.Parameters.AddWithValue("@tutar", Math.Round(float.Parse(txtFaturaTutar.Text),2));
            cmd.Parameters.AddWithValue("@kdvtutar", Math.Round(kdvtutar,2));
            cmd.Parameters.AddWithValue("@toplam", Math.Round(toplam,2));


            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();




            //yeni

            /*SqlCommand cmd4 = new SqlCommand("SELECT toplambakiye FROM toplambakiye WHERE firma_id=@firma_id", conn);
            cmd4.Parameters.AddWithValue("@firma_id", id);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            

            float toplamborc;

            
            toplamborc = (float)(kdvtutar + Convert.ToDouble(dt4.Rows[0][0]));



            string topguncelle = ("UPDATE toplambakiye SET toplambakiye=@toplambakiye WHERE firma_id=@firma_id");

            SqlCommand cmdTopGuncelle = new SqlCommand(topguncelle, conn);

            cmdTopGuncelle.Parameters.AddWithValue("@toplambakiye", Math.Round(toplamborc,2));
            cmdTopGuncelle.Parameters.AddWithValue("@firma_id", id);


            cmdTopGuncelle.ExecuteNonQuery();*/

            conn.Close();

            MessageBox.Show("Kayıt Tamam");
        }

        private void txtFaturaTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            gnl.SadeceRakamVirgulVeSilme(e);
        }
    }
}
