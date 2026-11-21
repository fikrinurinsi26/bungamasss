
namespace SIMRS
{
    partial class FrmLogin
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
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblSubJudul = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkLihatPassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.btnCekKoneksi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.Location = new System.Drawing.Point(12, 9);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(440, 23);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "SISTEM INFORMASI MANAJEMEN RUMAH SAKIT";
            this.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // lblSubJudul
            // 
            this.lblSubJudul.AutoSize = true;
            this.lblSubJudul.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubJudul.ForeColor = System.Drawing.Color.Gray;
            this.lblSubJudul.Location = new System.Drawing.Point(123, 44);
            this.lblSubJudul.Name = "lblSubJudul";
            this.lblSubJudul.Size = new System.Drawing.Size(189, 17);
            this.lblSubJudul.TabIndex = 1;
            this.lblSubJudul.Text = "Silakan login untuk melanjutkan";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(113, 93);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(113, 149);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(116, 109);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(143, 25);
            this.txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(116, 165);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(137, 25);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // chkLihatPassword
            // 
            this.chkLihatPassword.AutoSize = true;
            this.chkLihatPassword.ForeColor = System.Drawing.Color.Black;
            this.chkLihatPassword.Location = new System.Drawing.Point(116, 196);
            this.chkLihatPassword.Name = "chkLihatPassword";
            this.chkLihatPassword.Size = new System.Drawing.Size(124, 17);
            this.chkLihatPassword.TabIndex = 6;
            this.chkLihatPassword.Text = "Tampilkan Password";
            this.chkLihatPassword.UseVisualStyleBackColor = true;
            this.chkLihatPassword.CheckedChanged += new System.EventHandler(this.chkLihatPassword_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(116, 240);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.BackColor = System.Drawing.Color.IndianRed;
            this.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluar.ForeColor = System.Drawing.Color.White;
            this.btnKeluar.Location = new System.Drawing.Point(291, 240);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(75, 23);
            this.btnKeluar.TabIndex = 8;
            this.btnKeluar.Text = "KELUAR";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // btnCekKoneksi
            // 
            this.btnCekKoneksi.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCekKoneksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCekKoneksi.ForeColor = System.Drawing.Color.White;
            this.btnCekKoneksi.Location = new System.Drawing.Point(308, 149);
            this.btnCekKoneksi.Name = "btnCekKoneksi";
            this.btnCekKoneksi.Size = new System.Drawing.Size(75, 23);
            this.btnCekKoneksi.TabIndex = 9;
            this.btnCekKoneksi.Text = "Cek Koneksi";
            this.btnCekKoneksi.UseVisualStyleBackColor = false;
            this.btnCekKoneksi.Click += new System.EventHandler(this.btnCekKoneksi_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.btnCekKoneksi);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkLihatPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblSubJudul);
            this.Controls.Add(this.lblJudul);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - SIMRS";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblSubJudul;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkLihatPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Button btnCekKoneksi;
    }
}

