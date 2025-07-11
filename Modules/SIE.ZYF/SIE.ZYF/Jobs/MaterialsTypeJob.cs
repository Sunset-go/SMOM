using SIE.Common.Schdules;
using SIE.ZYF.Materials;
using System;

namespace SIE.ZYF.Jobs
{
    [Job("物料类型数量统计", typeof(MaterialsTypeJobParameter))]
    public class MaterialsTypeJob : JobBase
    {
        protected override void ExecuteJob(object param)
        {
            MaterialsTypeJobParameter args = param as MaterialsTypeJobParameter;
            #region
            MaterialType? types = args.MaterialsType ?? throw new Exception("物料类型不能为空");
            var count = RT.Service.Resolve<JobController>().GetMaterialTypeCount(types);
            #endregion
            AddLog("[{0}]类型的物料数量为：{1}".L10nFormat(types.ToLabel(),count));
        }
    }
}
