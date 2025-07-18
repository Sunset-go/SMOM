using SIE.Domain;
using SIE.Web.Command;
using SIE.ZYF.PurchaseOrders;
using System;

namespace SIE.Web.ZYF.PurchaseOrders.Commands
{
    public class SaveFormOrderCommand : FormSaveCommand
    {
        protected override void DoSave(Entity entity)
        {
            if (entity is PurchaseOrder po)
            {
                if (po.PurchaseOrderList.Count == 0)
                {
                    throw new Exception("订单明细不能为空".L10N());
                    
                }
                else
                {
                    base.DoSave(po); // 调用父类方法
                }
            }
        }
    }
}
