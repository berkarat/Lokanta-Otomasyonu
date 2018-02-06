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
    public partial class GunlukFis : Form
    {
        Genel gnl = new Genel();
        public GunlukFis()
        {
            InitializeComponent();

            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            string sorgu = "SELECT * FROM firma";
            SqlCommand cmd = new SqlCommand(sorgu, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbFirma.Items.Add(dr["firmaadi"].ToString().Trim());
            }

            lblGuncelle.Visible = false;
            lblGelenId.Visible = false;
        }

        //public bool IdVarmi()
        //{
        //    FisGetirmeyen fg = new FisGetirmeyen();
        //    //string gelenId = fg.gelenId.ToString();
        //    string gelenId= fg.dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //    bool sonuc;
        //    SqlConnection conn = new SqlConnection(gnl.baglan);
        //    conn.Open();

        //    StringBuilder builder = new StringBuilder();

        //    SqlCommand cmd = new SqlCommand(builder.AppendFormat("SELECT COUNT(id) FROM firma_detay WHERE id='{0}'",gelenId).ToString(), conn);

        //    sonuc = Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;

        //    return sonuc;

        //}

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            
            if(cbFirma.Text=="" || txtKisiSayisi.Text=="")
            {
                MessageBox.Show("Lütfen Bilgileri Girin");
            }
            else { 

            if (lblGuncelle.Text=="guncelle")
            {
                conn.Open();
                //FisGetirmeyen fg = new FisGetirmeyen();
                string gelenId = lblGelenId.Text;

                SqlCommand cmd2 = new SqlCommand("SELECT id,yemekfiyat FROM firma WHERE firmaadi=@firmaadi", conn);
                    cmd2.Parameters.AddWithValue("@firmaadi", cbFirma.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int id = Convert.ToInt32(dt.Rows[0][0]);

                float yemekfiyat = (float)Convert.ToDouble(dt.Rows[0][1]);

                float tutar = (float)(yemekfiyat * Convert.ToInt32(txtKisiSayisi.Text));


                SqlCommand cmd3 = new SqlCommand("SELECT toplambakiye FROM toplambakiye WHERE firma_id=@id", conn);
                    cmd3.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);

                //SqlCommand cmd4 = new SqlCommand("INSERT INTO firma_detay(toplamborc) VALUES(@toplamborc)", conn);

                float toplamborc;

                //if (dt3.rows[dt3.rows.count - 1][0] == null)
                //{
                //    dt3.rows[dt3.rows.count - 1][0] = 0;

                //}

                //SqlCommand cmd5 = new SqlCommand("SELECT COUNT(id) FROM firma_detay WHERE firma_id='" + id + "'", conn);

                //int verisayisi = Convert.ToInt32(cmd5.ExecuteScalar());

                //if (verisayisi < 1)
                //{
                //    toplamborc = tutar;
                //}

                //else
                //{
                    toplamborc = (float)(tutar + Convert.ToDouble(dt3.Rows[0][0]));
                //}



                bool fisdurum = false;

                //toplamborc += tutar;

                //cmd4.Parameters.AddWithValue("@toplamborc", toplamborc);
                //cmd4.ExecuteNonQuery();

                if (rdbtnGetirmedi.Checked == true)
                {
                    fisdurum = false;
                }
                else
                {
                    fisdurum = true;
                }




                string guncelle = "UPDATE firma_detay SET fis=@fis,tutar=@tutar, aciklama=@aciklama,fisdurum=@fisdurum WHERE id=@id";

                SqlCommand cmdGuncelle = new SqlCommand(guncelle, conn);
                    cmdGuncelle.Parameters.AddWithValue("@fis", txtKisiSayisi.Text);
                    cmdGuncelle.Parameters.AddWithValue("@tutar", Math.Round(tutar,2));
                    cmdGuncelle.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                    cmdGuncelle.Parameters.AddWithValue("@fisdurum", fisdurum);
                    cmdGuncelle.Parameters.AddWithValue("@id", gelenId);

                    cmdGuncelle.ExecuteNonQuery();



                //toplambakiye tablosunu güncelliyoruz

                string topguncelle = ("UPDATE toplambakiye SET toplambakiye=@toplambakiye WHERE firma_id=@firma_id");

                SqlCommand cmdTopGuncelle = new SqlCommand(topguncelle, conn);

                cmdTopGuncelle.Parameters.AddWithValue("@toplambakiye", Math.Round(toplamborc,2));
                cmdTopGuncelle.Parameters.AddWithValue("@firma_id", id);

                cmdTopGuncelle.ExecuteNonQuery();


                conn.Close();

                MessageBox.Show("Güncellendi..");

                if (cbFirma.Enabled == false) cbFirma.Enabled = true;
            }
            else
            {
               // SqlConnection conn = new SqlConnection(gnl.baglan);
                conn.Open();
                string kayitGir = "INSERT INTO firma_detay(firma_id,tarih,fis,tutar,aciklama,fisdurum) VALUES(@firma_id,@tarih,@fis,@tutar,@aciklama,@fisdurum)";

                SqlCommand cmd = new SqlCommand(kayitGir, conn);



                SqlCommand cmd2 = new SqlCommand("SELECT id,yemekfiyat FROM firma WHERE firmaadi=@firmaadi", conn);
                    cmd2.Parameters.AddWithValue("@firmaadi", cbFirma.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int id = Convert.ToInt32(dt.Rows[0][0]);

                float yemekfiyat = (float)Convert.ToDouble(dt.Rows[0][1]);

                float tutar = (float)(yemekfiyat * (float)Convert.ToInt32(txtKisiSayisi.Text));




               /* SqlCommand cmd3 = new SqlCommand("SELECT toplambakiye FROM toplambakiye WHERE firma_id=@firma_id", conn);
                    cmd3.Parameters.AddWithValue("@firma_id", id);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);

                //SqlCommand cmd4 = new SqlCommand("INSERT INTO firma_detay(toplamborc) VALUES(@toplamborc)", conn);

                float toplamborc;
               

                //if (dt3.rows[dt3.rows.count - 1][0] == null)
                //{
                //    dt3.rows[dt3.rows.count - 1][0] = 0;

                //}

                //SqlCommand cmd5 = new SqlCommand("SELECT COUNT(id) FROM firma_detay WHERE firma_id='" + id + "'", conn);

                //int verisayisi = Convert.ToInt32(cmd5.ExecuteScalar());

                //if (verisayisi < 1)
                //{
                //    toplamborc = tutar;
                //}

                //else
                //{
                    toplamborc = (float)(tutar + (float)Convert.ToDouble(dt3.Rows[0][0]));*/
                //}



                bool fisdurum = true;

                //toplamborc += tutar;

                //cmd4.Parameters.AddWithValue("@toplamborc", toplamborc);
                //cmd4.ExecuteNonQuery();

                if (rdbtnGetirmedi.Checked == true)
                {
                    fisdurum = false;
                }
                else
                {
                    fisdurum = true;
                }


                cmd.Parameters.AddWithValue("@firma_id", id);
                cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@fis", txtKisiSayisi.Text);
                cmd.Parameters.AddWithValue("@tutar", Math.Round(tutar,2));
                cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
               // cmd.Parameters.AddWithValue("@toplamborc", toplamborc);
                cmd.Parameters.AddWithValue("@fisdurum", fisdurum);

                cmd.ExecuteNonQuery();

                //toplambakiyeye son bakiyeyi ekleyeceğiz

                /*string topguncelle = ("UPDATE toplambakiye SET toplambakiye=@toplambakiye WHERE firma_id=@firma_id");

                SqlCommand cmdGuncelle = new SqlCommand(topguncelle, conn);

                cmdGuncelle.Parameters.AddWithValue("@toplambakiye", Math.Round(toplamborc,2));
                cmdGuncelle.Parameters.AddWithValue("@firma_id", id);

                cmdGuncelle.ExecuteNonQuery();*/

                conn.Close();

                lblTutar.Text = tutar.ToString();
                MessageBox.Show("Kaydedildi");
            }

            lblGuncelle.Text = "";
            lblGelenId.Text = "";

            }

        }

        private void rdbtnGetirmedi_CheckedChanged(object sender, EventArgs e)
        {
            txtKisiSayisi.Text = 0.ToString();
            txtKisiSayisi.Enabled = false;
            txtAciklama.Text = "Fiş Getirmedi";
        }

        private void rdbtnGelmedi_CheckedChanged(object sender, EventArgs e)
        {
            txtKisiSayisi.Text = 0.ToString();
            txtKisiSayisi.Enabled = false;
            txtAciklama.Text = "Yemeğe Gelmedi";
        }

        private void cbFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdbtnGelmedi.Checked==true|| rdbtnGetirmedi.Checked==true)
            {
                rdbtnGelmedi.Checked = false;
                rdbtnGetirmedi.Checked= false;
                txtKisiSayisi.Enabled = true;
                txtAciklama.Text = "";
            }
        }

        private void txtKisiSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVeSilme(e);
        }
    }
}
