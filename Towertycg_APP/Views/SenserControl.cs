using Towertycg_APP.Modules;
using Towertycg_APP.Protocols;

namespace Towertycg_APP.Views
{
    public partial class SenserControl : Field4Control
    {
        public SenserControl(AbsProtocol absProtocol, string DeviceName)
        {
            InitializeComponent();
            groupControl.Text = DeviceName;
            AbsProtocol = absProtocol;
        }
        public override void TextChange()
        {
            if (SenserDevice != null)
            {
                lbl_InputTemp.Text = $"{SenserDevice.Temp.ToString("0.##")} \xb0" + "C";
                lbl_WetBulbTemp.Text = $"{SenserDevice.WetBulbTemp.ToString("0.##")} \xb0" + "C";
                lbl_DewPointTemp.Text = $"{SenserDevice.DewPointTemp.ToString("0.##")} \xb0" + "C";
                lbl_RelativeHumidity.Text = $"{SenserDevice.Humidity.ToString("0.##")} %";
                lbl_AbsoluteHumidity.Text = $"{SenserDevice.AbsoluteHumidity.ToString("0.####")} g/m\xb3";
                lbl_Enthalpy.Text = $"{SenserDevice.Enthalpy.ToString("0.##")} kJ/kg";
                if (SenserDevice.ConnectionFlag)
                {
                    stateIndicatorComponent1.StateIndex = 3;
                }
                else
                {
                    stateIndicatorComponent1.StateIndex = 1;
                }
            }
            else
            {
                stateIndicatorComponent1.StateIndex = 1;
            }
        }
    }
}
