namespace OzBereketOrnek
{
    partial class Tahsilat
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFirmaAdi = new System.Windows.Forms.ComboBox();
            this.btnSenet = new System.Windows.Forms.Button();
            this.btnCek = new System.Windows.Forms.Button();
            this.btnNakit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Size = new System.Drawing.Size(1074, 489);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbFirmaAdi);
            this.panel3.Controls.Add(this.btnSenet);
            this.panel3.Controls.Add(this.btnCek);
            this.panel3.Controls.Add(this.btnNakit);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1074, 59);
            this.panel3.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Firmalar";
            // 
            // cbFirmaAdi
            // 
            this.cbFirmaAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFirmaAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFirmaAdi.FormattingEnabled = true;
            this.cbFirmaAdi.Location = new System.Drawing.Point(119, 23);
            this.cbFirmaAdi.Name = "cbFirmaAdi";
            this.cbFirmaAdi.Size = new System.Drawing.Size(185, 21);
            this.cbFirmaAdi.TabIndex = 1;
            this.cbFirmaAdi.SelectedIndexChanged += new System.EventHandler(this.cbFirmaAdi_SelectedIndexChanged);
            // 
            // btnSenet
            // 
            this.btnSenet.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSenet.FlatAppearance.BorderSize = 0;
            this.btnSenet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSenet.Location = new System.Drawing.Point(588, 23);
            this.btnSenet.Name = "btnSenet";
            this.btnSenet.Size = new System.Drawing.Size(95, 23);
            this.btnSenet.TabIndex = 0;
            this.btnSenet.Text = "Senet";
            this.btnSenet.UseVisualStyleBackColor = false;
            this.btnSenet.Click += new System.EventHandler(this.btnSenet_Click);
            // 
            // btnCek
            // 
            this.btnCek.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCek.FlatAppearance.BorderSize = 0;
            this.btnCek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCek.Location = new System.Drawing.Point(472, 21);
            this.btnCek.Name = "btnCek";
            this.btnCek.Size = new System.Drawing.Size(95, 23);
            this.btnCek.TabIndex = 0;
            this.btnCek.Text = "Çek";
            this.btnCek.UseVisualStyleBackColor = false;
            this.btnCek.Click += new System.EventHandler(this.btnCek_Click);
            // 
            // btnNakit
            // 
            this.btnNakit.BackColor = System.Drawing.Color.LimeGreen;
            this.btnNakit.FlatAppearance.BorderSize = 0;
            this.btnNakit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNakit.Location = new System.Drawing.Point(345, 21);
            this.btnNakit.Name = "btnNakit";
            this.btnNakit.Size = new System.Drawing.Size(95, 23);
            this.btnNakit.TabIndex = 0;
            this.btnNakit.Text = "Nakit";
            this.btnNakit.UseVisualStyleBackColor = false;
            this.btnNakit.Click += new System.EventHandler(this.btnNakit_Click);
            // 
            // Tahsilat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Name = "Tahsilat";
            this.Size = new System.Drawing.Size(1080, 557);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFirmaAdi;
        private System.Windows.Forms.Button btnSenet;
        private System.Windows.Forms.Button btnCek;
        private System.Windows.Forms.Button btnNakit;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
