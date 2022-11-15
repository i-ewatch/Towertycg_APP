using System;
using Towertycg_APP.Methods;
using Towertycg_APP.Modules;

namespace Towertycg_APP.Protocols
{
    public abstract class SenserData : AbsProtocol
    {
        /// <summary>
        /// 倍率
        /// </summary>
        public int Rate { get; set; }
        #region 溫度
        /// <summary>
        /// 溫度記錄點
        /// </summary>
        public decimal _temp { get; set; }
        /// <summary>
        /// 溫度
        /// </summary>
        public decimal Temp
        {
            get { return _temp; }
            set
            {
                if (_temp != value)
                {
                    if (value > DeviceSetting.MaxTemp && DeviceSetting.MaxTemp != 0) { tempIndex = 2; }
                    else if (value < DeviceSetting.MinTemp && DeviceSetting.MinTemp != 0) { tempIndex = 1; }
                    else if (value < DeviceSetting.MaxTemp && value > DeviceSetting.MinTemp && DeviceSetting.MaxTemp != 0 && DeviceSetting.MinTemp != 0) { tempIndex = 0; }
                    _temp = value;
                }
            }
        }
        /// <summary>
        /// 過去溫度狀態點
        /// </summary>
        public int tempFlag { get; set; } = 0;
        /// <summary>
        /// 延遲發送時間
        /// </summary>
        private DateTime tempDate { get; set; } = new DateTime();
        /// <summary>
        /// 溫度告警狀態點
        /// </summary>
        private int tempIndex
        {
            set
            {
                if (value != _tempIndex)
                {
                    tempDate = DateTime.Now;
                    _tempIndex = value;
                }
                else
                {
                    TimeSpan timeSpan = DateTime.Now.Subtract(tempDate);
                    if (timeSpan.TotalSeconds > 10 && tempFlag != value) //延遲十秒發送及確認無重複發送
                    {
                        switch (value)
                        {
                            case 0:
                                {
                                    AlarmNotifySender($"\r設備名稱:{DeviceSetting.Device_Name}\r環境溫度恢復正常");
                                    tempFlag = 0;
                                }
                                break;
                            case 1:
                                {
                                    AlarmNotifySender($"\r設備名稱:{DeviceSetting.Device_Name}\r環境溫度過低警報");
                                    tempFlag = 1;
                                }
                                break;
                            case 2:
                                {
                                    AlarmNotifySender($"\r設備名稱:{DeviceSetting.Device_Name}\r環境溫度過高警報");
                                    tempFlag = 2;
                                }
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 溫度告警狀態記錄點
        /// </summary>
        private int _tempIndex { get; set; } = 0;
        #endregion
        /// <summary>
        /// 濕度
        /// </summary>
        public decimal Humidity { get; set; }

        /// <summary>
        /// 計算環境資訊(暫存)
        /// </summary>
        public AirCalculationClass _AirCalculationClass { get; set; } = new AirCalculationClass();
        /// <summary>
        /// 計算環境資訊
        /// </summary>
        public AirCalculationClass AirCalculationClass
        {
            get
            {
                if (ConnectionFlag)
                {
                    _AirCalculationClass = AirCalculationMethod.Calculation(0, Convert.ToDouble(Temp), Convert.ToDouble(Humidity));
                    return _AirCalculationClass;
                }
                else
                {
                    return _AirCalculationClass;
                }
            }
        }
    }
}
