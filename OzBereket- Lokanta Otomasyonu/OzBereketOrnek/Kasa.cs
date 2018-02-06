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
    public partial class Kasa : UserControl
    {
        Genel gnl = new Genel();
        private static Kasa _instance;

        public static Kasa Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Kasa();
                }
                return _instance;
            }
        }

        public void kasaGetir()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            //string sorgu = "SELECT giderturu as GiderTürü, tarih as Tarih, tutar as Tutar, aciklama as Açıklama FROM gider";
            string cekToplam = "SELECT ISNULL(SUM(tutar), 0) FROM cek";
            SqlCommand cmdCek = new SqlCommand(cekToplam, conn);            
            decimal cekToplami = Convert.ToDecimal(cmdCek.ExecuteScalar());

            string senetToplam = "SELECT ISNULL(SUM(tutar), 0) FROM senet";
            SqlCommand cmdSenet = new SqlCommand(senetToplam, conn);
            decimal senetToplami = Convert.ToDecimal(cmdSenet.ExecuteScalar());

            string nakitToplam = "SELECT ISNULL(SUM(tutar), 0) FROM tahsilat";
            SqlCommand cmdNakit = new SqlCommand(nakitToplam, conn);
            decimal nakitToplami = Convert.ToDecimal(cmdNakit.ExecuteScalar());

            decimal giren = cekToplami + senetToplami + nakitToplami;


            string sorgu1 = "SELECT ISNULL(SUM(tutar), 0)  FROM gider";
            SqlCommand cmd2 = new SqlCommand(sorgu1, conn);
            //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            // DataTable dt2 = new DataTable();
            //da2.Fill(dt2);

            // if (dt2.Rows[0][0] == null) dt2.Rows[0][0] = 0.ToString();
            // double cikan = Convert.ToDouble(dt2.Rows[0][0]);

            decimal cikan = Convert.ToDecimal(cmd2.ExecuteScalar());


            decimal bakiye = giren - cikan;

            dtKasa.ColumnCount = 3;
            dtKasa.Columns[0].Name = "Giren";
            dtKasa.Columns[1].Name = "Çıkan";
            dtKasa.Columns[2].Name = "Bakiye";

            dtKasa.Rows.Add();

            dtKasa.Rows[0].Cells[0].Value = giren;
            dtKasa.Rows[0].Cells[1].Value = cikan;
            dtKasa.Rows[0].Cells[2].Value = bakiye;

            //dtKasa.DataSource = dt;

            conn.Close();
        }
        public Kasa()
        {
            InitializeComponent();
            kasaGetir();
        }
    }
}
