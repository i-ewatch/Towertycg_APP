using System;

namespace Towertycg_APP.Protocols
{
    public abstract class FlowData : AbsProtocol
    {
        private decimal _flow { get; set; }
        /// <summary>
        /// 順間流量
        /// </summary>
        public decimal Flow
        {
            get { return _flow; }
            set
            {
                if (value < 0)
                {
                    _flow = 0;
                }
                else
                {
                    _flow = value;
                }
            }
        }
        /// <summary>
        /// 累積流量
        /// </summary>
        public decimal FlowTotal { get; set; }
        #region 回水溫度

        /// <summary>
        /// 回水溫度記錄點
        /// </summary>
        public decimal _inputTemp { get; set; }
        /// <summary>
        /// 回水溫度
        /// </summary>
        public decimal InputTemp
        {
            get { return _inputTemp; }
            set
            {
                if (_inputTemp != value)
                {
                    if (value > DeviceSetting.MaxTemp && DeviceSetting.MaxTemp != 0) { inputtempIndex = 2; }
                    else if (value < DeviceSetting.MinTemp && DeviceSetting.MinTemp != 0) { inputtempIndex = 1; }
                    else if (value < DeviceSetting.MaxTemp && value > DeviceSetting.MinTemp && DeviceSetting.MaxTemp != 0 && DeviceSetting.MinTemp != 0) { inputtempIndex = 0; }
                    _inputTemp = value;
                }
            }
        }
        /// <summary>
        /// 過去回水溫度狀態點
        /// </summary>
        public int inputTempFlag { get; set; } = 0;
        /// <summary>
        /// 回水溫度延遲發送時間
        /// </summary>
        private DateTime inputtempDate { get; set; } = new DateTime();
        /// <summary>
        /// 回水溫度告警狀態點
        /// </summary>
        private int inputtempIndex
        {
            set
            {
                if (value != _inputtempIndex)
                {
                    inputtempDate = DateTime.Now;
                    _inputtempIndex = value;
                }
                else
                {
                    TimeSpan timeSpan = DateTime.Now.Subtract(inputtempDate);
                    if (timeSpan.TotalSeconds > 10 && inputTempFlag != value) //延遲十秒發送及確認無重複發送
                    {
                        switch (value)
                        {
                            case 0:
                                {
                                    AlarmNotifySender($"\r設備名稱:{DeviceSetting.Device_Name}\r入水溫度恢復正常");
                                    inputTempFlag = 0;
                                }
                                break;
                            case 1:
                                {
                                    AlarmNotifySender($"\r設備名稱:{DeviceSetting.Device_Name}\r入水溫度過低警報");
                                    inputTempFlag = 1;
                                }
                                break;
                            case 2:
                                {
                                    AlarmNotifySender($"\r設備名稱:{DeviceSetting.Device_Name}\r入水溫度過高警報");
                                    inputTempFlag = 2;
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
        private int _inputtempIndex { get; set; } = 0;
        #endregion
        #region 出水溫度
        /// <summary>
        /// 出水溫度記錄點
        /// </summary>
        public decimal _outputTemp { get; set; }
        /// <summary>
        /// 出水溫度
        /// </summary>
        public decimal OutputTemp { get; set; }
        /// <summary>
        /// 過去出水溫度狀態點
        /// </summary>
        public int outputTempFlag { get; set; } = 0;
        /// <summary>
        /// 出水溫度延遲發送時間
        /// </summary>
        private DateTime outputtempDate { get; set; } = new DateTime();
        /// <summary>
        /// 出水溫度告警狀態點
        /// </summary>
        private int outputtempIndex
        {
            set
            {
                if (value != _outputtempIndex)
                {
                    outputtempDate = DateTime.Now;
                    _outputtempIndex = value;
                }
                else
                {
                    TimeSpan timeSpan = DateTime.Now.Subtract(outputtempDate);
                    if (timeSpan.TotalSeconds > 10 && outputTempFlag != value) //延遲十秒發送及確認無重複發送
                    {
                        switch (value)
                        {
                            case 0:
                                {
                                    AlarmNotifySender($"\r設備名稱:{DeviceSetting.Device_Name}\r入水溫度恢復正常");
                                    outputTempFlag = 0;
                                }
                                break;
                            case 1:
                                {
                                    AlarmNotifySender($"\r設備名稱:{DeviceSetting.Device_Name}\r入水溫度過低警報");
                                    outputTempFlag = 1;
                                }
                                break;
                            case 2:
                                {
                                    AlarmNotifySender($"\r設備名稱:{DeviceSetting.Device_Name}\r入水溫度過高警報");
                                    outputTempFlag = 2;
                                }
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 出水溫度告警狀態記錄點
        /// </summary>
        private int _outputtempIndex { get; set; } = 0;
        #endregion
        /// <summary>
        /// 水溫差
        /// </summary>
        public decimal TempRang
        {
            get
            {
                decimal data = 0;
                if (InputTemp > OutputTemp)
                {
                    data = InputTemp - OutputTemp;
                }
                return data;
            }
        }
        /// <summary>
        /// 熱負載率
        /// </summary>
        public decimal HeatLoadRate
        {
            get
            {
                decimal data = 0;
                if (TempRang > 0)
                {
                    data = (TempRang / DeviceSetting.HeatLoad) * 100;
                }
                return data;
            }
        }
        /// <summary>
        /// 冷凍能力
        /// </summary>
        public decimal RT
        {
            get
            {
                decimal value = 0;
                if (Flow != 0 && InputTemp != 0 && OutputTemp != 0)
                {
                    value = Math.Round(Flow * (InputTemp - OutputTemp) * 60 / 3024, 2);
                }
                return value;
            }
        }
    }
}
