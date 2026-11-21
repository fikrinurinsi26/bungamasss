
namespace SIMRS
{
    partial class FrmPoli
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpDataPoli = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKodePoli = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNamaPoli = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnBaru = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.dgvPoli = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.keterangan = new System.Windows.Forms.Label();
            this.grpDataPoli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoli)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDataPoli
            // 
            this.grpDataPoli.Controls.Add(this.keterangan);
            this.grpDataPoli.Controls.Add(this.txtKeterangan);
            this.grpDataPoli.Controls.Add(this.label7);
            this.grpDataPoli.Controls.Add(this.btnTutup);
            this.grpDataPoli.Controls.Add(this.btnBatal);
            this.grpDataPoli.Controls.Add(this.btnHapus);
            this.grpDataPoli.Controls.Add(this.btnUbah);
            this.grpDataPoli.Controls.Add(this.btnSimpan);
            this.grpDataPoli.Controls.Add(this.btnBaru);
            this.grpDataPoli.Controls.Add(this.cmbStatus);
            this.grpDataPoli.Controls.Add(this.txtLokasi);
            this.grpDataPoli.Controls.Add(this.label4);
            this.grpDataPoli.Controls.Add(this.label3);
            this.grpDataPoli.Controls.Add(this.txtNamaPoli);
            this.grpDataPoli.Controls.Add(this.label2);
            this.grpDataPoli.Controls.Add(this.txtKodePoli);
            this.grpDataPoli.Controls.Add(this.label1);
            this.grpDataPoli.Location = new System.Drawing.Point(39, 49);
            this.grpDataPoli.Name = "grpDataPoli";
            this.grpDataPoli.Size = new System.Drawing.Size(574, 246);
            this.grpDataPoli.TabIndex = 0;
            this.grpDataPoli.TabStop = false;
            this.grpDataPoli.Text = "Data Poli";
            this.grpDataPoli.Enter += new System.EventHandler(this.grpDataPoli_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, -21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode Poli";
            // 
            // txtKodePoli
            // 
            this.txtKodePoli.Location = new System.Drawing.Point(104, 51);
            this.txtKodePoli.Name = "txtKodePoli";
            this.txtKodePoli.Size = new System.Drawing.Size(100, 20);
            this.txtKodePoli.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama Poli";
            // 
            // txtNamaPoli
            // 
            this.txtNamaPoli.Location = new System.Drawing.Point(104, 90);
            this.txtNamaPoli.Name = "txtNamaPoli";
            this.txtNamaPoli.Size = new System.Drawing.Size(107, 20);
            this.txtNamaPoli.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lokasi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Status";
            // 
            // txtLokasi
            // 
            this.txtLokasi.Location = new System.Drawing.Point(104, 129);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(107, 20);
            this.txtLokasi.TabIndex = 6;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbStatus.Location = new System.Drawing.Point(104, 168);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(107, 21);
            this.cmbStatus.TabIndex = 7;
            // 
            // btnBaru
            // 
            this.btnBaru.Location = new System.Drawing.Point(243, 174);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(75, 23);
            this.btnBaru.TabIndex = 8;
            this.btnBaru.Text = "Baru";
            this.btnBaru.UseVisualStyleBackColor = true;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(345, 174);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 9;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(437, 174);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(75, 23);
            this.btnUbah.TabIndex = 10;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(243, 213);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 11;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(345, 213);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 12;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(437, 213);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 13;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(503, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cari";
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(506, 318);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(107, 20);
            this.txtCari.TabIndex = 15;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // dgvPoli
            // 
            this.dgvPoli.AllowUserToAddRows = false;
            this.dgvPoli.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPoli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoli.Location = new System.Drawing.Point(39, 331);
            this.dgvPoli.MultiSelect = false;
            this.dgvPoli.Name = "dgvPoli";
            this.dgvPoli.ReadOnly = true;
            this.dgvPoli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPoli.Size = new System.Drawing.Size(443, 117);
            this.dgvPoli.TabIndex = 16;
            this.dgvPoli.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPoli_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(332, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "MASTER DATA POLI";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Kode Poli";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(104, 213);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(107, 20);
            this.txtKeterangan.TabIndex = 15;
            // 
            // keterangan
            // 
            this.keterangan.AutoSize = true;
            this.keterangan.Location = new System.Drawing.Point(37, 213);
            this.keterangan.Name = "keterangan";
            this.keterangan.Size = new System.Drawing.Size(61, 13);
            this.keterangan.TabIndex = 16;
            this.keterangan.Text = "keterangan";
            // 
            // FrmPoli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvPoli);
            this.Controls.Add(this.grpDataPoli);
            this.Name = "FrmPoli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Data Poli";
            this.Load += new System.EventHandler(this.FrmPoli_Load);
            this.grpDataPoli.ResumeLayout(false);
            this.grpDataPoli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDataPoli;
        private System.Windows.Forms.DataGridView dgvPoli;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamaPoli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKodePoli;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label keterangan;
        private System.Windows.Forms.TextBox txtKeterangan;
    }
}