using SIE.ZYF.ProductManages.Configs;

namespace SIE.Web.ZYF.ProductManages
{
    /// <summary>
    /// 编码规则视图配置
    /// </summary>
    internal class CodeConfigValueViewConfig : WebViewConfig<CodeConfigValue>
    {
        /// <summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigDetailsView()
        {
            View.Property(p => p.CodeRule);
        }
    }
}
