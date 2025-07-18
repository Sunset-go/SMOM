using SIE.Domain;
using SIE.MetaModel;
using SIE.ObjectModel;
using System;

namespace SIE.ZYF.Suppliers
{
    /// <summary>
    /// 供应商联系人
    /// </summary>
    [RootEntity, Serializable]
    [Label("供应商地址")]
    public partial class SupplierAddress : DataEntity
    {
        public const string SupplierAddressType = "供应商地址";
        #region 地址类型 AddressType
        /// <summary>
        /// 地址类型
        /// </summary>
        [Required]
        [Label("地址类型")]
        public static readonly Property<string> AddressTypeProperty = P<SupplierAddress>.Register(e => e.AddressType);

        /// <summary>
        /// 地址类型
        /// </summary>
        public string AddressType
        {
            get { return this.GetProperty(AddressTypeProperty); }
            set { this.SetProperty(AddressTypeProperty, value); }
        }
        #endregion

        #region 公司名称 CompanyName
        /// <summary>
        /// 公司名称
        /// </summary>
        [Required]
        [Label("公司名称")]
        public static readonly Property<string> CompanyNameProperty = P<SupplierAddress>.Register(e => e.CompanyName);

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName
        {
            get { return this.GetProperty(CompanyNameProperty); }
            set { this.SetProperty(CompanyNameProperty, value); }
        }
        #endregion

        #region 详细地址 DetailAddress
        /// <summary>
        /// 详细地址
        /// </summary>
        [Required]
        [Label("详细地址")]
        public static readonly Property<string> DetailAddressProperty = P<SupplierAddress>.Register(e => e.DetailAddress);

        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailAddress
        {
            get { return this.GetProperty(DetailAddressProperty); }
            set { this.SetProperty(DetailAddressProperty, value); }
        }
        #endregion

        #region 联系人 Concat
        /// <summary>
        /// 联系人
        /// </summary>
        [Label("联系人")]
        public static readonly Property<string> ConcatProperty = P<SupplierAddress>.Register(e => e.Concat);

        /// <summary>
        /// 联系人
        /// </summary>
        public string Concat
        {
            get { return this.GetProperty(ConcatProperty); }
            set { this.SetProperty(ConcatProperty, value); }
        }
        #endregion

        #region 电话 PhoneNumber
        /// <summary>
        /// 电话
        /// </summary>
        [Label("电话")]
        public static readonly Property<string> PhoneNumberProperty = P<SupplierAddress>.Register(e => e.PhoneNumber);

        /// <summary>
        /// 电话
        /// </summary>
        public string PhoneNumber
        {
            get { return this.GetProperty(PhoneNumberProperty); }
            set { this.SetProperty(PhoneNumberProperty, value); }
        }
        #endregion

        #region 地址与供应商的关系 SupAddress
        /// <summary>
        /// 地址与供应商的关系Id
        /// </summary>
        public static readonly IRefIdProperty SupAddressIdProperty =
            P<SupplierAddress>.RegisterRefId(e => e.SupAddressId, ReferenceType.Normal);

        /// <summary>
        /// 地址与供应商的关系Id
        /// </summary>
        public double? SupAddressId
        {
            get { return (double?)this.GetRefNullableId(SupAddressIdProperty); }
            set { this.SetRefNullableId(SupAddressIdProperty, value); }
        }

        /// <summary>
        /// 地址与供应商的关系
        /// </summary>
        public static readonly RefEntityProperty<Supplier> SupAddressProperty =
            P<SupplierAddress>.RegisterRef(e => e.SupAddress, SupAddressIdProperty);

        /// <summary>
        /// 地址与供应商的关系
        /// </summary>
        public Supplier SupAddress
        {
            get { return this.GetRefEntity(SupAddressProperty); }
            set { this.SetRefEntity(SupAddressProperty, value); }
        }
        #endregion
    }

    /// <summary>
    /// 供应商功能 实体配置
    /// </summary>
    internal class SupplierAttachConfig : EntityConfig<SupplierAddress>
    {
        /// <summary>
        /// 配置元数据
        /// </summary>
        protected override void ConfigMeta()
        {
            Meta.MapTable("SUPPLIER_ADDRESS").MapAllProperties();
            Meta.EnablePhantoms();
        }
    }
}
