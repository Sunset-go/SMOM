using SIE.Domain;
using SIE.MetaModel;
using SIE.ZYF.ProductManages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIE.Web.ZYF.ProductManages
{
    public class ProductManageQueryViewConfig:WebViewConfig<ProductManageCriteria>
    {
        protected override void ConfigView()
        {
            View.Property(p => p.Code).Show(ShowInWhere.Detail);
            View.Property(p => p.Name).Show(ShowInWhere.Detail);
            View.Property(p => p.SupplierId).HasLabel("供应商").Show(ShowInWhere.Detail).UseDataSource((source, pageinfo, keyword) =>
            {
                return RT.Service.Resolve<ProductManageController>().OpenState(pageinfo, State.Enable, keyword);
            });
        }
    }
}
