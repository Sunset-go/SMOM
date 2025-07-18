using SIE.Common.Configs;

namespace SIE.ZYF.ProductManages.Configs
{
    [System.ComponentModel.DisplayName("采购数量配置")]
    [System.ComponentModel.Description("采购数量配置")]
    public class QuantityConfig : ModuleConfig<QuantityConfigValue>
    {
        private readonly QuantityConfigValue defaultValue = new QuantityConfigValue { Quantity = 1 };
        public override QuantityConfigValue DefaultValue
        {
            get { return defaultValue; }
        }
    }
}
