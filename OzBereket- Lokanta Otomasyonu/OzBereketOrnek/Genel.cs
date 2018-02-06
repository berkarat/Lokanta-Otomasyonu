using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzBereketOrnek
{
    class Genel
        
    {

        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Muaz-Halil\Desktop\Ozbereket.mdf;Integrated Security=True;Connect Timeout=30
        /****
         * setupta çalışcak conn
        public string baglan = ConfigurationManager.ConnectionStrings["ozbreketconn"].ConnectionString;

        ***/
        //C:\Users\Muaz-Halil\Documents\Visual Studio 2015\Projects\OzBereketOrnek\OzBereketOrnek\Ozbereket.mdf
        //Data Source=((LocalDB)\MSSQLLocalDB;AttachDbFilename="'[DataDirectory]'\Ozbereket.mdf";Integrated Security=True);
        // public string baglan = (@"Data Source=((LocalDB)\MSSQLLocalDB;Integrated Security = True;AttachDbFilename=|DataDirectory|\Ozbereket.mdf");
        //'|DataDirectory|\

        //public string baglan = (@"Data Source=((LocalDB)\MSSQLLocalDB;Integrated Security = True;AttachDbFilename='|DataDirectory|\Ozbereket.mdf'");

        //--public string baglan = ("Server=Halil-Muaz; Database=Ozbereket; Trusted_Connection=true");

         public string baglan = ConfigurationManager.ConnectionStrings["ozbreketconn"].ConnectionString;

        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\Muaz-Halil\Documents\Visual Studio 2015\Projects\OzBereketOrnek\OzBereketOrnek\Ozbereket.mdf";Integrated Security=True;Connect Timeout=30

        //public string baglan = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ozbereket1.accdb");


        public void veriGetir(string sorgu, DataGridView dtw)
        {
            //Genel gnl = new Genel();
            //SqlConnection conn = new SqlConnection(baglan);
            SqlConnection conn = new SqlConnection(baglan);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtw.DataSource = dt;
            conn.Close();

        }

        public void SadeceRakamVirgulVeSilme(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),nokta(ascii kodu:44) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;
            }
        }

        public void SadeceRakamVeSilme(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;
            }
        }

        public void VirgulYasak(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)44)
            
            {
                e.Handled = true;
            }
        }
    }
}
