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
    [Label("供应商联系人")]
    public class SupplierPhone : DataEntity
    {
        #region 联系人 Concat
        /// <summary>
        /// 联系人
        /// </summary>
        [Label("联系人")]
        public static readonly Property<string> ConcatProperty = P<SupplierPhone>.Register(e => e.Concat);

        /// <summary>
        /// 联系人
        /// </summary>
        public string Concat
        {
            get { return this.GetProperty(ConcatProperty); }
            set { this.SetProperty(ConcatProperty, value); }
        }
        #endregion

        #region 联系电话 Phone
        /// <summary>
        /// 联系电话
        /// </summary>
        [Label("联系电话")]
        public static readonly Property<string> PhoneProperty = P<SupplierPhone>.Register(e => e.Phone);

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            get { return this.GetProperty(PhoneProperty); }
            set { this.SetProperty(PhoneProperty, value); }
        }
        #endregion

        #region 联系地址 ConcatAddress
        /// <summary>
        /// 联系地址
        /// </summary>
        [Label("联系地址")]
        public static readonly Property<string> ConcatAddressProperty = P<SupplierPhone>.Register(e => e.ConcatAddress);

        /// <summary>
        /// 联系地址
        /// </summary>
        public string ConcatAddress
        {
            get { return this.GetProperty(ConcatAddressProperty); }
            set { this.SetProperty(ConcatAddressProperty, value); }
        }
        #endregion

        #region 联系人与供应商的关系 SuConcat
        /// <summary>
        /// 联系人与供应商的关系Id
        /// </summary>
        public static readonly IRefIdProperty SuConcatIdProperty =
            P<SupplierPhone>.RegisterRefId(e => e.SuConcatId, ReferenceType.Parent);

        /// <summary>
        /// 联系人与供应商的关系Id
        /// </summary>
        public double SuConcatId
        {
            get { return (double)this.GetRefId(SuConcatIdProperty); }
            set { this.SetRefId(SuConcatIdProperty, value); }
        }

        /// <summary>
        /// 联系人与供应商的关系
        /// </summary>
        public static readonly RefEntityProperty<Supplier> SuConcatProperty =
            P<SupplierPhone>.RegisterRef(e => e.SuConcat, SuConcatIdProperty);

        /// <summary>
        /// 联系人与供应商的关系
        /// </summary>
        public Supplier SuConcat
        {
            get { return this.GetRefEntity(SuConcatProperty); }
            set { this.SetRefEntity(SuConcatProperty, value); }
        }
        #endregion
    }
    /// <summary>
    /// 供应商电话元数据配置
    /// </summary>
    internal class SupplierPhoneConfig : EntityConfig<SupplierPhone>
    {
        protected override void ConfigMeta()
        {
            Meta.MapTable("SUPPLIER_PHONE").MapAllProperties();
            Meta.EnablePhantoms();
        }
    }
}
