using DevExpress.CodeParser;
using SIE.MetaModel.View;
using SIE.ZYF.Suppliers;
using System;

namespace SIE.Web.ZYF.Suppliers
{
    public class SupplierPhoneViewConfig : WebViewConfig<SupplierPhone>
    {
        public const string SupplierConcatViewGroup = "SupplierConcatViewConfig";
        public const string SupplierConcatReadOnlyViewGroup = "SupplierConcatReadOnlyViewConfig";

        /// <summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigView()
        {
            View.DeclareExtendViewGroup(SupplierConcatViewGroup, SupplierConcatReadOnlyViewGroup);
            View.AssignAuthorize(typeof(Supplier));
            if(ViewGroup == SupplierConcatViewGroup)
            {
                SupplierConcatViewConfig();
            }
            else if( ViewGroup == SupplierConcatReadOnlyViewGroup)
            {
                SupplierConcatReadOnlyViewConfig();
            }
        }
        /// <summary>
        /// 配置供应商联系人只读视图
        /// </summary>
        private void SupplierConcatReadOnlyViewConfig()
        {
            View.DisableEditing();
            using (View.OrderProperties()) {
                View.Property(p => p.Concat).Show();
                View.Property(p => p.ConcatAddress).Show();
                View.Property(p => p.Phone).Show();
            };
        }
        /// <summary>
        /// 配置供应商联系人视图
        /// </summary>
        private void SupplierConcatViewConfig()
        {
            View.UseCommands("SIE.Web.ZYF.Suppliers.Commands.AddSupplierPhoneCommand");
            View.UseCommands(WebCommandNames.Delete);
            using(View.OrderProperties())
            {
                View.Property(p => p.Concat).Show();
                View.Property(p => p.ConcatAddress).Show();
                View.Property(p => p.Phone).Show();
            }
        }
    }
}
