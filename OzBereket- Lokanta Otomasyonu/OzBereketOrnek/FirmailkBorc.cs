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
    public partial class FirmailkBorc : Form
    {
        Genel gnl = new Genel();
        public FirmailkBorc()
        {
            InitializeComponent();
            firmaAdiGetir();
            
        }

        private void FirmailkBorc_Load(object sender, EventArgs e)
        {
            //firmaAdiGetir();
            kayitGetir();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(lblGuncel.Text=="")
            {
               
                kaydet();
            }
            else if(lblGuncel.Text=="guncelle")
            {
                guncelle();
            }
            
        }

        void kayitGetir()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            Firmalar frmlr = new Firmalar();

            //int firmid = frmlr.FirmId;

            SqlCommand cmdfirmaid = new SqlCommand("SELECT id FROM firma WHERE firmaadi=@firmaadi", conn);
            cmdfirmaid.Parameters.AddWithValue("@firmaadi", cbFirma.Text);
            int firma_id = Convert.ToInt32(cmdfirmaid.ExecuteScalar());

            string sorgu = "SELECT firma.firmaadi AS Firma, firmaoncekiborc.tarih AS Tarih, firmaoncekiborc.fborcu AS [Önceki Borcu], firmaoncekiborc.falacagi AS [Önceki Alacağı], firmaoncekiborc.aciklama AS Açıklama, firmaoncekiborc.id  FROM firmaoncekiborc INNER JOIN firma ON firma.id=firmaoncekiborc.firma_id WHERE firmaoncekiborc.firma_id=@firma_id";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@firma_id", firma_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgrid.DataSource = dt;
           dtgrid.Columns[5].Visible = false;

        }

        void firmaAdiGetir()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            string sorgu = "SELECT * FROM firma";
            SqlCommand cmd = new SqlCommand(sorgu, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbFirma.Items.Add(dr["firmaadi"].ToString().Trim());
            }
            conn.Close();
        }

        void kaydet()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            SqlCommand cmdfirmaid = new SqlCommand("SELECT id FROM firma WHERE firmaadi=@firmaadi", conn);
            cmdfirmaid.Parameters.AddWithValue("@firmaadi", cbFirma.Text);
            int firma_id = Convert.ToInt32(cmdfirmaid.ExecuteScalar());

            string veri = "INSERT INTO firmaoncekiborc (firma_id, tarih, fborcu, falacagi, aciklama) VALUES(@firma_id ,@tarih, @fborcu, @falacagi, @aciklama)";
            SqlCommand cmd = new SqlCommand(veri, conn);
            cmd.Parameters.AddWithValue("@firma_id", firma_id);
            cmd.Parameters.AddWithValue("@tarih", DbType.Date).Value = dtTarih.Value;
            cmd.Parameters.AddWithValue("@fborcu", Convert.ToDecimal(txtOncekiBorc.Text.Trim()));
            cmd.Parameters.AddWithValue("falacagi", Convert.ToDecimal(txtAlacak.Text.Trim()));
            cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text.Trim());

            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Kaydedildi.");
            temizle();
            kayitGetir();
        }

        void guncelle()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            SqlCommand cmdfirmaid = new SqlCommand("SELECT id FROM firma WHERE firmaadi=@firmaadi", conn);
            cmdfirmaid.Parameters.AddWithValue("@firmaadi", cbFirma.Text);
            int firma_id = Convert.ToInt32(cmdfirmaid.ExecuteScalar());
            int id = Convert.ToInt32(lblId.Text);

            string veri = "UPDATE firmaoncekiborc SET tarih=@tarih, fborcu=@fborcu, falacagi=@falacagi, aciklama=@aciklama WHERE id=@id";
            SqlCommand cmd = new SqlCommand(veri, conn);
            cmd.Parameters.AddWithValue("@tarih", DbType.Date).Value = dtTarih.Value;
            cmd.Parameters.AddWithValue("@fborcu", Convert.ToDecimal(txtOncekiBorc.Text.Trim()));
            cmd.Parameters.AddWithValue("falacagi", Convert.ToDecimal(txtAlacak.Text.Trim()));
            cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text.Trim());
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Güncellendi.");
            kayitGetir();
        }
        void temizle()
        {
            txtOncekiBorc.Text = "";
            txtAlacak.Text = "";
            txtAciklama.Text = "";
        }

        private void cbFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            kayitGetir();
            if (dtgrid.Rows.Count > 1)
            {
                btnSil.Enabled = true;
                btnDuzenle.Enabled = true;
            }
            else
            {
                btnSil.Enabled = false;
                btnDuzenle.Enabled = false;
            }
        }

        private void dtgrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            duzenle();
        }

        void duzenle()
        {
            
                dtTarih.Text = this.dtgrid.CurrentRow.Cells[1].Value.ToString();
                txtOncekiBorc.Text = this.dtgrid.CurrentRow.Cells[2].Value.ToString().Trim();
                txtAlacak.Text = this.dtgrid.CurrentRow.Cells[3].Value.ToString().Trim();
                txtAciklama.Text = this.dtgrid.CurrentRow.Cells[4].Value.ToString().Trim();
                lblId.Text = this.dtgrid.CurrentRow.Cells[5].Value.ToString().Trim();

                cbFirma.Enabled = false;
                lblGuncel.Text = "guncelle";
            
        
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            duzenle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            int id = Convert.ToInt32(this.dtgrid.CurrentRow.Cells[5].Value.ToString().Trim());

            DialogResult secenek = MessageBox.Show("Kaydı Silmek İstediğinize Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (secenek == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM firmaoncekiborc WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Silindi");
                kayitGetir();
            }
            else if (secenek == DialogResult.No)
            {
                
            }

            
        }

        private void txtOncekiBorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVirgulVeSilme(e);
        }

        private void txtAlacak_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVirgulVeSilme(e);
        }
    }
}
