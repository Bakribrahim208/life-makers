using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sqlite
{
    public partial class database_connect : Form
    {
        public database_connect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Database|*sqlite;*.SQLITE";
                if (op.ShowDialog() == DialogResult.OK)
                {

                    textBox1.Text = op.FileName;
            
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.database_path = textBox1.Text.ToString();
                data_access_layer data = new data_access_layer();
                MessageBox.Show("تم الاتصال بنجاح بقاعده البيانات");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("تاكد من صحه قاعده البياتات المعطاه بواسطه المبرمج");
             
            }
        }
    }
}
