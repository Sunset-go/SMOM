using SIE.Domain;
using SIE.MetaModel.View;
using SIE.Web.Common;
using SIE.ZYF.Suppliers;
using State = SIE.Domain.State;

namespace SIE.Web.ZYF.Suppliers
{
    /// <summary>
    /// 供应商功能视图配置
    /// </summary>
    internal class SupplierViewConfig : WebViewConfig<Supplier>
    {

        ///<summary>
        /// 配置明细视图
        /// </summary>
        protected override void ConfigDetailsView()
        {
            View.HasDetailColumnsCount(3); // 设置明细列数为3
            View.UseDefaultCommands(); // 使用默认命令
            View.Property(p => p.Code).Readonly(p => p.PersistenceStatus != Domain.PersistenceStatus.New);// 设置Code属性修改时为只读
            View.Property(p => p.Name);
            View.Property(p => p.Logo).UseImageComponentEditor(p =>
            {
                p.Width = 400;
                p.Height = 300;
            }).ShowInDetail(rowSpan: 8);
            View.Property(p => p.State).DefaultValue((int)State.Enable).Readonly();
            View.Property(p => p.Description);
            View.Property(p => p.Type).UseCatalogEditor(e =>
            {   // 快码设置供应商类型
                e.CatalogType = Supplier.SupperType;
                e.CatalogReloadData = true;
            });
            View.Property(p => p.Abbreviation);
            View.Property(p => p.EnglishName);
            View.Property(p => p.Region).UseCatalogEditor(e =>
            { // 快码设置供应商区域
                e.CatalogType = Supplier.SupperRegion;
                e.CatalogReloadData = true;
            });
            View.Property(p => p.TaxNumber);
            View.Property(p => p.ContactPerson);
            View.Property(p => p.ContactPhoneNumber);
            View.Property(p => p.ContactAddress);
            View.Property(p => p.Email);
            View.Property(p => p.PostalCode);
            View.Property(p => p.DataSourceEnum);
            View.Property(p => p.Remarks).UseMemoEditor();
            View.ChildrenProperty(p => p.SupplierMaterialsList);
            #region 供应商地址
            View.AssociateChildrenProperty(SupplierExtension.SuAddressProperty, (c) =>
            {
                var sup = c.Parent as Supplier;
                var address = RT.Service.Resolve<SupplierController>().SupplierAddressBySupplierId(sup.Id);
                if (address == null)
                {
                    var supplierAddress = new SupplierAddress();
                    supplierAddress.GenerateId();
                    return supplierAddress;
                }
                return address;
            }, SupplierAddressViewConfig.SupplierAddressViewGroup).HasLabel("供应商地址").Show(ChildShowInWhere.All);
            #endregion
            #region 供应商联系人
            View.AssociateChildrenProperty(SupplierExtension.SuConcatProperty, (c) =>
            {
                var pagingDataArgs = c as ChildPagingDataArgs;
                var sup = c.Parent as Supplier;
                var concat = RT.Service.Resolve<SupplierController>().SupplierConcatBySupplierId(sup.Id, pagingDataArgs.SortInfo, pagingDataArgs.PagingInfo);
                if (concat.Count == 0)
                {
                    return new EntityList<SupplierPhone>();
                }
                return concat;
            }, SupplierPhoneViewConfig.SupplierConcatViewGroup).HasLabel("供应商联系人").Show(ChildShowInWhere.All);
            #endregion
        }

        ///<summary>
        /// 配置列表视图
        /// </summary>
        protected override void ConfigListView()
        {
            View.FormEdit();
            View.UseDefaultCommands();
            View.RemoveCommands(WebCommandNames.Copy);
            View.Property(p => p.Code).FixColumn();
            View.Property(p => p.Name).FixColumn();
            View.Property(p => p.Logo).UseTextEditor(p => p.ColumnXType = "ImageInlineEditor");
            View.Property(p => p.State).DefaultValue((int)State.Enable).Readonly();
            View.Property(p => p.Description);
            View.Property(p => p.Type).UseCatalogEditor(e =>
            {   // 快码设置供应商类型
                e.CatalogType = Supplier.SupperType;
                e.CatalogReloadData = true;
            });
            View.Property(p => p.Abbreviation);
            View.Property(p => p.EnglishName);
            View.Property(p => p.Region).UseCatalogEditor(e =>
            { // 快码设置供应商区域
                e.CatalogType = Supplier.SupperRegion;
                e.CatalogReloadData = true;
            });
            View.Property(p => p.TaxNumber);
            View.Property(p => p.ContactPerson);
            View.Property(p => p.ContactPhoneNumber);
            View.Property(p => p.ContactAddress);
            View.Property(p => p.Email);
            View.Property(p => p.PostalCode);
            View.Property(p => p.Remarks);
            View.ChildrenProperty(p => p.SupplierMaterialsList);
            View.Property(p => p.DataSourceEnum);
            #region 供应商地址
            View.AssociateChildrenProperty(SupplierExtension.SuAddressProperty, (c) =>
            {
                var sup = c.Parent as Supplier;
                var address = RT.Service.Resolve<SupplierController>().SupplierAddressBySupplierId(sup.Id);
                if (address == null)
                {
                    var supplierAddress = new SupplierAddress();
                    supplierAddress.GenerateId();
                    return supplierAddress;
                }
                return address;
            }, SupplierAddressViewConfig.SupplierAddressReadOnlyViewGroup).HasLabel("供应商地址").Show(ChildShowInWhere.All);
            #endregion
            #region 供应商联系人
            View.AssociateChildrenProperty(SupplierExtension.SuConcatProperty, (c) =>
            {
                var pagingDataArgs = c as ChildPagingDataArgs;
                var sup = c.Parent as Supplier;
                var concat = RT.Service.Resolve<SupplierController>()
                .SupplierConcatBySupplierId(sup.Id, pagingDataArgs.SortInfo, pagingDataArgs.PagingInfo);
                if (concat.Count == 0)
                {
                    return new EntityList<SupplierPhone>();
                }
                return concat;
            }, SupplierPhoneViewConfig.SupplierConcatReadOnlyViewGroup).HasLabel("供应商联系人").Show(ChildShowInWhere.All);
            #endregion
        }

        ///<summary>
		///配置查询视图
		///</summary>
		protected override void ConfigQueryView()
        {
            View.Property(p => p.Code);
            View.Property(p => p.Name);
            View.Property(p => p.Type);
        }

        ///<summary>
        /// 配置下拉视图
        /// </summary>
        protected override void ConfigSelectionView()
        {
            View.Property(p => p.Code);
            View.Property(p => p.Name);
            View.Property(p => p.Logo).UseTextEditor(p => p.ColumnXType = "ImageInlineEditor");
            View.Property(p => p.Description);
            View.Property(p => p.Type).UseCatalogEditor(e =>
            {   // 快码设置供应商类型
                e.CatalogType = Supplier.SupperType;
                e.CatalogReloadData = true;
            });
            View.Property(p => p.Abbreviation);
            View.Property(p => p.EnglishName);
            View.Property(p => p.Region).UseCatalogEditor(e =>
            { // 快码设置供应商区域
                e.CatalogType = Supplier.SupperRegion;
                e.CatalogReloadData = true;
            });
            View.Property(p => p.TaxNumber);
            View.Property(p => p.ContactPerson);
            View.Property(p => p.ContactPhoneNumber);
            View.Property(p => p.ContactAddress);
            View.Property(p => p.Email);
            View.Property(p => p.PostalCode);
            View.Property(p => p.Remarks);
        }

        ///<summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigView()
        {
            View.HasDelegate(Supplier.NameProperty);
            View.UseDefaultCommands();
        }
    }
}