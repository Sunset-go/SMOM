using SIE.ObjectModel;

namespace SIE.ZYF.ProductManages
{
    public enum ProductStatus
    {
        /// <summary>
        /// 未审核
        /// </summary>
        [Label("未审核")]
        UnAudit = 0,
        /// <summary>
        /// 已审核
        /// </summary>
        [Label("已审核")]
        Audited = 1,
    }
}
