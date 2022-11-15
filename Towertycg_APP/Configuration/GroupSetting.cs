using System;
using System.Collections.Generic;

namespace Towertycg_APP.Configuration
{
    /// <summary>
    /// 群組資訊
    /// </summary>
    public class GroupSetting
    {
        /// <summary>
        /// 總一座資訊
        /// </summary>
        public List<SetSetting> SetSettings { get; set; } = new List<SetSetting>();
    }
    /// <summary>
    /// 一座資訊
    /// </summary>
    public class SetSetting
    {
        /// <summary>
        /// 一座編碼
        /// </summary>
        public Guid Set_Number { get; set; }
        /// <summary>
        /// 一座名稱
        /// </summary>
        public string Set_Name { get; set; }
        /// <summary>
        /// 總一室資訊
        /// </summary>
        public List<CellSetting> CellSettings { get; set; } = new List<CellSetting>();
    }
    /// <summary>
    /// 一室資訊
    /// </summary>
    public class CellSetting
    {
        /// <summary>
        /// 一室編碼
        /// </summary>
        public Guid Cell_Number { get; set; }
        /// <summary>
        /// 一室名稱
        /// </summary>
        public string Cell_Name { get; set; }
    }
}
