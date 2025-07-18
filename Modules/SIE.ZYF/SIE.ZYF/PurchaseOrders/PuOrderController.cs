using SIE.Common.Configs;
using SIE.Common.Configs.CommonConfigs;
using SIE.Common.NumberRules;
using SIE.Domain;
using SIE.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIE.ZYF.PurchaseOrders
{
    /// <summary>
    /// 采购订单控制器
    /// </summary>
    public class PuOrderController : DomainController
    {
        /// <summary>
        /// 获取采购订单明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sortInfo"></param>
        /// <param name="pagingInfo"></param>
        /// <returns></returns>
        public virtual EntityList<OrderDetail> GetPuOrderList(double id, IList<OrderInfo> sortInfo, PagingInfo pagingInfo)
        {
            return DB.Query<OrderDetail>()
                .Where(o => o.Id == id)
                .OrderBy(sortInfo)
                .ToList(pagingInfo, new EagerLoadOptions().LoadWithViewProperty());
        }
        /// <summary>
        /// 获取采购订单号
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public virtual string GetOrderNumber()
        {
            var config = ConfigService.GetConfig(new NoConfig(), typeof(PurchaseOrder));
            if (config == null || config.BacodeRule == null)
            {
                throw new ValidationException("没有配置订单号编码规则".L10N());
            }
            return RT.Service.Resolve<NumberRuleController>()
                .GenerateSegment(config.NumberRuleId.Value, 1)
                .FirstOrDefault();
        }
    }
}
