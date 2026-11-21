
namespace SIMRS
{
    partial class FrmDashboard
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
            this.components = new System.ComponentModel.Container();
            this.mnuPoli = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPasienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataDokterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPoliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataObatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendaftaranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pemeriksaanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rekamMedisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pembayaranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanPasienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanDokteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanPembayaranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.akunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblJudul = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblJam = new System.Windows.Forms.Label();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.lblNamaUser = new System.Windows.Forms.Label();
            this.lblSelamat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblJumlahPasien = new System.Windows.Forms.Label();
            this.lblTextPasien = new System.Windows.Forms.Label();
            this.panelDokter = new System.Windows.Forms.Panel();
            this.lblJumlahDokter = new System.Windows.Forms.Label();
            this.lbldk = new System.Windows.Forms.Label();
            this.panelPoli = new System.Windows.Forms.Panel();
            this.lblJumlahPoli = new System.Windows.Forms.Label();
            this.lblpl = new System.Windows.Forms.Label();
            this.panelObat = new System.Windows.Forms.Panel();
            this.lblJumlahObat = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.resepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPoli.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelDokter.SuspendLayout();
            this.panelPoli.SuspendLayout();
            this.panelObat.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPoli
            // 
            this.mnuPoli.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.traToolStripMenuItem,
            this.laporanToolStripMenuItem,
            this.akunToolStripMenuItem});
            this.mnuPoli.Location = new System.Drawing.Point(0, 0);
            this.mnuPoli.Name = "mnuPoli";
            this.mnuPoli.Size = new System.Drawing.Size(800, 24);
            this.mnuPoli.TabIndex = 0;
            this.mnuPoli.Text = "Data Poli";
            this.mnuPoli.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuPoli_ItemClicked);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataPasienToolStripMenuItem,
            this.dataDokterToolStripMenuItem,
            this.dataPoliToolStripMenuItem,
            this.dataObatToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            this.masterToolStripMenuItem.Click += new System.EventHandler(this.masterToolStripMenuItem_Click);
            // 
            // dataPasienToolStripMenuItem
            // 
            this.dataPasienToolStripMenuItem.Name = "dataPasienToolStripMenuItem";
            this.dataPasienToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataPasienToolStripMenuItem.Text = " Data Pasien";
            this.dataPasienToolStripMenuItem.Click += new System.EventHandler(this.dataPasienToolStripMenuItem_Click);
            // 
            // dataDokterToolStripMenuItem
            // 
            this.dataDokterToolStripMenuItem.Name = "dataDokterToolStripMenuItem";
            this.dataDokterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataDokterToolStripMenuItem.Text = "Data Dokter";
            this.dataDokterToolStripMenuItem.Click += new System.EventHandler(this.dataDokterToolStripMenuItem_Click);
            // 
            // dataPoliToolStripMenuItem
            // 
            this.dataPoliToolStripMenuItem.Name = "dataPoliToolStripMenuItem";
            this.dataPoliToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataPoliToolStripMenuItem.Text = " Data Poli";
            this.dataPoliToolStripMenuItem.Click += new System.EventHandler(this.dataPoliToolStripMenuItem_Click);
            // 
            // dataObatToolStripMenuItem
            // 
            this.dataObatToolStripMenuItem.Name = "dataObatToolStripMenuItem";
            this.dataObatToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataObatToolStripMenuItem.Text = "Data Obat";
            this.dataObatToolStripMenuItem.Click += new System.EventHandler(this.dataObatToolStripMenuItem_Click);
            // 
            // traToolStripMenuItem
            // 
            this.traToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendaftaranToolStripMenuItem,
            this.pemeriksaanToolStripMenuItem,
            this.rekamMedisToolStripMenuItem,
            this.pembayaranToolStripMenuItem,
            this.resepToolStripMenuItem});
            this.traToolStripMenuItem.Name = "traToolStripMenuItem";
            this.traToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.traToolStripMenuItem.Text = "Transaksi";
            // 
            // pendaftaranToolStripMenuItem
            // 
            this.pendaftaranToolStripMenuItem.Name = "pendaftaranToolStripMenuItem";
            this.pendaftaranToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pendaftaranToolStripMenuItem.Text = "Pendaftaran";
            this.pendaftaranToolStripMenuItem.Click += new System.EventHandler(this.pendaftaranToolStripMenuItem_Click);
            // 
            // pemeriksaanToolStripMenuItem
            // 
            this.pemeriksaanToolStripMenuItem.Name = "pemeriksaanToolStripMenuItem";
            this.pemeriksaanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pemeriksaanToolStripMenuItem.Text = "Pemeriksaan";
            this.pemeriksaanToolStripMenuItem.Click += new System.EventHandler(this.pemeriksaanToolStripMenuItem_Click);
            // 
            // rekamMedisToolStripMenuItem
            // 
            this.rekamMedisToolStripMenuItem.Name = "rekamMedisToolStripMenuItem";
            this.rekamMedisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rekamMedisToolStripMenuItem.Text = "Rekam Medis";
            this.rekamMedisToolStripMenuItem.Click += new System.EventHandler(this.rekamMedisToolStripMenuItem_Click);
            // 
            // pembayaranToolStripMenuItem
            // 
            this.pembayaranToolStripMenuItem.Name = "pembayaranToolStripMenuItem";
            this.pembayaranToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pembayaranToolStripMenuItem.Text = "Pembayaran";
            this.pembayaranToolStripMenuItem.Click += new System.EventHandler(this.pembayaranToolStripMenuItem_Click);
            // 
            // laporanToolStripMenuItem
            // 
            this.laporanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.laporanPasienToolStripMenuItem,
            this.laporanDokteToolStripMenuItem,
            this.laporanPembayaranToolStripMenuItem});
            this.laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            this.laporanToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.laporanToolStripMenuItem.Text = "Laporan";
            this.laporanToolStripMenuItem.Click += new System.EventHandler(this.laporanToolStripMenuItem_Click);
            // 
            // laporanPasienToolStripMenuItem
            // 
            this.laporanPasienToolStripMenuItem.Name = "laporanPasienToolStripMenuItem";
            this.laporanPasienToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.laporanPasienToolStripMenuItem.Text = "Laporan Pasien";
            this.laporanPasienToolStripMenuItem.Click += new System.EventHandler(this.laporanPasienToolStripMenuItem_Click);
            // 
            // laporanDokteToolStripMenuItem
            // 
            this.laporanDokteToolStripMenuItem.Name = "laporanDokteToolStripMenuItem";
            this.laporanDokteToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.laporanDokteToolStripMenuItem.Text = "Laporan Dokte";
            // 
            // laporanPembayaranToolStripMenuItem
            // 
            this.laporanPembayaranToolStripMenuItem.Name = "laporanPembayaranToolStripMenuItem";
            this.laporanPembayaranToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.laporanPembayaranToolStripMenuItem.Text = "Laporan Pembayaran";
            // 
            // akunToolStripMenuItem
            // 
            this.akunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.akunToolStripMenuItem.Name = "akunToolStripMenuItem";
            this.akunToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.akunToolStripMenuItem.Text = "Akun";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // lblJudul
            // 
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.Location = new System.Drawing.Point(187, 36);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(440, 23);
            this.lblJudul.TabIndex = 1;
            this.lblJudul.Text = "SISTEM INFORMASI MANAJEMEN RUMAH SAKIT";
            this.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblJam);
            this.panel1.Controls.Add(this.lblTanggal);
            this.panel1.Controls.Add(this.lblNamaUser);
            this.panel1.Controls.Add(this.lblSelamat);
            this.panel1.Location = new System.Drawing.Point(0, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 2;
            // 
            // lblJam
            // 
            this.lblJam.AutoSize = true;
            this.lblJam.Location = new System.Drawing.Point(253, 65);
            this.lblJam.Name = "lblJam";
            this.lblJam.Size = new System.Drawing.Size(35, 13);
            this.lblJam.TabIndex = 3;
            this.lblJam.Text = "Jam : ";
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Location = new System.Drawing.Point(75, 65);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(52, 13);
            this.lblTanggal.TabIndex = 2;
            this.lblTanggal.Text = "Tanggal :";
            this.lblTanggal.Click += new System.EventHandler(this.lblTanggal_Click);
            // 
            // lblNamaUser
            // 
            this.lblNamaUser.AutoSize = true;
            this.lblNamaUser.Location = new System.Drawing.Point(56, 33);
            this.lblNamaUser.Name = "lblNamaUser";
            this.lblNamaUser.Size = new System.Drawing.Size(67, 13);
            this.lblNamaUser.TabIndex = 1;
            this.lblNamaUser.Text = "Administrator";
            this.lblNamaUser.Click += new System.EventHandler(this.lblNamaUser_Click);
            // 
            // lblSelamat
            // 
            this.lblSelamat.AutoSize = true;
            this.lblSelamat.Location = new System.Drawing.Point(56, 11);
            this.lblSelamat.Name = "lblSelamat";
            this.lblSelamat.Size = new System.Drawing.Size(86, 13);
            this.lblSelamat.TabIndex = 0;
            this.lblSelamat.Text = "Selamat Datang,";
            this.lblSelamat.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.lblJumlahPasien);
            this.panel2.Controls.Add(this.lblTextPasien);
            this.panel2.Location = new System.Drawing.Point(12, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 100);
            this.panel2.TabIndex = 3;
            // 
            // lblJumlahPasien
            // 
            this.lblJumlahPasien.AutoSize = true;
            this.lblJumlahPasien.Location = new System.Drawing.Point(80, 50);
            this.lblJumlahPasien.Name = "lblJumlahPasien";
            this.lblJumlahPasien.Size = new System.Drawing.Size(13, 13);
            this.lblJumlahPasien.TabIndex = 5;
            this.lblJumlahPasien.Text = "0";
            // 
            // lblTextPasien
            // 
            this.lblTextPasien.AutoSize = true;
            this.lblTextPasien.Location = new System.Drawing.Point(49, 24);
            this.lblTextPasien.Name = "lblTextPasien";
            this.lblTextPasien.Size = new System.Drawing.Size(75, 13);
            this.lblTextPasien.TabIndex = 4;
            this.lblTextPasien.Text = "Jumlah Pasien";
            // 
            // panelDokter
            // 
            this.panelDokter.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panelDokter.Controls.Add(this.lblJumlahDokter);
            this.panelDokter.Controls.Add(this.lbldk);
            this.panelDokter.Location = new System.Drawing.Point(198, 273);
            this.panelDokter.Name = "panelDokter";
            this.panelDokter.Size = new System.Drawing.Size(180, 100);
            this.panelDokter.TabIndex = 4;
            // 
            // lblJumlahDokter
            // 
            this.lblJumlahDokter.AutoSize = true;
            this.lblJumlahDokter.Location = new System.Drawing.Point(88, 50);
            this.lblJumlahDokter.Name = "lblJumlahDokter";
            this.lblJumlahDokter.Size = new System.Drawing.Size(13, 13);
            this.lblJumlahDokter.TabIndex = 7;
            this.lblJumlahDokter.Text = "0";
            // 
            // lbldk
            // 
            this.lbldk.AutoSize = true;
            this.lbldk.Location = new System.Drawing.Point(55, 24);
            this.lbldk.Name = "lbldk";
            this.lbldk.Size = new System.Drawing.Size(75, 13);
            this.lbldk.TabIndex = 6;
            this.lbldk.Text = "Jumlah Dokter";
            // 
            // panelPoli
            // 
            this.panelPoli.BackColor = System.Drawing.Color.Orange;
            this.panelPoli.Controls.Add(this.lblJumlahPoli);
            this.panelPoli.Controls.Add(this.lblpl);
            this.panelPoli.Location = new System.Drawing.Point(384, 273);
            this.panelPoli.Name = "panelPoli";
            this.panelPoli.Size = new System.Drawing.Size(180, 100);
            this.panelPoli.TabIndex = 4;
            // 
            // lblJumlahPoli
            // 
            this.lblJumlahPoli.AutoSize = true;
            this.lblJumlahPoli.Location = new System.Drawing.Point(89, 50);
            this.lblJumlahPoli.Name = "lblJumlahPoli";
            this.lblJumlahPoli.Size = new System.Drawing.Size(13, 13);
            this.lblJumlahPoli.TabIndex = 8;
            this.lblJumlahPoli.Text = "0";
            // 
            // lblpl
            // 
            this.lblpl.AutoSize = true;
            this.lblpl.Location = new System.Drawing.Point(57, 24);
            this.lblpl.Name = "lblpl";
            this.lblpl.Size = new System.Drawing.Size(60, 13);
            this.lblpl.TabIndex = 8;
            this.lblpl.Text = "Jumlah Poli";
            // 
            // panelObat
            // 
            this.panelObat.BackColor = System.Drawing.Color.IndianRed;
            this.panelObat.Controls.Add(this.lblJumlahObat);
            this.panelObat.Controls.Add(this.label8);
            this.panelObat.Location = new System.Drawing.Point(570, 273);
            this.panelObat.Name = "panelObat";
            this.panelObat.Size = new System.Drawing.Size(180, 100);
            this.panelObat.TabIndex = 9;
            // 
            // lblJumlahObat
            // 
            this.lblJumlahObat.AutoSize = true;
            this.lblJumlahObat.Location = new System.Drawing.Point(89, 50);
            this.lblJumlahObat.Name = "lblJumlahObat";
            this.lblJumlahObat.Size = new System.Drawing.Size(13, 13);
            this.lblJumlahObat.TabIndex = 8;
            this.lblJumlahObat.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Jumlah Obat";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // resepToolStripMenuItem
            // 
            this.resepToolStripMenuItem.Name = "resepToolStripMenuItem";
            this.resepToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resepToolStripMenuItem.Text = "Resep";
            this.resepToolStripMenuItem.Click += new System.EventHandler(this.resepToolStripMenuItem_Click);
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelObat);
            this.Controls.Add(this.panelDokter);
            this.Controls.Add(this.panelPoli);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblJudul);
            this.Controls.Add(this.mnuPoli);
            this.MainMenuStrip = this.mnuPoli;
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - SIMRS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.mnuPoli.ResumeLayout(false);
            this.mnuPoli.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelDokter.ResumeLayout(false);
            this.panelDokter.PerformLayout();
            this.panelPoli.ResumeLayout(false);
            this.panelPoli.PerformLayout();
            this.panelObat.ResumeLayout(false);
            this.panelObat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPoli;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laporanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem akunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataPasienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataDokterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataPoliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataObatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendaftaranToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pemeriksaanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rekamMedisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pembayaranToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laporanPasienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laporanDokteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laporanPembayaranToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSelamat;
        private System.Windows.Forms.Label lblJam;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Label lblNamaUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblJumlahPasien;
        private System.Windows.Forms.Label lblTextPasien;
        private System.Windows.Forms.Panel panelDokter;
        private System.Windows.Forms.Label lblJumlahDokter;
        private System.Windows.Forms.Label lbldk;
        private System.Windows.Forms.Panel panelPoli;
        private System.Windows.Forms.Label lblJumlahPoli;
        private System.Windows.Forms.Label lblpl;
        private System.Windows.Forms.Panel panelObat;
        private System.Windows.Forms.Label lblJumlahObat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem resepToolStripMenuItem;
    }
}