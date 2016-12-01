using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraEditors.Controls;

namespace FreightHepler
{
    public partial class XtraFormMain : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormMain()
        {
            InitializeComponent();
        }

        private void XtraFormMain_Shown(object sender, EventArgs e)
        {
            new Thread(delegate(){
                        new FrmLogin().ShowDialog();
            }).Start();

            new Thread(delegate() {
                List<UnitPrice> listUnit = MyWebService.Instance.GetUnit(HttpUrl.Instance.UnitUrl);
                ComboBoxItemCollection itemsCollection = comboBoxEditPerson.Properties.Items;
                itemsCollection.BeginUpdate();
                try
                {
                    foreach (UnitPrice item in listUnit)
                        itemsCollection.Add(item.MC);
                }
                finally
                {
                    itemsCollection.EndUpdate();
                }
            }).Start();

            new Thread(delegate()
            {
                List<Bureau> listUnit = MyWebService.Instance.getCurBureauFz(HttpUrl.Instance.CurBureauFz);
                ComboBoxItemCollection itemsCollection = comboBoxEditFromStation.Properties.Items;
                itemsCollection.BeginUpdate();
                try
                {
                    foreach (Bureau item in listUnit)
                        itemsCollection.Add(item.HZZM);
                }
                finally
                {
                    itemsCollection.EndUpdate();
                }
            }).Start();
        }
    }
}