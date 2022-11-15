using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Towertycg_APP.Configuration;
using Towertycg_APP.Enums;
using Towertycg_APP.Modules;

namespace Towertycg_APP.Methods
{
    public class ExcelMethod
    {
        /// <summary>
        /// 開啟檔案
        /// </summary>
        private OpenFileDialog openFileDialog { get; set; }
        /// <summary>
        /// 載入檔案
        /// </summary>
        private XSSFWorkbook xworkbook { get; set; }
        /// <summary>
        /// 分頁數量
        /// </summary>
        private int SheetIndex { get; set; } = 0;
        /// <summary>
        /// 檔案名稱
        /// </summary>
        private string FileName { get; set; }
        /// <summary>
        /// 讀取系統資訊
        /// </summary>
        public SystemSetting SystemSetting { get; set; }
        private bool SystemFlag { get; set; } = false;
        /// <summary>
        /// 讀取群組資訊
        /// </summary>
        public GroupSetting GroupSetting { get; set; }
        private bool GroupFlag { get; set; } = false;
        /// <summary>
        /// 推播資訊
        /// </summary>
        public List<NotifySetting> NotifySettings { get; set; }
        private bool NotifyFlag { get; set; } = false;
        /// <summary>
        /// 設備資訊
        /// </summary>
        public List<UpdateClass> UpdateClasses { get; set; }
        /// <summary>
        /// 錯誤資訊
        /// </summary>
        public string ErrorStr
        {
            get
            {
                string error = "";
                if (!GroupFlag)
                {
                    error += "群組新增失敗 \r\n";
                }
                if (!SystemFlag)
                {
                    error += "系統新增失敗 \r\n";
                }
                if (!NotifyFlag)
                {
                    error += "推播新增失敗 \r\n";
                }
                return error;
            }
        }
        public bool Excel_Load()
        {
            SystemFlag = false;
            GroupFlag = false;
            NotifyFlag = false;
            SystemSetting = new SystemSetting();
            GroupSetting = new GroupSetting();
            NotifySettings = new List<NotifySetting>();
            try
            {
                openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "*.Xlsx| *.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = openFileDialog.FileName;
                    using (FileStream file = new FileStream($"{openFileDialog.FileName}", FileMode.Open, FileAccess.Read))
                    {
                        xworkbook = new XSSFWorkbook(file);//Excel檔案載入
                    }
                    SheetIndex = xworkbook.NumberOfSheets;//取得分頁數量
                    for (int Sheetnum = 0; Sheetnum < SheetIndex; Sheetnum++)
                    {
                        string SheetName = xworkbook.GetSheetName(Sheetnum).Trim();
                        var data = xworkbook.GetSheetAt(Sheetnum);//載入分頁資訊
                        switch (SheetName)
                        {
                            case "Group":
                                {
                                    for (int Rownum = 1; Rownum < data.LastRowNum + 1; Rownum++)
                                    {
                                        IRow row = data.GetRow(Rownum);
                                        if (row != null)
                                        {
                                            ICell setname = row.GetCell(0);
                                            ICell cellname = row.GetCell(1);
                                            if (GroupSetting.SetSettings.Count > 0)//有Set資料
                                            {
                                                SetSetting SetSetting = GroupSetting.SetSettings.SingleOrDefault(g => g.Set_Name == setname.ToString().Trim());
                                                if (SetSetting != null)//找到Set資料
                                                {
                                                    CellSetting CellSetting = SetSetting.CellSettings.SingleOrDefault(g => g.Cell_Name == cellname.ToString().Trim());
                                                    if (CellSetting == null)//沒找到Cell資料
                                                    {
                                                        SetSetting.CellSettings.Add(new CellSetting
                                                        {
                                                            Cell_Number = Guid.NewGuid(),
                                                            Cell_Name = cellname.ToString().Trim(),
                                                        });
                                                    }
                                                }
                                                else//沒找到Set資料
                                                {
                                                    SetSetting setSetting = new SetSetting
                                                    {
                                                        Set_Number = Guid.NewGuid(),
                                                        Set_Name = setname.ToString().Trim()
                                                    };
                                                    setSetting.CellSettings.Add(new CellSetting
                                                    {
                                                        Cell_Number = Guid.NewGuid(),
                                                        Cell_Name = cellname.ToString().Trim()
                                                    });
                                                    GroupSetting.SetSettings.Add(setSetting);
                                                }
                                            }
                                            else//無Set資料
                                            {
                                                SetSetting setSetting = new SetSetting
                                                {
                                                    Set_Number = Guid.NewGuid(),
                                                    Set_Name = setname.ToString().Trim()
                                                };
                                                setSetting.CellSettings.Add(new CellSetting
                                                {
                                                    Cell_Number = Guid.NewGuid(),
                                                    Cell_Name = cellname.ToString().Trim()
                                                });
                                                GroupSetting.SetSettings.Add(setSetting);
                                            }
                                        }
                                    }
                                    GroupFlag = true;
                                }
                                break;
                            case "Notify":
                                {
                                    for (int Rownum = 1; Rownum < data.LastRowNum + 1; Rownum++)
                                    {
                                        IRow row = data.GetRow(Rownum);
                                        if (row != null)
                                        {
                                            ICell notifyname = row.GetCell(0);
                                            ICell notifytoken = row.GetCell(1);
                                            NotifySettings.Add(new NotifySetting
                                            {
                                                Notify_Number = Guid.NewGuid(),
                                                NotifyName = notifyname.ToString().Trim(),
                                                Token = notifytoken.ToString().Trim()
                                            });
                                        }
                                    }
                                    NotifyFlag = true;
                                }
                                break;
                            case "Gateway":
                                {
                                    for (int Rownum = 1; Rownum < data.LastRowNum + 1; Rownum++)
                                    {
                                        IRow row = data.GetRow(Rownum);
                                        if (row != null)
                                        {
                                            ICell gatewaylocation = row.GetCell(0);
                                            ICell gatewayrate = row.GetCell(1);
                                            ICell gatewaytype = row.GetCell(2);
                                            ICell gatewayname = row.GetCell(3);
                                            if (SystemSetting.GatewaySettings.Count > 0)
                                            {
                                                GatewaySetting GatewaySetting = SystemSetting.GatewaySettings.SingleOrDefault(g => g.Gateway_Location == gatewaylocation.ToString().Trim() && g.Gateway_Rate == Convert.ToInt32(gatewayrate.ToString().Trim()) && g.Gateway_Name == gatewayname.ToString().Trim());
                                                if (GatewaySetting == null)
                                                {
                                                    SystemSetting.GatewaySettings.Add(new GatewaySetting
                                                    {
                                                        Gateway_Number = Guid.NewGuid(),
                                                        Gateway_Location = gatewaylocation.ToString().Trim(),
                                                        Gateway_Rate = Convert.ToInt32(gatewayrate.ToString().Trim()),
                                                        Gateway_Type = Convert.ToInt32(gatewaytype.ToString().Trim()),
                                                        Gateway_Name = gatewayname.ToString().Trim()
                                                    });
                                                }
                                            }
                                            else
                                            {
                                                SystemSetting.GatewaySettings.Add(new GatewaySetting
                                                {
                                                    Gateway_Number = Guid.NewGuid(),
                                                    Gateway_Location = gatewaylocation.ToString().Trim(),
                                                    Gateway_Rate = Convert.ToInt32(gatewayrate.ToString().Trim()),
                                                    Gateway_Type = Convert.ToInt32(gatewaytype.ToString().Trim()),
                                                    Gateway_Name = gatewayname.ToString().Trim()
                                                });
                                            }
                                        }
                                    }
                                }
                                break;
                            case "Device":
                                {
                                    for (int Rownum = 1; Rownum < data.LastRowNum + 1; Rownum++)
                                    {
                                        IRow row = data.GetRow(Rownum);
                                        if (row != null)
                                        {
                                            ICell gatewayname = row.GetCell(0);
                                            ICell setname = row.GetCell(1);
                                            ICell cellname = row.GetCell(2);
                                            ICell noodlename = row.GetCell(3);
                                            ICell notifyname = row.GetCell(4);
                                            ICell devicetype = row.GetCell(5);
                                            ICell deviceID = row.GetCell(6);
                                            ICell deviceName = row.GetCell(7);
                                            ICell inoutflag = row.GetCell(8);
                                            ICell temperatureregulate = row.GetCell(9);
                                            ICell humidityregulate = row.GetCell(10);
                                            ICell maxtemp = row.GetCell(11);
                                            ICell mintemp = row.GetCell(12);
                                            ICell ratepower = row.GetCell(13);
                                            ICell mincurrent = row.GetCell(14);
                                            ICell heatload = row.GetCell(15);
                                            ICell maxinputtemp = row.GetCell(16);
                                            ICell mininputtemp = row.GetCell(17);
                                            ICell maxoutputtemp = row.GetCell(18);
                                            ICell minoutputtemp = row.GetCell(19);
                                            if (gatewayname != null && devicetype != null && deviceID != null && deviceName!= null)
                                            {
                                                GatewaySetting GatewaySetting = SystemSetting.GatewaySettings.SingleOrDefault(g => g.Gateway_Name == gatewayname.ToString().Trim());
                                                if (GatewaySetting != null)
                                                {
                                                    Device_Type type = (Device_Type)Convert.ToInt32(devicetype.ToString().Trim());
                                                    switch (type)
                                                    {
                                                        case Device_Type.VMS_3000_WS_N01:
                                                            {
                                                                GatewaySetting.DeviceSettings.Add(new DeviceSetting
                                                                {
                                                                    Device_Number = Guid.NewGuid(),
                                                                    Device_Type = Convert.ToInt32(devicetype.ToString().Trim()),
                                                                    Device_ID = Convert.ToInt32(deviceID.ToString().Trim()),
                                                                    Device_Name = deviceName.ToString().Trim(),
                                                                    In_Out_Flag = Convert.ToBoolean(Convert.ToInt32(inoutflag.ToString().Trim())),
                                                                    MaxTemp = Convert.ToDecimal(maxtemp.ToString().Trim()),
                                                                    MinTemp = Convert.ToDecimal(mintemp.ToString().Trim()),
                                                                });
                                                                DeviceSetting DeviceSetting = GatewaySetting.DeviceSettings.SingleOrDefault(g => g.Device_ID == Convert.ToInt32(deviceID.ToString().Trim()) && g.Device_Name == deviceName.ToString().Trim());
                                                                if (temperatureregulate != null)
                                                                {
                                                                    List<decimal> temperature = Array.ConvertAll(temperatureregulate.ToString().Trim().Split(','), decimal.Parse).ToList();
                                                                    DeviceSetting.TemperatureRegulate = temperature;
                                                                }
                                                                if (humidityregulate != null)
                                                                {
                                                                    List<decimal> humidity = Array.ConvertAll(humidityregulate.ToString().Trim().Split(','), decimal.Parse).ToList();
                                                                    DeviceSetting.HumidityRegulate = humidity;
                                                                }
                                                                if (GroupSetting.SetSettings.Count > 0)
                                                                {
                                                                    SetSetting setSetting = GroupSetting.SetSettings.SingleOrDefault(g => g.Set_Name == setname.ToString().Trim());
                                                                    if (setSetting != null)
                                                                    {
                                                                        DeviceSetting.Set_Number = setSetting.Set_Number;
                                                                        CellSetting cellSetting = setSetting.CellSettings.SingleOrDefault(g => g.Cell_Name == cellname.ToString().Trim());
                                                                        if (cellSetting != null)
                                                                        {
                                                                            DeviceSetting.Cell_Number = cellSetting.Cell_Number;
                                                                            if (string.IsNullOrEmpty(noodlename.ToString()))
                                                                            {
                                                                                DeviceSetting.Noodle_Number = 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                DeviceSetting.Noodle_Number = Convert.ToInt32(noodlename.ToString());
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case Device_Type.CYUT2000:
                                                            {
                                                                GatewaySetting.DeviceSettings.Add(new DeviceSetting
                                                                {
                                                                    Device_Number = Guid.NewGuid(),
                                                                    Device_Type = Convert.ToInt32(devicetype.ToString().Trim()),
                                                                    Device_ID = Convert.ToInt32(deviceID.ToString().Trim()),
                                                                    Device_Name = deviceName.ToString().Trim(),
                                                                    HeatLoad = Convert.ToDecimal(heatload.ToString().Trim()),
                                                                    MaxInputTemp = Convert.ToDecimal(maxinputtemp.ToString().Trim()),
                                                                    MinInputTemp = Convert.ToDecimal(mininputtemp.ToString().Trim()),
                                                                    MaxOutputTemp = Convert.ToDecimal(maxoutputtemp.ToString().Trim()),
                                                                    MinOutputTemp = Convert.ToDecimal(minoutputtemp.ToString().Trim()),
                                                                });
                                                                DeviceSetting DeviceSetting = GatewaySetting.DeviceSettings.SingleOrDefault(g => g.Device_ID == Convert.ToInt32(deviceID.ToString().Trim()) && g.Device_Name == deviceName.ToString().Trim());
                                                                if (temperatureregulate != null)
                                                                {
                                                                    List<decimal> temperature = Array.ConvertAll(temperatureregulate.ToString().Trim().Split(','), decimal.Parse).ToList();
                                                                    DeviceSetting.TemperatureRegulate = temperature;
                                                                }
                                                                if (GroupSetting.SetSettings.Count > 0)
                                                                {
                                                                    SetSetting setSetting = GroupSetting.SetSettings.SingleOrDefault(g => g.Set_Name == setname.ToString().Trim());
                                                                    if (setSetting != null)
                                                                    {
                                                                        DeviceSetting.Set_Number = setSetting.Set_Number;
                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case Device_Type.PA310:
                                                            {
                                                                GatewaySetting.DeviceSettings.Add(new DeviceSetting
                                                                {
                                                                    Device_Number = Guid.NewGuid(),
                                                                    Device_Type = Convert.ToInt32(devicetype.ToString().Trim()),
                                                                    Device_ID = Convert.ToInt32(deviceID.ToString().Trim()),
                                                                    Device_Name = deviceName.ToString().Trim(),
                                                                    RatedPower = Convert.ToDecimal(ratepower.ToString().Trim()),
                                                                    MinCurrent = Convert.ToDecimal(mincurrent.ToString().Trim()),
                                                                });
                                                                DeviceSetting DeviceSetting = GatewaySetting.DeviceSettings.SingleOrDefault(g => g.Device_ID == Convert.ToInt32(deviceID.ToString().Trim()) && g.Device_Name == deviceName.ToString().Trim());
                                                                if (GroupSetting.SetSettings.Count > 0)
                                                                {
                                                                    SetSetting setSetting = GroupSetting.SetSettings.SingleOrDefault(g => g.Set_Name == setname.ToString().Trim());
                                                                    if (setSetting != null)
                                                                    {
                                                                        DeviceSetting.Set_Number = setSetting.Set_Number;
                                                                        CellSetting cellSetting = setSetting.CellSettings.SingleOrDefault(g => g.Cell_Name == cellname.ToString().Trim());
                                                                        if (cellSetting != null)
                                                                        {
                                                                            DeviceSetting.Cell_Number = cellSetting.Cell_Number;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    SystemFlag = true;
                                }
                                break;
                        }
                    }
                    UpdateClasses = new List<UpdateClass>();
                    foreach (var Setitem in GroupSetting.SetSettings)
                    {
                        SetDevice setDevice = new SetDevice
                        {
                            Guid = Setitem.Set_Number
                        };
                        foreach (var Cellitem in Setitem.CellSettings)
                        {
                            CellDevice cellDevice = new CellDevice();
                            foreach (var gatewayitem in SystemSetting.GatewaySettings)
                            {
                                List<DeviceSetting> deviceSettings = gatewayitem.DeviceSettings.Where(w => w.Set_Number == Setitem.Set_Number).ToList();
                                if (deviceSettings.Count > 0)
                                {
                                    cellDevice.Guid = Cellitem.Cell_Number;
                                    foreach (var deviceitem in deviceSettings)
                                    {
                                        Device_Type device_Type = (Device_Type)deviceitem.Device_Type;
                                        switch (device_Type)
                                        {
                                            case Device_Type.VMS_3000_WS_N01:
                                                {
                                                    if (deviceitem.Cell_Number == Cellitem.Cell_Number)
                                                    {
                                                        cellDevice.SenserDevices.Add(new SenserDevice
                                                        {
                                                            Guid = deviceitem.Device_Number,
                                                            Noodle_Number = deviceitem.Noodle_Number,
                                                            DeviceType = deviceitem.Device_Type,
                                                        });
                                                    }
                                                }
                                                break;
                                            case Device_Type.CYUT2000:
                                                {
                                                    if (setDevice.FlowDvices.Count > 0)
                                                    {
                                                        FlowDevice flowDevice = setDevice.FlowDvices.SingleOrDefault(s => s.Guid == deviceitem.Device_Number);
                                                        if (flowDevice == null)
                                                        {
                                                            setDevice.FlowDvices.Add(new FlowDevice
                                                            {
                                                                Guid = deviceitem.Device_Number,
                                                            });
                                                        }
                                                    }
                                                    else
                                                    {
                                                        setDevice.FlowDvices.Add(new FlowDevice
                                                        {
                                                            Guid = deviceitem.Device_Number,
                                                        });
                                                    }
                                                }
                                                break;
                                            case Device_Type.PA310:
                                                {
                                                    if (deviceitem.Cell_Number == Cellitem.Cell_Number)
                                                    {
                                                        cellDevice.ElectricDvices.Add(new ElectricDevice
                                                        {
                                                            Guid = deviceitem.Device_Number,
                                                            DeviceType = deviceitem.Device_Type
                                                        });
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            setDevice.CellDevices.Add(cellDevice);
                        }
                        UpdateClass updateClass = new UpdateClass();
                        updateClass.SetDevice = setDevice;
                        UpdateClasses.Add(updateClass);
                    }
                    if (string.IsNullOrEmpty(ErrorStr))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { Log.Error(ex, $"資料匯入失敗  檔案名稱 : {FileName}"); return false; }
        }
    }
}
