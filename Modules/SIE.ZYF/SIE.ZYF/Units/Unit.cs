using SIE.Domain;
using SIE.MetaModel;
using SIE.ObjectModel;
using System;


namespace SIE.ZYF.Units
{

    /// <summary>
    /// 单位功能
    /// </summary>
    [RootEntity, Serializable]
    [CriteriaQuery]
    [Label("单位")]
    [DisplayMember(nameof(Name))]
    [QueryMembers(new[] { nameof(Code), nameof(Name) })]
    public partial class Unit : DataEntity, IStateEntity
    {
        #region 单位编码 Code
        /// <summary>
        /// 单位编码
        /// </summary>
        [Required]
        [NotDuplicate]
        [Label("单位编码")]
        public static readonly Property<string> CodeProperty = P<Unit>.Register(e => e.Code);

        /// <summary>
        /// 单位编码
        /// </summary>
        public string Code
        {
            get { return GetProperty(CodeProperty); }
            set { SetProperty(CodeProperty, value); }
        }
        #endregion

        #region 单位名称 Name
        /// <summary>
        /// 单位名称
        /// </summary>
        [Required] // 非空
        [NotDuplicate] // 不允许重复
        [Label("单位名称")]
        public static readonly Property<string> NameProperty = P<Unit>.Register(e => e.Name);

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }
        #endregion

        #region 类型 Type
        /// <summary>
        /// 单位类型
        /// </summary>
		[Required]
        [Label("单位类型")]
        public static readonly Property<string> TypeProperty = P<Unit>.Register(e => e.Type);

        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
            get { return GetProperty(TypeProperty); }
            set { SetProperty(TypeProperty, value); }
        }
        #endregion

        #region 单位精度 UnitPrecision
        /// <summary>
        /// 单位精度
        /// </summary>
        [MinValue(0)]
        [Label("单位精度")]
        public static readonly Property<int> UnitPrecisionProperty = P<Unit>.Register(e => e.UnitPrecision);

        /// <summary>
        /// 单位精度
        /// </summary>
        public int UnitPrecision
        {
            get { return GetProperty(UnitPrecisionProperty); }
            set { SetProperty(UnitPrecisionProperty, value); }
        }
        #endregion

        #region 状态 State
        /// <summary>
        /// 状态
        /// </summary>
        [Label("状态")]
        public static readonly Property<State> StateProperty = P<Unit>.Register(e => e.State);

        /// <summary>
        /// 状态
        /// </summary>
        public State State
        {
            get { return this.GetProperty(StateProperty); }
            set { this.SetProperty(StateProperty, value); }
        }
        #endregion

        /// <summary>
        /// 快码类型
        /// </summary>
        public const string UnitType = "Unit_Type";
    }

    /// <summary>
    /// 单位功能 实体配置
    /// </summary>
    internal class UnitConfig : EntityConfig<Unit>
    {
        /// <summary>
        /// 配置元数据
        /// </summary>
        protected override void ConfigMeta()
        {
            Meta.MapTable("UNIT").MapAllProperties();
            Meta.EnablePhantoms();
        }
    }
}