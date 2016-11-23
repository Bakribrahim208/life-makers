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
    public partial class add_vul : Form
    {
        data_access_layer data;
        public int id = 0;
        public add_vul()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Edite_Vul)
            {
                groupBox1.Text = "تعديل بيانات المتطوعيين";
                button1.Text = "تعديل";
            }
            data = new data_access_layer();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] IAmage;
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                IAmage = ms.ToArray();
                if (Properties.Settings.Default.Edite_Vul)
                {
                    //updated code   
                    string sql = "UPDATE volunteers SET name='" + txt_name.Text.ToString() + "',phone='" + txt_phone.Text.ToString() + "',mail='" + txt_email.Text.ToString() + "',type='" + cmb_type.SelectedItem.ToString() + "',date='" + dateTimePicker1.Value.ToShortDateString() + "',address='" + txt_address.Text + "',code='" + txt_code.Text + "',photo='" + IAmage + "'  WHERE id='" + id + "'";
                    data.Execuate_quary(sql);
                    MessageBox.Show("updated");

                }
                else
                {

                    if (txt_name.Text != String.Empty && cmb_type.SelectedItem.ToString() != String.Empty)
                    {
                        string sql = "insert into  volunteers (name, phone,mail,type,date,address,code,photo) values ('" + txt_name.Text.ToString() + "', '" + txt_phone.Text.ToString() + "','" + txt_email.Text.ToString() + "','" + cmb_type.SelectedItem.ToString() + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + txt_address.Text + "','" + txt_code.Text + "','" + IAmage + "')";
                        data.Execuate_quary(sql);
                        MessageBox.Show("added");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
