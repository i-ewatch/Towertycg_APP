using NModbus;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using Towertycg_APP.Configuration;
using Towertycg_APP.Enums;
using Towertycg_APP.Modules;
using Towertycg_APP.Protocols;
using Towertycg_APP.Protocols.ElectricDevice;
using Towertycg_APP.Protocols.FlowDevice;
using Towertycg_APP.Protocols.SenserDevice;

namespace Towertycg_APP.Components
{
    public partial class TCPComponent : Field4Component
    {
        public TCPComponent(GatewaySetting gatewaySetting, List<DeviceSetting> deviceSettings, List<NotifySetting> notifySettings, GroupSetting groupSetting)
        {
            InitializeComponent();
            GatewaySetting = gatewaySetting;
            DeviceSettings = deviceSettings;
            NotifySettings = notifySettings;
            GroupSetting = groupSetting;
        }

        public TCPComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                foreach (var item in DeviceSettings)
                {
                    Device_Type device = (Device_Type)item.Device_Type;
                    switch (device)
                    {
                        case Device_Type.VMS_3000_WS_N01:
                            {
                                VMS_3000_WS_N01Protocol protocol = new VMS_3000_WS_N01Protocol(GatewaySetting.Gateway_Number, item, NotifySettings);
                                AbsProtocols.Add(protocol);
                            }
                            break;
                        case Device_Type.CYUT2000:
                            {
                                CYUT2000Protocol protocol = new CYUT2000Protocol(GatewaySetting.Gateway_Number, item, NotifySettings);
                                AbsProtocols.Add(protocol);
                            }
                            break;
                        case Device_Type.PA310:
                            {
                                PA310Protocol protocol = new PA310Protocol(GatewaySetting.Gateway_Number, item, NotifySettings);
                                AbsProtocols.Add(protocol);
                            }
                            break;
                    }
                }
                Factory = new ModbusFactory();
                ReadThread = new Thread(Analysis);
                ReadThread.Start();
            }
            else
            {
                if (ReadThread != null)
                {
                    ReadThread.Abort();
                }
            }
        }
        private void Analysis()
        {
            while (myWorkState)
            {
                TimeSpan ReadSpan = DateTime.Now.Subtract(ReadTime);
                if (ReadSpan.TotalMilliseconds >= 5000)
                {
                    #region 通訊
                    foreach (var item in AbsProtocols)
                    {
                        if (myWorkState)
                        {
                            try
                            {
                                using (TcpClient client = new TcpClient(GatewaySetting.Gateway_Location, GatewaySetting.Gateway_Rate))
                                {
                                    master = Factory.CreateMaster(client);//建立TCP通訊
                                    master.Transport.Retries = 0;
                                    master.Transport.ReadTimeout = 2000;
                                    master.Transport.WriteTimeout = 2000;
                                    item.Read_Protocol(master);
                                    Thread.Sleep(10);
                                };
                                ReadTime = DateTime.Now;
                            }
                            catch (ThreadAbortException) { }
                            catch (Exception ex)
                            {
                                ReadTime = DateTime.Now;
                                Log.Error(ex, $"通訊失敗 IP:{GatewaySetting.Gateway_Location} Port:{GatewaySetting.Gateway_Rate} ");
                            }
                        }
                    }
                    #endregion
                    #region 上傳資料整合
                    if (myWorkState)
                    {
                        try
                        {
                            SetDevice _setDevice = new SetDevice();
                            _setDevice.Guid = GatewaySetting.DeviceSettings[0].Set_Number;
                            foreach (var Deviceitem in GatewaySetting.DeviceSettings)
                            {
                                if (_setDevice.CellDevices.Count > 0)
                                {
                                    if (Deviceitem.Cell_Number.ToString() != "00000000-0000-0000-0000-000000000000")
                                    {
                                        CellDevice cellDevice = _setDevice.CellDevices.SingleOrDefault(g => g.Guid == Deviceitem.Cell_Number);
                                        if (cellDevice == null)
                                        {
                                            _setDevice.CellDevices.Add
                                            (new CellDevice
                                            {
                                                Guid = Deviceitem.Cell_Number
                                            }
                                            );
                                        }
                                    }
                                }
                                else
                                {
                                    _setDevice.CellDevices.Add
                                        (new CellDevice
                                        {
                                            Guid = Deviceitem.Cell_Number
                                        }
                                        );
                                }
                            }
                            #region 設備類型判別與整合
                            foreach (var pitem in AbsProtocols)
                            {
                                if (pitem.DeviceSetting.Set_Number == _setDevice.Guid)
                                {
                                    Device_Type device = (Device_Type)pitem.DeviceSetting.Device_Type;
                                    switch (device)
                                    {
                                        case Device_Type.VMS_3000_WS_N01:
                                            {
                                                SenserData deviceData = (SenserData)pitem;
                                                if (deviceData != null)
                                                {
                                                    var cellitem = _setDevice.CellDevices.SingleOrDefault(g => g.Guid == deviceData.DeviceSetting.Cell_Number);
                                                    if (cellitem != null)
                                                    {
                                                        SenserDevice data = new SenserDevice
                                                        {
                                                            Guid = deviceData.DeviceSetting.Device_Number,
                                                            DeviceType = deviceData.DeviceSetting.Device_Type,
                                                            Temp = deviceData.Temp,
                                                            Humidity = deviceData.Humidity,
                                                            WetBulbTemp = Convert.ToDecimal(deviceData.AirCalculationClass.TWB),
                                                            DewPointTemp = Convert.ToDecimal(deviceData.AirCalculationClass.Td),
                                                            AbsoluteHumidity = Convert.ToDecimal(deviceData.AirCalculationClass.AH),
                                                            Enthalpy = Convert.ToDecimal(deviceData.AirCalculationClass.h),
                                                            MaxTemp = deviceData.DeviceSetting.MaxTemp,
                                                            MinTemp = deviceData.DeviceSetting.MinTemp,
                                                            In_Out_Flag = deviceData.DeviceSetting.In_Out_Flag,
                                                            ErrorType = deviceData.tempFlag,
                                                            Noodle_Number = deviceData.DeviceSetting.Noodle_Number,
                                                            ConnectionFlag = deviceData.ConnectionFlag
                                                        };
                                                        cellitem.SenserDevices.Add(data);
                                                    }
                                                }
                                            }
                                            break;
                                        case Device_Type.CYUT2000:
                                            {
                                                FlowData deviceData = (FlowData)pitem;
                                                if (deviceData != null)
                                                {
                                                    FlowDevice data = new FlowDevice
                                                    {
                                                        Guid = deviceData.DeviceSetting.Device_Number,
                                                        DeviceType = deviceData.DeviceSetting.Device_Type,
                                                        Flow = deviceData.Flow,
                                                        FlowTotal = deviceData.FlowTotal,
                                                        InputTemp = deviceData.InputTemp,
                                                        OutputTemp = deviceData.OutputTemp,
                                                        Rang = deviceData.TempRang,
                                                        HeatLoadRate = deviceData.HeatLoadRate,
                                                        HeatLoad = deviceData.DeviceSetting.HeatLoad,
                                                        MaxInputTemp = deviceData.DeviceSetting.MaxInputTemp,
                                                        MinInputTemp = deviceData.DeviceSetting.MinInputTemp,
                                                        MaxOutputTemp = deviceData.DeviceSetting.MaxOutputTemp,
                                                        MinOutputTemp = deviceData.DeviceSetting.MinOutputTemp,
                                                        InErrorType = deviceData.inputTempFlag,
                                                        OutErrorType = deviceData.outputTempFlag,
                                                        ConnectionFlag = deviceData.ConnectionFlag
                                                    };
                                                    _setDevice.FlowDvices.Add(data);
                                                }
                                            }
                                            break;
                                        case Device_Type.PA310:
                                            {
                                                ElectricData deviceData = (ElectricData)pitem;
                                                var cellitem = _setDevice.CellDevices.SingleOrDefault(g => g.Guid == deviceData.DeviceSetting.Cell_Number);
                                                cellitem.ActionFlag = deviceData.ActionFlag;
                                                if (deviceData != null)
                                                {
                                                    ElectricDevice data = new ElectricDevice
                                                    {
                                                        Guid = deviceData.DeviceSetting.Device_Number,
                                                        DeviceType = deviceData.DeviceSetting.Device_Type,
                                                        RV = deviceData.RV,
                                                        SV = deviceData.SV,
                                                        TV = deviceData.TV,
                                                        RSV = deviceData.RSV,
                                                        STV = deviceData.STV,
                                                        TRV = deviceData.TRV,
                                                        RA = deviceData.RA,
                                                        SA = deviceData.SA,
                                                        TA = deviceData.TA,
                                                        AAvg = deviceData.AAVG,
                                                        KW = deviceData.KW,
                                                        PF = deviceData.PFE,
                                                        KWH = deviceData.KWH,
                                                        HZ = deviceData.HZ,
                                                        RatedPower = deviceData.DeviceSetting.RatedPower,
                                                        MinCurrent = deviceData.DeviceSetting.MinCurrent,
                                                        ActionFlag = deviceData.ActionFlag,
                                                        ElectricLoadRate = deviceData.ElectricLoadRate,
                                                        ErrorType = 0,
                                                        ConnectionFlag = deviceData.ConnectionFlag
                                                    };
                                                    cellitem.ElectricDvices.Add(data);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            #endregion
                            #region Cell整合
                            foreach (var Cellitem in _setDevice.CellDevices)
                            {
                                int InputIndex = 0;
                                int OutputIndex = 0;
                                decimal InputTemp = 0;
                                decimal OutputTemp = 0;
                                decimal InWetBulbTemp = 0;
                                decimal InDewPointTemp = 0;
                                decimal InRelativeHumidity = 0;
                                decimal InAbsoluteHumidity = 0;
                                decimal InEnthalpy = 0;
                                decimal OutWetBulbTemp = 0;
                                decimal OutDewPointTemp = 0;
                                decimal OutRelativeHumidity = 0;
                                decimal OutAbsoluteHumidity = 0;
                                decimal OutEnthalpy = 0;
                                if (Cellitem.SenserDevices.Count > 0)
                                {
                                    foreach (var item in Cellitem.SenserDevices)
                                    {
                                        if (item.In_Out_Flag)
                                        {
                                            OutputTemp += Convert.ToDecimal(item.Temp);
                                            OutWetBulbTemp += Convert.ToDecimal(item.WetBulbTemp);
                                            OutDewPointTemp += Convert.ToDecimal(item.DewPointTemp);
                                            OutRelativeHumidity += Convert.ToDecimal(item.Humidity);
                                            OutAbsoluteHumidity += Convert.ToDecimal(item.AbsoluteHumidity);
                                            OutEnthalpy += Convert.ToDecimal(item.Enthalpy);
                                            OutputIndex++;
                                        }
                                        else
                                        {
                                            InputTemp += Convert.ToDecimal(item.Temp);
                                            InWetBulbTemp += Convert.ToDecimal(item.WetBulbTemp);
                                            InDewPointTemp += Convert.ToDecimal(item.DewPointTemp);
                                            InRelativeHumidity += Convert.ToDecimal(item.Humidity);
                                            InAbsoluteHumidity += Convert.ToDecimal(item.AbsoluteHumidity);
                                            InEnthalpy += Convert.ToDecimal(item.Enthalpy);
                                            InputIndex++;
                                        }
                                    }
                                    Cellitem.InputTemp = InputTemp / InputIndex;
                                    Cellitem.InWetBulbTemp = InWetBulbTemp / InputIndex;
                                    Cellitem.InDewPointTemp = InDewPointTemp / InputIndex;
                                    Cellitem.InRelativeHumidity = InRelativeHumidity / InputIndex;
                                    Cellitem.InAbsoluteHumidity = InAbsoluteHumidity / InputIndex;
                                    Cellitem.InEnthalpy = InEnthalpy / InputIndex;

                                    Cellitem.OutputTemp = OutputTemp / OutputIndex;
                                    Cellitem.OutWetBulbTemp = OutWetBulbTemp / OutputIndex;
                                    Cellitem.OutDewPointTemp = OutDewPointTemp / OutputIndex;
                                    Cellitem.OutRelativeHumidity = OutRelativeHumidity / OutputIndex;
                                    Cellitem.OutAbsoluteHumidity = OutAbsoluteHumidity / OutputIndex;
                                    Cellitem.OutEnthalpy = OutEnthalpy / OutputIndex;
                                    if (Cellitem.ElectricDvices.Count > 0)
                                    {
                                        Cellitem.ActionFlag = Cellitem.ElectricDvices[0].ActionFlag;
                                    }
                                }
                            }
                            #endregion
                            #region Set整合
                            if (_setDevice.CellDevices.Count > 0)
                            {
                                List<CellDevice> cellDevices = _setDevice.CellDevices.Where(g => g.ActionFlag).ToList();
                                if (cellDevices.Count > 0)
                                {
                                    int ElectricIndex = 0;
                                    decimal InputTemp = 0;
                                    decimal OutputTemp = 0;
                                    decimal InWetBulbTemp = 0;
                                    decimal InDewPointTemp = 0;
                                    decimal InRelativeHumidity = 0;
                                    decimal InAbsoluteHumidity = 0;
                                    decimal InEnthalpy = 0;
                                    decimal OutWetBulbTemp = 0;
                                    decimal OutDewPointTemp = 0;
                                    decimal OutRelativeHumidity = 0;
                                    decimal OutAbsoluteHumidity = 0;
                                    decimal OutEnthalpy = 0;
                                    decimal HeatLoadRate = 0;
                                    decimal ElectricLoadRate = 0;
                                    decimal OutputFlowTemp = 0;
                                    foreach (var cellitem in cellDevices)
                                    {
                                        InputTemp += cellitem.InputTemp;
                                        OutputTemp += cellitem.OutputTemp;
                                        InWetBulbTemp += cellitem.InWetBulbTemp;
                                        InDewPointTemp += cellitem.InDewPointTemp;
                                        InRelativeHumidity += cellitem.InRelativeHumidity;
                                        InAbsoluteHumidity += cellitem.InAbsoluteHumidity;
                                        InEnthalpy += cellitem.InEnthalpy;

                                        OutWetBulbTemp += cellitem.OutWetBulbTemp;
                                        OutDewPointTemp += cellitem.OutDewPointTemp;
                                        OutRelativeHumidity += cellitem.OutRelativeHumidity;
                                        OutAbsoluteHumidity += cellitem.OutAbsoluteHumidity;
                                        OutEnthalpy += cellitem.OutEnthalpy;
                                        foreach (var Electricitem in cellitem.ElectricDvices)
                                        {
                                            ElectricLoadRate += Electricitem.ElectricLoadRate;
                                            ElectricIndex++;
                                        }
                                    }
                                    foreach (var item in _setDevice.FlowDvices)
                                    {
                                        HeatLoadRate += item.HeatLoadRate;
                                        OutputFlowTemp += item.OutputTemp;
                                    }
                                    if (cellDevices.Count > 0)
                                    {
                                        _setDevice.OutputTemp = OutputTemp / cellDevices.Count();
                                        _setDevice.InputTemp = InputTemp / cellDevices.Count();
                                        _setDevice.InWetBulbTemp = InWetBulbTemp / cellDevices.Count();
                                        _setDevice.InDewPointTemp = InDewPointTemp / cellDevices.Count();
                                        _setDevice.InRelativeHumidity = InRelativeHumidity / cellDevices.Count();
                                        _setDevice.InAbsoluteHumidity = InAbsoluteHumidity / cellDevices.Count();
                                        _setDevice.InEnthalpy = InEnthalpy / cellDevices.Count();

                                        _setDevice.OutWetBulbTemp = OutWetBulbTemp / cellDevices.Count();
                                        _setDevice.OutDewPointTemp = OutDewPointTemp / cellDevices.Count();
                                        _setDevice.OutRelativeHumidity = OutRelativeHumidity / cellDevices.Count();
                                        _setDevice.OutAbsoluteHumidity = OutAbsoluteHumidity / cellDevices.Count();
                                        _setDevice.OutEnthalpy = OutEnthalpy / cellDevices.Count();
                                    }
                                    if (_setDevice.FlowDvices.Count > 0)
                                    {
                                        _setDevice.HeatLoadRate = HeatLoadRate / _setDevice.FlowDvices.Count();
                                        OutputFlowTemp = OutputFlowTemp / _setDevice.FlowDvices.Count();
                                        _setDevice.Appr = OutputFlowTemp - _setDevice.InWetBulbTemp;
                                    }
                                    _setDevice.ElectricLoadRate = ElectricLoadRate/ ElectricIndex;
                                    _setDevice.SendTime = DateTime.Now;
                                }
                                else
                                {
                                    _setDevice.OutputTemp = 0;
                                    _setDevice.InputTemp = 0;
                                    _setDevice.InWetBulbTemp = 0;
                                    _setDevice.InDewPointTemp = 0;
                                    _setDevice.InRelativeHumidity = 0;
                                    _setDevice.InAbsoluteHumidity = 0;
                                    _setDevice.InEnthalpy = 0;
                                    _setDevice.OutWetBulbTemp = 0;
                                    _setDevice.OutDewPointTemp = 0;
                                    _setDevice.OutRelativeHumidity = 0;
                                    _setDevice.OutAbsoluteHumidity = 0;
                                    _setDevice.OutEnthalpy = 0;
                                    _setDevice.HeatLoadRate = 0;
                                    _setDevice.ElectricLoadRate = 0;
                                    _setDevice.Appr = 0;
                                    _setDevice.SendTime = DateTime.Now;
                                }
                            }
                            else
                            {
                                _setDevice.OutputTemp = 0;
                                _setDevice.InputTemp = 0;
                                _setDevice.InWetBulbTemp = 0;
                                _setDevice.InDewPointTemp = 0;
                                _setDevice.InRelativeHumidity = 0;
                                _setDevice.InAbsoluteHumidity = 0;
                                _setDevice.InEnthalpy = 0;
                                _setDevice.OutWetBulbTemp = 0;
                                _setDevice.OutDewPointTemp = 0;
                                _setDevice.OutRelativeHumidity = 0;
                                _setDevice.OutAbsoluteHumidity = 0;
                                _setDevice.OutEnthalpy = 0;
                                _setDevice.HeatLoadRate = 0;
                                _setDevice.ElectricLoadRate = 0;
                                _setDevice.Appr = 0;
                                _setDevice.SendTime = DateTime.Now;
                            }
                            #endregion
                            if (UpdateClass == null)
                            {
                                UpdateClass = new UpdateClass();
                            }
                            UpdateClass.SetDevice = _setDevice;
                        }
                        catch (ThreadAbortException) { }
                        catch (Exception ex)
                        {

                            Log.Error(ex, $"上傳資料整合失敗");
                        }
                    }
                    #endregion
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }
    }
}
