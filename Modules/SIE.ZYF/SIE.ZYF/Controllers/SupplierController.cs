using Org.BouncyCastle.Asn1.Crmf;
using SIE.Domain;
using SIE.ZYF.Suppliers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIE.ZYF.Controllers
{
    /// <summary>
    /// 物料列表
    /// </summary>
    [Serializable]
    public class Materials3Info
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 供应商信息
    /// </summary>
    [Serializable]
    public partial  class Supplier2Info
    {
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }

        public List<Materials3Info> materialsList { get; set; }

    }
    /// <summary>
    /// 供应商信息
    /// eg:
    /// {
    //    Count: 1,
    //    SuppliersList: [
    //        SupplierCode: "SIE001",
    //        SupplierName: "供应商1",
    //        MaterialsList: [
    //            {
    //                ColCode: "M001",
    //                ColName: "物料1"
    //            },
    //            {
    //                ColCode: "M002",
    //                ColName: "物料2"
    //            }
    //        ]
    //   ]
    //}
    /// </summary>
    public partial class Supplier1Info
    {
        /// <summary>
        /// 供应商数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 供应商列表
        /// </summary>
        //public EntityList<ColSupplier> SuppliersList { get; set; }
        public List<Supplier2Info> SuppliersList { get; set; }
    }
}
