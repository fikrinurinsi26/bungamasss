    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;
    using System.Globalization;
    namespace SIMRS
    {

        public partial class FrmPembayaran : Form
        {

            private KoneksiDatabase db = new KoneksiDatabase();
            private int idPembayaran = 0;
            private bool sedangMenghitung = false;
            public FrmPembayaran()
            {
                InitializeComponent();
            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void FrmPembayaran_Load(object sender, EventArgs e)
            {
                txtPasien.ReadOnly = true;
                txtPoli.ReadOnly = true;
                txtDokter.ReadOnly = true;
                txtTotal.ReadOnly = true;

                LoadPendaftaran();
                LoadMetode();
                LoadStatus();

                Bersih();
                TampilData();
            }
            private void LoadPendaftaran()
            {
                try
                {
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string sql = @"
                            SELECT 
                                p.id_pendaftaran,
                                p.nomor_pendaftaran,
                                ps.nama_lengkap AS pasien,
                                pl.nama_poli AS poli,
                                d.nama_lengkap AS dokter
                            FROM pendaftaran p
                            INNER JOIN pasien ps
                                ON p.id_pasien = ps.id_pasien
                            INNER JOIN poli pl
                                ON p.id_poli = pl.poli_id
                            INNER JOIN dokter d
                                ON p.id_dokter = d.id_dokter
                            ORDER BY p.id_pendaftaran DESC";

                        MySqlDataAdapter da =
                            new MySqlDataAdapter(sql, conn);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbPendaftaran.DataSource = dt;
                        cmbPendaftaran.DisplayMember = "nomor_pendaftaran";
                        cmbPendaftaran.ValueMember = "id_pendaftaran";
                        cmbPendaftaran.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // =========================
            // LOAD METODE
            // =========================
            private void LoadMetode()
            {
                cmbMetode.Items.Clear();

                cmbMetode.Items.Add("Tunai");
                cmbMetode.Items.Add("Debit");
                cmbMetode.Items.Add("Transfer");
                cmbMetode.Items.Add("QRIS");

                cmbMetode.SelectedIndex = 0;
            }

            // =========================
            // LOAD STATUS
            // =========================
            private void LoadStatus()
            {
                cmbStatus.Items.Clear();

                cmbStatus.Items.Add("Belum Bayar");
                cmbStatus.Items.Add("Lunas");

                cmbStatus.SelectedIndex = 0;
            }

            // =========================
            // NOMOR PEMBAYARAN
            // =========================
            private void GenerateNoPembayaran()
            {
                try
                {
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string sql =
                            "SELECT MAX(nomor_pembayaran) FROM pembayaran";

                        MySqlCommand cmd =
                            new MySqlCommand(sql, conn);

                        object hasil = cmd.ExecuteScalar();

                        if (hasil != null && hasil != DBNull.Value)
                        {
                            string kode = hasil.ToString();

                            int nomor =
                                Convert.ToInt32(kode.Substring(4));

                            nomor++;

                            txtNoPembayaran.Text =
                                "BYR-" + nomor.ToString("D3");
                        }
                        else
                        {
                            txtNoPembayaran.Text = "BYR-001";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // =========================
            // BERSIH
            // =========================
            private void Bersih()
            {
            idPembayaran = 0; GenerateNoPembayaran();
            cmbPendaftaran.SelectedIndex = -1;
            txtPasien.Clear(); txtPoli.Clear();
            txtDokter.Clear();
           
             txtBiayaKonsultasi.Clear();
            txtBiayaObat.Clear();
            txtBiayaLainnya.Clear();
             txtTotal.Clear(); cmbMetode.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            dtpTanggalPembayaran.Value = DateTime.Now;
            cmbPendaftaran.Focus();
        }
       

            // =========================
            // HITUNG TOTAL
            // =========================
            private void HitungTotal()
        {
            if (sedangMenghitung)
                return;

            sedangMenghitung = true;

            try
            {
                if (string.IsNullOrWhiteSpace(txtBiayaKonsultasi.Text) &&
                    string.IsNullOrWhiteSpace(txtBiayaObat.Text) &&
                    string.IsNullOrWhiteSpace(txtBiayaLainnya.Text))
                {
                    txtTotal.Clear();
                    return;
                }

                decimal konsultasi = AmbilAngka(txtBiayaKonsultasi.Text);
                decimal obat = AmbilAngka(txtBiayaObat.Text);
                decimal lainnya = AmbilAngka(txtBiayaLainnya.Text);

                decimal total = konsultasi + obat + lainnya;

                txtTotal.Text = FormatRupiah(total);
            }
            finally
            {
                sedangMenghitung = false;
            }
        }
            private decimal AmbilAngka(string teks)
            {
                if (string.IsNullOrWhiteSpace(teks))
                    return 0;

                // Hapus titik pemisah ribuan
                teks = teks.Replace(".", "");

                decimal hasil;

                if (decimal.TryParse(teks, out hasil))
                    return hasil;

                return 0;
            }

            private string FormatRupiah(decimal angka)
            {
                return angka.ToString("#,##0", new CultureInfo("id-ID"));
            }
            private void CariData()
            {
                try
                {
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string keyword = txtCari.Text.Trim();

                        string sql = @"
                    SELECT
                        pb.id_pembayaran,
                        pb.nomor_pembayaran,
                        pd.nomor_pendaftaran,
                        ps.nama_lengkap,
                        pl.nama_poli,
                        pb.tanggal_pembayaran,
                        pb.biaya_konsultasi,
                        pb.biaya_obat,
                        pb.biaya_lainnya,
                        pb.total_biaya,
                        pb.metode_pembayaran,
                        pb.status_pembayaran
                    FROM pembayaran pb
                    INNER JOIN pendaftaran pd
                        ON pb.id_pendaftaran = pd.id_pendaftaran
                    INNER JOIN pasien ps
                        ON pd.id_pasien = ps.id_pasien
                    INNER JOIN poli pl
                        ON pd.id_poli = pl.poli_id
                    WHERE
                        pb.nomor_pembayaran LIKE @cari
                        OR pd.nomor_pendaftaran LIKE @cari
                        OR ps.nama_lengkap LIKE @cari
                        OR pl.nama_poli LIKE @cari
                        OR pb.metode_pembayaran LIKE @cari
                        OR pb.status_pembayaran LIKE @cari
                    ORDER BY pb.id_pembayaran ASC";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@cari", "%" + keyword + "%");

                            MySqlDataAdapter da =
                                new MySqlDataAdapter(cmd);

                            DataTable dt = new DataTable();

                            da.Fill(dt);

                            dgvPembayaran.DataSource = dt;

                            AturGridPembayaran();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal mencari data pembayaran.\n\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            private void AturGridPembayaran()
            {
                if (dgvPembayaran.Columns.Count == 0)
                    return;

                // Sembunyikan ID Pembayaran
                if (dgvPembayaran.Columns.Contains("id_pembayaran"))
                    dgvPembayaran.Columns["id_pembayaran"].Visible = false;

                // Header
                if (dgvPembayaran.Columns.Contains("nomor_pembayaran"))
                    dgvPembayaran.Columns["nomor_pembayaran"].HeaderText = "No. Pembayaran";

                if (dgvPembayaran.Columns.Contains("nomor_pendaftaran"))
                    dgvPembayaran.Columns["nomor_pendaftaran"].HeaderText = "No. Pendaftaran";

                if (dgvPembayaran.Columns.Contains("nama_lengkap"))
                    dgvPembayaran.Columns["nama_lengkap"].HeaderText = "Pasien";

                if (dgvPembayaran.Columns.Contains("nama_poli"))
                    dgvPembayaran.Columns["nama_poli"].HeaderText = "Poli";

                if (dgvPembayaran.Columns.Contains("tanggal_pembayaran"))
                    dgvPembayaran.Columns["tanggal_pembayaran"].HeaderText = "Tanggal";

                if (dgvPembayaran.Columns.Contains("biaya_konsultasi"))
                    dgvPembayaran.Columns["biaya_konsultasi"].HeaderText = "Konsultasi";

                if (dgvPembayaran.Columns.Contains("biaya_obat"))
                    dgvPembayaran.Columns["biaya_obat"].HeaderText = "Obat";

                if (dgvPembayaran.Columns.Contains("biaya_lainnya"))
                    dgvPembayaran.Columns["biaya_lainnya"].HeaderText = "Lainnya";

                if (dgvPembayaran.Columns.Contains("total_biaya"))
                    dgvPembayaran.Columns["total_biaya"].HeaderText = "Total";

                if (dgvPembayaran.Columns.Contains("metode_pembayaran"))
                    dgvPembayaran.Columns["metode_pembayaran"].HeaderText = "Metode";

                if (dgvPembayaran.Columns.Contains("status_pembayaran"))
                    dgvPembayaran.Columns["status_pembayaran"].HeaderText = "Status";


                // =========================
                // FORMAT TANGGAL
                // =========================

                if (dgvPembayaran.Columns.Contains("tanggal_pembayaran"))
                {
                    dgvPembayaran.Columns["tanggal_pembayaran"]
                        .DefaultCellStyle.Format = "dd-MM-yyyy";
                }


                // =========================
                // FORMAT UANG
                // =========================

                if (dgvPembayaran.Columns.Contains("biaya_konsultasi"))
                {
                    dgvPembayaran.Columns["biaya_konsultasi"]
                        .DefaultCellStyle.Format = "#,##0";
                }

                if (dgvPembayaran.Columns.Contains("biaya_obat"))
                {
                    dgvPembayaran.Columns["biaya_obat"]
                        .DefaultCellStyle.Format = "#,##0";
                }

                if (dgvPembayaran.Columns.Contains("biaya_lainnya"))
                {
                    dgvPembayaran.Columns["biaya_lainnya"]
                        .DefaultCellStyle.Format = "#,##0";
                }

                if (dgvPembayaran.Columns.Contains("total_biaya"))
                {
                    dgvPembayaran.Columns["total_biaya"]
                        .DefaultCellStyle.Format = "#,##0";
                }


                // =========================
                // RATA KANAN ANGKA
                // =========================

                if (dgvPembayaran.Columns.Contains("biaya_konsultasi"))
                {
                    dgvPembayaran.Columns["biaya_konsultasi"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvPembayaran.Columns.Contains("biaya_obat"))
                {
                    dgvPembayaran.Columns["biaya_obat"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvPembayaran.Columns.Contains("biaya_lainnya"))
                {
                    dgvPembayaran.Columns["biaya_lainnya"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvPembayaran.Columns.Contains("total_biaya"))
                {
                    dgvPembayaran.Columns["total_biaya"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }


                // =========================
                // SETTING GRID
                // =========================

                dgvPembayaran.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvPembayaran.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvPembayaran.MultiSelect = false;

                dgvPembayaran.ReadOnly = true;

                dgvPembayaran.AllowUserToAddRows = false;

                dgvPembayaran.AllowUserToDeleteRows = false;

                dgvPembayaran.RowHeadersVisible = false;
            }

            // =========================
            // SIMPAN
            // =========================
            private void SimpanData()
            {
                if (cmbPendaftaran.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Pilih pendaftaran terlebih dahulu!");

                    cmbPendaftaran.Focus();
                    return;
                }

                HitungTotal();

                try
                {
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string sql = @"
                            INSERT INTO pembayaran
                            (
                                id_pendaftaran,
                                nomor_pembayaran,
                                tanggal_pembayaran,
                                biaya_konsultasi,
                                biaya_obat,
                                biaya_lainnya,
                                total_biaya,
                                metode_pembayaran,
                                status_pembayaran
                            )
                            VALUES
                            (
                                @pendaftaran,
                                @nomor,
                                @tanggal,
                                @konsultasi,
                                @obat,
                                @lainnya,
                                @total,
                                @metode,
                                @status
                            )";

                        MySqlCommand cmd =
                            new MySqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue(
                            "@pendaftaran",
                            cmbPendaftaran.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@nomor",
                            txtNoPembayaran.Text);

                        cmd.Parameters.AddWithValue(
                            "@tanggal",
                            dtpTanggalPembayaran.Value);
                        cmd.Parameters.AddWithValue(
                            "@konsultasi",
                            AmbilAngka(txtBiayaKonsultasi.Text));

                        cmd.Parameters.AddWithValue(
                            "@obat",
                            AmbilAngka(txtBiayaObat.Text));

                        cmd.Parameters.AddWithValue(
                            "@lainnya",
                            AmbilAngka(txtBiayaLainnya.Text));

                        cmd.Parameters.AddWithValue(
                            "@total",
                            AmbilAngka(txtTotal.Text));

                        cmd.Parameters.AddWithValue(
                            "@metode",
                            cmbMetode.Text);

                        cmd.Parameters.AddWithValue(
                            "@status",
                            cmbStatus.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show(
                            "Data pembayaran berhasil disimpan.");

                        Bersih();
                        TampilData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // =========================
            // TAMPIL DATA
            // =========================
            private void TampilData()
            {
                try
                {
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string sql = @"
                    SELECT 
                        pb.id_pembayaran,
                        pb.nomor_pembayaran,
                        pd.nomor_pendaftaran,
                        ps.nama_lengkap,
                        pl.nama_poli,
                        pb.tanggal_pembayaran,
                        pb.biaya_konsultasi,
                        pb.biaya_obat,
                        pb.biaya_lainnya,
                        pb.total_biaya,
                        pb.metode_pembayaran,
                        pb.status_pembayaran
                    FROM pembayaran pb
                    INNER JOIN pendaftaran pd
                        ON pb.id_pendaftaran = pd.id_pendaftaran
                    INNER JOIN pasien ps
                        ON pd.id_pasien = ps.id_pasien
                    INNER JOIN poli pl
                        ON pd.id_poli = pl.poli_id
                    ORDER BY pb.id_pembayaran ASC";

                        MySqlDataAdapter da =
                            new MySqlDataAdapter(sql, conn);

                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        // WAJIB DataSource terlebih dahulu
                        dgvPembayaran.DataSource = dt;

                        // Setelah DataSource terisi baru atur Grid
                        AturGridPembayaran();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal menampilkan data pembayaran.\n\n" +
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            private void btnSimpan_Click(object sender, EventArgs e)
            {
                SimpanData();
            }

            private void btnBaru_Click(object sender, EventArgs e)
            {
                Bersih();
            }

            private void btnBatal_Click(object sender, EventArgs e)
            {
                Bersih();
            }

            private void btnTutup_Click(object sender, EventArgs e)
            {
                Close();
            }

            private void txtBiayaKonsultasi_TextChanged(object sender, EventArgs e)
            {
                HitungTotal();
            }

            private void txtBiayaObat_TextChanged(object sender, EventArgs e)
            {
                HitungTotal();
            }

            private void txtBiayaLainnya_TextChanged(object sender, EventArgs e)
            {
                HitungTotal();
            }

            private void cmbPendaftaran_SelectedIndexChanged_1(object sender, EventArgs e)
            {
                if (cmbPendaftaran.SelectedIndex < 0)
                    return;

                try
                {
                    if (cmbPendaftaran.SelectedValue == null)
                        return;

                    // Pastikan SelectedValue berupa ID
                    if (cmbPendaftaran.SelectedValue is DataRowView)
                        return;

                    int idPendaftaran = Convert.ToInt32(cmbPendaftaran.SelectedValue);

                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string sql = @"
                    SELECT
                        ps.nama_lengkap AS pasien,
                        pl.nama_poli AS poli,
                        d.nama_lengkap AS dokter
                    FROM pendaftaran p
                    INNER JOIN pasien ps
                        ON p.id_pasien = ps.id_pasien
                    INNER JOIN poli pl
                        ON p.id_poli = pl.poli_id
                    INNER JOIN dokter d
                        ON p.id_dokter = d.id_dokter
                    WHERE p.id_pendaftaran = @id";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idPendaftaran);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    txtPasien.Text = reader["pasien"].ToString();
                                    txtPoli.Text = reader["poli"].ToString();
                                    txtDokter.Text = reader["dokter"].ToString();
                                }
                                else
                                {
                                    txtPasien.Clear();
                                    txtPoli.Clear();
                                    txtDokter.Clear();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal mengambil data pendaftaran.\n\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            private void txtCari_TextChanged(object sender, EventArgs e)
            {
                CariData();
            }
        }
    }
