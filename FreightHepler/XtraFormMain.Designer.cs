namespace FreightHepler
{
    partial class XtraFormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditFromStation = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditPerson = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumnShipper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFromSt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditFromStation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.Appearance.BackColor = System.Drawing.Color.Lime;
            this.groupControlQuery.Appearance.Options.UseBackColor = true;
            this.groupControlQuery.AutoSize = true;
            this.groupControlQuery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupControlQuery.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControlQuery.Controls.Add(this.simpleButtonCancel);
            this.groupControlQuery.Controls.Add(this.simpleButtonQuery);
            this.groupControlQuery.Controls.Add(this.labelControl3);
            this.groupControlQuery.Controls.Add(this.labelControl2);
            this.groupControlQuery.Controls.Add(this.labelControl1);
            this.groupControlQuery.Controls.Add(this.comboBoxEditName);
            this.groupControlQuery.Controls.Add(this.comboBoxEditFromStation);
            this.groupControlQuery.Controls.Add(this.comboBoxEditPerson);
            this.groupControlQuery.Location = new System.Drawing.Point(0, 1);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(984, 146);
            this.groupControlQuery.TabIndex = 0;
            this.groupControlQuery.Text = "发货权限申请查询条件";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(538, 96);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(121, 23);
            this.simpleButtonCancel.TabIndex = 7;
            this.simpleButtonCancel.Text = "清除";
            // 
            // simpleButtonQuery
            // 
            this.simpleButtonQuery.Location = new System.Drawing.Point(317, 96);
            this.simpleButtonQuery.Name = "simpleButtonQuery";
            this.simpleButtonQuery.Size = new System.Drawing.Size(121, 23);
            this.simpleButtonQuery.TabIndex = 6;
            this.simpleButtonQuery.Text = "查 询";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(663, 51);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "货物名称:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(340, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "发    站：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "托运人：";
            // 
            // comboBoxEditName
            // 
            this.comboBoxEditName.Location = new System.Drawing.Point(761, 47);
            this.comboBoxEditName.Name = "comboBoxEditName";
            this.comboBoxEditName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditName.Size = new System.Drawing.Size(214, 22);
            this.comboBoxEditName.TabIndex = 2;
            // 
            // comboBoxEditFromStation
            // 
            this.comboBoxEditFromStation.Location = new System.Drawing.Point(431, 47);
            this.comboBoxEditFromStation.Name = "comboBoxEditFromStation";
            this.comboBoxEditFromStation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditFromStation.Size = new System.Drawing.Size(214, 22);
            this.comboBoxEditFromStation.TabIndex = 1;
            // 
            // comboBoxEditPerson
            // 
            this.comboBoxEditPerson.Location = new System.Drawing.Point(106, 47);
            this.comboBoxEditPerson.Name = "comboBoxEditPerson";
            this.comboBoxEditPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditPerson.Size = new System.Drawing.Size(214, 22);
            this.comboBoxEditPerson.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Location = new System.Drawing.Point(0, 153);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(984, 436);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "待申请发货权限信息";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(980, 411);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCheck,
            this.gridColumnShipper,
            this.gridColumnFromSt,
            this.gridColumnPlan,
            this.gridColumnDescription,
            this.gridColumnStatus});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumnCheck
            // 
            this.gridColumnCheck.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnCheck.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnCheck.Caption = "选中";
            this.gridColumnCheck.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumnCheck.Name = "gridColumnCheck";
            this.gridColumnCheck.Visible = true;
            this.gridColumnCheck.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumnShipper
            // 
            this.gridColumnShipper.Caption = "托运人名称";
            this.gridColumnShipper.Name = "gridColumnShipper";
            this.gridColumnShipper.OptionsColumn.AllowEdit = false;
            this.gridColumnShipper.Visible = true;
            this.gridColumnShipper.VisibleIndex = 1;
            // 
            // gridColumnFromSt
            // 
            this.gridColumnFromSt.Caption = "发站";
            this.gridColumnFromSt.Name = "gridColumnFromSt";
            this.gridColumnFromSt.OptionsColumn.AllowEdit = false;
            this.gridColumnFromSt.Visible = true;
            this.gridColumnFromSt.VisibleIndex = 2;
            // 
            // gridColumnPlan
            // 
            this.gridColumnPlan.Caption = "装车地点";
            this.gridColumnPlan.Name = "gridColumnPlan";
            this.gridColumnPlan.OptionsColumn.AllowEdit = false;
            this.gridColumnPlan.Visible = true;
            this.gridColumnPlan.VisibleIndex = 3;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "货物名称";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.OptionsColumn.AllowEdit = false;
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 4;
            // 
            // gridColumnStatus
            // 
            this.gridColumnStatus.Caption = "状态";
            this.gridColumnStatus.Name = "gridColumnStatus";
            this.gridColumnStatus.OptionsColumn.AllowEdit = false;
            this.gridColumnStatus.Visible = true;
            this.gridColumnStatus.VisibleIndex = 5;
            // 
            // XtraFormMain
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 590);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControlQuery);
            this.MaximizeBox = false;
            this.Name = "XtraFormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "乌鲁木齐铁路局";
            this.Shown += new System.EventHandler(this.XtraFormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.groupControlQuery.ResumeLayout(false);
            this.groupControlQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditFromStation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditName;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditFromStation;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditPerson;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonQuery;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnShipper;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFromSt;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPlan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStatus;
    }
}