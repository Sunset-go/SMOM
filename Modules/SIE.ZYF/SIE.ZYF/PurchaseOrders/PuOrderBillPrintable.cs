using SIE.Common.Prints;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIE.ZYF.PurchaseOrders
{
    /// <summary>
    /// 采购订单据打印
    /// </summary>
    [DisplayName("采购订单单据打印")]
    public class PuOrderBillPrintable : BillPrintable<PurchaseOrder>
    {
        public override IEnumerable<string> GetPropertys(Type type = null)
        {
            var property = new List<string>();
            if (type == typeof(PurchaseOrder))
            {
                property.Add("单号");
                property.Add("采购日期");
                property.Add("总金额");
                property.Add("状态");
                property.Add("备注");
                property.Add("创建人");
                property.Add("创建时间");
                property.Add("修改人");
                property.Add("修改时间");
                property.Add("Id");
            }
            if (type == typeof(OrderDetail))
            {
                property.Add("产品编码");
                property.Add("产品名称");
                property.Add("采购价");
                property.Add("采购数量");
                property.Add("总金额");
                property.Add("描述");
                property.Add("修改人");
                property.Add("修改时间");
                property.Add("Id");
                property.Add("PurchaseOrderId");
            }
            return property;
        }

        public override string ConverterData(object data)
        {
            var content = string.Empty;
            if (data is PurchaseOrder)
            {
                if (data is PurchaseOrder order)
                {
                    content += order.OrderNumber + Separator
                        + order.PurchaseDate.ToString("yyyy年MM月dd日") + Separator
                        + order.TotalAmount + Separator
                        + order.Status.ToLabel() + Separator
                        + order.Remarks + Separator
                        + order.CreateByName + Separator
                        + order.CreateDate.ToString("yyyy年MM月dd日") + Separator
                        + order.UpdateByName + Separator
                        + order.UpdateDate.ToString("yyyy年MM月dd日") + Separator
                        + order.Id + Separator;
                }
            }
            if (data is OrderDetail)
            {
                var detail = data as OrderDetail;
                if (detail != null)
                {
                    content += detail.ProManDetail?.Code + Separator
                        + detail.Name + Separator
                        + detail.PurPrice + Separator
                        + detail.PurQty + Separator
                        + detail.TotalAmount + Separator
                        + detail.Remark + Separator
                        + detail.UpdateByName + Separator
                        + detail.UpdateDate.ToString("yyyy年MM月dd日") + Separator
                        + detail.Id + Separator
                        + detail.PurchaseOrderId + Separator;
                }
            }
            return content;
        }
    }
}
