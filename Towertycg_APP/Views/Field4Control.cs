using DevExpress.XtraEditors;
using System.Collections.Generic;
using Towertycg_APP.Configuration;
using Towertycg_APP.Modules;
using Towertycg_APP.Protocols;

namespace Towertycg_APP.Views
{
    public class Field4Control : XtraUserControl
    {
        public AbsProtocol AbsProtocol { get; set; }
        /// <summary>
        /// 總設備通訊物件
        /// </summary>
        public List<AbsProtocol> AbsProtocols { get; set; }
        /// <summary>
        /// 群組資訊
        /// </summary>
        public GroupSetting GroupSetting { get; set; }
        /// <summary>
        /// 一座資訊
        /// </summary>
        public SetSetting SetSetting { get; set; }
        /// <summary>
        /// 一室資訊
        /// </summary>
        public CellSetting CellSetting { get; set; }
        /// <summary>
        /// 上傳Set資訊
        /// </summary>
        public SetDevice SetDevice { get; set; }
        /// <summary>
        /// 上傳Cell資訊
        /// </summary>
        public CellDevice CellDevice { get; set; }
        /// <summary>
        /// 上傳Senser資訊
        /// </summary>
        public SenserDevice SenserDevice { get; set; }
        /// <summary>
        /// 上傳Flow資訊
        /// </summary>
        public FlowDevice FlowDevice { get; set; }
        /// <summary>
        /// 上傳Electric資訊
        /// </summary>
        public ElectricDevice ElectricDevice { get; set; }
        /// <summary>
        /// 更新畫面
        /// </summary>
        public virtual void TextChange() { }
    }
}
