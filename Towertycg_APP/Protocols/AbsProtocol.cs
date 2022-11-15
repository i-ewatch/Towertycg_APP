using LineNotifyLibrary;
using MathLibrary;
using NModbus;
using System;
using System.Collections.Generic;
using Towertycg_APP.Configuration;

namespace Towertycg_APP.Protocols
{
    public abstract class AbsProtocol
    {
        /// <summary>
        /// 連線旗標
        /// </summary>
        public bool ConnectionFlag { get; set; }
        /// <summary>
        /// 完整讀取旗標
        /// </summary>
        public bool CompleteFlag { get; set; }
        /// <summary>
        /// 設備最後通訊完成時間
        /// </summary>
        public DateTime LastTime { get; set; }
        /// <summary>
        /// 通道編碼
        /// </summary>
        public Guid Gateway_Number { get; set; }
        /// <summary>
        /// 設備資訊
        /// </summary>
        public DeviceSetting DeviceSetting { get; set; }
        /// <summary>
        /// 推播資訊
        /// </summary>
        public List<NotifySetting> NotifySettings { get; set; }
        /// <summary>
        /// 數學公式
        /// </summary>
        public MathClass Calculate = new MathClass();
        /// <summary>
        /// 讀取通訊
        /// </summary>
        /// <param name="master"></param>
        public virtual void Read_Protocol(IModbusMaster master) { }
        /// <summary>
        /// 告警發送
        /// </summary>
        public void AlarmNotifySender(string message)
        {
            foreach (var item in NotifySettings)
            {
                foreach (var Notify_Numberitem in DeviceSetting.Notify_Number)
                {
                    if (item.Notify_Number == Notify_Numberitem && item.Token != "")
                    {
                        using (LineNotifyClass lineNotifyClass = new LineNotifyClass(item.Token))
                        {
                            lineNotifyClass.LineNotifyFunction(message);
                        }
                    }
                }
            }
        }
    }
}
