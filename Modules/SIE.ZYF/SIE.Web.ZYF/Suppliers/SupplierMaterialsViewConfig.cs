using DevExpress.CodeParser;
using DevExpress.DataProcessing;
using DevExpress.PivotGrid.CriteriaVisitors;
using SIE.MetaModel.View;
using SIE.Web.ZYF.Suppliers.Commands;
using SIE.ZYF.Materials;
using SIE.ZYF.Suppliers;
using System.Collections.Generic;

namespace SIE.WPF.ZYF.Suppliers
{
    /// <summary>
    /// 视图配置
    /// </summary>
	internal class SupplierMaterialsViewConfig : WebViewConfig<SupplierMaterials>
	{
        ///<summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigView()
		{
            View.HasDelegate(SupplierMaterials.MaterialIdProperty);
            View.UseDefaultCommands();
		}

        ///<summary>
        /// 配置列表视图
        /// </summary>
        protected override void ConfigListView()
		{
            View.UseDefaultCommands();
            View.RemoveCommands(WebCommandNames.Edit);
            View.UseCommands(typeof(SelectionMaterialsCommand).FullName);
            View.RemoveCommands(WebCommandNames.Copy);
            View.RemoveCommands(WebCommandNames.Save);
            View.RemoveCommands(WebCommandNames.ExportXls);
            View.RemoveCommands(WebCommandNames.ExportXlsAll);
            View.RemoveCommands(WebCommandNames.ExportXlsSelection);
            View.Property(p => p.MaterialId).UsePagingLookUpEditor((c, p) =>
            {	// 配置下拉框，通过编码动态设置名称
                Dictionary<string, string> dic = new Dictionary<string, string>
                {
                    { nameof(p.Name), nameof(p.Material.Name) }
                };
				c.DicLinkField = dic;
            });
			View.Property(p => p.Name).Readonly();
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
			View.Property(p => p.MaterialId);
            View.Property(p => p.Name);
		} 
	}
}