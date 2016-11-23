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
    public partial class add_support : Form
    {
        data_access_layer d  ;

   public  int id = 1;

        public add_support()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Edite_support)
            {
                button1.Text = "تعديل البيانات";
                groupBox1.Text = "تعديل البيانات";
            }
            d = new data_access_layer();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.Edite_support)
                {
                    if (txt_name.Text != String.Empty && cmb_type.SelectedItem.ToString() != String.Empty)
                    {
                        string sql = "UPDATE supports SET name='" + txt_name.Text.ToString() + "',phone='" + txt_phone.Text.ToString() + "',address='" + txt_address.Text.ToString() + "' ,support_type='" + cmb_type.SelectedItem.ToString() + "'  WHERE id='" + id + "'";
                        d.Execuate_quary(sql);
                        MessageBox.Show("updated");
                    }

                   else
                    {
                        MessageBox.Show("يجب كتابه اسم واختيار نوع الداعم ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }
                else
                {
                    if (txt_name.Text != String.Empty && cmb_type.SelectedItem.ToString() != String.Empty)
                    {
                        string sql = "insert into  supports (name, phone,address,support_type) values ('" + txt_name.Text.ToString() + "', '" + txt_phone.Text.ToString() + "','" + txt_address.Text.ToString() + "','" + cmb_type.SelectedItem.ToString() + "')";
                        d.Execuate_quary(sql);
                        MessageBox.Show("sucess");
                        clear_txts();
                    }
                    else
                    {
                        MessageBox.Show("يجب كتابه اسم واختيار نوع الداعم ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
        public void clear_txts()
        {
            txt_address.Clear();
            txt_name.Clear();
            txt_phone.Clear();
        }
    }
}
