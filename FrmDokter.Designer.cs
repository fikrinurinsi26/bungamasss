
namespace SIMRS
{
    partial class FrmDokter
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
            this.cmbPoli = new System.Windows.Forms.ComboBox();
            this.txtNoHP = new System.Windows.Forms.TextBox();
            this.txtNamaDokter = new System.Windows.Forms.TextBox();
            this.txtKodeDokter = new System.Windows.Forms.TextBox();
            this.cmbJenisKelamin = new System.Windows.Forms.ComboBox();
            this.txtAlamat = new System.Windows.Forms.RichTextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBaru = new System.Windows.Forms.Button();
            this.dgvDokter = new System.Windows.Forms.DataGridView();
            this.txtSpesialisasi = new System.Windows.Forms.TextBox();
            this.txtNomorIzin = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDokter)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPoli
            // 
            this.cmbPoli.FormattingEnabled = true;
            this.cmbPoli.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbPoli.Location = new System.Drawing.Point(85, 159);
            this.cmbPoli.Name = "cmbPoli";
            this.cmbPoli.Size = new System.Drawing.Size(107, 21);
            this.cmbPoli.TabIndex = 19;
            this.cmbPoli.SelectedIndexChanged += new System.EventHandler(this.cmbPoli_SelectedIndexChanged);
            // 
            // txtNoHP
            // 
            this.txtNoHP.Location = new System.Drawing.Point(85, 101);
            this.txtNoHP.Name = "txtNoHP";
            this.txtNoHP.Size = new System.Drawing.Size(107, 20);
            this.txtNoHP.TabIndex = 18;
            // 
            // txtNamaDokter
            // 
            this.txtNamaDokter.Location = new System.Drawing.Point(85, 35);
            this.txtNamaDokter.Name = "txtNamaDokter";
            this.txtNamaDokter.Size = new System.Drawing.Size(107, 20);
            this.txtNamaDokter.TabIndex = 17;
            this.txtNamaDokter.TextChanged += new System.EventHandler(this.txtNamaDokter_TextChanged);
            // 
            // txtKodeDokter
            // 
            this.txtKodeDokter.Location = new System.Drawing.Point(85, 5);
            this.txtKodeDokter.Name = "txtKodeDokter";
            this.txtKodeDokter.Size = new System.Drawing.Size(107, 20);
            this.txtKodeDokter.TabIndex = 16;
            this.txtKodeDokter.TextChanged += new System.EventHandler(this.txtKodeDokter_TextChanged);
            // 
            // cmbJenisKelamin
            // 
            this.cmbJenisKelamin.FormattingEnabled = true;
            this.cmbJenisKelamin.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbJenisKelamin.Location = new System.Drawing.Point(85, 74);
            this.cmbJenisKelamin.Name = "cmbJenisKelamin";
            this.cmbJenisKelamin.Size = new System.Drawing.Size(107, 21);
            this.cmbJenisKelamin.TabIndex = 21;
            this.cmbJenisKelamin.SelectedIndexChanged += new System.EventHandler(this.cmbJenisKelamin_SelectedIndexChanged);
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(85, 260);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(107, 37);
            this.txtAlamat.TabIndex = 22;
            this.txtAlamat.Text = "";
            this.txtAlamat.TextChanged += new System.EventHandler(this.txtAlamat_TextChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbStatus.Location = new System.Drawing.Point(82, 225);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(107, 21);
            this.cmbStatus.TabIndex = 23;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(451, 183);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(107, 20);
            this.txtCari.TabIndex = 25;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(448, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Cari Data";
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(629, 97);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 31;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(537, 97);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 30;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(435, 97);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 29;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(629, 58);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(75, 23);
            this.btnUbah.TabIndex = 28;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(537, 58);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 27;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBaru
            // 
            this.btnBaru.Location = new System.Drawing.Point(435, 58);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(75, 23);
            this.btnBaru.TabIndex = 26;
            this.btnBaru.Text = "Baru";
            this.btnBaru.UseVisualStyleBackColor = true;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // dgvDokter
            // 
            this.dgvDokter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDokter.Location = new System.Drawing.Point(308, 269);
            this.dgvDokter.Name = "dgvDokter";
            this.dgvDokter.Size = new System.Drawing.Size(402, 150);
            this.dgvDokter.TabIndex = 32;
            this.dgvDokter.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDokter_CellContentClick);
            // 
            // txtSpesialisasi
            // 
            this.txtSpesialisasi.Location = new System.Drawing.Point(85, 303);
            this.txtSpesialisasi.Name = "txtSpesialisasi";
            this.txtSpesialisasi.Size = new System.Drawing.Size(107, 20);
            this.txtSpesialisasi.TabIndex = 33;
            // 
            // txtNomorIzin
            // 
            this.txtNomorIzin.Location = new System.Drawing.Point(85, 190);
            this.txtNomorIzin.Name = "txtNomorIzin";
            this.txtNomorIzin.Size = new System.Drawing.Size(107, 20);
            this.txtNomorIzin.TabIndex = 34;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(85, 127);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(107, 20);
            this.txtEmail.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Kode Dokter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Jenis Kelamin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Poli";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Nomor SIP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Alamat";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Spesialis";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "No. HP";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Nama Dokter";
            // 
            // FrmDokter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNomorIzin);
            this.Controls.Add(this.txtSpesialisasi);
            this.Controls.Add(this.dgvDokter);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBaru);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.cmbJenisKelamin);
            this.Controls.Add(this.cmbPoli);
            this.Controls.Add(this.txtNoHP);
            this.Controls.Add(this.txtNamaDokter);
            this.Controls.Add(this.txtKodeDokter);
            this.Name = "FrmDokter";
            this.Text = "FrmDokter";
            this.Load += new System.EventHandler(this.FrmDokter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDokter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbPoli;
        private System.Windows.Forms.TextBox txtNoHP;
        private System.Windows.Forms.TextBox txtNamaDokter;
        private System.Windows.Forms.TextBox txtKodeDokter;
        private System.Windows.Forms.ComboBox cmbJenisKelamin;
        private System.Windows.Forms.RichTextBox txtAlamat;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.DataGridView dgvDokter;
        private System.Windows.Forms.TextBox txtSpesialisasi;
        private System.Windows.Forms.TextBox txtNomorIzin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}