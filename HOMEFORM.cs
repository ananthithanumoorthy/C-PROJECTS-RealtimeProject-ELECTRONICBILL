using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELECTRONICBILL
{
    public partial class HOMEFORM : Form
    {
        public HOMEFORM()
        {
            InitializeComponent();
        }

        private void bRANDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BRAND brdObj = new BRAND();
            brdObj.Show();
            this.Hide();
        }
    }
}
