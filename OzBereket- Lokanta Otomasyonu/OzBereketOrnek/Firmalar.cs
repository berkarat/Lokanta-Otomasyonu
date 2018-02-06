using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace OzBereketOrnek
{
    public partial class Firmalar : UserControl
    {
        Genel gnl = new Genel();
        private static Firmalar _instance;
        private int firmId;
        public int FirmId
        {
            get
            { return firmId; }
            set
            {
                firmId = value;
            }
        }

       

        public static Firmalar Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Firmalar();
                }
                return _instance;
            }
        }
        public Firmalar()
        {
            //this.Load += new EventHandler(Firmalar_Load);
            InitializeComponent();
            FirmaGoser();
           btnYazdir.Visible = false;
        }

        public void FirmaGoser()
        {
            string sorgu = "SELECT firma.id,firma.firmaadi as FirmaAdı, firma.yetkili as Yetkili, firma.adres as Adres, firma.tel1 as Telefon, firma.tel2, firma.gsm, firma.mail, firma.vdairesi, firma.vno, firma.yemekfiyat, firma.aciklama,((SELECT SUM(firmaoncekiborc.fborcu) FROM firmaoncekiborc WHERE firmaoncekiborc.firma_id=firma.id) +(SELECT SUM(firma_detay.tutar) FROM firma_detay WHERE firma_detay.firma_id=firma.id)+(SELECT SUM(fatura.kdvtutar) FROM fatura WHERE fatura.firma_id=firma.id)-(SELECT SUM(firmaoncekiborc.falacagi) FROM firmaoncekiborc WHERE firmaoncekiborc.firma_id=firma.id)) AS Bakiye  FROM firma";

            // string bakiyesorgu = "SELECT toplamborc FROM firma_detay WHERE firma_id='"+id+"'";

            //string topFirmaDetay = "SELECT ";
           // string topOnceki = "";


            gnl.veriGetir(sorgu, dataGridView1);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            
            dataGridView1.Refresh();
        }
        public void Yenile()
        {
            dataGridView1.DataSource = null;
            string sorgu = "SELECT firma.id,firma.firmaadi as FirmaAdı, firma.yetkili as Yetkili, firma.adres as Adres, firma.tel1 as Telefon, firma.tel2, firma.gsm, firma.mail, firma.vdairesi, firma.vno, firma.yemekfiyat, firma.aciklama, toplambakiye.toplambakiye as Bakiye FROM firma INNER JOIN toplambakiye ON toplambakiye.firma_id=firma.id";

            gnl.veriGetir(sorgu, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FirmaEkle frmEkle = new FirmaEkle();
            frmEkle.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Duzenle();

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Duzenle();
        }

        public void Duzenle()
        {
            FirmaEkle fe = new FirmaEkle();

            int index = fe.cbYemekFiyat.FindString(this.dataGridView1.CurrentRow.Cells[10].Value.ToString().Trim());
            fe.lblid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            fe.txtFirmaAd.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            fe.txtYetkili.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            fe.txtAdres.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            fe.txtTel1.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
            fe.txtTel2.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            fe.txtGsm.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
            fe.txtMail.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString().Trim();
            fe.txtVergiDairesi.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString().Trim();
            fe.txtVergiNo.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString().Trim();
            fe.cbYemekFiyat.SelectedIndex = index;
            fe.txtAciklama.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString().Trim();

            fe.lblGuncelle.Text = "guncelle";
            //fe.lblOncekiBorcu.Visible = false;
            //fe.txtOncekiBorcu.Visible = false;

            fe.Show();
        }

        private void Firmalar_Load(object sender, EventArgs e)
        {
            FirmaGoser();
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
                            
                                if (Cel.Visible != false)
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

                ////-----------------------------

                //e.Graphics.DrawString("Toplam: " + lblToplam.Text.ToString() + " TL", lblToplam.Font,
                //                    new SolidBrush(lblToplam.ForeColor),
                //                    new RectangleF((int)arrColumnLefts[0], (float)iTopMargin,
                //                    (int)arrColumnWidths[0], (float)iCellHeight), strFormat);

                ////---------------------------

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

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog onizleme = new PrintPreviewDialog();
            onizleme.Document = printDocument1;
            ((Form)onizleme).WindowState = FormWindowState.Maximized;
            onizleme.PrintPreviewControl.Zoom = 1.0;
            onizleme.ShowDialog();
        }

        private void btnOncekiBorc_Click(object sender, EventArgs e)
        {
            firmId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());

            FirmailkBorc fib = new FirmailkBorc();

            int index = fib.cbFirma.FindString(this.dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim());
            

            fib.cbFirma.SelectedIndex = index;

            fib.ShowDialog();
        }

        private void btnBakiyeler_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT firma.firmaadi AS Firma, SUM(firma_detay.tutar)+SUM(firmaoncekiborc.fborcu)-SUM(firmaoncekiborc.falacagi) AS Bakiye FROM firma INNER JOIN firma_detay ON firma.id=firma_detay.firma_id INNER JOIN firmaoncekiborc ON firma_detay.firma_id=firmaoncekiborc.firma_id GROUP BY firma.firmaadi";

            string oncborc = "SELECT firma.firmaadi AS Firma, SUM(firmaoncekiborc.fborcu) FROM firma INNER JOIN firmaoncekiborc ON firma.id = firmaoncekiborc.firma_id GROUP BY firma.firmaadi";

            string oncalacak = "SELECT firma.firmaadi AS Firma, SUM(firmaoncekiborc.falacagi) FROM firma INNER JOIN firmaoncekiborc ON firma.id = firmaoncekiborc.firma_id GROUP BY firma.firmaadi";

             string topyedigi="SELECT firma.firmaadi AS Firma, SUM(firma_detay.tutar) FROM firma INNER JOIN firma_detay ON firma.id = firma_detay.firma_id GROUP BY firma.firmaadi";

            gnl.veriGetir(sorgu, dataGridView1);
            btnOncekiBorc.Enabled = false;
            btnDuzenle.Enabled = false;
        }

        private void btnFirmalar_Click(object sender, EventArgs e)
        {
            FirmaGoser();
            btnOncekiBorc.Enabled = true;
            btnDuzenle.Enabled = true;
        }

        //if (Cel.Visible != false) { }
    }
}
