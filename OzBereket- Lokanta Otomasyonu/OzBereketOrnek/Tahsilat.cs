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
    public partial class Tahsilat : UserControl
    {
        Genel gnl = new Genel();

        private static Tahsilat _instance;

       public static Tahsilat Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Tahsilat();
                }
                return _instance;
            }
        }
        public Tahsilat()
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

            
        }

        private void btnNakit_Click(object sender, EventArgs e)
        {
            Nakit frmNakit = new Nakit();
            frmNakit.Show();
        }

        private void btnCek_Click(object sender, EventArgs e)
        {
            Cek frmCek = new Cek();
            frmCek.Show();
        }

        private void btnSenet_Click(object sender, EventArgs e)
        {
            Senet frmSenet = new Senet();
            frmSenet.Show();
        }

        private void cbFirmaAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();

            SqlCommand cmd2 = new SqlCommand("SELECT id FROM firma WHERE firmaadi=@firmaadi", conn);
            cmd2.Parameters.AddWithValue("@firmaadi", cbFirmaAdi.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int id = Convert.ToInt32(dt.Rows[0][0]);


            string sorgu = "SELECT tahsilat.id,tahsilat.tarih as Tarih, tahsilat.islemtipi as İşlemTipi, firma.firmaadi as Firma, tahsilat.tutar as Tutar, tahsilat.aciklama as Açıklama FROM tahsilat INNER JOIN firma ON firma.id=tahsilat.firma_id WHERE firma_id = '" + id + "' "+
                     "UNION SELECT cek.id,cek.tarih as Tarih, cek.islemtipi as İşlemTipi, firma.firmaadi as Firma, cek.tutar as Tutar, cek.aciklama as Açıklama FROM cek INNER JOIN firma ON firma.id=cek.firma_id WHERE firma_id = '" + id + "'"+
                     "UNION SELECT senet.id,senet.tarih as Tarih, senet.islemtipi as İşlemTipi,firma.firmaadi as Firma, senet.tutar as Tutar, senet.aciklama as Açıklama FROM senet INNER JOIN firma ON firma.id=senet.firma_id WHERE firma_id = '" + id + "'";
            //string sorgu = "SELECT tarih, islemtipi, tutar, aciklama FROM tahsilat WHERE firma_id = '" + id + "' UNION SELECT tarih, islemtipi, tutar, aciklama FROM cek WHERE firma_id = '" + id + "'";
            gnl.veriGetir(sorgu, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Duzenle();
        }

        public void Duzenle()
        {
            Nakit nkt = new Nakit();
            Cek cek = new Cek();
            Senet senet = new Senet();            

            if (this.dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim() == "Nakit")
            {
                int index = nkt.cbFirma.FindString(this.dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim());
                nkt.dtTarih.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                nkt.txtTutar.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
                nkt.txtAciklama.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();

                nkt.cbFirma.SelectedIndex = index;

                nkt.lblGuncelle.Text = "guncelle";
                nkt.lblNakitid.Text= this.dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();

                nkt.Show();                
            }
            else if(this.dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim() == "Çek")
            {
                SqlConnection conn = new SqlConnection(gnl.baglan);
                conn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT id FROM firma WHERE firmaadi=@firmaadi", conn);
                cmd2.Parameters.AddWithValue("@firmaadi", cbFirmaAdi.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int id = Convert.ToInt32(dt.Rows[0][0]);

                int cekid= Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());

                string sorgu = "SELECT cek.id,cek.tarih,cek.cekno,cek.vade,cek.odemeyeri,cek.banka,cek.sube,cek.hno, cek.tutar,cek.aciklama,firma.firmaadi FROM cek INNER JOIN firma ON firma.id=cek.firma_id WHERE firma_id = @id AND cek.id=@cekid";
                SqlCommand cmd3 =new SqlCommand(sorgu, conn);
                cmd3.Parameters.AddWithValue("@id", id);
                cmd3.Parameters.AddWithValue("@cekid", cekid);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);

                int index = cek.cbFirma.FindString(this.dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim());

                cek.cbFirma.SelectedIndex = index;
                cek.dtTarih.Text = dt3.Rows[0][1].ToString();
                cek.txtCekno.Text = dt3.Rows[0][2].ToString();
                cek.dtVade.Text = dt3.Rows[0][3].ToString();
                cek.txtOdemeyeri.Text = dt3.Rows[0][4].ToString();
                cek.txtBanka.Text = dt3.Rows[0][5].ToString();
                cek.txtSube.Text= dt3.Rows[0][6].ToString();
                cek.txtHesapno.Text= dt3.Rows[0][7].ToString();
                cek.txtTutar.Text= dt3.Rows[0][8].ToString();
                cek.txtAciklama.Text= dt3.Rows[0][9].ToString();


                cek.lblGuncelle.Text = "guncelle";
                cek.lblid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();


                cek.Show();                
            }

            else if(this.dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim() == "Senet")
            {
                SqlConnection conn = new SqlConnection(gnl.baglan);
                conn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT id FROM firma WHERE firmaadi=@firmaadi", conn);
                cmd2.Parameters.AddWithValue("@firmaadi", cbFirmaAdi.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int id = Convert.ToInt32(dt.Rows[0][0]);

                int senetid = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());


                string sorgu = "SELECT senet.id,senet.tarih,senet.senetno,senet.vade,senet.odemeyeri,senet.kefil,senet.tutar,senet.aciklama,firma.firmaadi FROM senet INNER JOIN firma ON firma.id=senet.firma_id WHERE firma_id = @id AND senet.id=@senetid";
                SqlCommand cmd3 = new SqlCommand(sorgu, conn);
                cmd3.Parameters.AddWithValue("@id", id);
                cmd3.Parameters.AddWithValue("@senetid", senetid);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);

                int index = cek.cbFirma.FindString(this.dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim());

                senet.cbFirma.SelectedIndex = index;
                senet.dtTarih.Text = dt3.Rows[0][1].ToString();
                senet.txtSenetno.Text = dt3.Rows[0][2].ToString();
                senet.dtVade.Text = dt3.Rows[0][3].ToString();
                senet.txtOdemeyeri.Text = dt3.Rows[0][4].ToString();
                senet.txtKefil.Text = dt3.Rows[0][5].ToString();
                senet.txtTutar.Text = dt3.Rows[0][6].ToString();
                senet.txtAciklama.Text = dt3.Rows[0][7].ToString();


                senet.lblGuncelle.Text = "guncelle";
                senet.lblid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();


                senet.Show();
            }
        }

        public void Guncelle()
        {

        }
    }
}
