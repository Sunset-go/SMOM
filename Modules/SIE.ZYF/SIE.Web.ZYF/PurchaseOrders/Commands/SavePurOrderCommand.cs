using SIE.Domain;
using SIE.Domain.Validation;
using SIE.Web.Command;
using SIE.ZYF.PurchaseOrders;
using System;
using System.Collections.Generic;
namespace SIE.Web.ZYF.PurchaseOrders.Commands
{
    public class SavePurOrderCommand : SaveCommand
    {
        protected override void DoSave(EntityList data)
        {
            var orderIdList = new List<double?>();
            foreach (var item in data.DeletedList)
            {
                var order = item as OrderDetail;
                orderIdList.Add(order.PurchaseOrderId);
                var deleteQuery = DB.Query<OrderDetail>()
                    .Where(p => p.PurchaseOrderId == order.PurchaseOrderId);
                if(deleteQuery.Count() - data.DeletedList.Count <= 0)
                {
                    throw new ValidationException("订单明细不能为空".L10N());
                }
            }
            base.DoSave(data);
            foreach (var item in orderIdList)
            {
                double totalAmount = 0;
                var query = DB.Query<OrderDetail>()
                    .Where(p => p.PurchaseOrderId == item) // 根据订单ID查询订单明细
                    .ToList(); // 获取订单明细列表
                foreach (var o in query)
                {
                    totalAmount += o.TotalAmount;
                }
                DB.Update<PurchaseOrder>()
                    .Where(p => p.Id == item)
                    .Set(p => p.TotalAmount, totalAmount)
                    .Execute();
            }
        }
        protected override void OnSaving(EntityList data)
        {
            foreach (var item in data)
            {
                var order = item as OrderDetail;
                if(order.PurQty == 0)
                {
                    throw new ValidationException("订单明细数量不能为0".L10N());
                }
            }
        }
    }
}
