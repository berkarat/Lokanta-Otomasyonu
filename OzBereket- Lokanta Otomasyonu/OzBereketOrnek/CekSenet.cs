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
    public partial class CekSenet : UserControl
    {
        private static CekSenet _instance;

        Genel gnl = new Genel();

        public void CekGetir()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            string sorgu = "SELECT cek.islemtipi as Tip, cek.tarih as VerilişTarihi,firma.firmaadi as Firma, cek.cekno as No, cek.vade as Vade, cek.odemeyeri as ÖdemeYeri, cek.banka as Banka, cek.sube as Şube, cek.hno as HesapNo, cek.tutar as Tutar, cek.aciklama as Açıklama FROM cek INNER JOIN firma ON firma.id=cek.firma_id";
            //cek.tarih as VerilişTarihi, cek.cekno as No, cek.vade as Vade, cek.tutar as Tutar, cek.aciklama as Açıklama
            // INNER JOIN senet.tarih as VerilişTarihi, senet.senetno as No, senet.vade as Vade, senet.tutar as Tutar, senet.aciklama as Açıklama
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //dt.Columns.Add("IslemTipi");
            //DataRow row = dt.NewRow();
            //row["IslemTipi"] = "Çek";
            //dt.Rows.Add(row);
            da.Fill(dt);
            dtCek.DataSource = dt;
            conn.Close();

        }

        public void SenetGetir()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            string sorgu = "SELECT senet.islemtipi as Tip, senet.tarih as VerilişTarihi,firma.firmaadi as Firma, senet.senetno as No, senet.vade as Vade, senet.odemeyeri as ÖdemeYeri,senet.kefil as Kefil, senet.tutar as Tutar, senet.aciklama as Açıklama FROM senet INNER JOIN firma ON firma.id=senet.firma_id";
            //cek.tarih as VerilişTarihi, cek.cekno as No, cek.vade as Vade, cek.tutar as Tutar, cek.aciklama as Açıklama
            // INNER JOIN senet.tarih as VerilişTarihi, senet.senetno as No, senet.vade as Vade, senet.tutar as Tutar, senet.aciklama as Açıklama
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //dt.Columns.Add("IslemTipi");
            //DataRow row = dt.NewRow();
            //row["IslemTipi"] = "Çek";
            //dt.Rows.Add(row);
            da.Fill(dt);
            dtSenet.DataSource = dt;
            conn.Close();

        }

        public static CekSenet Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CekSenet();
                }
                return _instance;
            }
        }
        public CekSenet()
        {
            InitializeComponent();
            CekGetir();
            SenetGetir();
        }

        private void btnCekGiris_Click(object sender, EventArgs e)
        {
            Cek frmCek = new Cek();
            frmCek.Show();
        }

        private void btnSenetGiris_Click(object sender, EventArgs e)
        {
            Senet frmSenet = new Senet();
            frmSenet.Show();
        }
    }
}
