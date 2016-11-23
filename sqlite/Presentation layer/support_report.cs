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
    public partial class support_report : Form
    {
        
         SQLiteConnection m_dbConnection;
        string sql;
        public support_report()
        {
            InitializeComponent();
             m_dbConnection = new SQLiteConnection("Data Source=D:\\hussien embaby\\database1.sqlite;Version=3;");
            m_dbConnection.Open();
        }
        public support_report(string quary)
        {
            InitializeComponent();
            sql = quary;
            m_dbConnection = new SQLiteConnection("Data Source=D:\\hussien embaby\\database1.sqlite;Version=3;");
            m_dbConnection.Open();
        }
         

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            AllVul vul = new AllVul();

            SQLiteDataAdapter d = new SQLiteDataAdapter(sql, m_dbConnection);
            DataTable dt = new DataTable();
            d.Fill(vul.Tables["support"]);
            Report.all_support report = new Report.all_support();
            report.SetDataSource(vul.Tables["support"]);
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();

        }

        
    }
}
