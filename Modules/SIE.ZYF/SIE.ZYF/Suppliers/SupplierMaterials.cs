using SIE;
using SIE.Domain;
using SIE.MetaModel;
using SIE.ObjectModel;
using SIE.ZYF.Materials;
using SIE.ZYF.Suppliers;
using System;

namespace SIE.ZYF.Suppliers
{
	/// <summary>
	/// 
	/// </summary>
	[ChildEntity, Serializable]
    //[CriteriaQuery]
    [Label("供应商物料")]
    public partial class SupplierMaterials : DataEntity
    {
        #region 供应商物料与物料的功能 Material
        /// <summary>
        /// 供应商物料与物料的功能Id
        /// </summary>
        [Label("物料编码")]
        public static readonly IRefIdProperty MaterialIdProperty = P<SupplierMaterials>.RegisterRefId(e => e.MaterialId, ReferenceType.Normal);

        /// <summary>
        /// 供应商物料与物料的功能Id
        /// </summary>
        public double MaterialId
        {
            get { return (double)GetRefId(MaterialIdProperty); }
            set { SetRefId(MaterialIdProperty, value); }
        }

        /// <summary>
        /// 供应商物料与物料的功能
        /// </summary>
        public static readonly RefEntityProperty<Material> MaterialProperty = P<SupplierMaterials>.RegisterRef(e => e.Material, MaterialIdProperty);

        /// <summary>
        /// 供应商物料与物料的功能
        /// </summary>
        public Material Material
        {
            get { return GetRefEntity(MaterialProperty); }
            set { SetRefEntity(MaterialProperty, value); }
        }
        #endregion

        #region 供应商与供应商物料的关系 Supplier
        /// <summary>
        /// 供应商与供应商物料的关系Id
        /// </summary>
        public static readonly IRefIdProperty SupplierIdProperty = P<SupplierMaterials>.RegisterRefId(e => e.SupplierId, ReferenceType.Parent);

        /// <summary>
        /// 供应商与供应商物料的关系Id
        /// </summary>
        public double SupplierId
        {
            get { return (double)GetRefId(SupplierIdProperty); }
            set { SetRefId(SupplierIdProperty, value); }
        }

        /// <summary>
        /// 供应商与供应商物料的关系
        /// </summary>
        public static readonly RefEntityProperty<Supplier> SupplierProperty = P<SupplierMaterials>.RegisterRef(e => e.Supplier, SupplierIdProperty);

        /// <summary>
        /// 供应商与供应商物料的关系
        /// </summary>
        public Supplier Supplier
        {
            get { return GetRefEntity(SupplierProperty); }
            set { SetRefEntity(SupplierProperty, value); }
        }
        #endregion

        #region 物料名称 Name
        /// <summary>
        /// 物料名称
        /// </物料summary>
        //[Required]
        [Label("物料名称")]
        public static readonly Property<string> NameProperty = P<SupplierMaterials>.RegisterView(e => e.Name,p=>p.Material.Name);

        /// <summary>
        /// 物料名称
        /// </summary>
        public string Name
        {
            get { return GetProperty(NameProperty); }
        }
        #endregion

    }


    /// <summary>
    ///  实体配置
    /// </summary>
    internal class SupplierMaterialsConfig : EntityConfig<SupplierMaterials>
	{
		/// <summary>
      	  	/// 配置元数据
    	    	/// </summary>
		protected override void ConfigMeta()
		{
			Meta.MapTable("SUPPLIER_MATERIALS").MapAllProperties();
			Meta.EnablePhantoms();
		}
	}
}