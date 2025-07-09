using SIE.MetaModel.View;
using SIE.ZYF.Suppliers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIE.Web.ZYF.Suppliers
{
    public class SupplierPhoneViewConfig: WebViewConfig<SupplierPhone>
    {
        /// <summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigView()
        {
            View.AssignAuthorize(typeof(Supplier));
        }

        protected override void ConfigListView()
        {
            View.UseCommands("SIE.Web.ZYF.Suppliers.Commands.AddSupplierPhoneCommand");
            View.UseCommands(WebCommandNames.Delete);
            View.Property(p => p.Concat);
            View.Property(p=>p.ConcatAddress);
            View.Property(p => p.Phone);
        }
    }
}
