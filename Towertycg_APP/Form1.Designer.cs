
namespace Towertycg_APP
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.bbtn_ImportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bbtn_Login = new DevExpress.XtraBars.BarButtonItem();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.xtcl_DeviceView = new DevExpress.XtraTab.XtraTabControl();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcl_DeviceView)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbtn_ImportExcel,
            this.bbtn_Login});
            this.fluentFormDefaultManager1.MaxItemId = 2;
            // 
            // bbtn_ImportExcel
            // 
            this.bbtn_ImportExcel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbtn_ImportExcel.Caption = "匯入檔案";
            this.bbtn_ImportExcel.Id = 0;
            this.bbtn_ImportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtn_ImportExcel.ImageOptions.Image")));
            this.bbtn_ImportExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtn_ImportExcel.ImageOptions.LargeImage")));
            this.bbtn_ImportExcel.Name = "bbtn_ImportExcel";
            this.bbtn_ImportExcel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbtn_Login
            // 
            this.bbtn_Login.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbtn_Login.Caption = "登入";
            this.bbtn_Login.Id = 1;
            this.bbtn_Login.Name = "bbtn_Login";
            this.bbtn_Login.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbtn_ImportExcel,
            this.bbtn_Login});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1078, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.bbtn_Login);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.bbtn_ImportExcel);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "Login.png");
            this.imageCollection.Images.SetKeyName(1, "Admin.png");
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // xtcl_DeviceView
            // 
            this.xtcl_DeviceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcl_DeviceView.Location = new System.Drawing.Point(0, 31);
            this.xtcl_DeviceView.LookAndFeel.UseDefaultLookAndFeel = false;
            this.xtcl_DeviceView.Name = "xtcl_DeviceView";
            this.xtcl_DeviceView.Size = new System.Drawing.Size(1078, 736);
            this.xtcl_DeviceView.TabIndex = 3;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Towertycg_App";
            this.notifyIcon.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 767);
            this.Controls.Add(this.xtcl_DeviceView);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Towertycg_App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcl_DeviceView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.BarButtonItem bbtn_ImportExcel;
        private DevExpress.XtraBars.BarButtonItem bbtn_Login;
        private DevExpress.Utils.ImageCollection imageCollection;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraTab.XtraTabControl xtcl_DeviceView;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

