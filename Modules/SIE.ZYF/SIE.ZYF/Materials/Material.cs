using SIE.Domain;
using SIE.MetaModel;
using SIE.ObjectModel;
using SIE.ZYF.Suppliers;
using SIE.ZYF.Units;
using System;

namespace SIE.ZYF.Materials
{
	/// <summary>
	/// 物料功能
	/// </summary>
	[RootEntity, Serializable]
	[CriteriaQuery]
	[Label("物料")]
	[DisplayMember(nameof(Code))]
	[QueryMembers(new[] { nameof(Code), nameof(Name) })]
	public partial class Material : DataEntity
	{
        #region 物料编码 Code
        /// <summary>
        /// 物料编码
        /// </summary>
        [Required] // 非空
		[Label("物料编码")]
		public static readonly Property<string> CodeProperty = P<Material>.Register(e => e.Code);

        /// <summary>
        /// 物料编码
        /// </summary>
        public string Code
		{
			get { return GetProperty(CodeProperty); }
			set { SetProperty(CodeProperty, value); }
		}
        #endregion

        #region 物料名称 Name
        /// <summary>
        /// 物料名称
        /// </summary>
        [Required]
		[NotDuplicate]
		[Label("物料名称")]
		public static readonly Property<string> NameProperty = P<Material>.Register(e => e.Name);

        /// <summary>
        /// 物料名称
        /// </summary>
        public string Name
		{
			get { return GetProperty(NameProperty); }
			set { SetProperty(NameProperty, value); }
		}
		#endregion

		#region 描述 Description
		/// <summary>
		/// 描述
		/// </summary>
		[Label("描述")]
		public static readonly Property<string> DescriptionProperty = P<Material>.Register(e => e.Description);

		/// <summary>
		/// 描述
		/// </summary>
		public string Description
		{
			get { return GetProperty(DescriptionProperty); }
			set { SetProperty(DescriptionProperty, value); }
		}
		#endregion

		#region 物料功能与单位功能的关系 Unit
		/// <summary>
		/// 物料功能与单位功能的关系Id
		/// </summary>
		[Label("单位")]
		public static readonly IRefIdProperty UnitIdProperty = P<Material>.RegisterRefId(e => e.UnitId, ReferenceType.Normal);

		/// <summary>
		/// 物料功能与单位功能的关系Id
		/// </summary>
		public double UnitId
		{
			get { return (double)GetRefId(UnitIdProperty); }
			set { SetRefId(UnitIdProperty, value); }
		}

		/// <summary>
		/// 物料功能与单位功能的关系
		/// </summary>
		public static readonly RefEntityProperty<Unit> UnitProperty = P<Material>.RegisterRef(e => e.Unit, UnitIdProperty);

		/// <summary>
		/// 物料功能与单位功能的关系
		/// </summary>
		public Unit Unit
		{
			get { return GetRefEntity(UnitProperty); }
			set { SetRefEntity(UnitProperty, value); }
		}
        #endregion

        #region 物料类型 MaterialType
        /// <summary>
        /// 物料类型
        /// 
        /// </summary>
        [Required]
		[Label("物料类型")]
		public static readonly Property<MaterialType?> MaterialTypeProperty = P<Material>.Register(e => e.MaterialTypes);

		/// <summary>
		/// 物料类型
		/// </summary>
		public MaterialType? MaterialTypes
        {
			get { return GetProperty(MaterialTypeProperty); }
			set { SetProperty(MaterialTypeProperty, value); }
		}

        public double SupplierMaterialsId { get; internal set; }
        #endregion
    }

		/// <summary>
		/// 物料功能 实体配置
		/// </summary>
	internal class MaterialConfig : EntityConfig<Material>
	{
		/// <summary>
      	  	/// 配置元数据
    	    	/// </summary>
		protected override void ConfigMeta()
		{
			Meta.MapTable("MATERIAL").MapAllProperties();
			Meta.EnablePhantoms();
		}
	}
}