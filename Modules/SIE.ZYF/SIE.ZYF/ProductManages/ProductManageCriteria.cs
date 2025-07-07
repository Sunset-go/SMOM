using SIE.Domain;
using SIE.ObjectModel;
using SIE.ZYF.ProductManages;
using SIE.ZYF.Suppliers;
using System;

namespace SIE.Web.ZYF.ProductManages
{
    [QueryEntity,Serializable]
    public class ProductManageCriteria : Criteria
    {
        #region 编码 Code
        /// <summary>
        /// 产品管理编码
        /// </summary>
        [Label("编码")]
        public static readonly Property<string> CodeProperty = P<ProductManageCriteria>.Register(e => e.Code);
        /// <summary>
        /// 产品管理编码
        /// </summary>
        public string Code
        {
            get { return GetProperty(CodeProperty); }
            set { SetProperty(CodeProperty, value); }
        }
        #endregion

        #region 名称 Name
        /// <summary>
        /// 产品管理名称
        /// </summary>
        [Label("名称")]
        public static readonly Property<string> NameProperty = P<ProductManageCriteria>.Register(e => e.Name);
        /// <summary>
        /// 产品管理名称
        /// </summary>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }
        #endregion

        #region 产品管理与供应商的关系  Supplier
        /// <summary>
        /// 产品管理与供应商的关系Id
        /// </summary>
        [Label("供应商")]
        public static readonly IRefIdProperty SupplierIdProperty = P<ProductManageCriteria>.RegisterRefId(e => e.SupplierId, ReferenceType.Normal);
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
        public static readonly RefEntityProperty<Supplier> SupplierProperty = P<ProductManageCriteria>.RegisterRef(e => e.Supplier, SupplierIdProperty);
        /// <summary>
        /// 产品管理与供应商的关系
        /// </summary>
        public Supplier Supplier
        {
            get { return GetRefEntity(SupplierProperty); }
            set { SetRefEntity(SupplierProperty, value); }
        }
        #endregion
        protected override EntityList Fetch()
        {
            return RT.Service.Resolve<ProductManageController>().GetProducManage(this);
        }
    }
}
