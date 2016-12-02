using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FreightHepler
{
    public partial class XtraFormEdit : DevExpress.XtraEditors.XtraForm
    {
        public DataRow Row;
        public XtraFormEdit()
        {
            InitializeComponent();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
  
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}