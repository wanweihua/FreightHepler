namespace FreightHepler
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class CustomComboBox : XtraUserControl
    {
        private IContainer components = null;
        private ListBoxControl listBoxControl1;
        private PopupContainerControl popupContainerControl1;
        private PopupContainerEdit popupContainerEdit1;

        public event EventHandler OnRemoveItem;

        public event EventHandler OnSlectetChanged;

        public CustomComboBox()
        {
            this.InitializeComponent();
            this.popupContainerControl1.BorderStyle = BorderStyles.NoBorder;
            Application.Idle += new EventHandler(this.Application_Idle);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            if (this.listBoxControl1.ItemCount == 0)
            {
                this.popupContainerEdit1.Properties.PopupControl = null;
            }
            else
            {
                this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.AllowDrop = true;
            this.popupContainerEdit1.CausesValidation = false;
            this.popupContainerEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupContainerEdit1.Location = new System.Drawing.Point(0, 0);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Properties.PopupSizeable = false;
            this.popupContainerEdit1.Properties.ShowPopupCloseButton = false;
            this.popupContainerEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.popupContainerEdit1.Size = new System.Drawing.Size(118, 22);
            this.popupContainerEdit1.TabIndex = 0;
            this.popupContainerEdit1.TabStop = false;
            this.popupContainerEdit1.Popup += new System.EventHandler(this.popupContainerEdit1_Popup);
            this.popupContainerEdit1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.popupContainerEdit1_KeyUp);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.popupContainerControl1.Controls.Add(this.listBoxControl1);
            this.popupContainerControl1.Location = new System.Drawing.Point(53, 68);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(135, 99);
            this.popupContainerControl1.TabIndex = 1;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControl1.Location = new System.Drawing.Point(2, 2);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(131, 95);
            this.listBoxControl1.TabIndex = 0;
            this.listBoxControl1.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.listBoxControl1_DrawItem);
            this.listBoxControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.popupContainerEdit1_KeyUp);
            this.listBoxControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxControl1_MouseClick);
            this.listBoxControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxControl1_MouseMove);
            // 
            // CustomComboBox
            // 
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.popupContainerEdit1);
            this.MaximumSize = new System.Drawing.Size(300, 21);
            this.MinimumSize = new System.Drawing.Size(75, 21);
            this.Name = "CustomComboBox";
            this.Size = new System.Drawing.Size(118, 21);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            this.ResumeLayout(false);

        }

        private void listBoxControl1_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            //Image image = Resource.web_icon_009;
            //Graphics graphics = e.Graphics;
            //this.listBoxControl1.PointToClient(Control.MousePosition);
            //if (e.State.ToString().Contains("Selected"))
            //{
            //    graphics.FillRectangle(new SolidBrush(SystemColors.GradientActiveCaption), e.Bounds);
            //    graphics.DrawImage(image, new RectangleF((float) (e.Bounds.Right - 20), (float) e.Bounds.Y, (float) e.Bounds.Height, (float) e.Bounds.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            //}
            //graphics.DrawString(e.Item.ToString(), this.Font, Brushes.Black, (PointF) e.Bounds.Location);
            //e.Handled = true;
        }

        private void listBoxControl1_MouseClick(object sender, MouseEventArgs e)
        {
            int num2 = (this.listBoxControl1.ItemHeight == 0) ? 0x11 : this.listBoxControl1.ItemHeight;
            int index = this.listBoxControl1.SelectedIndex = e.Y / num2;
            if (this.listBoxControl1.SelectedIndex != -1)
            {
                if ((this.listBoxControl1.SelectedIndex == index) && (e.X > (this.listBoxControl1.Width - 20)))
                {
                    if (this.OnRemoveItem != null)
                    {
                        this.OnRemoveItem(this.listBoxControl1.Items[index], null);
                    }
                    this.listBoxControl1.Items.RemoveAt(index);
                    this.listBoxControl1.FindForm().Height = ((num2 + 2) * this.listBoxControl1.ItemCount) + 5;
                }
                else
                {
                    this.popupContainerEdit1.Text = this.listBoxControl1.Items[this.listBoxControl1.SelectedIndex].ToString();
                    this.popupContainerEdit1.ClosePopup();
                    if (this.OnSlectetChanged != null)
                    {
                        this.OnSlectetChanged(this.listBoxControl1.Items[this.listBoxControl1.SelectedIndex], null);
                    }
                }
            }
        }

        private void listBoxControl1_MouseMove(object sender, MouseEventArgs e)
        {
            int num = (this.listBoxControl1.ItemHeight == 0) ? 0x11 : this.listBoxControl1.ItemHeight;
            if (this.listBoxControl1.SelectedIndex != (e.Y / num))
            {
                this.listBoxControl1.SelectedIndex = e.Y / num;
            }
        }

        private void popupContainerEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode == Keys.Enter) && (this.listBoxControl1.SelectedIndex >= 0)) && (this.OnSlectetChanged != null))
            {
                this.OnSlectetChanged(this.listBoxControl1.Items[this.listBoxControl1.SelectedIndex], null);
            }
        }

        private void popupContainerEdit1_Popup(object sender, EventArgs e)
        {
            int num = (this.listBoxControl1.ItemHeight == 0) ? 0x11 : this.listBoxControl1.ItemHeight;
            this.listBoxControl1.FindForm().Height = ((num + 2) * this.listBoxControl1.ItemCount) + 5;
        }

        public ListBoxItemCollection Items
        {
            get
            {
                return this.listBoxControl1.Items;
            }
        }

        public int PopupWidth
        {
            get
            {
                return this.popupContainerControl1.Width;
            }
            set
            {
                this.popupContainerControl1.Width = value;
            }
        }

        //public string  Text //weihua.wan
        //{
        //    get
        //    {
        //        return this.popupContainerEdit1.Text;
        //    }
        //    set
        //    {
        //        this.popupContainerEdit1.Text = value;
        //    }
        //}
    }
}

