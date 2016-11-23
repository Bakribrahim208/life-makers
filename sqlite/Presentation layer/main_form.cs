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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
         
        private void اضافهداعمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Edite_support = false;

            try
            {
                Presentation_layer.add_support add_sup = new Presentation_layer.add_support();
                add_sup.MdiParent = this;
                add_sup.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void تعديلبياناتداعمToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Presentation_layer.delete_support delete_sup = new Presentation_layer.delete_support();
                delete_sup.MdiParent = this;
                delete_sup.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void مسحداعمToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void اضافهمتطوعجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Edite_Vul = false;
                Presentation_layer.add_vul add_vul = new Presentation_layer.add_vul();
                add_vul.MdiParent = this;
                add_vul.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void تعديلبياناتمتطوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Presentation_layer.Edite_vul edite_vul = new Presentation_layer.Edite_vul();
                edite_vul.MdiParent = this;
                edite_vul.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void مسحمتطوعToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void اضافهبحثToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Edite_search = false;

                Presentation_layer.add_search add_search = new Presentation_layer.add_search();
                add_search.MdiParent = this;
                add_search.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void تعديلبحثToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Presentation_layer.Edite_search Edite_search = new Presentation_layer.Edite_search();
                Edite_search.MdiParent = this;
                Edite_search.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void مسحبحثToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MdiClient chld;

            //foreach (Control ctrl in this.Controls)
            //{
            //    try
            //    {
            //        chld = (MdiClient)ctrl;

            //        chld.BackColor = this.BackColor;
            //    }

            //    catch (InvalidCastException exe)
            //    {
            //        MessageBox.Show(exe.Message);
            //    }
            //}
         

        }

        private void طباعهكلالمتطوعيينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.single_vul = false;
                Presentation_layer.reports form = new Presentation_layer.reports("select * from volunteers");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.single_vul = false;

                Presentation_layer.reports form = new Presentation_layer.reports("select * from volunteers where type='A'");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.single_vul = false;

                Presentation_layer.reports form = new Presentation_layer.reports("select * from volunteers where type='B'");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.single_vul = false;

                Presentation_layer.reports form = new Presentation_layer.reports("select * from volunteers where type='C'");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.single_vul = false;

                Presentation_layer.reports form = new Presentation_layer.reports("select * from volunteers where type='D'");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void تقريربنوعالدعمToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Presentation_layer.support_report form = new Presentation_layer.support_report(" select * from supports ");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        




        private void ماديToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Presentation_layer.support_report form = new Presentation_layer.support_report(" select * from supports where support_type='مادي' ");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void وسيلهمواصلاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           try
            {
                Presentation_layer.support_report form = new Presentation_layer.support_report(" select * from supports where support_type='وسيله مواصلات' ");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void مدربينToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            try
            {
                Presentation_layer.support_report form = new Presentation_layer.support_report(" select * from supports where support_type='مدرب' ");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void علاقاتحكوميهToolStripMenuItem_Click(object sender, EventArgs e)
        {
          try
            {
                Presentation_layer.support_report form = new Presentation_layer.support_report(" select * from supports where support_type='علاقات حكوميه' ");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void علاToolStripMenuItem_Click(object sender, EventArgs e)
        {
         try
            {
                Presentation_layer.support_report form = new Presentation_layer.support_report(" select * from supports where support_type='علاقات عامه وشركات خاصه' ");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void دليلمراكزToolStripMenuItem_Click(object sender, EventArgs e)
        {
         try
            {
                Presentation_layer.support_report form = new Presentation_layer.support_report(" select * from supports where support_type='دليل مراكز' ");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void عينيToolStripMenuItem_Click(object sender, EventArgs e)
        {
         try
            {
                Presentation_layer.support_report form = new Presentation_layer.support_report(" select * from supports where support_type='عيني' ");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void اخريToolStripMenuItem_Click(object sender, EventArgs e)
        {
        try
            {
                Presentation_layer.support_report form = new Presentation_layer.support_report(" select * from supports where support_type='اخري' ");
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void اتصالبقاعدهبياناتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database_connect connect = new database_connect();
            connect.ShowDialog();
        }

        private void عملنسخهاحتياطيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentation_layer.backup_form backup = new Presentation_layer.backup_form();
            backup.ShowDialog();
        }

        private void طباعهكلابحاثالحالهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.single_search = false;
            search_report form = new search_report("select * from search ");
            form.Show();
        }
  
 
    

       
         

     
        }
}
