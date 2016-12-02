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
        private Thread threadKeepLogin;
        private Thread[] threadPool;
        public XtraFormMain()
        {
            InitializeComponent();
            this.lblMessage.Text = string.Empty;
            if (DateTime.Now.Minute > 30)
                this.timeEdit1.Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0).AddHours(1.0);//weihua.wan or 1.0
            else
            {
                int span = 0;
                if (DateTime.Now.Minute >= 0 && DateTime.Now.Minute <= 30)
                {
                    span = 30 - DateTime.Now.Minute;
                }
                else
                    span = 59 - DateTime.Now.Minute;
                this.timeEdit1.Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0).AddMinutes(span);
            }
        }

        private void XtraFormMain_Shown(object sender, EventArgs e)
        {
            
          //  new Thread(delegate(){
                        FrmLogin login = new FrmLogin();
                       
                        login.ShowDialog();
                        
           // }).Start();
                        if (MyWebService.Instance.DataPermission != null) { 
                            gridControl1.DataSource = MyWebService.Instance.DataPermission.data.dataRows;
                            gridControl1.RefreshDataSource();
                        }
                         
            new Thread(delegate() {
                List<UnitPrice> listUnit = MyWebService.Instance.GetUnit(HttpUrl.Instance.UnitUrl);
                MyWebService.Instance.listUnit = listUnit;
                if (listUnit != null)
                {
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
                }
                
            }).Start();

            new Thread(delegate()
            {
                List<Bureau> listUnit = MyWebService.Instance.getCurBureauFz(HttpUrl.Instance.CurBureauFz);
                MyWebService.Instance.listBureau = listUnit;
                if (listUnit!=null)
                {
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
                }
                
            }).Start();

            new Thread(delegate()
            {
                List<PM> listPM = MyWebService.Instance.getAllPm(HttpUrl.Instance.PM);
                MyWebService.Instance.listPM = listPM;
                if (listPM != null)
                {
                    ComboBoxItemCollection itemsCollection = comboBoxEditName.Properties.Items;
                    itemsCollection.BeginUpdate();
                    try
                    {
                        foreach (PM item in listPM)
                            itemsCollection.Add(item.MC);
                    }
                    finally
                    {
                        itemsCollection.EndUpdate();
                    }
                }
                
            }).Start();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            comboBoxEditName.Text = string.Empty;
            comboBoxEditFromStation.Text = string.Empty;
            comboBoxEditPerson.Text = string.Empty;

        }

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {
            MyWebService.Instance.DataPermission = MyWebService.Instance.getDataPermission(HttpUrl.Instance.searchDataPermissionApply, MyWebService.Instance.UUID);
            gridControl1.DataSource = MyWebService.Instance.DataPermission.data.dataRows;
            gridControl1.RefreshDataSource();
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetFormEnable(bool enable)
        {
            this.checkEditInternal.Enabled = enable;
            this.spinEditInternal.Enabled = this.spinEditInternal.Enabled = enable;
            
        }

        private void AbortThread()
        {
            if (this.threadPool != null)
            {
                for (int i = 0; i < this.threadPool.Length; i++)
                {
                    try
                    {
                        if ((this.threadPool[i] != null) && this.threadPool[i].IsAlive)
                        {
                            this.threadPool[i].Abort();
                        }
                    }
                    catch
                    {
                        
                    }
                }
            }
            try
            {
                if ((this.threadKeepLogin != null) && this.threadKeepLogin.IsAlive)
                {
                    this.threadKeepLogin.Abort();
                }
            }
            catch
            {
            }
        }
        private void StartKeepOnline()
        {
            this.threadKeepLogin = new Thread(delegate() {

                Thread.Sleep(5000);
            });
            this.threadKeepLogin.IsBackground = true;
            this.threadKeepLogin.Start();
            
        }

        private void StopKeepOnline()
        {
            try
            {
                if ((this.threadKeepLogin != null) && this.threadKeepLogin.IsAlive)
                {
                    this.threadKeepLogin.Abort();
                }
            }
            catch
            {
            }
        }
        private void btnStartInTime_Click(object sender, EventArgs e)
        {
            if (this.btnStartInTime.Text == "定时启动")
            {
               // if (this.ValidateForStart())
                {
                    if (this.timeEdit1.Time <= DateTime.Now)
                    {
                        XtraMessageBox.Show("定时启动时间不能早于当前系统时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        this.StartKeepOnline();

                        this.btnStartInTime.Text = "停止启动";
                        this.SetFormEnable(false);
                        this.timeEdit1.Enabled = false;
                        this.btnCancel.Enabled = false;
                        this.btnOK.Enabled = false;
                        this.timerStart.Start();
                    }
                }
            }
            else
            {
                this.timerStart.Stop();
                this.btnStartInTime.Text = "定时启动";
                this.SetFormEnable(true);
                this.timeEdit1.Enabled = true;
                this.btnCancel.Enabled = true;
                this.btnOK.Enabled = true;
                this.lblMessage.Text = string.Empty;
                this.StopKeepOnline();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
           
            
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= this.timeEdit1.Time)
            {
                this.btnOK_Click(null, null);
            }
            else
            {
                TimeSpan span = (TimeSpan)(this.timeEdit1.Time - DateTime.Now);
                this.lblMessage.Text = string.Format("{0}时{1}分{2}秒{3}毫秒后开始自动购票", new object[] { span.Hours.ToString("d2"), span.Minutes.ToString("d2"), span.Seconds.ToString("d2"), span.Milliseconds.ToString("d3") });
            }
        }
        private void StartBuyTicket(object args)
        {
            if ((args != null) && (args is object[]))
            {
                while (true) {
                    DataRow row = ((object[])args)[0] as DataRow;
                    Submit submit = MyWebService.Instance.OutBurDataPermissionApply(HttpUrl.Instance.outBurDataPermissionApply, MyWebService.Instance.UUID);
                    if (submit != null) {
                        if (submit.success && submit.message.Contains("成功"))
                        {
                           // this.AfterSubmiteSuccess(row, submit);
                            this.AppendLog(row, submit.message);
                            break;

                        }
                        else if (!submit.success && submit.message.Contains("至少有一条待提报的数据权限"))
                        {
                           // this.AfterSubmiteSuccess(row, submit);
                            this.AppendLog(row, "提交成功");
                            break;
                        }
                    }
                }
            }
 
        }
        private void AfterSubmiteSuccess(DataRow row, Submit orderInfo)
        {
            this.AbortThread();
            this.SetFormEnable(true);
            this.btnStartInTime.Enabled = true;
            this.timeEdit1.Enabled = true;
            this.btnCancel.Enabled = true;
            this.btnOK.Enabled = true;
        }
        private void AppendLog(DataRow row, string message)
        {
            MethodManager.ControlInvoke(this.listBoxControl1, delegate
            {
                while (this.listBoxControl1.ItemCount > 500)
                {
                    this.listBoxControl1.Items.RemoveAt(0);
                }
                
                this.listBoxControl1.Items.Add(message);
                this.listBoxControl1.SelectedIndex = this.listBoxControl1.Items.Count - 1;
            });
        }
        private void AbortFullTicketCondition(DataRow row)
        {
            MethodInvoker invoker2 = null;
            try
            {
                if (invoker2 == null)
                {
                    invoker2 = delegate
                    {
                        //this.isRunning = false;
                        this.AbortThread();
                        this.SetFormEnable(true);
                        this.btnStartInTime.Enabled = true;
                        this.timeEdit1.Enabled = true;
                        this.btnCancel.Enabled = true;
                        this.btnOK.Enabled = true;
                        this.lblMessage.Text = "休息时间，自动停止购票!";
                        this.btnOK.Text = "自动购票";

                        Thread.Sleep(1000);
                        this.btnStartInTime.Text = "停止启动";
                        this.SetFormEnable(false);
                        this.timeEdit1.Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 59, 50).AddDays(1);
                        this.timeEdit1.Enabled = false;
                        this.btnCancel.Enabled = false;
                        this.btnOK.Enabled = false;
                        this.timerStart.Start();

                    };
                }

                MethodManager.ControlInvoke(this, invoker2);
            }
            catch
            {
                Thread.Sleep(1000);
                this.btnStartInTime.Text = "停止启动";
                this.SetFormEnable(false);
                this.timeEdit1.Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 59, 50).AddDays(1);
                this.timeEdit1.Enabled = false;
                this.btnCancel.Enabled = false;
                this.btnOK.Enabled = false;
                this.timerStart.Start();
            }


        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnOK.Text == "自动购票")
                {
                    this.StopKeepOnline();
                    //this.isRunning = true;
                    this.timerStart.Stop();
                    this.lblMessage.Text = string.Empty;
                    this.SetFormEnable(false);
                    this.btnStartInTime.Enabled = false;
                    this.timeEdit1.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.btnOK.Enabled = false;
                    this.btnOK.Text = "停止购票";
                    this.btnOK.Enabled = true;
                    this.threadPool = new Thread[this.gridView1.RowCount];
                    for (int i = 0; i < this.gridView1.RowCount; i++)
                    {
                        this.threadPool[i] = new Thread(new ParameterizedThreadStart(this.StartBuyTicket));
                        this.threadPool[i].IsBackground = true;
                        this.threadPool[i].Start(new object[] { this.gridView1.GetRow(i), i });
                        
                    }
                }
                else
                {
                    this.StopKeepOnline();
                    //this.isRunning = false;
                    this.AbortThread();
                    this.SetFormEnable(true);
                    this.btnStartInTime.Enabled = true;
                    this.timeEdit1.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnOK.Enabled = true;
                    this.lblMessage.Text = string.Empty;
                    this.btnOK.Text = "自动购票";
                    this.btnStartInTime.Text = "定时启动";
                }

            }
            catch
            {
            }
        }

        private void simpleButtonNew_Click(object sender, EventArgs e)
        {
            new XtraFormEdit().ShowDialog();
        }
    }
}