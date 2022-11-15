
namespace Towertycg_APP.Views
{
    partial class SenserControl
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
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState1 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState2 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState3 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState4 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateIndicatorGauge1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.stateIndicatorComponent1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Enthalpy = new DevExpress.XtraEditors.LabelControl();
            this.lbl_AbsoluteHumidity = new DevExpress.XtraEditors.LabelControl();
            this.lbl_RelativeHumidity = new DevExpress.XtraEditors.LabelControl();
            this.lbl_DewPointTemp = new DevExpress.XtraEditors.LabelControl();
            this.lbl_WetBulbTemp = new DevExpress.XtraEditors.LabelControl();
            this.lbl_InputTemp = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            this.groupControl.Controls.Add(this.gaugeControl1);
            this.groupControl.Controls.Add(this.labelControl8);
            this.groupControl.Controls.Add(this.lbl_Enthalpy);
            this.groupControl.Controls.Add(this.lbl_AbsoluteHumidity);
            this.groupControl.Controls.Add(this.lbl_RelativeHumidity);
            this.groupControl.Controls.Add(this.lbl_DewPointTemp);
            this.groupControl.Controls.Add(this.lbl_WetBulbTemp);
            this.groupControl.Controls.Add(this.lbl_InputTemp);
            this.groupControl.Controls.Add(this.labelControl7);
            this.groupControl.Controls.Add(this.labelControl6);
            this.groupControl.Controls.Add(this.labelControl5);
            this.groupControl.Controls.Add(this.labelControl4);
            this.groupControl.Controls.Add(this.labelControl3);
            this.groupControl.Controls.Add(this.labelControl1);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl.Location = new System.Drawing.Point(0, 0);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(396, 192);
            this.groupControl.TabIndex = 2;
            this.groupControl.Text = "N/A";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(97, 25);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(40, 40);
            this.gaugeControl1.TabIndex = 24;
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
            indicatorState1.Name = "State1";
            indicatorState1.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight1;
            indicatorState2.Name = "State2";
            indicatorState2.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight2;
            indicatorState3.Name = "State3";
            indicatorState3.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight3;
            indicatorState4.Name = "State4";
            indicatorState4.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight4;
            this.stateIndicatorComponent1.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState1,
            indicatorState2,
            indicatorState3,
            indicatorState4});
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(14, 36);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(64, 19);
            this.labelControl8.TabIndex = 23;
            this.labelControl8.Text = "連線狀態";
            // 
            // lbl_Enthalpy
            // 
            this.lbl_Enthalpy.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_Enthalpy.Appearance.Options.UseFont = true;
            this.lbl_Enthalpy.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Enthalpy.Location = new System.Drawing.Point(288, 78);
            this.lbl_Enthalpy.Name = "lbl_Enthalpy";
            this.lbl_Enthalpy.Size = new System.Drawing.Size(102, 19);
            this.lbl_Enthalpy.TabIndex = 16;
            this.lbl_Enthalpy.Text = "N/A";
            // 
            // lbl_AbsoluteHumidity
            // 
            this.lbl_AbsoluteHumidity.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_AbsoluteHumidity.Appearance.Options.UseFont = true;
            this.lbl_AbsoluteHumidity.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_AbsoluteHumidity.Location = new System.Drawing.Point(97, 162);
            this.lbl_AbsoluteHumidity.Name = "lbl_AbsoluteHumidity";
            this.lbl_AbsoluteHumidity.Size = new System.Drawing.Size(102, 19);
            this.lbl_AbsoluteHumidity.TabIndex = 15;
            this.lbl_AbsoluteHumidity.Text = "N/A";
            // 
            // lbl_RelativeHumidity
            // 
            this.lbl_RelativeHumidity.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_RelativeHumidity.Appearance.Options.UseFont = true;
            this.lbl_RelativeHumidity.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_RelativeHumidity.Location = new System.Drawing.Point(288, 162);
            this.lbl_RelativeHumidity.Name = "lbl_RelativeHumidity";
            this.lbl_RelativeHumidity.Size = new System.Drawing.Size(102, 19);
            this.lbl_RelativeHumidity.TabIndex = 14;
            this.lbl_RelativeHumidity.Text = "N/A";
            // 
            // lbl_DewPointTemp
            // 
            this.lbl_DewPointTemp.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_DewPointTemp.Appearance.Options.UseFont = true;
            this.lbl_DewPointTemp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_DewPointTemp.Location = new System.Drawing.Point(288, 120);
            this.lbl_DewPointTemp.Name = "lbl_DewPointTemp";
            this.lbl_DewPointTemp.Size = new System.Drawing.Size(102, 19);
            this.lbl_DewPointTemp.TabIndex = 13;
            this.lbl_DewPointTemp.Text = "N/A";
            // 
            // lbl_WetBulbTemp
            // 
            this.lbl_WetBulbTemp.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_WetBulbTemp.Appearance.Options.UseFont = true;
            this.lbl_WetBulbTemp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_WetBulbTemp.Location = new System.Drawing.Point(97, 120);
            this.lbl_WetBulbTemp.Name = "lbl_WetBulbTemp";
            this.lbl_WetBulbTemp.Size = new System.Drawing.Size(102, 19);
            this.lbl_WetBulbTemp.TabIndex = 12;
            this.lbl_WetBulbTemp.Text = "N/A";
            // 
            // lbl_InputTemp
            // 
            this.lbl_InputTemp.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_InputTemp.Appearance.Options.UseFont = true;
            this.lbl_InputTemp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_InputTemp.Location = new System.Drawing.Point(97, 78);
            this.lbl_InputTemp.Name = "lbl_InputTemp";
            this.lbl_InputTemp.Size = new System.Drawing.Size(102, 19);
            this.lbl_InputTemp.TabIndex = 10;
            this.lbl_InputTemp.Text = "N/A";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(205, 78);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(32, 19);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "熱焓";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(14, 162);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 19);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "絕對溼度";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(205, 162);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(64, 19);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "相對溼度";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(205, 120);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 19);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "露點溫度";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(14, 120);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 19);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "溼球溫度";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(14, 78);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "溫度";
            // 
            // SenserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl);
            this.Name = "SenserControl";
            this.Size = new System.Drawing.Size(396, 192);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl;
        private DevExpress.XtraEditors.LabelControl lbl_Enthalpy;
        private DevExpress.XtraEditors.LabelControl lbl_AbsoluteHumidity;
        private DevExpress.XtraEditors.LabelControl lbl_RelativeHumidity;
        private DevExpress.XtraEditors.LabelControl lbl_DewPointTemp;
        private DevExpress.XtraEditors.LabelControl lbl_WetBulbTemp;
        private DevExpress.XtraEditors.LabelControl lbl_InputTemp;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent stateIndicatorComponent1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}
