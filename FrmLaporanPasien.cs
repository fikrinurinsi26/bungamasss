
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SIMRS
{
    public partial class FrmLaporanPasien : Form
    {
        private string connectionString =
            "server=localhost;database=db_rumah_sakit;uid=root;pwd=;";

        private PrintDocument printDocument = new PrintDocument();
        private int nomorBarisCetak = 0;

        public FrmLaporanPasien()
        {
            InitializeComponent();

            btnTampilkan.Click -= btnTampilkan_Click;
            btnTampilkan.Click += btnTampilkan_Click;

            btnReset.Click -= btnReset_Click;
            btnReset.Click += btnReset_Click;

            btnCetakPDF.Click -= btnCetakPDF_Click;
            btnCetakPDF.Click += btnCetakPDF_Click;

            btnKembali.Click -= btnKembali_Click;
            btnKembali.Click += btnKembali_Click;

            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.PrintPage += printDocument_PrintPage;

            this.Load -= FrmLaporanPasien_Load;
            this.Load += FrmLaporanPasien_Load;
        }

        // =========================================
        // LOAD FORM
        // =========================================
        private void FrmLaporanPasien_Load(object sender, EventArgs e)
        {
            // Ambil seluruh data dari tahun 2000 sampai hari ini
            dtpTanggalMulai.Value = new DateTime(2000, 1, 1);
            dtpTanggalAkhir.Value = DateTime.Today;

            dgvLaporanPasien.AutoGenerateColumns = true;
            dgvLaporanPasien.ReadOnly = true;
            dgvLaporanPasien.AllowUserToAddRows = false;
            dgvLaporanPasien.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvLaporanPasien.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvLaporanPasien.RowHeadersVisible = false;

            LoadPoli();
            TampilkanLaporan();
        }

        // =========================================
        // LOAD DATA POLI
        // =========================================
        private void LoadPoli()
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT nama_poli
                        FROM poli
                        WHERE is_active = 1
                        ORDER BY nama_poli";

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbPoli.Items.Clear();
                    cmbPoli.Items.Add("Semua Poli");

                    foreach (DataRow row in dt.Rows)
                    {
                        cmbPoli.Items.Add(
                            row["nama_poli"].ToString());
                    }

                    cmbPoli.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data poli: " + ex.Message,
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // =========================================
        // TAMPILKAN LAPORAN
        // =========================================
        private void TampilkanLaporan()
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            id_pendaftaran,
                            nomor_pendaftaran,
                            nomor_rekam_medis,
                            nama_pasien,
                            tanggal_pendaftaran,
                            tanggal_kunjungan,
                            nama_poli,
                            nama_dokter,
                            keluhan,
                            status_pendaftaran
                        FROM vw_laporan_pasien
                        WHERE tanggal_kunjungan >= @mulai
                        AND tanggal_kunjungan < @akhirBesok
                    ";

                    if (cmbPoli.SelectedIndex > 0)
                    {
                        query += " AND nama_poli = @poli";
                    }

                    query += " ORDER BY tanggal_kunjungan DESC";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@mulai",
                        dtpTanggalMulai.Value.Date);

                    cmd.Parameters.AddWithValue(
                        "@akhirBesok",
                        dtpTanggalAkhir.Value.Date.AddDays(1));

                    if (cmbPoli.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue(
                            "@poli",
                            cmbPoli.Text);
                    }

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvLaporanPasien.DataSource = dt;

                    // =================================
                    // JUDUL KOLOM
                    // =================================

                    if (dgvLaporanPasien.Columns.Contains("id_pendaftaran"))
                        dgvLaporanPasien.Columns["id_pendaftaran"].HeaderText =
                            "ID Pendaftaran";

                    if (dgvLaporanPasien.Columns.Contains("nomor_pendaftaran"))
                        dgvLaporanPasien.Columns["nomor_pendaftaran"].HeaderText =
                            "Nomor Pendaftaran";

                    if (dgvLaporanPasien.Columns.Contains("nomor_rekam_medis"))
                        dgvLaporanPasien.Columns["nomor_rekam_medis"].HeaderText =
                            "No. Rekam Medis";

                    if (dgvLaporanPasien.Columns.Contains("nama_pasien"))
                        dgvLaporanPasien.Columns["nama_pasien"].HeaderText =
                            "Nama Pasien";

                    if (dgvLaporanPasien.Columns.Contains("tanggal_pendaftaran"))
                        dgvLaporanPasien.Columns["tanggal_pendaftaran"].HeaderText =
                            "Tanggal Pendaftaran";

                    if (dgvLaporanPasien.Columns.Contains("tanggal_kunjungan"))
                        dgvLaporanPasien.Columns["tanggal_kunjungan"].HeaderText =
                            "Tanggal Kunjungan";

                    if (dgvLaporanPasien.Columns.Contains("nama_poli"))
                        dgvLaporanPasien.Columns["nama_poli"].HeaderText =
                            "Poli";

                    if (dgvLaporanPasien.Columns.Contains("nama_dokter"))
                        dgvLaporanPasien.Columns["nama_dokter"].HeaderText =
                            "Dokter";

                    if (dgvLaporanPasien.Columns.Contains("keluhan"))
                        dgvLaporanPasien.Columns["keluhan"].HeaderText =
                            "Keluhan";

                    if (dgvLaporanPasien.Columns.Contains("status_pendaftaran"))
                        dgvLaporanPasien.Columns["status_pendaftaran"].HeaderText =
                            "Status";

                    // =================================
                    // JUMLAH DATA
                    // =================================

                    MessageBox.Show(
                        "Laporan berhasil dimuat.\n\n" +
                        "Jumlah data pendaftaran: " + dt.Rows.Count,
                        "Informasi Laporan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan laporan:\n" + ex.Message,
                    "Kesalahan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // TOMBOL TAMPILKAN
        // =========================================
        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            if (dtpTanggalMulai.Value.Date >
                dtpTanggalAkhir.Value.Date)
            {
                MessageBox.Show(
                    "Tanggal mulai tidak boleh melebihi tanggal akhir.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TampilkanLaporan();
        }

        // =========================================
        // TOMBOL RESET
        // =========================================
        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpTanggalMulai.Value = new DateTime(2000, 1, 1);
            dtpTanggalAkhir.Value = DateTime.Today;

            if (cmbPoli.Items.Count > 0)
            {
                cmbPoli.SelectedIndex = 0;
            }

            TampilkanLaporan();
        }

        // =========================================
        // TOMBOL KEMBALI
        // =========================================
        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================================
        // TOMBOL CETAK PDF
        // =========================================
        private void btnCetakPDF_Click(object sender, EventArgs e)
        {
            if (dgvLaporanPasien.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Tidak ada data yang dapat dicetak.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (PrintDialog dialog = new PrintDialog())
            {
                dialog.Document = printDocument;
                dialog.AllowSomePages = false;
                dialog.UseEXDialog = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        nomorBarisCetak = 0;
                        printDocument.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Gagal mencetak laporan: " + ex.Message,
                            "Kesalahan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =========================================
        // PROSES CETAK LAPORAN
        // =========================================
        private void printDocument_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Font fontJudul =
                new Font("Arial", 16, FontStyle.Bold))
            using (Font fontSubjudul =
                new Font("Arial", 9, FontStyle.Regular))
            using (Font fontHeader =
                new Font("Arial", 8, FontStyle.Bold))
            using (Font fontIsi =
                new Font("Arial", 8, FontStyle.Regular))
            using (StringFormat format =
                new StringFormat())
            {
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;
                float lebar = e.MarginBounds.Width;

                // JUDUL
                string judul = "LAPORAN DATA PASIEN";

                SizeF ukuranJudul =
                    g.MeasureString(judul, fontJudul);

                g.DrawString(
                    judul,
                    fontJudul,
                    Brushes.Black,
                    x + (lebar - ukuranJudul.Width) / 2,
                    y);

                y += 35;

                // PERIODE
                g.DrawString(
                    "Periode: " +
                    dtpTanggalMulai.Value.ToString("dd-MM-yyyy") +
                    " s/d " +
                    dtpTanggalAkhir.Value.ToString("dd-MM-yyyy"),
                    fontSubjudul,
                    Brushes.Black,
                    x,
                    y);

                y += 20;

                g.DrawString(
                    "Poli: " + cmbPoli.Text,
                    fontSubjudul,
                    Brushes.Black,
                    x,
                    y);

                y += 25;

                DataGridView grid = dgvLaporanPasien;

                int jumlahKolom = 0;

                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (col.Visible)
                        jumlahKolom++;
                }

                if (jumlahKolom == 0)
                {
                    e.HasMorePages = false;
                    return;
                }

                float lebarKolom = lebar / jumlahKolom;
                float tinggiHeader = 35;
                float tinggiBaris = 35;

                // HEADER TABEL
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (!col.Visible)
                        continue;

                    RectangleF kotak = new RectangleF(
                        x,
                        y,
                        lebarKolom,
                        tinggiHeader);

                    g.FillRectangle(
                        Brushes.LightGray,
                        kotak);

                    g.DrawRectangle(
                        Pens.Black,
                        kotak.X,
                        kotak.Y,
                        kotak.Width,
                        kotak.Height);

                    g.DrawString(
                        col.HeaderText,
                        fontHeader,
                        Brushes.Black,
                        kotak);

                    x += lebarKolom;
                }

                y += tinggiHeader;
                x = e.MarginBounds.Left;

                // ISI TABEL
                while (nomorBarisCetak < grid.Rows.Count)
                {
                    DataGridViewRow row =
                        grid.Rows[nomorBarisCetak];

                    if (row.IsNewRow)
                    {
                        nomorBarisCetak++;
                        continue;
                    }

                    if (y + tinggiBaris > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    foreach (DataGridViewColumn col in grid.Columns)
                    {
                        if (!col.Visible)
                            continue;

                        RectangleF kotak = new RectangleF(
                            x,
                            y,
                            lebarKolom,
                            tinggiBaris);

                        g.DrawRectangle(
                            Pens.Black,
                            kotak.X,
                            kotak.Y,
                            kotak.Width,
                            kotak.Height);

                        string isi = "";

                        if (row.Cells[col.Index].Value != null)
                        {
                            isi = row.Cells[col.Index].Value.ToString();
                        }

                        format.Trimming =
                            StringTrimming.EllipsisCharacter;

                        format.Alignment =
                            StringAlignment.Near;

                        format.LineAlignment =
                            StringAlignment.Center;

                        g.DrawString(
                            isi,
                            fontIsi,
                            Brushes.Black,
                            kotak,
                            format);

                        x += lebarKolom;
                    }

                    y += tinggiBaris;
                    x = e.MarginBounds.Left;

                    nomorBarisCetak++;
                }

                e.HasMorePages = false;
                nomorBarisCetak = 0;
            }
        }

        // =========================================
        // EVENT LABEL LAMA
        // =========================================
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
