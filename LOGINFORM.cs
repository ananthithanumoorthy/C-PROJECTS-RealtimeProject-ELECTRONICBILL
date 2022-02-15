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
    public partial class LOGINFORM : Form
    {
        public LOGINFORM()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textUserName.Text == "")
            {
                MessageBox.Show("Please enter the username");
                return;
            }
            if (textPassword.Text == "")
            {
                MessageBox.Show("Please enter the Password");
                return;
            }
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=ANANTHITHANUMOO;Initial Catalog=EBill;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select count(*) from USERS where Name='" + textUserName.Text + "'and Pass='" + textPassword.Text + "'", conn); 
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                int x = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                if (x >= 1)
                {

                    HOMEFORM hmobj = new HOMEFORM();
                    hmobj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Login Details ");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error is:" + ex.Message);
            }
        }
    }
}
