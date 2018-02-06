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
using System.Collections;

namespace OzBereketOrnek
{
    public partial class Raporlar : UserControl
    {
        Genel gnl = new Genel();
        private static Raporlar _instance;

        public static Raporlar Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Raporlar();
                }
                return _instance;
            }
            

        }
        public Raporlar()
        {
            InitializeComponent();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Orange, 3);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 62, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        private void btnAylikGoster_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            //DateTime tarih1 = dtGelen1.Value;
            //DateTime tarih2 = dtGelen2.Value;

            string sorgu = ("SELECT firma.firmaadi as Firma, SUM(firma_detay.fis) as [Kişi Sayısı], SUM(firma_detay.tutar) as Tutar FROM firma INNER JOIN firma_detay ON firma_detay.firma_id=firma.id WHERE firma_detay.tarih >= @tarih1 AND firma_detay.tarih <= @tarih2 GROUP BY firma.firmaadi");

            DateTime tarih1 = dtGelen1.Value.AddDays(-1);

            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@tarih1", tarih1);
            cmd.Parameters.AddWithValue("@tarih2", SqlDbType.DateTime).Value = dtGelen2.Value;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            decimal intel = 0;
            int topKisi = 0;
            if (dataGridView1.RowCount > 0)
            {

                int index;
                for (index = 0; index <= (dataGridView1.RowCount - 1); index++)
                {
                    intel += Convert.ToDecimal(dataGridView1.Rows[index].Cells[2].Value); // hangi column ise onun indexi yazılacak 
                    

                }
                for (index = 0; index <= (dataGridView1.RowCount - 1); index++)
                {
                    topKisi += Convert.ToInt32(dataGridView1.Rows[index].Cells[1].Value); // hangi column ise onun indexi yazılacak 


                }
            }

            lblToplam.Text = intel.ToString();
            lblToplamKisi.Text = topKisi.ToString();

                conn.Close();
        }

        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;
        public int gelenId;
        string baslik = "Raporlar";

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog onizleme = new PrintPreviewDialog();
            onizleme.Document = printDocument1;
            ((Form)onizleme).WindowState = FormWindowState.Maximized;
            onizleme.PrintPreviewControl.Zoom = 1.0;
            onizleme.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int iLeftMargin = e.MarginBounds.Left;
                int iTopMargin = e.MarginBounds.Top;
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                bFirstPage = true;

                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;


                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];

                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;

                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {

                            e.Graphics.DrawString(baslik, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString(baslik, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString(baslik, new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);


                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;

                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }

                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }

                       
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //-----------------------------

                e.Graphics.DrawString("Toplam: " + lblToplamKisi.Text.ToString() + " Kişi\n", lblToplam.Font,
                                   new SolidBrush(lblToplam.ForeColor),
                                   new RectangleF((int)arrColumnLefts[0], (float)iTopMargin,
                                   (int)arrColumnWidths[0], (float)iCellHeight), strFormat);


                e.Graphics.DrawString("Toplam: "+lblToplam.Text.ToString()+" TL", lblToplam.Font,
                                    new SolidBrush(lblToplam.ForeColor),
                                    new RectangleF((int)arrColumnLefts[1], (float)iTopMargin,
                                    (int)arrColumnWidths[1], (float)iCellHeight), strFormat);

                //---------------------------

                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGunlukGoster_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            //DateTime tarih1 = dtGelen1.Value;
            //DateTime tarih2 = dtGelen2.Value;

            string sorgu = ("SELECT firma.firmaadi as Firma, SUM(firma_detay.fis) as [Kişi Sayısı], SUM(firma_detay.tutar) as Tutar FROM firma INNER JOIN firma_detay ON firma_detay.firma_id=firma.id WHERE firma_detay.tarih >= @tarih1 AND firma_detay.tarih <= @tarih2 GROUP BY firma.firmaadi");

            SqlCommand cmd = new SqlCommand(sorgu, conn);

            DateTime tarih1 = dtGunlukTarih.Value.AddDays(-1);
            DateTime tarih2 = dtGunlukTarih.Value;

            cmd.Parameters.AddWithValue("@tarih1", tarih1);
            cmd.Parameters.AddWithValue("@tarih2", tarih2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            decimal intel = 0;
            int topKisi = 0;
            if (dataGridView1.RowCount > 0)
            {

                int index;
                
                for (index = 0; index <= (dataGridView1.RowCount - 1); index++)
                {
                    intel += Convert.ToDecimal(dataGridView1.Rows[index].Cells[2].Value); // hangi column ise onun indexi yazılacak 

                }
                for (index = 0; index <= (dataGridView1.RowCount - 1); index++)
                {
                    topKisi += Convert.ToInt32(dataGridView1.Rows[index].Cells[1].Value); // hangi column ise onun indexi yazılacak 


                }
            }

            lblToplam.Text = intel.ToString();
            lblToplamKisi.Text = topKisi.ToString();

            conn.Close();
        }
    }
}
