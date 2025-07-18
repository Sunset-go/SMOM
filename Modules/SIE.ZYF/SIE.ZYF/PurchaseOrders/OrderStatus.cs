using SIE.ObjectModel;

namespace SIE.ZYF.PurchaseOrders
{
    // 定义一个枚举类
    public enum OrderStatus
    {
        /// <summary>
        /// 新建
        /// </summary>
        [Label("新建")]
        NewBuild = 0,
        /// <summary>
        /// 部分接受
        /// </summary>
        [Label("部分接受")]
        Part = 1,
        /// <summary>
        /// 全部接受
        /// </summary>
        [Label("全部接受")]
        All = 2
    }
}
