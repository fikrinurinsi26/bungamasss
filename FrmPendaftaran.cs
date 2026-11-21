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
namespace SIMRS
{
    public partial class FrmPendaftaran : Form
    {
        // Koneksi Database
        private KoneksiDatabase db = new KoneksiDatabase();

        // Menyimpan ID Pendaftaran
        private int idPendaftaran = 0;
        public FrmPendaftaran()
        {
            InitializeComponent();
        }

        private void FrmPendaftaran_Load(object sender, EventArgs e)
        {
            LoadPasien();
            LoadPoli();
            LoadDokter();
            LoadStatus();

            GenerateNoPendaftaran();
            Bersih();
            TampilData();
        }
        private void LoadStatus()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Menunggu");
            cmbStatus.Items.Add("Pemeriksaan");
            cmbStatus.Items.Add("Selesai");

            cmbStatus.SelectedIndex = 0;
        }
        private void LoadPasien()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT
                           id_pasien,
                           nama_lengkap
                           FROM pasien
                           ORDER BY nama_lengkap";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    cmbPasien.DataSource = dt;
                    cmbPasien.DisplayMember = "nama_lengkap";
                    cmbPasien.ValueMember = "id_pasien";
                    cmbPasien.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadPoli()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT
                           poli_id,
                           nama_poli
                           FROM poli
                           ORDER BY nama_poli";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    cmbPoli.DataSource = dt;
                    cmbPoli.DisplayMember = "nama_poli";
                    cmbPoli.ValueMember = "poli_id";
                    cmbPoli.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadDokter()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT
                           id_dokter,
                           nama_lengkap
                           FROM dokter
                           ORDER BY nama_lengkap";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    cmbDokter.DataSource = dt;
                    cmbDokter.DisplayMember = "nama_lengkap";
                    cmbDokter.ValueMember = "id_dokter";
                    cmbDokter.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GenerateNoPendaftaran()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = "SELECT MAX(nomor_pendaftaran) FROM pendaftaran";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    object hasil = cmd.ExecuteScalar();

                    if (hasil != null && hasil != DBNull.Value)
                    {
                        string kode = hasil.ToString();

                        // PD-001 -> 001
                        int nomor = Convert.ToInt32(kode.Substring(3));

                        nomor++;

                        txtNoDaftar.Text = "PD-" + nomor.ToString("D3");
                    }
                    else
                    {
                        txtNoDaftar.Text = "PD-001";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int GetStatusValue()
        {
            switch (cmbStatus.Text)
            {
                case "Menunggu":
                    return 0;

                case "Pemeriksaan":
                    return 1;

                case "Selesai":
                    return 2;

                default:
                    return 0;
            }
        }
        private void Bersih()
        {
            idPendaftaran = 0;

            GenerateNoPendaftaran();

            cmbPasien.SelectedIndex = -1;
            cmbDokter.SelectedIndex = -1;
            cmbPoli.SelectedIndex = -1;

            txtKeluhan.Clear();
            txtCari.Clear();

            cmbStatus.SelectedIndex = 0;

            dtpTanggal.Value = DateTime.Now;
            dtpTanggalKunjungan.Value = DateTime.Now;

            cmbPasien.Focus();
        }
        private void TampilData()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT
                            p.id_pendaftaran,
                            p.nomor_pendaftaran,
                            ps.nama_lengkap,
                            d.nama_lengkap,
                            pl.nama_poli,
                            p.tanggal_pendaftaran,
                            p.tanggal_kunjungan,
                            p.keluhan,
                            CASE
    WHEN p.status_pendaftaran = 0 THEN 'Menunggu'
    WHEN p.status_pendaftaran = 1 THEN 'Pemeriksaan'
    WHEN p.status_pendaftaran = 2 THEN 'Selesai'
    ELSE 'Menunggu'
                   END AS status_pendaftaran
                           FROM pendaftaran p
                           INNER JOIN pasien ps
                                ON p.id_pasien = ps.id_pasien
                           INNER JOIN dokter d
                                ON p.id_dokter = d.id_dokter
                           INNER JOIN poli pl
                                ON p.id_poli = pl.poli_id
                           ORDER BY p.id_pendaftaran ASC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvPendaftaran.DataSource = dt;

                    dgvPendaftaran.Columns[0].Visible = false;
                    dgvPendaftaran.Columns[1].HeaderText = "No. Daftar";
                    dgvPendaftaran.Columns[2].HeaderText = "Pasien";
                    dgvPendaftaran.Columns[3].HeaderText = "Dokter";
                    dgvPendaftaran.Columns[4].HeaderText = "Poli";
                    dgvPendaftaran.Columns[5].HeaderText = "Tgl Daftar";
                    dgvPendaftaran.Columns[6].HeaderText = "Tgl Kunjungan";
                    dgvPendaftaran.Columns[7].HeaderText = "Keluhan";
                    dgvPendaftaran.Columns[8].HeaderText = "Status";

                    dgvPendaftaran.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvPendaftaran.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvPendaftaran.MultiSelect = false;
                    dgvPendaftaran.ReadOnly = true;
                    dgvPendaftaran.AllowUserToAddRows = false;
                    dgvPendaftaran.AllowUserToDeleteRows = false;
                    dgvPendaftaran.RowHeadersVisible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SimpanData()
        {
            if (cmbPasien.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih pasien terlebih dahulu!");
                cmbPasien.Focus();
                return;
            }

            if (cmbPoli.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih poli terlebih dahulu!");
                cmbPoli.Focus();
                return;
            }

            if (cmbDokter.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih dokter terlebih dahulu!");
                cmbDokter.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO pendaftaran
                        (
                            nomor_pendaftaran,
                            id_pasien,
                            id_dokter,
                            id_poli,
                            tanggal_pendaftaran,
                            tanggal_kunjungan,
                            keluhan,
                            status_pendaftaran
                        )
                        VALUES
                        (
                            @nomor,
                            @pasien,
                            @dokter,
                            @poli,
                            @tglDaftar,
                            @tglKunjungan,
                            @keluhan,
                            @status
                        )";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@nomor", txtNoDaftar.Text);
                    cmd.Parameters.AddWithValue("@pasien", cmbPasien.SelectedValue);
                    cmd.Parameters.AddWithValue("@dokter", cmbDokter.SelectedValue);
                    cmd.Parameters.AddWithValue("@poli", cmbPoli.SelectedValue);
                    cmd.Parameters.AddWithValue("@tglDaftar", dtpTanggal.Value.Date);
                    cmd.Parameters.AddWithValue("@tglKunjungan", dtpTanggalKunjungan.Value.Date);
                    cmd.Parameters.AddWithValue("@keluhan", txtKeluhan.Text);
                    cmd.Parameters.AddWithValue("@status", GetStatusValue());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data pendaftaran berhasil disimpan.");

                    Bersih();
                    TampilData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UbahData()
        {
            if (idPendaftaran == 0)
            {
                MessageBox.Show("Pilih data yang akan diubah!");
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"UPDATE pendaftaran SET

                            id_pasien=@pasien,
                            id_dokter=@dokter,
                            id_poli=@poli,
                            tanggal_pendaftaran=@tglDaftar,
                            tanggal_kunjungan=@tglKunjungan,
                            keluhan=@keluhan,
                            status_pendaftaran=@status

                           WHERE id_pendaftaran=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@pasien", cmbPasien.SelectedValue);
                    cmd.Parameters.AddWithValue("@dokter", cmbDokter.SelectedValue);
                    cmd.Parameters.AddWithValue("@poli", cmbPoli.SelectedValue);
                    cmd.Parameters.AddWithValue("@tglDaftar", dtpTanggal.Value.Date);
                    cmd.Parameters.AddWithValue("@tglKunjungan", dtpTanggalKunjungan.Value.Date);
                    cmd.Parameters.AddWithValue("@keluhan", txtKeluhan.Text);
                    cmd.Parameters.AddWithValue("@status", GetStatusValue());

                    cmd.Parameters.AddWithValue("@id", idPendaftaran);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil diubah.");

                    Bersih();
                    TampilData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CariData()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT
                            p.id_pendaftaran,
                            p.nomor_pendaftaran,
                            ps.nama_lengkap,
                            d.nama_lengkap,
                            pl.nama_poli,
                            p.tanggal_pendaftaran,
                            p.tanggal_kunjungan,
                            p.keluhan,
                            CASE 
    WHEN p.status_pendaftaran = 0 THEN 'Menunggu'
    WHEN p.status_pendaftaran = 1 THEN 'Pemeriksaan'
    WHEN p.status_pendaftaran = 2 THEN 'Selesai'
    ELSE 'Menunggu'
END AS status_pendaftaran
                           FROM pendaftaran p
                           INNER JOIN pasien ps
                                ON p.id_pasien = ps.id_pasien
                           INNER JOIN dokter d
                                ON p.id_dokter = d.id_dokter
                           INNER JOIN poli pl
                                ON p.id_poli = pl.poli_id
                           WHERE
                                p.nomor_pendaftaran LIKE @cari
                                OR ps.nama_lengkap LIKE @cari
                                OR d.nama_lengkap LIKE @cari
                                OR pl.nama_poli LIKE @cari
                           ORDER BY p.id_pendaftaran ASC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    da.SelectCommand.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvPendaftaran.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HapusData()
        {
            if (idPendaftaran == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus!");
                return;
            }

            DialogResult hasil = MessageBox.Show(
                "Yakin ingin menghapus data ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (hasil == DialogResult.No)
                return;

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = "DELETE FROM pendaftaran WHERE id_pendaftaran=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", idPendaftaran);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil dihapus.");

                    Bersih();
                    TampilData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSimpan_Click(object sender, EventArgs e)
        {
            SimpanData();
        }

        private void dgvPendaftaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPendaftaran.Rows[e.RowIndex];

                idPendaftaran = Convert.ToInt32(row.Cells[0].Value);

                txtNoDaftar.Text = row.Cells[1].Value.ToString();

                cmbPasien.Text = row.Cells[2].Value.ToString();

                cmbDokter.Text = row.Cells[3].Value.ToString();

                cmbPoli.Text = row.Cells[4].Value.ToString();

                dtpTanggal.Value =
                    Convert.ToDateTime(row.Cells[5].Value);

                dtpTanggalKunjungan.Value =
                    Convert.ToDateTime(row.Cells[6].Value);

                txtKeluhan.Text = row.Cells[7].Value.ToString();

                cmbStatus.Text = row.Cells[8].Value.ToString();
            }
        
    }


        private void btnUbah_Click(object sender, EventArgs e)
        {
            UbahData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            HapusData();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            CariData();
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
            this.Close();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
