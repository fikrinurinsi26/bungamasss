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
    public partial class FrmPasien : Form
    {
        // Koneksi Database
        private KoneksiDatabase db = new KoneksiDatabase();

        // Menyimpan ID Pasien
        private int idPasien = 0;
        public FrmPasien()
        {
            InitializeComponent();
        }
        private void LoadStatusPernikahan()
        {
            cmbStatusPernikahan.Items.Clear();

            cmbStatusPernikahan.Items.Add("Belum Menikah");
            cmbStatusPernikahan.Items.Add("Menikah");
            cmbStatusPernikahan.Items.Add("Cerai");

            cmbStatusPernikahan.SelectedIndex = 0;
        }
        private void FrmPasien_Load(object sender, EventArgs e)
        {
            LoadJenisKelamin();
            LoadGolonganDarah();
            LoadAgama();
            LoadStatusPernikahan();
            LoadStatus();

            GenerateKodePasien();
            Bersih();
            TampilData();
        }
        private void TampilData()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT
        id_pasien,
        nomor_rekam_medis,
        nomor_identitas,
        nama_lengkap,
        jenis_kelamin,
        tempat_lahir,
        tanggal_lahir,
        alamat,
        nomor_telepon,
        golongan_darah,
        agama,
        status_pernikahan,
        pekerjaan
       FROM pasien
       ORDER BY id_pasien ASC";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);


                    dgvPasien.DataSource = dt;

                    dgvPasien.Columns[0].Visible = false;
                    dgvPasien.Columns[1].HeaderText = "No. RM";
                    dgvPasien.Columns[2].HeaderText = "NIK";
                    dgvPasien.Columns[3].HeaderText = "Nama";
                    dgvPasien.Columns[4].HeaderText = "JK";
                    dgvPasien.Columns[5].HeaderText = "Tempat Lahir";
                    dgvPasien.Columns[6].HeaderText = "Tanggal Lahir";
                    dgvPasien.Columns[7].HeaderText = "Alamat";
                    dgvPasien.Columns[8].HeaderText = "No HP";
                    dgvPasien.Columns[9].HeaderText = "Gol. Darah";
                    dgvPasien.Columns[10].HeaderText = "Agama";
                    dgvPasien.Columns[11].HeaderText = "Status";
                    dgvPasien.Columns[12].HeaderText = "Pekerjaan";
                    dgvPasien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvPasien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvPasien.MultiSelect = false;
                    dgvPasien.ReadOnly = true;
                    dgvPasien.AllowUserToAddRows = false;
                    dgvPasien.AllowUserToDeleteRows = false;
                    dgvPasien.RowHeadersVisible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Bersih()
        {
            idPasien = 0;

            GenerateKodePasien();

            txtNIK.Clear();
            txtNamaPasien.Clear();
            txtTempatLahir.Clear();
            txtAlamat.Clear();
            txtNoHP.Clear();
            txtPekerjaan.Clear();
            txtCari.Clear();

            cmbJenisKelamin.SelectedIndex = 0;
            cmbGolonganDarah.SelectedIndex = 0;
            cmbAgama.SelectedIndex = 0;
            cmbStatusPernikahan.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            dtpTanggalLahir.Value = DateTime.Now;

            txtNIK.Focus();
        }
        private void SimpanData()
        {
            if (txtNIK.Text == "")
            {
                MessageBox.Show("Nomor Identitas masih kosong!");
                txtNIK.Focus();
                return;
            }

            if (txtNamaPasien.Text == "")
            {
                MessageBox.Show("Nama Pasien masih kosong!");
                txtNamaPasien.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO pasien
            (
                nomor_rekam_medis,
                nomor_identitas,
                nama_lengkap,
                jenis_kelamin,
                tempat_lahir,
                tanggal_lahir,
                alamat,
                nomor_telepon,
                golongan_darah,
                agama,
                status_pernikahan,
                pekerjaan
            )
            VALUES
            (
                @rm,
                @nik,
                @nama,
                @jk,
                @tempat,
                @tgl,
                @alamat,
                @telp,
                @goldar,
                @agama,
                @status,
                @pekerjaan
            )";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@rm", txtKodePasien.Text);
                    cmd.Parameters.AddWithValue("@nik", txtNIK.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNamaPasien.Text);
                    cmd.Parameters.AddWithValue("@jk", cmbJenisKelamin.Text);
                    cmd.Parameters.AddWithValue("@tempat", txtTempatLahir.Text);
                    cmd.Parameters.AddWithValue("@tgl", dtpTanggalLahir.Value.Date);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@telp", txtNoHP.Text);
                    cmd.Parameters.AddWithValue("@goldar", cmbGolonganDarah.Text);
                    cmd.Parameters.AddWithValue("@agama", cmbAgama.Text);
                    cmd.Parameters.AddWithValue("@status", cmbStatusPernikahan.Text);
                    cmd.Parameters.AddWithValue("@pekerjaan", txtPekerjaan.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data pasien berhasil disimpan.");

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
            if (idPasien == 0)
            {
                MessageBox.Show("Pilih data yang akan diubah!");
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"UPDATE pasien SET
                    nomor_rekam_medis=@rm,
                    nomor_identitas=@nik,
                    nama_lengkap=@nama,
                    jenis_kelamin=@jk,
                    tempat_lahir=@tempat,
                    tanggal_lahir=@tgl,
                    alamat=@alamat,
                    nomor_telepon=@telp,
                    golongan_darah=@goldar,
                    agama=@agama,
                    status_pernikahan=@status,
                    pekerjaan=@pekerjaan
                   WHERE id_pasien=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@rm", txtKodePasien.Text);
                    cmd.Parameters.AddWithValue("@nik", txtNIK.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNamaPasien.Text);
                    cmd.Parameters.AddWithValue("@jk", cmbJenisKelamin.Text);
                    cmd.Parameters.AddWithValue("@tempat", txtTempatLahir.Text);
                    cmd.Parameters.AddWithValue("@tgl", dtpTanggalLahir.Value.Date);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@telp", txtNoHP.Text);
                    cmd.Parameters.AddWithValue("@goldar", cmbGolonganDarah.Text);
                    cmd.Parameters.AddWithValue("@agama", cmbAgama.Text);
                    cmd.Parameters.AddWithValue("@status", cmbStatusPernikahan.Text);
                    cmd.Parameters.AddWithValue("@pekerjaan", txtPekerjaan.Text);
                    cmd.Parameters.AddWithValue("@id", idPasien);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data pasien berhasil diubah.");

                    Bersih();
                    TampilData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HapusData()
        {
            if (idPasien == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus!");
                return;
            }

            DialogResult hasil = MessageBox.Show(
                "Yakin ingin menghapus data pasien ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (hasil == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string sql = "DELETE FROM pasien WHERE id_pasien=@id";

                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", idPasien);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data pasien berhasil dihapus.");

                        Bersih();
                        TampilData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
                            id_pasien,
                            nomor_rekam_medis,
                            nomor_identitas,
                            nama_lengkap,
                            jenis_kelamin,
                            tempat_lahir,
                            tanggal_lahir,
                            alamat,
                            nomor_telepon,
                            golongan_darah,
                            agama,
                            status_pernikahan,
                            pekerjaan
                           FROM pasien
                           WHERE
                           nomor_rekam_medis LIKE @cari OR
                           nomor_identitas LIKE @cari OR
                           nama_lengkap LIKE @cari
                           ORDER BY id_pasien ASC";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPasien.DataSource = dt;

                    dgvPasien.Columns[0].Visible = false;
                    dgvPasien.Columns[1].HeaderText = "No. RM";
                    dgvPasien.Columns[2].HeaderText = "NIK";
                    dgvPasien.Columns[3].HeaderText = "Nama";
                    dgvPasien.Columns[4].HeaderText = "JK";
                    dgvPasien.Columns[5].HeaderText = "Tempat Lahir";
                    dgvPasien.Columns[6].HeaderText = "Tanggal Lahir";
                    dgvPasien.Columns[7].HeaderText = "Alamat";
                    dgvPasien.Columns[8].HeaderText = "No HP";
                    dgvPasien.Columns[9].HeaderText = "Gol. Darah";
                    dgvPasien.Columns[10].HeaderText = "Agama";
                    dgvPasien.Columns[11].HeaderText = "Status";
                    dgvPasien.Columns[12].HeaderText = "Pekerjaan";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadAgama()
        {
            cmbAgama.Items.Clear();

            cmbAgama.Items.Add("Islam");
            cmbAgama.Items.Add("Kristen");
            cmbAgama.Items.Add("Katolik");
            cmbAgama.Items.Add("Hindu");
            cmbAgama.Items.Add("Buddha");
            cmbAgama.Items.Add("Konghucu");

            cmbAgama.SelectedIndex = 0;
        }
        private void GenerateKodePasien()
        {
            try
    {
        using (MySqlConnection conn = db.GetConnection())
        {
            conn.Open();

            string sql = "SELECT MAX(nomor_rekam_medis) FROM pasien";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            object hasil = cmd.ExecuteScalar();

            if (hasil != null && hasil != DBNull.Value)
            {
                string kode = hasil.ToString().Trim();

                // Contoh: RM-001 -> 001
                int nomor = Convert.ToInt32(kode.Substring(3));

                nomor++;

                txtKodePasien.Text = "RM-" + nomor.ToString("D3");
            }
            else
            {
                txtKodePasien.Text = "RM-001";
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
        }
        private void LoadJenisKelamin()
        {
            cmbJenisKelamin.Items.Clear();

            cmbJenisKelamin.Items.Add("L");
            cmbJenisKelamin.Items.Add("P");

            cmbJenisKelamin.SelectedIndex = 0;
        }
        private void LoadStatus()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Aktif");
            cmbStatus.Items.Add("Tidak Aktif");

            cmbStatus.SelectedIndex = 0;
        }
        private void LoadGolonganDarah()
        {
            cmbGolonganDarah.Items.Clear();

            cmbGolonganDarah.Items.Add("A");
            cmbGolonganDarah.Items.Add("B");
            cmbGolonganDarah.Items.Add("AB");
            cmbGolonganDarah.Items.Add("O");

            cmbGolonganDarah.SelectedIndex = 0;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            SimpanData();
        }

        private void dgvPasien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPasien.Rows[e.RowIndex];

                idPasien = Convert.ToInt32(row.Cells[0].Value);

                txtKodePasien.Text = row.Cells[1].Value.ToString();
                txtNIK.Text = row.Cells[2].Value.ToString();
                txtNamaPasien.Text = row.Cells[3].Value.ToString();

                cmbJenisKelamin.Text = row.Cells[4].Value.ToString();

                txtTempatLahir.Text = row.Cells[5].Value.ToString();

                dtpTanggalLahir.Value =
                    Convert.ToDateTime(row.Cells[6].Value);

                txtAlamat.Text = row.Cells[7].Value.ToString();
                txtNoHP.Text = row.Cells[8].Value.ToString();

                cmbGolonganDarah.Text = row.Cells[9].Value.ToString();
                cmbAgama.Text = row.Cells[10].Value.ToString();
                cmbStatusPernikahan.Text = row.Cells[11].Value.ToString();

                txtPekerjaan.Text = row.Cells[12].Value.ToString();
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
    }
}
