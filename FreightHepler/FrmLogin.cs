﻿namespace FreightHepler
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
 

    public class FrmLogin : XtraForm
    {
        private bool autoLogin;
        private SimpleButton btnCancel;
        private SimpleButton btnLogin;
        private CheckEdit chkRemerber;
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private Label lblMessage;
        private Panel panel1;
        private string randCode;
        private TableLayoutPanel tableLayoutPanel1;
        private Thread threadLogin;
        private TextEdit txtPassword;
        private ComboBoxEdit txtUserName;
       // private CustomComboBox txtUserName;

        public FrmLogin()
        {
            this.randCode = string.Empty;
            this.autoLogin = false;
            this.components = null;
            this.InitializeComponent();
        }

        public FrmLogin(bool autoLogin)
        {
            this.randCode = string.Empty;
            this.autoLogin = false;
            this.components = null;
            this.autoLogin = autoLogin;
            this.InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        protected override void Dispose(bool disposing)
        {
            MethodManager.InvokeNoneException(() => this.threadLogin.Abort());
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DisposePicturBox(PictureEdit picEdit)
        {
            Image image = picEdit.Image;
            picEdit.Image = null;
            if (image != null)
            {
                image.Dispose();
            }
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            //foreach (string[] strArray in LoginInfoTemp.Instance.ListUsers)
            //{
            //    this.txtUserName.Items.Add(strArray[0]);
            //}
            //this.txtUserName.Text = LoginInfoTemp.Instance.UserName;
            //this.txtPassword.Text = LoginInfoTemp.Instance.Password;
            //this.txtUserName.PopupWidth = this.txtUserName.Width;
            //this.chkRemerber.Checked = !string.IsNullOrEmpty(LoginInfoTemp.Instance.Password);
            //if (this.autoLogin && (LoginInfoTemp.Instance.Password.Length > 0))
            //{
            //    this.btnLogin_Click(null, null);
            //}
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtUserName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.chkRemerber = new DevExpress.XtraEditors.CheckEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemerber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.chkRemerber);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 286);
            this.panel1.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(194, 101);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtUserName.Size = new System.Drawing.Size(218, 22);
            this.txtUserName.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Location = new System.Drawing.Point(199, 81);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(209, 14);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "请使用12306货运网站用户密码登录";
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.Location = new System.Drawing.Point(295, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(143, 140);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "密  码:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(139, 104);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "用户名:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(205, 206);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 249);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(569, 37);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(284, 10);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 0;
            // 
            // chkRemerber
            // 
            this.chkRemerber.Location = new System.Drawing.Point(192, 174);
            this.chkRemerber.Name = "chkRemerber";
            this.chkRemerber.Properties.Caption = "记住用户名与密码";
            this.chkRemerber.Size = new System.Drawing.Size(129, 19);
            this.chkRemerber.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(194, 137);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.AllowFocused = false;
            this.txtPassword.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(218, 22);
            this.txtPassword.TabIndex = 2;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.ClientSize = new System.Drawing.Size(569, 286);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.Shown += new System.EventHandler(this.FrmLogin_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemerber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        protected override void OnFormClosed(FormClosedEventArgs formClosedEventArgs_0)
        {
            base.OnFormClosed(formClosedEventArgs_0);
            MethodManager.InvokeNoneException(() => this.threadLogin.Abort());
        }

        private void SetFormEnable(bool enable)
        {
            this.txtUserName.Enabled = enable;
            this.txtPassword.Enabled = enable;
            this.chkRemerber.Enabled = enable;
            this.btnLogin.Enabled = enable;
        }

        private void txtUserName_OnRemoveItem(object sender, EventArgs e)
        {
            string userName = sender.ToString();
            LoginInfoTemp.Instance.ListUsers.RemoveAll(string_0 => string_0[0] == userName);
            LoginInfoTemp.Instance.Save();
        }

        private void txtUserName_OnSlectetChanged(object sender, EventArgs e)
        {
            //string str = sender.ToString();
            //this.txtUserName.Text = str;
            //this.txtPassword.Text = string.Empty;
            //using (List<string[]>.Enumerator enumerator = LoginInfoTemp.Instance.ListUsers.GetEnumerator())
            //{
            //    string[] current;
            //    while (enumerator.MoveNext())
            //    {
            //        current = enumerator.Current;
            //        if (current[0] == str)
            //        {
            //            goto Label_0057;
            //        }
            //    }
            //    return;
            //Label_0057:
            //    this.txtPassword.Text = current[1];
            //}
        }
    }
}

