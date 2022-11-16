using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using Towertycg_APP.Configuration;
using Towertycg_APP.Enums;
using Towertycg_APP.Modules;
using Towertycg_APP.Protocols;

namespace Towertycg_APP.Views
{
    public partial class DeviceView : Field4Control
    {
        /// <summary>
        /// 總物件
        /// </summary>
        private List<Field4Control> Field4Controls { get; set; } = new List<Field4Control>();
        private int CellIndex { get; set; } = 0;
        private int FlowIndex { get; set; } = 1;
        private int SenserIndex { get; set; } = 0;
        private int ElectricIndex { get; set; } = 0;
        public DeviceView(GroupSetting groupSetting, List<AbsProtocol> absProtocols)
        {
            InitializeComponent();
            GroupSetting = groupSetting;
            AbsProtocols = absProtocols;
            SetSetting setSetting = groupSetting.SetSettings.SingleOrDefault(g => g.Set_Number == absProtocols[0].DeviceSetting.Set_Number);
            if (setSetting != null)
            {
                SetControl setControl = new SetControl(setSetting, setSetting.Set_Name) { Location = new Point(5, 3), Tag = "Set" };
                Field4Controls.Add(setControl);
                xscl_View.Controls.Add(setControl);
                #region 建立流量計畫面
                List<AbsProtocol> Flow = AbsProtocols.Where(g => g.DeviceSetting.Set_Number == setSetting.Set_Number & g.DeviceSetting.Device_Type == 1).ToList();
                foreach (var flowitem in Flow)
                {
                    Device_Type type = (Device_Type)flowitem.DeviceSetting.Device_Type;
                    switch (type)
                    {
                        case Device_Type.CYUT2000:
                            {
                                FlowControl flowControl = new FlowControl(flowitem, $"{flowitem.DeviceSetting.Device_Name}")
                                { Location = new Point(5 + (628 * FlowIndex), 3), Tag = "Flow" };
                                Field4Controls.Add(flowControl);
                                xscl_View.Controls.Add(flowControl);
                                FlowIndex++;
                            }
                            break;
                    }
                }
                #endregion
                foreach (var cellitem in setSetting.CellSettings)
                {
                    #region 建立Cell畫面
                    CellControl cellControl = new CellControl(cellitem, cellitem.Cell_Name) { Location = new Point(5 + (460 * CellIndex), 275), Tag = "Cell" };//455, 302
                    Field4Controls.Add(cellControl);
                    xscl_View.Controls.Add(cellControl);
                    #endregion
                    #region 建立電表畫面
                    List<AbsProtocol> Electric = AbsProtocols.Where(g => g.DeviceSetting.Cell_Number == cellitem.Cell_Number & g.DeviceSetting.Device_Type == 2).ToList();
                    foreach (var electricitem in Electric)
                    {
                        Device_Type type = (Device_Type)electricitem.DeviceSetting.Device_Type;
                        switch (type)
                        {
                            case Device_Type.PA310:
                                {
                                    ElectricControl electricControl = new ElectricControl(electricitem, $"{cellitem.Cell_Name}_{electricitem.DeviceSetting.Device_Name}")
                                    { Location = new Point(5 + (460 * ElectricIndex), 583), Tag = "Electric" };//396, 292
                                    Field4Controls.Add(electricControl);
                                    xscl_View.Controls.Add(electricControl);
                                    ElectricIndex++;
                                }
                                break;
                        }
                    }
                    #endregion
                    #region 建立溫溼度畫面
                    SenserIndex = 0;
                    List<AbsProtocol> protocols = AbsProtocols.Where(g => g.DeviceSetting.Cell_Number == cellitem.Cell_Number).ToList();
                    foreach (var protocolitem in protocols)
                    {
                        Device_Type type = (Device_Type)protocolitem.DeviceSetting.Device_Type;
                        switch (type)
                        {
                            case Device_Type.VMS_3000_WS_N01:
                                {
                                    string TitleName = "";
                                    switch (protocolitem.DeviceSetting.Noodle_Number)
                                    {
                                        case 0:
                                            {
                                                TitleName = $"{cellitem.Cell_Name}_左側A面_{protocolitem.DeviceSetting.Device_Name}";
                                            }
                                            break;
                                        case 1:
                                            {
                                                TitleName = $"{cellitem.Cell_Name}_左側B面_{protocolitem.DeviceSetting.Device_Name}";
                                            }
                                            break;
                                        case 2:
                                            {
                                                TitleName = $"{cellitem.Cell_Name}_左側側面_{protocolitem.DeviceSetting.Device_Name}";
                                            }
                                            break;
                                        case 3:
                                            {
                                                TitleName = $"{cellitem.Cell_Name}_左側頂面_{protocolitem.DeviceSetting.Device_Name}";
                                            }
                                            break;
                                        case 4:
                                            {
                                                TitleName = $"{cellitem.Cell_Name}_右側A面_{protocolitem.DeviceSetting.Device_Name}";
                                            }
                                            break;
                                        case 5:
                                            {
                                                TitleName = $"{cellitem.Cell_Name}_右側B面_{protocolitem.DeviceSetting.Device_Name}";
                                            }
                                            break;
                                        case 6:
                                            {
                                                TitleName = $"{cellitem.Cell_Name}_右側側面_{protocolitem.DeviceSetting.Device_Name}";
                                            }
                                            break;
                                        case 7:
                                            {
                                                TitleName = $"{cellitem.Cell_Name}_右側頂面_{protocolitem.DeviceSetting.Device_Name}";
                                            }
                                            break;
                                    }

                                    SenserControl senserControl = new SenserControl(protocolitem, TitleName)
                                    { Location = new Point(5 + 460 * (CellIndex % 2), 880 + 195 * SenserIndex), Tag = "Senser" };//396, 192
                                    Field4Controls.Add(senserControl);
                                    xscl_View.Controls.Add(senserControl);
                                    SenserIndex++;
                                }
                                break;
                        }
                    }
                    #endregion
                    CellIndex++;
                }
            }
        }
        public override void TextChange()
        {
            foreach (var item in Field4Controls)
            {
                if (SetDevice != null)
                {
                    string Control = item.Tag.ToString();
                    switch (Control)
                    {
                        case "Set":
                            {
                                item.SetDevice = SetDevice;
                                item.TextChange();
                            }
                            break;
                        case "Cell":
                            {
                                CellDevice device = SetDevice.CellDevices.SingleOrDefault(g => g.Guid == item.CellSetting.Cell_Number);
                                if (device != null)
                                {
                                    item.CellDevice = device;
                                    item.TextChange();
                                }
                            }
                            break;
                        case "Senser":
                            {
                                if (SetDevice.CellDevices.Count > 0)
                                {
                                    SenserDevice device = SetDevice.CellDevices.SingleOrDefault(g => g.Guid == item.AbsProtocol.DeviceSetting.Cell_Number)
                                                                   .SenserDevices.SingleOrDefault(g => g.Guid == item.AbsProtocol.DeviceSetting.Device_Number);
                                    if (device != null)
                                    {
                                        item.SenserDevice = device;
                                        item.TextChange();
                                    }
                                }
                            }
                            break;
                        case "Flow":
                            {
                                if (SetDevice.CellDevices.Count > 0)
                                {
                                    FlowDevice device = SetDevice.FlowDvices.SingleOrDefault(g => g.Guid == item.AbsProtocol.DeviceSetting.Device_Number);
                                    if (device != null)
                                    {
                                        item.FlowDevice = device;
                                        item.TextChange();
                                    }
                                }
                            }
                            break;
                        case "Electric":
                            {
                                if (SetDevice.CellDevices.Count > 0)
                                {
                                    ElectricDevice device = SetDevice.CellDevices.SingleOrDefault(g => g.Guid == item.AbsProtocol.DeviceSetting.Cell_Number)
                                                                     .ElectricDvices.SingleOrDefault(g => g.Guid == item.AbsProtocol.DeviceSetting.Device_Number);
                                    if (device != null)
                                    {
                                        item.ElectricDevice = device;
                                        item.TextChange();
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
