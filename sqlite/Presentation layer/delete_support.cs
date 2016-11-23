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
    public partial class delete_support : Form
    {
        data_access_layer data ;
        public delete_support()
        {
            InitializeComponent();
            data = new data_access_layer();
            string sql = "select * from supports";
            dataGridView1.DataSource = data.select(sql);
             
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Edite_support = true;

            Presentation_layer.add_support sup = new add_support();
            sup.txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            sup.txt_address.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            sup.id=Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value.ToString());
            sup.txt_phone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            sup.ShowDialog();
            string sql = "select * from supports";
            dataGridView1.DataSource = data.select(sql);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from supports where support_type='" + comboBox1.SelectedItem.ToString() + "'";
                dataGridView1.DataSource = data.select(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from supports where name='"+ textBox1.Text.ToString() + "'";
                dataGridView1.DataSource = data.select(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               if (MessageBox.Show("تاكيد الحذف ", "حذف مستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string sql = "DELETE  from supports  WHERE id='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'";
                    data_access_layer d = new data_access_layer();
                    d.Execuate_quary(sql);
                    sql = "select * from supports";
                    dataGridView1.DataSource = d.select(sql);
                }
 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        
    }
}
