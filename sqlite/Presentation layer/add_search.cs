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
using System.IO;

namespace sqlite.Presentation_layer
{
    public partial class add_search : Form
    {
        data_access_layer d;
        public int id = 0;
        public add_search()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Edite_search)
            {
                groupBox1.Text = "تعديل بيانات بحوث الحاله";
                button2.Text = "تعديل";
            }
            d = new data_access_layer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                   byte[] IAmage;
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    IAmage = ms.ToArray();
                if (Properties.Settings.Default.Edite_search)
                {
                    //updated code   
                    string sql = "UPDATE search SET name='" + txt_name.Text.ToString() + "',address='" + txt_city.Text.ToString() + "',need='" + txt_need.Text.ToString() + "',project_type='" + cmb_type.SelectedItem.ToString() + "',phone='" + txt_phone.Text + "',photo='" + IAmage + "'  WHERE id='" + id + "'";
                    d.Execuate_quary(sql);
                    MessageBox.Show("updated");

                }
                else
                {
                 
                    if (txt_name.Text != String.Empty && cmb_type.SelectedItem.ToString() != String.Empty)
                    {
                        string sql = "insert into  search (name,address,need,project_type, phone,photo) values ('" + txt_name.Text.ToString() + "', '" + txt_city.Text.ToString() + "','" + txt_need.Text.ToString() + "','" + cmb_type.SelectedItem.ToString() + "','" + txt_phone.Text + "','" + IAmage + "')";
                        d.Execuate_quary(sql);
                        MessageBox.Show("added");
                    }
                }

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
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "picture|*.jpg;*.png;*.JPG;*.PNG";
                if (op.ShowDialog() == DialogResult.OK)
                {

                    pictureBox1.Image = Image.FromFile(op.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
