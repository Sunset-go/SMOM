using SIE.Common.Configs;
using SIE.Common.Configs.CommonConfigs;
using SIE.Domain;
using SIE.MetaModel;
using SIE.ObjectModel;
using SIE.Web.ZYF.ProductManages;
using SIE.ZYF.Materials;
using SIE.ZYF.ProductManages.Configs;
using SIE.ZYF.Suppliers;
using System;

namespace SIE.ZYF.ProductManages
{
    /// <summary>
    /// 产品管理
    /// </summary>
    [RootEntity, Serializable]
    //[CriteriaQuery]
    [ConditionQueryType(typeof(ProductManageCriteria))]
    [Label("产品管理")]
    [EntityWithConfig(typeof(QuantityConfig))]
    [EntityWithConfig(typeof(NoConfig), "编码规则","编码生成规则")]
    public class ProductManage : DataEntity
    {
        #region 编码 Code
        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [Label("编码")]
        public static readonly Property<string> CodeProperty = P<ProductManage>.Register(e => e.Code);

        /// <summary>
        /// 编码
        /// </summary>
        public string Code
        {
            get { return this.GetProperty(CodeProperty); }
            set { this.SetProperty(CodeProperty, value); }
        }
        #endregion

        #region 名称 Name
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [Label("名称")]
        public static readonly Property<string> NameProperty = P<ProductManage>.Register(e => e.Name);

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.SetProperty(NameProperty, value); }
        }
        #endregion

        #region 描述 Description
        /// <summary>
        /// 描述
        /// </summary>
        [Label("描述")]
        public static readonly Property<string> DescriptionProperty = P<ProductManage>.Register(e => e.Description);

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return this.GetProperty(DescriptionProperty); }
            set { this.SetProperty(DescriptionProperty, value); }
        }
        #endregion

        #region 采购数量 PurchaseQuantity
        /// <summary>
        /// 采购数量
        /// </summary>
        [Required]
        [Label("采购数量")]
        [MinValue(0)]
        public static readonly Property<int> PurchaseQuantityProperty = P<ProductManage>.Register(e => e.PurchaseQuantity);

        /// <summary>
        /// 采购数量
        /// </summary>
        public int PurchaseQuantity
        {
            get { return this.GetProperty(PurchaseQuantityProperty); }
            set { this.SetProperty(PurchaseQuantityProperty, value); }
        }
        #endregion

        #region 采购价格 PurchasePrice
        /// <summary>
        /// 采购价格
        /// </summary>
        [MinValue(0)]
        [Label("采购价格")]
        public static readonly Property<double> PurchasePriceProperty = P<ProductManage>.Register(e => e.PurchasePrice);

        /// <summary>
        /// 采购价格
        /// </summary>
        public double PurchasePrice
        {
            get { return this.GetProperty(PurchasePriceProperty); }
            set { this.SetProperty(PurchasePriceProperty, value); }
        }
        #endregion

        #region 销售价 Price
        /// <summary>
        /// 销售价
        /// </summary>
        [MinValue(0)]
        [Label("销售价格")]
        public static readonly Property<double> PriceProperty = P<ProductManage>.Register(e => e.Price);

        /// <summary>
        /// 销售价
        /// </summary>
        public double Price
        {
            get { return this.GetProperty(PriceProperty); }
            set { this.SetProperty(PriceProperty, value); }
        }
        #endregion

        #region 产品管理与供应商的关系 SupplierId
        /// <summary>
        /// 产品管理与供应商的关系Id
        /// </summary>
        [Required]
        [Label("供应商")]
        public static readonly IRefIdProperty SupplierIdProperty = P<ProductManage>.RegisterRefId(e => e.SupplierId, ReferenceType.Normal);

        /// <summary>
        /// 产品管理与供应商的关系Id
        /// </summary>
        public double SupplierId
        {
            get { return (double)GetRefId(SupplierIdProperty); }
            set { SetRefId(SupplierIdProperty, value); }
        }

        /// <summary>
        /// 产品管理与供应商的关系
        /// </summary>
        public static readonly RefEntityProperty<Supplier> SupplierProperty = P<ProductManage>.RegisterRef(e => e.Supplier, SupplierIdProperty);

        /// <summary>
        /// 产品管理与供应商的关系
        /// </summary>
        public Supplier Supplier
        {
            get { return GetRefEntity(SupplierProperty); }
            set { SetRefEntity(SupplierProperty, value); }
        }
        #endregion

        #region 产品管理与物料的关系Id ProductMaterialId
        /// <summary>
        /// 产品管理与物料的关系Id
        /// </summary>
        [Required]
        [Label("物料")]
        public static readonly IRefIdProperty ProductMaterialIdProperty = P<ProductManage>.RegisterRefId(e => e.ProductMaterialId, ReferenceType.Normal);

        /// <summary>
        /// 产品管理与物料的关系Id
        /// </summary>
        public double ProductMaterialId
        {
            get { return (double)GetRefId(ProductMaterialIdProperty); }
            set { SetRefId(ProductMaterialIdProperty, value); }
        }
        /// <summary>
        /// 产品管理与供应商的关系
        /// </summary>
        public static readonly RefEntityProperty<Material> ProductMaterialProperty = P<ProductManage>.RegisterRef(e => e.ProductMaterial, ProductMaterialIdProperty);

        /// <summary>
        /// 产品管理与供应商的关系
        /// </summary>
        public Material ProductMaterial
        {
            get { return GetRefEntity(ProductMaterialProperty); }
            set { SetRefEntity(ProductMaterialProperty, value); }
        }
        #endregion

        #region 修改次数 ModifyCount
        /// <summary>
        /// 修改次数
        /// </summary>
        [Label("修改次数")]
        public static readonly Property<int> ModifyCountProperty = P<ProductManage>.Register(e => e.ModifyCount);

        /// <summary>
        /// 修改次数
        /// </summary>
        public int ModifyCount
        {
            get { return this.GetProperty(ModifyCountProperty); }
            set { this.SetProperty(ModifyCountProperty, value); }
        }
        #endregion

        #region 状态 Status
        /// <summary>
        /// 状态
        /// </summary>
        [Label("状态")]
        public static readonly Property<ProductStatus> StatusProperty = P<ProductManage>.Register(e => e.Status);

        /// <summary>
        /// 状态
        /// </summary>
        public ProductStatus Status
        {
            get { return this.GetProperty(StatusProperty); }
            set { this.SetProperty(StatusProperty, value); }
        }
        #endregion

        #region 备注 Remark
        /// <summary>
        /// 备注
        /// </summary>
        [Label("备注")]
        public static readonly Property<string> RemarkProperty = P<ProductManage>.Register(e => e.Remark);

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return this.GetProperty(RemarkProperty); }
            set { this.SetProperty(RemarkProperty, value); }
        }
        #endregion

        #region 附件 ProductManageAttachment
        /// <summary>
        /// 附件
        /// </summary>
        [Label("附件")]
        public static readonly ListProperty<EntityList<ProductManageAttachment>> ProductManageAttachmentProperty =
            P<ProductManage>.RegisterList(e => e.ProductManageAttachment);

        /// <summary>
        /// 附件
        /// </summary>
        public EntityList<ProductManageAttachment> ProductManageAttachment
        {
            get { return this.GetLazyList(ProductManageAttachmentProperty); }
        }
        #endregion

    }
    internal class ProductManageConfig : EntityConfig<ProductManage>
    {
        /// <summary>
        /// 配置元数据
        /// </summary>
        protected override void ConfigMeta()
        {
            Meta.MapTable("PRODUCT_MANAGE").MapAllProperties();
            Meta.EnablePhantoms();
        }
    }
}
