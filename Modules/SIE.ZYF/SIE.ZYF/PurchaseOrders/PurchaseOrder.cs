using SIE.Common.Configs;
using SIE.Common.Configs.CommonConfigs;
using SIE.Common.Prints;
using SIE.Domain;
using SIE.MetaModel;
using SIE.ObjectModel;
using SIE.ZYF.ProductManages;
using System;

namespace SIE.ZYF.PurchaseOrders
{
    /// <summary>
    /// 采购订单
    /// </summary>
    [RootEntity, Serializable]
    [CriteriaQuery]
    [Label("采购订单")]
    [BillPrintable(typeof(PuOrderBillPrintable))]
    [EntityWithConfig(typeof(NoConfig), "单号编码", "采购订单单号生成规则")]
    //[DisplayMember(nameof(OrderNumber))]
    //[QueryMembers(new[] { nameof(OrderNumber), nameof(PurchaseDate) })]
    public partial class PurchaseOrder : DataEntity
    {
        #region 单号 OrderNumber
        /// <summary>
        /// 单号
        /// </summary>
        [Label("单号")]
        public static readonly Property<string> OrderNumberProperty = P<PurchaseOrder>.Register(e => e.OrderNumber);

        /// <summary>
        /// 单号
        /// </summary>
        public string OrderNumber
        {
            get { return this.GetProperty(OrderNumberProperty); }
            set { this.SetProperty(OrderNumberProperty, value); }
        }
        #endregion

        #region 采购日期 PurchaseDate
        /// <summary>
        /// 采购日期
        /// </summary>
        [Label("采购日期")]
        public static readonly Property<DateTime> PurchaseDateProperty = P<PurchaseOrder>.Register(e => e.PurchaseDate);

        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime PurchaseDate
        {
            get { return this.GetProperty(PurchaseDateProperty); }
            set { this.SetProperty(PurchaseDateProperty, value); }
        }
        #endregion

        #region 总金额 TotalAmount
        /// <summary>
        /// 总金额
        /// </summary>
        [Label("总金额")]
        public static readonly Property<double> TotalAmountProperty = P<PurchaseOrder>.Register(e => e.TotalAmount);

        /// <summary>
        /// 总金额
        /// </summary>
        public double TotalAmount
        {
            get { return this.GetProperty(TotalAmountProperty); }
            set { this.SetProperty(TotalAmountProperty, value); }
        }
        #endregion

        #region 状态 Status
        /// <summary>
        /// 状态
        /// </summary>
        [Label("状态")]
        public static readonly Property<OrderStatus?> StatusProperty = P<PurchaseOrder>.Register(e => e.Status);

        /// <summary>
        /// 状态
        /// </summary>
        public OrderStatus? Status
        {
            get { return this.GetProperty(StatusProperty); }
            set { this.SetProperty(StatusProperty, value); }
        }
        #endregion

        #region 备注 Remarks
        /// <summary>
        /// 备注
        /// </summary>
        [Label("备注")]
        public static readonly Property<string> RemarksProperty = P<PurchaseOrder>.Register(e => e.Remarks);

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            get { return this.GetProperty(RemarksProperty); }
            set { this.SetProperty(RemarksProperty, value); }
        }
        #endregion

        #region 采购订单列表 PurchaseOrderList
        /// <summary>
        /// 采购订单列表
        /// </summary>
        public static readonly ListProperty<EntityList<OrderDetail>> PurchaseOrderListProperty = P<PurchaseOrder>.RegisterList(e => e.PurchaseOrderList);

        /// <summary>
        /// 采购订单列表
        /// </summary>
        [Required]
        public EntityList<OrderDetail> PurchaseOrderList
        {
            get { return this.GetLazyList(PurchaseOrderListProperty); }
        }
        #endregion

    }

    internal class PurchaseOrderConfig : EntityConfig<PurchaseOrder>
    {
        /// <summary>
        /// 配置元数据
        /// </summary>
        protected override void ConfigMeta()
        {
            Meta.MapTable("PURCHASE_ORDER").MapAllProperties();
            Meta.EnablePhantoms();
        }
    }
}
