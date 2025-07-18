using SIE.ZYF.ProductManages.Configs;

namespace SIE.Web.ZYF.ProductManages
{
    /// <summary>
    /// 采购数量视图配置
    /// </summary>
    internal class QuantityConfigValueViewConfig : WebViewConfig<QuantityConfigValue>
    {
        /// <summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigDetailsView()
        {
            View.Property(p => p.Quantity).UseSpinEditor(p => p.MinValue = 1);
        }
    }
}
