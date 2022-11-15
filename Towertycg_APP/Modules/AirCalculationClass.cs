namespace Towertycg_APP.Modules
{
    public class AirCalculationClass
    {
        /// <summary>
        /// 海拔高度
        /// </summary>
        public double z { get; set; }
        /// <summary>
        /// 乾球溫度
        /// </summary>
        public double T_DB { get; set; }
        /// <summary>
        /// 相對溼度(%)
        /// </summary>
        public double RH { get; set; }
        /// <summary>
        /// 壓力
        /// </summary>
        public double P { get; set; }
        /// <summary>
        /// 飽和狀態之水蒸氣分壓
        /// </summary>
        public double PWS { get; set; }
        /// <summary>
        /// 水蒸氣分壓
        /// </summary>
        public double PW { get; set; }
        /// <summary>
        /// 濕度比
        /// </summary>
        public double W { get; set; }
        /// <summary>
        /// 飽和濕空氣之濕度比
        /// </summary>
        public double WS { get; set; }
        /// <summary>
        /// 濕空氣之焓值
        /// </summary>
        public double h { get; set; }
        /// <summary>
        /// 濕空氣之比容
        /// </summary>
        public double v { get; set; }
        /// <summary>
        /// 濕球溫度
        /// </summary>
        public double TWB { get; set; }
        /// <summary>
        /// 濕球溫度下，飽和狀態之水蒸氣分壓
        /// </summary>
        public double PWSS { get; set; }
        /// <summary>
        /// 濕球溫度下，飽和狀態之濕度比
        /// </summary>
        public double WSS { get; set; }
        /// <summary>
        /// 露點溫度
        /// </summary>
        public double Td { get; set; }
        /// <summary>
        /// 絕對溼度
        /// </summary>
        public double AH { get; set; }

    }
}
