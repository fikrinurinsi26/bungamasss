using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SIMRS
{
    public partial class FrmLogin : Form
    {
        private KoneksiDatabase db = new KoneksiDatabase();

        public FrmLogin()
        {
            InitializeComponent();
        }

        // =========================
        // PROSES LOGIN
        // =========================
        private void Login()
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Username masih kosong!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsername.Focus();
                return;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Password masih kosong!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT *
                                       FROM users
                                       WHERE username=@username
                                       AND password=@password
                                       AND is_active=1";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            MessageBox.Show("Login Berhasil!",
         "Informasi",
         MessageBoxButtons.OK,
         MessageBoxIcon.Information);

                            // Ambil nama lengkap dari database
                            string nama = dr["full_name"].ToString();

                            // Kirim ke Dashboard
                            FrmDashboard dashboard = new FrmDashboard(nama);
                            dashboard.Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Username atau Password Salah!",
                                "Login Gagal",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // EVENT FORM
        // =========================
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        // =========================
        // BUTTON LOGIN
        // =========================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        // =========================
        // BUTTON KELUAR
        // =========================
        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // =========================
        // CHECKBOX PASSWORD
        // =========================
        private void chkLihatPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkLihatPassword.Checked;
        }

        // =========================
        // ENTER PADA PASSWORD
        // =========================
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        // =========================
        // CEK KONEKSI
        // =========================
        private void btnCekKoneksi_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MessageBox.Show("Koneksi Database Berhasil!",
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Koneksi Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
