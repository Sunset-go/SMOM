using SIE.Web.Common;
using SIE.ZYF.Suppliers;

namespace SIE.Web.ZYF.Suppliers
{
    public class SupplierAddressViewConfig : WebViewConfig<SupplierAddress>
    {
        public const string SupplierAddressViewGroup = "SupplierAddressViewGroup";
        public const string SupplierAddressReadOnlyViewGroup = "SupplierAddressReadOnlyViewGroup";

        ///<summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigView()
        {
            View.DeclareExtendViewGroup(SupplierAddressViewGroup, SupplierAddressReadOnlyViewGroup);
            View.AssignAuthorize(typeof(Supplier));
            if (ViewGroup == SupplierAddressViewGroup)
            {
                SupplierAddressEditViewConfig();
            }
            else if (ViewGroup == SupplierAddressReadOnlyViewGroup)
            {
                SupplierAddressReadOnlyViewConfig();
            }
        }
        /// <summary>
        /// 配置可编辑视图
        /// </summary>
        private void SupplierAddressEditViewConfig()
        {
            View.HasDetailColumnsCount(2);
            using (View.OrderProperties())
            {
                View.Property(p => p.AddressType)
                .UseCatalogEditor(e =>
                {
                    e.CatalogType = SupplierAddress.SupplierAddressType;
                    e.CatalogReloadData = true;
                }).Show();
                View.Property(p => p.CompanyName).Show();
                View.Property(p => p.DetailAddress).Show();
                View.Property(p => p.Concat).Show();
                View.Property(p => p.PhoneNumber).Show();
            }
        }
        /// <summary>
        /// 配置只读视图
        /// </summary>
        protected void SupplierAddressReadOnlyViewConfig()
        {
            View.DisableEditing();
            View.HasDetailColumnsCount(2);
            using (View.OrderProperties())
            {
                View.Property(p => p.AddressType).UseCatalogEditor(p =>
                    {
                        p.CatalogReloadData = true;
                        p.CatalogType = SupplierAddress.SupplierAddressType;
                    }).Show();
                View.Property(p => p.CompanyName).Show();
                View.Property(p => p.DetailAddress).Show();
                View.Property(p => p.Concat).Show();
                View.Property(p => p.PhoneNumber).Show();
            }
        }

        ///// <summary>
        ///// 配置明细视图
        ///// </summary>
        //protected override void ConfigDetailsView()
        //{
        //}
        ///// <summary>
        ///// 配置列表视图
        ///// </summary>
        //protected override void ConfigListView()
        //{
        //}
    }
}
