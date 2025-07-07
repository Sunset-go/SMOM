using System;
using System.Collections.Generic;
using System.Text;

namespace SIE.ZYF.Controllers
{
    /// <summary>
    /// 物料查询
    /// </summary>
    [Serializable]
    public class MaterialQuery
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 物料类型
        /// </summary>
        public string Material_Types { get; set; }
        /// <summary>
        /// 单位编码
        /// </summary>
        public string Unit_Code { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string Unit_Name { get; set; }
    }
}
