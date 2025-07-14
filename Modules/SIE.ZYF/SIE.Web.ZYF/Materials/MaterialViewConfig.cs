using SIE.Domain;
using SIE.MetaModel.View;
using SIE.Web.ZYF.Materials.Commands;
using SIE.ZYF.Materials;

namespace SIE.Web.ZYF.Materials
{
    /// <summary>
    /// 物料功能视图配置
    /// </summary>
    internal class MaterialViewConfig : WebViewConfig<Material>
    {


        ///<summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigView()
        {
            View.HasDelegate(Material.NameProperty);
            View.UseDefaultCommands();
        }

        ///<summary>
        /// 配置列表视图
        /// </summary>
        protected override void ConfigListView()
        {
            View.UseDefaultCommands();
            View.ReplaceCommands(WebCommandNames.Add,typeof(AddMaterialCommand).FullName);
            View.AddBehavior("SIE.Web.ZYF.Materials.Behaviors.DescriptionToNameBehavior");
            View.Property(p => p.Code).Readonly().FixColumn();
            View.Property(p => p.Name).FixColumn();
            View.Property(p => p.Description);
            View.Property(p => p.MaterialTypes).DefaultValue(MaterialType.Products);
            View.Property(p => p.UnitId).UseDataSource((source, pagingInfo, keyword) =>
            {
                return AppRuntime.Service.Resolve<MaterialsController>().GetUnit(pagingInfo, State.Enable, keyword);
            });
        }

        ///<summary>
        /// 配置明细视图
        /// </summary>
        protected override void ConfigDetailsView()
        {
        }

        ///<summary>
        /// 配置下拉视图
        /// </summary>
        protected override void ConfigSelectionView()
        {
            View.Property(p => p.Code);  // 编码
            View.Property(p => p.Name);  // 名称
            View.Property(p => p.UnitId);  // 单位
            View.Property(p => p.MaterialTypes);  // 物料类型
        }

        ///<summary>
		///配置查询视图
		///</summary>
		protected override void ConfigQueryView()
        {
            View.Property(p => p.Code);  // 编码
            View.Property(p => p.Name);  // 名称
            View.Property(p => p.UnitId);  // 单位
            View.Property(p => p.MaterialTypes);  // 物料类型
        }


    }
}