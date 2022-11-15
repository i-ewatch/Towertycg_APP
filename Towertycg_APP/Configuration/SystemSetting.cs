using System;
using System.Collections.Generic;

namespace Towertycg_APP.Configuration
{
    /// <summary>
    /// 系統資訊
    /// </summary>
    public class SystemSetting
    {
        /// <summary>
        /// 總通道資訊
        /// </summary>
        public List<GatewaySetting> GatewaySettings { get; set; } = new List<GatewaySetting>();
    }
    /// <summary>
    /// 通道資訊
    /// </summary>
    public class GatewaySetting
    {
        /// <summary>
        /// 通道編碼
        /// </summary>
        public Guid Gateway_Number { get; set; }
        /// <summary>
        /// 通道位址
        /// </summary>
        public string Gateway_Location { get; set; }
        /// <summary>
        /// 通道Rate
        /// </summary>
        public int Gateway_Rate { get; set; }
        /// <summary>
        /// 通道類型
        /// </summary>
        public int Gateway_Type { get; set; }
        /// <summary>
        /// 通道名稱
        /// </summary>
        public string Gateway_Name { get; set; }
        /// <summary>
        /// 總設備資訊
        /// </summary>
        public List<DeviceSetting> DeviceSettings { get; set; } = new List<DeviceSetting>();
    }
    /// <summary>
    /// 設備資訊
    /// </summary>
    public class DeviceSetting
    {
        /// <summary>
        /// 設備編碼
        /// </summary>
        public Guid Device_Number { get; set; }
        /// <summary>
        /// 設備類型
        /// </summary>
        public int Device_Type { get; set; }
        /// <summary>
        /// 設備站號
        /// </summary>
        public int Device_ID { get; set; }
        /// <summary>
        /// 設備名稱
        /// </summary>
        public string Device_Name { get; set; }
        /// <summary>
        /// 進/出風旗標
        /// </summary>
        public bool In_Out_Flag { get; set; }
        /// <summary>
        /// 溫度較正值
        /// </summary>
        public List<decimal> TemperatureRegulate = new List<decimal>();
        /// <summary>
        /// 濕度較正值
        /// </summary>
        public List<decimal> HumidityRegulate = new List<decimal>();
        /// <summary>
        /// 最高溫度警報(溫溼度計)
        /// </summary>
        public decimal MaxTemp { get; set; } = 50;
        /// <summary>
        /// 最低溫度警報(溫溼度計)
        /// </summary>
        public decimal MinTemp { get; set; } = 5;
        /// <summary>
        /// 熱負載定值
        /// </summary>
        public decimal HeatLoad { get; set; } = 5;
        /// <summary>
        /// 額定功率(電表)
        /// </summary>
        public decimal RatedPower { get; set; }
        /// <summary>
        /// 最小判斷啟動電流
        /// </summary>
        public decimal MinCurrent { get; set; }
        /// <summary>
        /// 最高入水溫度警報(流量計)
        /// </summary>
        public decimal MaxInputTemp { get; set; } = 50;
        /// <summary>
        /// 最低入水溫度警報(流量計)
        /// </summary>
        public decimal MinInputTemp { get; set; } = 5;
        /// <summary>
        /// 最高出水溫度警報(流量計)
        /// </summary>
        public decimal MaxOutputTemp { get; set; } = 50;
        /// <summary>
        /// 最低出水溫度警報(流量計)
        /// </summary>
        public decimal MinOutputTemp { get; set; } = 5;
        /// <summary>
        /// 推播編碼
        /// </summary>
        public List<Guid> Notify_Number { get; set; } = new List<Guid>();
        /// <summary>
        /// 一座編碼
        /// </summary>
        public Guid Set_Number { get; set; }
        /// <summary>
        /// 一室編碼
        /// </summary>
        public Guid Cell_Number { get; set; }
        /// <summary>
        /// 一面編碼
        /// </summary>
        public int Noodle_Number { get; set; }
    }
}