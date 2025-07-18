using SIE.Domain;
using SIE.Domain.Validation;
using SIE.MetaModel;
using SIE.ZYF.ProductManages;
using System;

namespace SIE.ZYF.PurchaseOrders
{
    [System.ComponentModel.DisplayName("同一订单下不能有重复的产品")]
    [System.ComponentModel.Description("同一订单下不能有重复的产品")]
    public class OrderNotDuplicateRule : NotDuplicateRule<OrderDetail>
    {
        public OrderNotDuplicateRule()
        {
            Properties.Add(OrderDetail.ProManDetailIdProperty);
            Properties.Add(OrderDetail.PurchaseOrderIdProperty);
            MessageBuilder = (e) =>
            {
                var od = e as OrderDetail;
                return "已存在名称为[{0}]的产品".L10nFormat(od.ProManDetail.Name);
            };
        }
    }

    [System.ComponentModel.DisplayName("采购价格不能小于销售价格")]
    [System.ComponentModel.Description("采购价格不能小于销售价格")]
    public class OrderDetailRule : EntityRule<OrderDetail>
    {
        public OrderDetailRule()
        {
            Property = OrderDetail.PurPriceProperty;
            ConnectToDataSource = false;
        }
        protected override void Validate(IEntity entity, RuleArgs e)
        {
            var od = entity as OrderDetail;
            if (od != null)
            {
                var sPrice = DB.Query<ProductManage>()
                    .Where(p => p.Id == od.ProManDetailId)
                    .Select(p => p.Price).FirstOrDefault().Price;
                if (od.PurPrice > sPrice)
                {
                    e.BrokenDescription = "采购价格不能小于销售价格";
                }
            }
        }
    }
}
