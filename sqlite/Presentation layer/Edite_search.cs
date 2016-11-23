using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sqlite.Presentation_layer
{
    public partial class Edite_search : Form
    {
        data_access_layer data;
        public Edite_search()
        {
            InitializeComponent();
            data = new data_access_layer();
            string sql = "select * from search";
            dataGridView1.DataSource = data.select(sql);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("تاكيد الحذف ", "حذف البحث", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string sql = "DELETE  from search  WHERE id='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'";
                    data_access_layer d = new data_access_layer();
                    d.Execuate_quary(sql);
                    sql = "select * from search";
                    dataGridView1.DataSource = d.select(sql);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Edite_search = true;
            Presentation_layer.add_search add = new add_search();
            add.txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            add.txt_city.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            add.txt_need.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            add.txt_phone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            add.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
          string  sql = "select * from search";
            dataGridView1.DataSource = data.select(sql);
            add.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.single_search = true;
            search_report form = new search_report("select * from search where id='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'");
            form.Show();
        }
    }
}
