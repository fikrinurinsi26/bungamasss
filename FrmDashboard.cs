using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SIMRS
{
    public partial class FrmDashboard : Form
    {
        // Koneksi Database
        private KoneksiDatabase db = new KoneksiDatabase();

        // Menyimpan nama lengkap user yang login
        private string full_name;

        // Constructor untuk menerima full_name dari Login
        public FrmDashboard(string nama)
        {
            InitializeComponent();
            full_name = nama;
        }

        public FrmDashboard()
        {
            InitializeComponent();
        }

        // Saat Dashboard dibuka
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();

            // Menampilkan nama lengkap user yang login
            lblNamaUser.Text = full_name;

            // Menampilkan jumlah data
            HitungJumlahData();
        }

        // Timer berjalan setiap 1 detik
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTanggal.Text = "Tanggal : " + DateTime.Now.ToString("dddd, dd MMMM yyyy");
            lblJam.Text = "Jam : " + DateTime.Now.ToString("HH:mm:ss");
        }

        // Menghitung jumlah data
        private void HitungJumlahData()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Jumlah Pasien
                    MySqlCommand cmdPasien = new MySqlCommand("SELECT COUNT(*) FROM pasien", conn);
                    lblJumlahPasien.Text = cmdPasien.ExecuteScalar().ToString();

                    // Jumlah Dokter
                    MySqlCommand cmdDokter = new MySqlCommand("SELECT COUNT(*) FROM dokter", conn);
                    lblJumlahDokter.Text = cmdDokter.ExecuteScalar().ToString();

                    // Jumlah Poli
                    MySqlCommand cmdPoli = new MySqlCommand("SELECT COUNT(*) FROM poli", conn);
                    lblJumlahPoli.Text = cmdPoli.ExecuteScalar().ToString();

                    // Jumlah Obat
                    MySqlCommand cmdObat = new MySqlCommand("SELECT COUNT(*) FROM obat", conn);
                    lblJumlahObat.Text = cmdObat.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengambil data.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTanggal_Click(object sender, EventArgs e)
        {

        }

        private void lblNamaUser_Click(object sender, EventArgs e)
        {

        }

        private void mnuPoli_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void dataPoliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPoli frm = new FrmPoli();
            frm.ShowDialog();
        }

        private void dataDokterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDokter frm = new FrmDokter();
            frm.ShowDialog();
        }

        private void dataObatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmObat frm = new FrmObat();
            frm.ShowDialog();
        }

        private void dataPasienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPasien frm = new FrmPasien();
            frm.ShowDialog();
        }

        private void pendaftaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPendaftaran frm = new FrmPendaftaran();
            frm.ShowDialog();
        }

        private void rekamMedisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRekamMedis frm = new FrmRekamMedis();
            frm.ShowDialog();
        }

        private void pembayaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPembayaran frm = new FrmPembayaran();
            frm.ShowDialog();
        }

        private void pemeriksaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
          FrmPemeriksaan frm = new FrmPemeriksaan();
            frm.ShowDialog();
        }

        private void resepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResep frm = new FrmResep();
            frm.ShowDialog();
        }

        private void laporanPasienToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void laporanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}