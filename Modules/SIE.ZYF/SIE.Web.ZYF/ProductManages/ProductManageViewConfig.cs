using SIE.Domain;
using SIE.MetaModel.View;
using SIE.Web.ZYF.ProductManages.Commands;
using SIE.ZYF.ProductManages;

namespace SIE.Web.ZYF.ProductManages
{
    /// <summary>
    /// 产品管理功能视图配置
    /// </summary>
    internal class ProductManageViewConfig : WebViewConfig<ProductManage>
    {
        /// <summary>
        /// 修改视图组
        /// </summary>
        public const string EditProductManageCommand = "EditProductManageCommand";
        /// <summary>
        /// 审核视图组
        /// </summary>
        public const string ReviewProductManageCommand = "ReviewProductManageCommand";
        ///<summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigView()
        {
            View.DeclareExtendViewGroup(ReviewProductManageCommand, EditProductManageCommand);
            if (ViewGroup == EditProductManageCommand)
            {
                EditProductManageCommandView();
            }
            if (ViewGroup == ReviewProductManageCommand)
            {
                ReviewProductManageCommandView();
            }
        }
        /// <summary>
        /// 配置审核视图
        /// </summary>
        protected void ReviewProductManageCommandView()
        {
            View.UseDetail(columnCount: 2, dialogHeight: 400, dialogWidth: 750);
            using (View.OrderProperties())
            {
                View.Property(p => p.Remark).Show();
            }
        }
        /// <summary>
        /// 配置修改视图
        /// </summary>
        protected void EditProductManageCommandView()
        {
            View.UseDetail(columnCount: 2, dialogHeight: 400, dialogWidth: 750);
            View.ReplaceCommands(WebCommandNames.FormSave, typeof(SaveProductManageCommand).FullName);
            View.AddBehavior("SIE.Web.ZYF.ProductManages.Behaviors.ProductManageAutoAddBehaviors");
            using (View.OrderProperties())
            {
                View.Property(p => p.Code).Readonly().Show();
                View.Property(p => p.Name).Readonly().Show();
                View.Property(p => p.PurchaseQuantity).Show();
                View.Property(p => p.PurchasePrice).Show();
                View.Property(p => p.Price).Show();
                View.Property(p => p.Description).Show();
            }
        }
        ///<summary>
        /// 配置列表视图
        /// </summary>
        protected override void ConfigListView()
        {
            View.AddBehavior("SIE.Web.ZYF.ProductManages.Behaviors.ProductManageColorBehavior");
            View.FormEdit();
            View.UseDefaultCommands();
            View.ReplaceCommands(WebCommandNames.Add, typeof(AddProductManageCommand).FullName);
            View.ReplaceCommands(WebCommandNames.Edit, "SIE.Web.ZYF.ProductManages.Commands.EditProductManageCommand");
            View.ReplaceCommands(WebCommandNames.Copy, "SIE.Web.ZYF.ProductManages.Commands.ReviewProductManageCommand");
            View.UseCommands(typeof(ImportProductManageCommand).FullName);
            View.UseCommands(typeof(ProManPrintableCommand).FullName);
            View.ReplaceCommands(WebCommandNames.Delete, typeof(DeleteProductManageCommand).FullName);
            View.Property(p => p.Code).Readonly(p => p.PersistenceStatus != PersistenceStatus.New);
            View.Property(p => p.Name).Readonly(p => p.PersistenceStatus != PersistenceStatus.New);
            View.Property(p => p.Description);
            View.Property(p => p.Status).DefaultValue((int)ProductStatus.UnAudit);
            View.Property(p => p.PurchaseQuantity);
            View.Property(p => p.PurchasePrice);
            View.Property(p => p.Price);
            View.Property(p => p.Supplier);
            View.Property(p => p.ProductMaterialId);
            View.Property(p => p.ModifyCount);
            View.Property(p => p.Remark);
            View.Property(p => p.CreateByName);
            View.Property(p => p.CreateDate);
            View.Property(p => p.UpdateByName);
            View.Property(p => p.UpdateDate);
            View.ChildrenProperty(p => p.ProductManageAttachment);
        }

        ///<summary>
		/// 配置明细视图
		/// </summary>
		protected override void ConfigDetailsView()
        {
            View.HasDetailColumnsCount(2);
            View.UseDefaultCommands();
            View.AddBehavior("SIE.Web.ZYF.ProductManages.Behaviors.AddProductManageBehavior");
            View.AddBehavior("SIE.Web.ZYF.ProductManages.Behaviors.ProductManageAutoAddBehaviors");
            View.Property(p => p.Code).Readonly();
            View.Property(p => p.Name).Readonly(p => p.PersistenceStatus != PersistenceStatus.New);
            View.Property(p => p.Status).DefaultValue((int)ProductStatus.UnAudit).Readonly();
            View.Property(p => p.PurchaseQuantity);
            View.Property(p => p.PurchasePrice);
            View.Property(p => p.Price);
            View.Property(p => p.SupplierId).UseDataSource((source, pagingInfo, keyword) =>
            {
                return RT.Service.Resolve<ProductManageController>().OpenState(pagingInfo, State.Enable, keyword);
            }).Cascade(p => p.ProductMaterialId, null);
            View.Property(p => p.ProductMaterialId).UseDataSource((source, pagingInfo, keyword) =>
            {
                return RT.Service.Resolve<ProductManageController>().QueryMaterial(source, pagingInfo, keyword);
            });
            View.Property(p => p.Description);
        }
        ///<summary>
		/// 配置下拉视图
		/// </summary>
		protected override void ConfigSelectionView()
        {
            View.Property(p => p.Code);
            View.Property(p => p.Name);
            View.Property(p => p.Description);
        }
        /// <summary>
		/// 配置查询视图
		/// </summary>
        protected override void ConfigQueryView()
        {
            View.Property(p => p.Code);
            View.Property(p => p.Name);
            View.Property(p => p.Supplier);
        }

        /// <summary>
        /// 配置导入视图
        /// </summary>
        protected override void ConfigImportView()
        {
            View.Property(p => p.Code);
            View.Property(p => p.Name);
            View.Property(p => p.Description);
            View.Property(p => p.Status);
            View.Property(p => p.PurchaseQuantity);
            View.Property(p => p.PurchasePrice);
            View.Property(p => p.Price);
            View.Property(p => p.SupplierId);
            View.Property(p => p.ProductMaterialId);
        }
    }
}