using SIE.Web.Command;
using SIE.ZYF.PurchaseOrders;

namespace SIE.Web.ZYF.PurchaseOrders.Commands
{
    public class AddPurOrderCommand : ViewCommand
    {
        protected override object Excute(ViewArgs args, string scope)
        {
            var productManage = args.Data.ToJsonObject<PurchaseOrder>();
            productManage.OrderNumber = RT.Service.Resolve<PuOrderController>().GetOrderNumber();
            return productManage.OrderNumber;
        }
    }

}
