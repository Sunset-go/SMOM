using SIE.Domain;
using SIE.MetaModel;

namespace SIE.ZYF.PurchaseOrders
{
    [ManagedProperty.CompiledPropertyDeclarer]
    public static class PurOrderExtension
    {
        #region EntityList<OrderDetail> SuOrderDetail (订单与明细的关系)
        /// <summary>
        /// 订单与明细的关系 扩展属性。
        /// </summary>
        public static readonly ListProperty<EntityList<OrderDetail>> SuOrderDetailProperty =
            P<PurchaseOrder>.RegisterExtensionList<EntityList<OrderDetail>>("SuOrderDetail", typeof(PurOrderExtension));

        /// <summary>
        /// 获取 订单与明细的关系 属性的值。
        /// </summary>
        /// <param name="me">要获取扩展属性值的对象。</param>
        public static EntityList<OrderDetail> GetSuOrderDetail(this PurchaseOrder me)
        {
            return me.GetProperty(SuOrderDetailProperty) as EntityList<OrderDetail>;
        }
        #endregion
        internal class PurOrderExtensionConfig : EntityConfig<PurchaseOrder>
        {
            protected override void ConfigMeta()
            {
                Meta.Property(SuOrderDetailProperty).DontMapColumn();
            }
        }
    }
}
