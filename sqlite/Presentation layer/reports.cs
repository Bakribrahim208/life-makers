using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace sqlite.Presentation_layer
{
    public partial class reports : Form
    {
         SQLiteConnection m_dbConnection;
        string sql;
        public reports()
        {
            InitializeComponent();
             m_dbConnection = new SQLiteConnection("Data Source=D:\\hussien embaby\\database1.sqlite;Version=3;");
            m_dbConnection.Open();
        }
        public reports(string quary)
        {
            InitializeComponent();
            sql = quary;
            m_dbConnection = new SQLiteConnection("Data Source=D:\\hussien embaby\\database1.sqlite;Version=3;");
            m_dbConnection.Open();
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
               
        
       AllVul vul = new AllVul();
      
       SQLiteDataAdapter d = new SQLiteDataAdapter(sql,m_dbConnection);
       DataTable dt = new DataTable();
       d.Fill(vul.Tables["Vultaneers"]);
       if (Properties.Settings.Default.single_vul)
       {
           Report.CrystalReport1 report = new Report.CrystalReport1();
           report.SetDataSource(vul.Tables["Vultaneers"]);
           crystalReportViewer1.ReportSource = report;
           crystalReportViewer1.Refresh();
       }
       else
       {
           Report.Allvultaners report = new Report.Allvultaners();
           report.SetDataSource(vul.Tables["Vultaneers"]);
           crystalReportViewer1.ReportSource = report;
           crystalReportViewer1.Refresh();
       }
        }
    }
}
