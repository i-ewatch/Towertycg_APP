using Towertycg_APP.Configuration;
using Towertycg_APP.Modules;

namespace Towertycg_APP.Views
{
    public partial class SetControl : Field4Control
    {
        public SetControl(SetSetting setSetting, string DeviceName)
        {
            InitializeComponent();
            groupControl.Text = DeviceName;
            SetSetting = setSetting;
        }
        public override void TextChange()
        {
            if (SetDevice != null)
            {
                lbl_InputTemp.Text = $"{SetDevice.InputTemp.ToString("0.##")} \xb0" + "C";
                lbl_OutputTemp.Text = $"{SetDevice.OutputTemp.ToString("0.##")} \xb0" + "C";
                lbl_InWetBulbTemp.Text = $"{SetDevice.InWetBulbTemp.ToString("0.##")} \xb0" + "C";
                lbl_InDewPointTemp.Text = $"{SetDevice.InDewPointTemp.ToString("0.##")} \xb0" + "C";
                lbl_InRelativeHumidity.Text = $"{SetDevice.InRelativeHumidity.ToString("0.##")} %";
                lbl_InAbsoluteHumidity.Text = $"{SetDevice.InAbsoluteHumidity.ToString("0.####")} kg/m\xb3";
                lbl_InEnthalpy.Text = $"{SetDevice.InEnthalpy.ToString("0.##")} kJ/kg";
                lbl_OutWetBulbTemp.Text = $"{SetDevice.OutWetBulbTemp.ToString("0.##")} \xb0" + "C";
                lbl_OutDewPointTemp.Text = $"{SetDevice.OutDewPointTemp.ToString("0.##")} \xb0" + "C";
                lbl_OutRelativeHumidity.Text = $"{SetDevice.OutRelativeHumidity.ToString("0.##")} %";
                lbl_OutAbsoluteHumidity.Text = $"{SetDevice.OutAbsoluteHumidity.ToString("0.####")} kg/m\xb3";
                lbl_OutEnthalpy.Text = $"{SetDevice.OutEnthalpy.ToString("0.##")} kJ/kg";
                lbl_HeatLoadRate.Text = $"{SetDevice.HeatLoadRate.ToString("0.##")} %";
                lbl_ElectricLoadRate.Text = $"{SetDevice.ElectricLoadRate.ToString("0.##")} %";
                lbl_Appr.Text = $"{SetDevice.Appr.ToString("0.##")} \xb0" + "C";
            }
        }
    }
}
