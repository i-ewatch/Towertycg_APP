using System;

namespace Towertycg_APP.Configuration
{
    /// <summary>
    /// 推播資訊
    /// </summary>
    public class NotifySetting
    {
        /// <summary>
        /// 推播編碼
        /// </summary>
        public Guid Notify_Number { get; set; }
        /// <summary>
        /// 推播名稱
        /// </summary>
        public string NotifyName { get; set; }
        /// <summary>
        /// 推播權杖
        /// </summary>
        public string Token { get; set; }
    }
}
