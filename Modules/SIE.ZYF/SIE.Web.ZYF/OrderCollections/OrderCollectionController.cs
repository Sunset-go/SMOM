using SIE.Domain;
using SIE.Domain.Validation;
using SIE.ZYF.PurchaseOrders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIE.Web.ZYF.OrderCollections
{
    public class OrderCollectionController : DomainController
    {
        /// <summary>
        /// 获取订单明细列表
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="sortInfo"></param>
        /// <param name="pagingInfo"></param>
        /// <returns></returns>
        public virtual EntityList<OrderDetail> GetOrderDetail(string orderNumber, IList<OrderInfo> sortInfo, PagingInfo pagingInfo)
        {
            if (orderNumber == null) return new EntityList<OrderDetail>();
            return DB.Query<OrderDetail>()
                .Where(p => p.PurchaseOrder.OrderNumber == orderNumber)
                .OrderBy(sortInfo)
                .ToList(
                    pagingInfo,
                    new EagerLoadOptions().LoadWithViewProperty()
                );
        }
        /// <summary>
        /// 保存订单明细
        /// </summary>
        /// <param name="order"></param>
        /// <param name="code"></param>
        /// <exception cref="ValidationException"></exception>
        public virtual void SaveCollection(string order, string code)
        {


            var query = DB.Query<OrderDetail>() // 获取订单明细
                .Where(od => od.PurchaseOrder.OrderNumber == order && od.ProManDetail.Code == code) // 根据订单号和产品编号获取订单明细
                .FirstOrDefault(new EagerLoadOptions().LoadWithViewProperty()) ?? throw new ValidationException("没有找到对应的订单明细"); // 如果找不到，抛出异常
            var update = DB.Update<PurchaseOrder>().Where(p => p.OrderNumber == order); // 根据ID获取订单
            if (query.EnterQty < query.PurQty) // 如果入库数量小于采购数量
            {
                query.EnterQty += 1; // 入库数量加1
                RF.Save(query); // 保存订单明细
                var query_statue = DB.Query<OrderDetail>()
                    .Where(p => p.PurchaseOrder.OrderNumber == order)
                    .ToList(); // 获取订单明细列表
                if (query_statue.All(p =>p.EnterQty == p.PurQty)) // 如果所有订单明细的入库数量等于采购数量
                {
                    update.Set(p => p.Status, OrderStatus.All).Execute(); // 将订单状态设置为全部入库
                }
                else
                {
                    update.Set(p => p.Status, OrderStatus.Part).Execute(); // 否则将订单状态设置为部分入库
                }
            }
            else
            {
                throw new ValidationException("[产品 {0} 入库数量不能大于采购数量]".L10nFormat(query.Name));
            }
        }
    }
}
