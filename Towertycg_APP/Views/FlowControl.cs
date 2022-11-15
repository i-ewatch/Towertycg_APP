using Towertycg_APP.Modules;
using Towertycg_APP.Protocols;

namespace Towertycg_APP.Views
{
    public partial class FlowControl : Field4Control
    {
        public FlowControl(AbsProtocol absProtocol, string DeviceName)
        {
            InitializeComponent();
            groupControl.Text = DeviceName;
            AbsProtocol = absProtocol;
        }
        public override void TextChange()
        {
            if (FlowDevice != null)
            {
                lbl_Flow.Text = $"{FlowDevice.Flow.ToString("0.##")} m\xb3" + "/h";
                lbl_FlowTotal.Text = $"{FlowDevice.FlowTotal.ToString("0.##")} m\xb3";
                lbl_InputTemp.Text = $"{FlowDevice.InputTemp.ToString("0.##")} \xb0" + "C";
                lbl_OutputTemp.Text = $"{FlowDevice.OutputTemp.ToString("0.##")} \xb0" + "C";
                lbl_Rang.Text = $"{FlowDevice.Rang.ToString("0.##")} \xb0" + "C";
                lbl_HeatloadRate.Text = $"{FlowDevice.HeatLoadRate.ToString("0.##")} %";
                if (FlowDevice.ConnectionFlag)
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
