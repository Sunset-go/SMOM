using SIE.Domain;
using SIE.Web.Common;
using SIE.ZYF.Units;

namespace SIE.Web.ZYF.UnitFunctions
{
	/// <summary>
	/// 单位功能视图配置
	/// </summary>
	internal class UnitViewConfig : WebViewConfig<Unit>
	{
		///<summary>
		/// 配置视图
		/// </summary>
		protected override void ConfigView()
		{
			View.HasDelegate(Unit.NameProperty);
			View.UseDefaultCommands();
		}
		
		///<summary>
		/// 配置列表视图
		/// </summary>
		protected override void ConfigListView()
		{ 	  
			View.UseDefaultCommands(); 
			View.Property(p => p.Code).Readonly(p =>p.PersistenceStatus != PersistenceStatus.New);
			View.Property(p => p.Name);
			View.Property(p=>p.State).DefaultValue((int)State.Disable).Readonly();
			View.Property(p => p.Type).UseCatalogEditor(e =>
			{
				e.CatalogType = Unit.UnitType;
				e.CatalogReloadData = true;
			});
			View.Property(p => p.UnitPrecision);
			View.Property(p => p.CreateByName);
			View.Property(p => p.CreateDate).ShowInList(width: 200);
            View.Property(p => p.UpdateByName);
            View.Property(p => p.UpdateDate).ShowInList(width: 200);
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
			View.Property(p => p.Code)	;  // 编码
			View.Property(p => p.Name);  // 名称
			View.Property(p => p.Type);  // 类型
			View.Property(p => p.UnitPrecision);  // 单位精度
        }
		
		/// <summary>
		/// 配置查询视图
		/// </summary>
        protected override void ConfigQueryView()
        {
			View.Property(p => p.Code);
			View.Property(p => p.Name);
        }
    }
}