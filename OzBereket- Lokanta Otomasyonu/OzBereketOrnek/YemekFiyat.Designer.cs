namespace OzBereketOrnek
{
    partial class YemekFiyat
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
            this.dtYemekFiyat = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnYeniFiyat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtYemekFiyat)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtYemekFiyat
            // 
            this.dtYemekFiyat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtYemekFiyat.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.dtYemekFiyat.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtYemekFiyat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtYemekFiyat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtYemekFiyat.Location = new System.Drawing.Point(3, 65);
            this.dtYemekFiyat.Name = "dtYemekFiyat";
            this.dtYemekFiyat.ReadOnly = true;
            this.dtYemekFiyat.RowHeadersWidth = 50;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dtYemekFiyat.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtYemekFiyat.Size = new System.Drawing.Size(1074, 489);
            this.dtYemekFiyat.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.btnYeniFiyat);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1074, 59);
            this.panel3.TabIndex = 21;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LimeGreen;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(389, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 23);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnYeniFiyat
            // 
            this.btnYeniFiyat.BackColor = System.Drawing.Color.LimeGreen;
            this.btnYeniFiyat.FlatAppearance.BorderSize = 0;
            this.btnYeniFiyat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniFiyat.Location = new System.Drawing.Point(262, 20);
            this.btnYeniFiyat.Name = "btnYeniFiyat";
            this.btnYeniFiyat.Size = new System.Drawing.Size(95, 23);
            this.btnYeniFiyat.TabIndex = 0;
            this.btnYeniFiyat.Text = "Yeni Fiyat";
            this.btnYeniFiyat.UseVisualStyleBackColor = false;
            this.btnYeniFiyat.Click += new System.EventHandler(this.btnYeniFiyat_Click);
            // 
            // YemekFiyat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.Controls.Add(this.dtYemekFiyat);
            this.Controls.Add(this.panel3);
            this.Name = "YemekFiyat";
            this.Size = new System.Drawing.Size(1080, 557);
            ((System.ComponentModel.ISupportInitialize)(this.dtYemekFiyat)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnYeniFiyat;
        private System.Windows.Forms.DataGridView dtYemekFiyat;
    }
}
