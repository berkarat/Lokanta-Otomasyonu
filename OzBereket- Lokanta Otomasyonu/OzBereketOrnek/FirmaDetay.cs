using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace OzBereketOrnek
{
    public partial class FirmaDetay : UserControl
    {
        Genel gnl = new Genel();
        private static FirmaDetay _instance;
        public FirmaDetay()
        {
            InitializeComponent();
            FirmaAdiGetir();
            btnSil.Enabled = false;
            groupBox1.Enabled = false;
        }
        public void FirmaAdiGetir()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM firma", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbFirmaAdi.Items.Add(dr["firmaadi"].ToString().Trim());
            }

            cbFirmaAdi.Text = "";
        }

        public static FirmaDetay Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FirmaDetay();
                }
                return _instance;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GunlukFis gnlkFis = new GunlukFis();
            gnlkFis.Show();
        }

        private void cbFirmaAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu = "SELECT firma_detay.tarih as Tarih, firma_detay.fis as KişiSayısı,firma.yemekfiyat as YemekFiyatı, firma_detay.tutar as Tutar, firma_detay.aciklama as Açıklama, firma_detay.id FROM firma INNER JOIN firma_detay ON firma.id=firma_detay.firma_id WHERE firma.firmaadi='" + cbFirmaAdi.Text + "'";
            gnl.veriGetir(sorgu, dataGridView1);
            dataGridView1.Columns[5].Visible = false;
            if(dataGridView1.Rows.Count > 1)
            {
                btnSil.Enabled = true;
                groupBox1.Enabled = true;
            }
            else
            {
                btnSil.Enabled = false;
                groupBox1.Enabled = false;
            }

            toplam();            
        }

        void toplam()
        {
            int toplamKisi = 0;                     
            decimal toplamTutar = 0;

            if (dataGridView1.RowCount > 0)
            {

                int index;
                for (index = 0; index <= (dataGridView1.RowCount - 1); index++)
                {
                    toplamKisi += Convert.ToInt32(dataGridView1.Rows[index].Cells[1].Value); // toplam kişi sayısı
                }
                for (index = 0; index <= (dataGridView1.RowCount - 1); index++)
                {
                    toplamTutar += Convert.ToDecimal(dataGridView1.Rows[index].Cells[3].Value); // toplam tutar 
                }
             }

            lblToplamKisi.Text = "Toplam: "+toplamKisi.ToString()+ " Kişi";
            lblToplamTutar.Text = "Toplam: " + toplamTutar.ToString()+" TL";
        }

        private void btnFisGetirmeyen_Click(object sender, EventArgs e)
        {
            FisGetirmeyen fsg = new FisGetirmeyen();
            fsg.Show();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            int id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim());

            DialogResult secenek = MessageBox.Show("Kaydı Silmek İstediğinize Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (secenek == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM firma_detay WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Silindi");
                //kayitGetir();
            }
            else if (secenek == DialogResult.No)
            {

            }
        }

        private void btnSuz_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            DateTime tarih1 = dtTarih1.Value.AddDays(-1);

            string sorgu = "SELECT firma_detay.tarih as Tarih, firma_detay.fis as KişiSayısı,firma.yemekfiyat as YemekFiyatı, firma_detay.tutar as Tutar, firma_detay.aciklama as Açıklama, firma_detay.id FROM firma INNER JOIN firma_detay ON firma.id=firma_detay.firma_id WHERE firma.firmaadi=@firmaadi AND firma_detay.tarih BETWEEN @tarih1 AND @tarih2";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@firmaadi", cbFirmaAdi.Text);
            cmd.Parameters.AddWithValue("@tarih1", tarih1);
            cmd.Parameters.AddWithValue("@tarih2", dtTarih2.Value);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[5].Visible = false;

            toplam();
        }
    }
}
