using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace sqlite.Presentation_layer
{
    public partial class Edite_vul : Form
    {
        data_access_layer data;
        public Edite_vul()
        {
            InitializeComponent();
            data = new data_access_layer();
            fill_gridview();
        }
        public void fill_gridview()
        {
            string sql = "select * from volunteers";
            dataGridView1.DataSource = data.select(sql);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Edite_Vul = true;
            Presentation_layer.add_vul edite_vul = new add_vul();
            edite_vul.txt_address.Text=dataGridView1.CurrentRow.Cells[6].Value.ToString(); 
            edite_vul.txt_code.Text=dataGridView1.CurrentRow.Cells[7].Value.ToString(); 
            edite_vul.txt_email.Text=dataGridView1.CurrentRow.Cells[3].Value.ToString(); 
            edite_vul.txt_name.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString(); 
            edite_vul.txt_phone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            edite_vul.id =Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value.ToString());
           
            edite_vul.ShowDialog();
            fill_gridview();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from volunteers where type='" + comboBox1.SelectedItem.ToString() + "'";
                dataGridView1.DataSource = data.select(sql);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[8].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from volunteers where date='" + dateTimePicker1.Value.ToShortDateString()+ "'";
                dataGridView1.DataSource = data.select(sql);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[8].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.single_vul = true;
                reports form = new reports("select * from volunteers where id='"+Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value.ToString())+"'");
                form.Show();
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
                if (MessageBox.Show("تاكيد الحذف ", "حذف مستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string sql = "DELETE  from volunteers  WHERE id='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'";
                    data_access_layer d = new data_access_layer();
                    d.Execuate_quary(sql);
                    fill_gridview();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fill_gridview();
            textBox1.Clear();
        }
    }
}
