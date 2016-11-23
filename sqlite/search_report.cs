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
namespace sqlite
{
    public partial class search_report : Form
    {
    
         SQLiteConnection m_dbConnection;
        string sql;
        public search_report()
        {
            InitializeComponent();
             m_dbConnection = new SQLiteConnection("Data Source=D:\\hussien embaby\\database1.sqlite;Version=3;");
            m_dbConnection.Open();
        }
        public search_report(string quary)
        {
            InitializeComponent();
            sql = quary;
            m_dbConnection = new SQLiteConnection("Data Source=D:\\hussien embaby\\database1.sqlite;Version=3;");
            m_dbConnection.Open();
        }
         

      
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            AllVul vul = new AllVul();

            SQLiteDataAdapter d = new SQLiteDataAdapter(sql, m_dbConnection);
            DataTable dt = new DataTable();
            d.Fill(vul.Tables["support"]);

            if(Properties.Settings.Default.single_search)
            {
                Report.one_search report = new Report.one_search();
                report.SetDataSource(vul.Tables["support"]);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Report.All_search report = new Report.All_search();
                report.SetDataSource(vul.Tables["support"]);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            

        }
    }
}
