using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SIMRS
{
    public partial class Frm_data_pasien : Form
    {
        private string reportFileName;
        public Frm_data_pasien() : this("LAPORAN DATA PASIEN.rpt")
        {
        }
        public Frm_data_pasien(string fileName)
        {
            InitializeComponent();
            this.reportFileName = fileName;
            this.Load += Frm_data_pasien_Load;
        }
        public Frm_data_pasien(ReportDocument rpt)
        {
            InitializeComponent();
            SetReport(rpt);
        }
        private void SetReport(ReportDocument rpt)
        {
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
        private void Frm_data_pasien_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(reportFileName))
                return;

            string filePath = Path.Combine(Application.StartupPath, reportFileName);

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File laporan tidak ditemukan di: " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReportDocument rpt = new ReportDocument();
            rpt.Load(filePath);
            SetReport(rpt);
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
                
        }
    }
}
