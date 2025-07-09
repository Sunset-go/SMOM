using SIE.Web.Common;
using SIE.ZYF.Suppliers;

namespace SIE.Web.ZYF.Suppliers
{
    public class SupplierAddressViewConfig : WebViewConfig<SupplierAddress>
    {
        ///<summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigView()
        {
            View.AssignAuthorize(typeof(Supplier));
            View.FormEdit();
        }

        /// <summary>
        /// 配置明细视图
        /// </summary>
        protected override void ConfigDetailsView()
        {
            View.HasDetailColumnsCount(2);
            View.Property(p => p.AddressType)
                .UseCatalogEditor(e =>
            {
                e.CatalogType = SupplierAddress.SupplierAddressType;
                e.CatalogReloadData = true;
            });
            View.Property(p => p.CompanyName);
            View.Property(p => p.DetailAddress);
            View.Property(p => p.Concat);
            View.Property(p => p.PhoneNumber);
        }
        /// <summary>
        /// 配置列表视图
        /// </summary>
        protected override void ConfigListView()
        {
        }
    }
}
