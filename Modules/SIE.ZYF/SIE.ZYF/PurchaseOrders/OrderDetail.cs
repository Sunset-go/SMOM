using SIE.Domain;
using SIE.MetaModel;
using SIE.ObjectModel;
using SIE.ZYF.ProductManages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIE.ZYF.PurchaseOrders
{
    /// <summary>
    /// 明细
    /// </summary>
    [RootEntity, Serializable]
    //[CriteriaQuery]
    [Label("明细")]
    public partial class OrderDetail:DataEntity
    {
        #region 明细与采购订单的关系 PurchaseOrder
        /// <summary>
        /// 明细与采购订单的关系Id
        /// </summary>
        [Required]
        public static readonly IRefIdProperty PurchaseOrderIdProperty =
            P<OrderDetail>.RegisterRefId(e => e.PurchaseOrderId, ReferenceType.Parent);

        /// <summary>
        /// 明细与采购订单的关系Id
        /// </summary>
        public double? PurchaseOrderId
        {
            get { return (double?)this.GetRefNullableId(PurchaseOrderIdProperty); }
            set { this.SetRefNullableId(PurchaseOrderIdProperty, value); }
        }

        /// <summary>
        /// 明细与采购订单的关系
        /// </summary>
        public static readonly RefEntityProperty<PurchaseOrder> PurchaseOrderProperty =
            P<OrderDetail>.RegisterRef(e => e.PurchaseOrder, PurchaseOrderIdProperty);

        /// <summary>
        /// 明细与采购订单的关系
        /// </summary>
        public PurchaseOrder PurchaseOrder
        {
            get { return this.GetRefEntity(PurchaseOrderProperty); }
            set { this.SetRefEntity(PurchaseOrderProperty, value); }
        }
        #endregion

        #region 明细与产品管理的关系 ProManDetail
        /// <summary>
        /// 明细与产品管理的关系Id
        /// </summary>
        [Required]
        [Label("编码")]
        public static readonly IRefIdProperty ProManDetailIdProperty =
            P<OrderDetail>.RegisterRefId(e => e.ProManDetailId, ReferenceType.Normal);

        /// <summary>
        /// 明细与产品管理的关系Id
        /// </summary>
        public double? ProManDetailId
        {
            get { return (double?)this.GetRefNullableId(ProManDetailIdProperty); }
            set { this.SetRefNullableId(ProManDetailIdProperty, value); }
        }

        /// <summary>
        /// 明细与产品管理的关系
        /// </summary>
        public static readonly RefEntityProperty<ProductManage> ProManDetailProperty =
            P<OrderDetail>.RegisterRef(e => e.ProManDetail, ProManDetailIdProperty);

        /// <summary>
        /// 明细与产品管理的关系
        /// </summary>
        public ProductManage ProManDetail
        {
            get { return this.GetRefEntity(ProManDetailProperty); }
            set { this.SetRefEntity(ProManDetailProperty, value); }
        }
        #endregion

        #region 名称 Name
        /// <summary>
        /// 名称
        /// </summary>
        [Label("名称")]
        public static readonly Property<string> NameProperty = P<OrderDetail>.Register(e => e.Name);

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.SetProperty(NameProperty, value); }
        }
        #endregion

        #region 总金额 TotalAmount
        /// <summary>
        /// 总金额
        /// </summary>
        [Label("总金额")]
        [MinValue(0)]
        public static readonly Property<double> TotalAmountProperty = P<OrderDetail>.Register(e => e.TotalAmount);

        /// <summary>
        /// 总金额
        /// </summary>
        public double TotalAmount
        {
            get { return (double)this.GetProperty(TotalAmountProperty); }
            set { this.SetProperty(TotalAmountProperty, value); }
        }
        #endregion

        #region 采购价 PurPrice
        /// <summary>
        /// 采购价
        /// </summary>
        [Label("采购价")]
        [Required]
        [MinValue(0)]
        public static readonly Property<double> PurPriceProperty = P<OrderDetail>.Register(e => e.PurPrice);

        /// <summary>
        /// 采购价
        /// </summary>
        public double PurPrice
        {
            get { return this.GetProperty(PurPriceProperty); }
            set { this.SetProperty(PurPriceProperty, value); }
        }
        #endregion

        #region 采购数量 PurQty
        /// <summary>
        /// 采购数量
        /// </summary>
        [Label("采购数量")]
        [Required]
        [MinValue(1)]
        public static readonly Property<int> PurQtyProperty = P<OrderDetail>.Register(e => e.PurQty);

        /// <summary>
        /// 采购数量
        /// </summary>
        public int PurQty
        {
            get { return this.GetProperty(PurQtyProperty); }
            set { this.SetProperty(PurQtyProperty, value); }
        }
        #endregion

        #region 备注 Remark
        /// <summary>
        /// 备注
        /// </summary>
        [Label("备注")]
        public static readonly Property<string> RemarkProperty = P<OrderDetail>.Register(e => e.Remark);

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return this.GetProperty(RemarkProperty); }
            set { this.SetProperty(RemarkProperty, value); }
        }
        #endregion

        #region 入库数量 EnterQty
        /// <summary>
        /// 入库数量
        /// </summary>
        [Label("入库数量")]
        [MinValue(0)]
        public static readonly Property<int> EnterQtyProperty = P<OrderDetail>.Register(e => e.EnterQty);

        /// <summary>
        /// 入库数量
        /// </summary>
        public int EnterQty
        {
            get { return this.GetProperty(EnterQtyProperty); }
            set { this.SetProperty(EnterQtyProperty, value); }
        }
        #endregion
    }
    internal class OrderDetailConfig: EntityConfig<OrderDetail>
    {
        /// <summary>
        /// 配置元数据
        /// </summary>
        protected override void ConfigMeta()
        {
            Meta.MapTable("ORDER_DETAIL").MapAllProperties();
            Meta.EnablePhantoms();
        }
    }
}
