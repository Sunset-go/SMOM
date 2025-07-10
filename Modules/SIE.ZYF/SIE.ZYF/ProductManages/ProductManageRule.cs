using SIE.Domain;
using SIE.Domain.Validation;
using SIE.MetaModel;
using System;

namespace SIE.ZYF.ProductManages
{
    /// <summary>
    /// 销售价格验证
    /// </summary>
    [System.ComponentModel.DisplayName("销售价格验证")]
    [System.ComponentModel.Description("销售价格必须大于0，且销售价格必须大于等于采购价")]
    public class ProductManageRule : EntityRule<ProductManage>
    {
        public ProductManageRule()
        {
            Property = ProductManage.PriceProperty;
            ConnectToDataSource = false;
        }

        protected override void Validate(IEntity entity, RuleArgs e)
        {
            ProductManage productManage = entity as ProductManage;
            if (productManage != null)
            {
                if (productManage.Price <= 0)
                {
                    e.BrokenDescription = "销售价格必须大于0".L10N();
                }
                else if (productManage.Price < productManage.PurchasePrice)
                {
                    e.BrokenDescription = "销售价格必须大于等于采购价".L10N();
                }
            }
        }

    }
}

