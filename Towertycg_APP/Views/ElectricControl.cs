using Towertycg_APP.Modules;
using Towertycg_APP.Protocols;

namespace Towertycg_APP.Views
{
    public partial class ElectricControl : Field4Control
    {
        public ElectricControl(AbsProtocol absProtocol, string DeviceName)
        {
            InitializeComponent();
            groupControl.Text = DeviceName;
            AbsProtocol = absProtocol;
        }
        public override void TextChange()
        {
            if (ElectricDevice != null)
            {
                lbl_RV.Text = $"{ElectricDevice.RV.ToString("0.##")} V";
                lbl_SV.Text = $"{ElectricDevice.SV.ToString("0.##")} V";
                lbl_TV.Text = $"{ElectricDevice.TV.ToString("0.##")} V";
                lbl_RSV.Text = $"{ElectricDevice.RSV.ToString("0.##")} V";
                lbl_STV.Text = $"{ElectricDevice.STV.ToString("0.##")} V";
                lbl_TRV.Text = $"{ElectricDevice.TRV.ToString("0.##")} V";
                lbl_RA.Text = $"{ElectricDevice.RA.ToString("0.##")} A";
                lbl_SA.Text = $"{ElectricDevice.SA.ToString("0.##")} A";
                lbl_TA.Text = $"{ElectricDevice.TA.ToString("0.##")} A";
                lbl_PF.Text = $"{ElectricDevice.PF.ToString("0.##")}";
                lbl_KW.Text = $"{ElectricDevice.KW.ToString("0.##")} kW";
                lbl_KWH.Text = $"{ElectricDevice.KWH.ToString("0.##")} kWh";
                lbl_ElectricLoadRate.Text = $"{ElectricDevice.ElectricLoadRate.ToString("0.##")} %";
                if (ElectricDevice.ConnectionFlag)
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
