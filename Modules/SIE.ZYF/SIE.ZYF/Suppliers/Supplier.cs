using SIE.Common.Prints;
using SIE.Domain;
using SIE.MetaModel;
using SIE.ObjectModel;
using System;

namespace SIE.ZYF.Suppliers
{
    /// <summary>
    /// 供应商功能
    /// </summary>
    [RootEntity, Serializable]
    [CriteriaQuery]
    [Label("供应商")]
    [BillPrintable(typeof(SupplierBillPrintable))]
    public partial class Supplier : DataEntity, IStateEntity
    {
        #region 快码
        /// <summary>
        /// 快码: 供应商类型
        /// </summary>
        public const string SupperType = "SUPPLIER_TYPE";
        /// <summary>
        /// 快码: 供应商区域
        /// </summary>
        public const string SupperRegion = "SUPPLIER_Region";
        #endregion

        #region 供应商编码 Code
        /// <summary>
        /// 供应商编码
        /// </summary>
        [Required]
        [NotDuplicate]
        [Label("供应商编码")]
        public static readonly Property<string> CodeProperty = P<Supplier>.Register(e => e.Code);

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string Code
        {
            get { return GetProperty(CodeProperty); }
            set { SetProperty(CodeProperty, value); }
        }
        #endregion

        #region 供应商名称 Name
        /// <summary>
        /// 供应商名称
        /// </summary>
        [Required]
        [Label("供应商名称")]
        public static readonly Property<string> NameProperty = P<Supplier>.Register(e => e.Name);

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }
        #endregion

        #region Logo Logo
        /// <summary>
        /// Logo
        /// </summary>
        [Label("Logo")]
        public static readonly Property<byte[]> LogoProperty = P<Supplier>.Register(e => e.Logo);

        /// <summary>
        /// Logo
        /// </summary>
        public byte[] Logo
        {
            get { return this.GetProperty(LogoProperty); }
            set { this.SetProperty(LogoProperty, value); }
        }
        #endregion

        #region 描述 Description
        /// <summary>
        /// 描述
        /// </summary>
        [Label("描述")]
        public static readonly Property<string> DescriptionProperty = P<Supplier>.Register(e => e.Description);

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return GetProperty(DescriptionProperty); }
            set { SetProperty(DescriptionProperty, value); }
        }
        #endregion

        #region 类型 Type
        /// <summary>
        /// 类型
        /// </summary>
        [Label("类型")]
        public static readonly Property<string> TypeProperty = P<Supplier>.Register(e => e.Type);

        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
            get { return GetProperty(TypeProperty); }
            set { SetProperty(TypeProperty, value); }
        }
        #endregion

        #region 简称 Abbreviation
        /// <summary>
        /// 简称
        /// </summary>
        [Label("简称")]
        public static readonly Property<string> AbbreviationProperty = P<Supplier>.Register(e => e.Abbreviation);

        /// <summary>
        /// 简称
        /// </summary>
        public string Abbreviation
        {
            get { return GetProperty(AbbreviationProperty); }
            set { SetProperty(AbbreviationProperty, value); }
        }
        #endregion

        #region 英文名称 EnglishName
        /// <summary>
        /// 英文名称
        /// </summary>
        [Label("英文名称")]
        public static readonly Property<string> EnglishNameProperty = P<Supplier>.Register(e => e.EnglishName);

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName
        {
            get { return GetProperty(EnglishNameProperty); }
            set { SetProperty(EnglishNameProperty, value); }
        }
        #endregion

        #region 所在地区 Region
        /// <summary>
        /// 所在地区
        /// </summary>
        [Label("所在地区")]
        public static readonly Property<string> RegionProperty = P<Supplier>.Register(e => e.Region);

        /// <summary>
        /// 所在地区
        /// </summary>
        public string Region
        {
            get { return GetProperty(RegionProperty); }
            set { SetProperty(RegionProperty, value); }
        }
        #endregion

        #region 税号 TaxNumber
        /// <summary>
        /// 税号
        /// </summary>
        [Label("税号")]
        public static readonly Property<string> TaxNumberProperty = P<Supplier>.Register(e => e.TaxNumber);

        /// <summary>
        /// 税号
        /// </summary>
        public string TaxNumber
        {
            get { return GetProperty(TaxNumberProperty); }
            set { SetProperty(TaxNumberProperty, value); }
        }
        #endregion

        #region 联系人 ContactPerson
        /// <summary>
        /// 联系人
        /// </summary>
        [Label("联系人")]
        public static readonly Property<string> ContactPersonProperty = P<Supplier>.Register(e => e.ContactPerson);

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactPerson
        {
            get { return GetProperty(ContactPersonProperty); }
            set { SetProperty(ContactPersonProperty, value); }
        }
        #endregion

        #region 联系电话 ContactPhoneNumber
        /// <summary>
        /// 联系电话
        /// </summary>
        [Label("联系电话")]
        public static readonly Property<string> ContactPhoneNumberProperty = P<Supplier>.Register(e => e.ContactPhoneNumber);

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhoneNumber
        {
            get { return GetProperty(ContactPhoneNumberProperty); }
            set { SetProperty(ContactPhoneNumberProperty, value); }
        }
        #endregion

        #region 联系地址 ContactAddress
        /// <summary>
        /// 联系地址
        /// </summary>
        [Label("联系地址")]
        public static readonly Property<string> ContactAddressProperty = P<Supplier>.Register(e => e.ContactAddress);

        /// <summary>
        /// 联系地址
        /// </summary>
        public string ContactAddress
        {
            get { return GetProperty(ContactAddressProperty); }
            set { SetProperty(ContactAddressProperty, value); }
        }
        #endregion

        #region 电子邮件 Email
        /// <summary>
        /// 电子邮件
        /// </summary>
        [Label("电子邮件")]
        public static readonly Property<string> EmailProperty = P<Supplier>.Register(e => e.Email);

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email
        {
            get { return GetProperty(EmailProperty); }
            set { SetProperty(EmailProperty, value); }
        }
        #endregion

        #region 邮编 PostalCode
        /// <summary>
        /// 邮编
        /// </summary>
        [Label("邮编")]
        public static readonly Property<string> PostalCodeProperty = P<Supplier>.Register(e => e.PostalCode);

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostalCode
        {
            get { return GetProperty(PostalCodeProperty); }
            set { SetProperty(PostalCodeProperty, value); }
        }
        #endregion

        #region 备注 Remarks
        /// <summary>
        /// 备注
        /// </summary>
        [Label("备注")]
        public static readonly Property<string> RemarksProperty = P<Supplier>.Register(e => e.Remarks);

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            get { return GetProperty(RemarksProperty); }
            set { SetProperty(RemarksProperty, value); }
        }
        #endregion

        #region 列表 SupplierMaterialsList
        /// <summary>
        /// 列表
        /// </summary>
        public static readonly ListProperty<EntityList<SupplierMaterials>> SupplierMaterialsListProperty = P<Supplier>.RegisterList(e => e.SupplierMaterialsList);
        /// <summary>
        /// 列表
        /// </summary>
        public EntityList<SupplierMaterials> SupplierMaterialsList
        {
            get { return this.GetLazyList(SupplierMaterialsListProperty); }
        }
        #endregion

        #region 数据来源 DataSourceEnum
        /// <summary>
        /// 数据来源
        /// </summary>
        [Label("数据来源")]
        public static readonly Property<DataSourceEnum?> DataSourceEnumProperty = P<Supplier>.Register(e => e.DataSourceEnum);

        /// <summary>
        /// 数据来源
        /// </summary>
        public DataSourceEnum? DataSourceEnum
        {
            get { return GetProperty(DataSourceEnumProperty); }
            set { SetProperty(DataSourceEnumProperty, value); }
        }
        #endregion

        #region 状态 State
        /// <summary>
        /// 状态
        /// </summary>
        [Label("状态")]
        public static readonly Property<State> StateProperty = P<Supplier>.Register(e => e.State);

        /// <summary>
        /// 状态
        /// </summary>
        public State State
        {
            get { return this.GetProperty(StateProperty); }
            set { this.SetProperty(StateProperty, value); }
        }
        #endregion

    }

    /// <summary>
    /// 供应商功能 实体配置
    /// </summary>
    internal class SupplierConfig : EntityConfig<Supplier>
    {
        /// <summary>
        /// 配置元数据
        /// </summary>
        protected override void ConfigMeta()
        {
            Meta.MapTable("SUPPLIER").MapAllProperties();
            Meta.EnablePhantoms();
        }
    }
}