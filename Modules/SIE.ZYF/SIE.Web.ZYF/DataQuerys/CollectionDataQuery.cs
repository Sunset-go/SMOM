using SIE.Domain;
using SIE.Domain.Validation;
using SIE.Web.Data;
using SIE.Web.ZYF.OrderCollections;
using SIE.ZYF.PurchaseOrders;
using System.Linq;

namespace SIE.Web.ZYF.DataQuerys
{
    public class CollectionDataQuery : DataQueryer
    {
        /// <summary>
        /// 分析列表为空时扫描采购订单号，根据订单号加载订单明细
        /// </summary>
        /// <param name="OrderNumber">订单号</param>
        /// <exception cref="ValidationException"></exception>
        public void LoadOrderDetails(string OrderNumber)
        {
            var orderNo = DB.Query<OrderDetail>()
                .Where(p => p.PurchaseOrder.OrderNumber == OrderNumber)
                .FirstOrDefault(new EagerLoadOptions().LoadWithViewProperty()) ?? throw new ValidationException("订单不存在");
        }
        /// <summary>
        /// 检验订单号是否存在，以及订单是否全部入库
        /// </summary>
        /// <param name="orderNo"></param>
        /// <exception cref="ValidationException"></exception>
        public void ValidationOrder(string orderNo)
        {
            var query = DB.Query<OrderDetail>()
                .Where(p => p.PurchaseOrder.OrderNumber == orderNo)
                .ToList() ?? throw new ValidationException("订单号不存在");
            if(query.All(x => x.EnterQty == x.PurQty))
            {
                throw new ValidationException("订单已全部入库");
            }
        }
        /// <summary>
        /// 订单明细部位空时扫描产品编码
        /// </summary>
        /// <param name="order"></param>
        /// <param name="code"></param>
        public void AddEntry(string order, string code)
        {
            RT.Service.Resolve<OrderCollectionController>().SaveCollection(order, code);
        }

    }
}
