
namespace Towertycg_APP.Views
{
    partial class ElectricControl
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
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState5 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState6 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState7 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState8 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateIndicatorGauge1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.stateIndicatorComponent1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.lbl_TRV = new DevExpress.XtraEditors.LabelControl();
            this.lbl_STV = new DevExpress.XtraEditors.LabelControl();
            this.lbl_RSV = new DevExpress.XtraEditors.LabelControl();
            this.lbl_TV = new DevExpress.XtraEditors.LabelControl();
            this.lbl_SV = new DevExpress.XtraEditors.LabelControl();
            this.lbl_RV = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_RA = new DevExpress.XtraEditors.LabelControl();
            this.lbl_SA = new DevExpress.XtraEditors.LabelControl();
            this.lbl_TA = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_KWH = new DevExpress.XtraEditors.LabelControl();
            this.lbl_KW = new DevExpress.XtraEditors.LabelControl();
            this.lbl_PF = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_ElectricLoadRate = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl.AppearanceCaption.Options.UseFont = true;
            this.groupControl.Controls.Add(this.lbl_ElectricLoadRate);
            this.groupControl.Controls.Add(this.labelControl11);
            this.groupControl.Controls.Add(this.lbl_KWH);
            this.groupControl.Controls.Add(this.lbl_KW);
            this.groupControl.Controls.Add(this.lbl_PF);
            this.groupControl.Controls.Add(this.labelControl16);
            this.groupControl.Controls.Add(this.labelControl15);
            this.groupControl.Controls.Add(this.labelControl14);
            this.groupControl.Controls.Add(this.lbl_TA);
            this.groupControl.Controls.Add(this.lbl_SA);
            this.groupControl.Controls.Add(this.lbl_RA);
            this.groupControl.Controls.Add(this.labelControl10);
            this.groupControl.Controls.Add(this.labelControl9);
            this.groupControl.Controls.Add(this.labelControl8);
            this.groupControl.Controls.Add(this.gaugeControl1);
            this.groupControl.Controls.Add(this.lbl_TRV);
            this.groupControl.Controls.Add(this.lbl_STV);
            this.groupControl.Controls.Add(this.lbl_RSV);
            this.groupControl.Controls.Add(this.lbl_TV);
            this.groupControl.Controls.Add(this.lbl_SV);
            this.groupControl.Controls.Add(this.lbl_RV);
            this.groupControl.Controls.Add(this.labelControl7);
            this.groupControl.Controls.Add(this.labelControl6);
            this.groupControl.Controls.Add(this.labelControl5);
            this.groupControl.Controls.Add(this.labelControl4);
            this.groupControl.Controls.Add(this.labelControl3);
            this.groupControl.Controls.Add(this.labelControl2);
            this.groupControl.Controls.Add(this.labelControl1);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl.Location = new System.Drawing.Point(0, 0);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(396, 292);
            this.groupControl.TabIndex = 4;
            this.groupControl.Text = "N/A";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(76, 21);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(40, 40);
            this.gaugeControl1.TabIndex = 22;
            // 
            // stateIndicatorGauge1
            // 
            this.stateIndicatorGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 28, 28);
            this.stateIndicatorGauge1.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.stateIndicatorComponent1});
            this.stateIndicatorGauge1.Name = "stateIndicatorGauge1";
            // 
            // stateIndicatorComponent1
            // 
            this.stateIndicatorComponent1.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.stateIndicatorComponent1.Name = "stateIndicatorComponent1";
            this.stateIndicatorComponent1.Size = new System.Drawing.SizeF(200F, 200F);
            this.stateIndicatorComponent1.StateIndex = 0;
            indicatorState5.Name = "State1";
            indicatorState5.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight1;
            indicatorState6.Name = "State2";
            indicatorState6.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight2;
            indicatorState7.Name = "State3";
            indicatorState7.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight3;
            indicatorState8.Name = "State4";
            indicatorState8.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight4;
            this.stateIndicatorComponent1.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState5,
            indicatorState6,
            indicatorState7,
            indicatorState8});
            // 
            // lbl_TRV
            // 
            this.lbl_TRV.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_TRV.Appearance.Options.UseFont = true;
            this.lbl_TRV.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_TRV.Location = new System.Drawing.Point(289, 149);
            this.lbl_TRV.Name = "lbl_TRV";
            this.lbl_TRV.Size = new System.Drawing.Size(102, 19);
            this.lbl_TRV.TabIndex = 15;
            this.lbl_TRV.Text = "N/A";
            // 
            // lbl_STV
            // 
            this.lbl_STV.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_STV.Appearance.Options.UseFont = true;
            this.lbl_STV.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_STV.Location = new System.Drawing.Point(289, 110);
            this.lbl_STV.Name = "lbl_STV";
            this.lbl_STV.Size = new System.Drawing.Size(102, 19);
            this.lbl_STV.TabIndex = 14;
            this.lbl_STV.Text = "N/A";
            // 
            // lbl_RSV
            // 
            this.lbl_RSV.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_RSV.Appearance.Options.UseFont = true;
            this.lbl_RSV.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_RSV.Location = new System.Drawing.Point(289, 71);
            this.lbl_RSV.Name = "lbl_RSV";
            this.lbl_RSV.Size = new System.Drawing.Size(102, 19);
            this.lbl_RSV.TabIndex = 13;
            this.lbl_RSV.Text = "N/A";
            // 
            // lbl_TV
            // 
            this.lbl_TV.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_TV.Appearance.Options.UseFont = true;
            this.lbl_TV.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_TV.Location = new System.Drawing.Point(89, 149);
            this.lbl_TV.Name = "lbl_TV";
            this.lbl_TV.Size = new System.Drawing.Size(102, 19);
            this.lbl_TV.TabIndex = 12;
            this.lbl_TV.Text = "N/A";
            // 
            // lbl_SV
            // 
            this.lbl_SV.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_SV.Appearance.Options.UseFont = true;
            this.lbl_SV.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_SV.Location = new System.Drawing.Point(89, 110);
            this.lbl_SV.Name = "lbl_SV";
            this.lbl_SV.Size = new System.Drawing.Size(102, 19);
            this.lbl_SV.TabIndex = 11;
            this.lbl_SV.Text = "N/A";
            // 
            // lbl_RV
            // 
            this.lbl_RV.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_RV.Appearance.Options.UseFont = true;
            this.lbl_RV.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_RV.Location = new System.Drawing.Point(89, 71);
            this.lbl_RV.Name = "lbl_RV";
            this.lbl_RV.Size = new System.Drawing.Size(102, 19);
            this.lbl_RV.TabIndex = 10;
            this.lbl_RV.Text = "N/A";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(6, 188);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 19);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "R相電流";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(206, 149);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(58, 19);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "T線電壓";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(206, 110);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(57, 19);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "S線電壓";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(206, 71);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 19);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "R線電壓";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(6, 149);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 19);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "T相電壓";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(6, 110);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 19);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "S相電壓";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(6, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "R相電壓";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(6, 227);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(57, 19);
            this.labelControl8.TabIndex = 23;
            this.labelControl8.Text = "S相電流";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(6, 32);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(64, 19);
            this.labelControl9.TabIndex = 24;
            this.labelControl9.Text = "連線狀態";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(6, 266);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(58, 19);
            this.labelControl10.TabIndex = 25;
            this.labelControl10.Text = "T相電流";
            // 
            // lbl_RA
            // 
            this.lbl_RA.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_RA.Appearance.Options.UseFont = true;
            this.lbl_RA.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_RA.Location = new System.Drawing.Point(89, 188);
            this.lbl_RA.Name = "lbl_RA";
            this.lbl_RA.Size = new System.Drawing.Size(102, 19);
            this.lbl_RA.TabIndex = 26;
            this.lbl_RA.Text = "N/A";
            // 
            // lbl_SA
            // 
            this.lbl_SA.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_SA.Appearance.Options.UseFont = true;
            this.lbl_SA.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_SA.Location = new System.Drawing.Point(89, 227);
            this.lbl_SA.Name = "lbl_SA";
            this.lbl_SA.Size = new System.Drawing.Size(102, 19);
            this.lbl_SA.TabIndex = 27;
            this.lbl_SA.Text = "N/A";
            // 
            // lbl_TA
            // 
            this.lbl_TA.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_TA.Appearance.Options.UseFont = true;
            this.lbl_TA.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_TA.Location = new System.Drawing.Point(89, 266);
            this.lbl_TA.Name = "lbl_TA";
            this.lbl_TA.Size = new System.Drawing.Size(102, 19);
            this.lbl_TA.TabIndex = 28;
            this.lbl_TA.Text = "N/A";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(206, 188);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(64, 19);
            this.labelControl14.TabIndex = 29;
            this.labelControl14.Text = "功率因數";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(205, 227);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(64, 19);
            this.labelControl15.TabIndex = 30;
            this.labelControl15.Text = "瞬間功率";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Location = new System.Drawing.Point(205, 266);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(64, 19);
            this.labelControl16.TabIndex = 31;
            this.labelControl16.Text = "累積功率";
            // 
            // lbl_KWH
            // 
            this.lbl_KWH.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_KWH.Appearance.Options.UseFont = true;
            this.lbl_KWH.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_KWH.Location = new System.Drawing.Point(289, 266);
            this.lbl_KWH.Name = "lbl_KWH";
            this.lbl_KWH.Size = new System.Drawing.Size(102, 19);
            this.lbl_KWH.TabIndex = 34;
            this.lbl_KWH.Text = "N/A";
            // 
            // lbl_KW
            // 
            this.lbl_KW.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_KW.Appearance.Options.UseFont = true;
            this.lbl_KW.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_KW.Location = new System.Drawing.Point(289, 227);
            this.lbl_KW.Name = "lbl_KW";
            this.lbl_KW.Size = new System.Drawing.Size(102, 19);
            this.lbl_KW.TabIndex = 33;
            this.lbl_KW.Text = "N/A";
            // 
            // lbl_PF
            // 
            this.lbl_PF.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_PF.Appearance.Options.UseFont = true;
            this.lbl_PF.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_PF.Location = new System.Drawing.Point(289, 188);
            this.lbl_PF.Name = "lbl_PF";
            this.lbl_PF.Size = new System.Drawing.Size(102, 19);
            this.lbl_PF.TabIndex = 32;
            this.lbl_PF.Text = "N/A";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(205, 32);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(64, 19);
            this.labelControl11.TabIndex = 35;
            this.labelControl11.Text = "電負載率";
            // 
            // lbl_ElectricLoadRate
            // 
            this.lbl_ElectricLoadRate.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_ElectricLoadRate.Appearance.Options.UseFont = true;
            this.lbl_ElectricLoadRate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_ElectricLoadRate.Location = new System.Drawing.Point(289, 32);
            this.lbl_ElectricLoadRate.Name = "lbl_ElectricLoadRate";
            this.lbl_ElectricLoadRate.Size = new System.Drawing.Size(102, 19);
            this.lbl_ElectricLoadRate.TabIndex = 36;
            this.lbl_ElectricLoadRate.Text = "N/A";
            // 
            // ElectricControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl);
            this.Name = "ElectricControl";
            this.Size = new System.Drawing.Size(396, 292);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent stateIndicatorComponent1;
        private DevExpress.XtraEditors.LabelControl lbl_TRV;
        private DevExpress.XtraEditors.LabelControl lbl_STV;
        private DevExpress.XtraEditors.LabelControl lbl_RSV;
        private DevExpress.XtraEditors.LabelControl lbl_TV;
        private DevExpress.XtraEditors.LabelControl lbl_SV;
        private DevExpress.XtraEditors.LabelControl lbl_RV;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl lbl_KWH;
        private DevExpress.XtraEditors.LabelControl lbl_KW;
        private DevExpress.XtraEditors.LabelControl lbl_PF;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl lbl_TA;
        private DevExpress.XtraEditors.LabelControl lbl_SA;
        private DevExpress.XtraEditors.LabelControl lbl_RA;
        private DevExpress.XtraEditors.LabelControl lbl_ElectricLoadRate;
        private DevExpress.XtraEditors.LabelControl labelControl11;
    }
}
