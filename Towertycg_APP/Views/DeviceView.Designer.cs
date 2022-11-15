
namespace Towertycg_APP.Views
{
    partial class DeviceView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xscl_View = new DevExpress.XtraEditors.XtraScrollableControl();
            this.SuspendLayout();
            // 
            // xscl_View
            // 
            this.xscl_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xscl_View.Location = new System.Drawing.Point(0, 0);
            this.xscl_View.Name = "xscl_View";
            this.xscl_View.Size = new System.Drawing.Size(1022, 813);
            this.xscl_View.TabIndex = 0;
            // 
            // DeviceView
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xscl_View);
            this.Name = "DeviceView";
            this.Size = new System.Drawing.Size(1022, 813);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xscl_View;
    }
}
