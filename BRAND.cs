using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ELECTRONICBILL
{
    public partial class BRAND : Form
    {
        public BRAND()
        {
            InitializeComponent();
            LoadCombo();
        }

        public void LoadCombo()
        {
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBrandName.Text == "")
            {
                MessageBox.Show("Please enter the brand name");
                textBrandName.Focus();
                return;
            }
            if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select category type");
                comboBox1.Focus();
                return;
            }
            try {
                SqlConnection conn = new SqlConnection("Data Source=ANANTHITHANUMOO;Initial Catalog=EBill;Integrated Security=true");
                SqlCommand cmd = new SqlCommand("insert into BRAND values('"+ textBrandName.Text + "' , '"+ comboBox1 .Text+ "')",conn);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                if (x == 1)
                {
                    MessageBox.Show("Brand Details Added Successfully");

                }
                SqlCommand cmd1 = new SqlCommand("select BRAND.BID as Brand ID,BRAND.bName as Brand Name,category.CName as Category Name from BRAND innerjoin category on BRAND.CID=category.CID", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=ANANTHITHANUMOO;Initial Catalog=EBill;Integrated Security=true");
                SqlCommand cmd = new SqlCommand("select CID,CName from Category", conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "CName";
                comboBox1.ValueMember = "CID";
                comboBox1.SelectedIndex = -1;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
