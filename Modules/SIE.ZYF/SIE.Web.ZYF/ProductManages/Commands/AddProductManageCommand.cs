using SIE.Web.Command;
using SIE.ZYF.ProductManages;

namespace SIE.Web.ZYF.ProductManages.Commands
{
    public class AddProductManageCommand : ViewCommand
    {

        protected override object Excute(ViewArgs args, string scope)
        {
            var productManage = args.Data.ToJsonObject<ProductManage>();
            productManage.Code = RT.Service.Resolve<ProductManageController>().GetCode();
            productManage.PurchaseQuantity = RT.Service.Resolve<ProductManageController>().GetQuantity();
            return productManage;
        }
    }
}
