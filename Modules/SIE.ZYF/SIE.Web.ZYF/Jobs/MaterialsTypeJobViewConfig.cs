using SIE.ZYF.Jobs;

namespace SIE.Web.ZYF.Jobs
{
    public class MaterialsTypeJobViewConfig : WebViewConfig<MaterialsTypeJobParameter>
    {
        /// <summary>
        /// 配置明细视图
        /// </summary>
        protected override void ConfigDetailsView()
        {
            View.Property(p => p.MaterialsType).HasLabel("要统计的物料类型");
        }
    }
}
