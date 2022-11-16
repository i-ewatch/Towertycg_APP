using Towertycg_APP.Configuration;
using Towertycg_APP.Modules;

namespace Towertycg_APP.Views
{
    public partial class CellControl : Field4Control
    {
        public CellControl(CellSetting cellSetting, string DeviceName)
        {
            InitializeComponent();
            groupControl.Text = DeviceName;
            CellSetting = cellSetting;
        }
        public override void TextChange()
        {
            if (CellDevice != null)
            {
                lbl_InputTemp.Text = $"{CellDevice.InputTemp.ToString("0.##")} \xb0" + "C";
                lbl_InWetBulbTemp.Text = $"{CellDevice.InWetBulbTemp.ToString("0.##")} \xb0" + "C";
                lbl_InDewPointTemp.Text = $"{CellDevice.InDewPointTemp.ToString("0.##")} \xb0" + "C";
                lbl_InRelativeHumidity.Text = $"{CellDevice.InRelativeHumidity.ToString("0.##")} %";
                lbl_InAbsoluteHumidity.Text = $"{CellDevice.InAbsoluteHumidity.ToString("0.####")} g/m\xb3";
                lbl_InEnthalpy.Text = $"{CellDevice.InEnthalpy.ToString("0.##")} kJ/kg";
                lbl_OutputTemp.Text = $"{CellDevice.OutputTemp.ToString("0.##")} \xb0" + "C";
                lbl_OutWetBulbTemp.Text = $"{CellDevice.OutWetBulbTemp.ToString("0.##")} \xb0" + "C";
                lbl_OutDewPointTemp.Text = $"{CellDevice.OutDewPointTemp.ToString("0.##")} \xb0" + "C";
                lbl_OutRelativeHumidity.Text = $"{CellDevice.OutRelativeHumidity.ToString("0.##")} %";
                lbl_OutAbsoluteHumidity.Text = $"{CellDevice.OutAbsoluteHumidity.ToString("0.####")} g/m\xb3";
                lbl_OutEnthalpy.Text = $"{CellDevice.OutEnthalpy.ToString("0.##")} kJ/kg";
                if (CellDevice.ActionFlag)
                {
                    stateIndicatorComponent1.StateIndex = 3;
                }
                else
                {
                    stateIndicatorComponent1.StateIndex = 1;
                }
            }
        }
    }
}
