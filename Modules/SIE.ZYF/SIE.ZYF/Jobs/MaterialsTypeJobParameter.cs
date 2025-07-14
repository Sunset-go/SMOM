using SIE.Common.Schdules;
using SIE.Domain;
using SIE.ObjectModel;
using SIE.ZYF.Materials;
using System;

namespace SIE.ZYF.Jobs
{
    [RootEntity,Serializable]
    [Label("统计物料类型数量调度")]
    public class MaterialsTypeJobParameter : JobParameter
    {
        #region 物料类型 MaterialsType
        /// <summary>
        /// 物料类型
        /// </summary>
        [Label("物料类型")]
        public static readonly Property<MaterialType?> MaterialsTypeProperty = P<MaterialsTypeJobParameter>.Register(e => e.MaterialsType);

        /// <summary>
        /// 物料类型
        /// </summary>
        public MaterialType? MaterialsType
        {
            get { return GetProperty(MaterialsTypeProperty); }
            set { SetProperty(MaterialsTypeProperty, value); }
        }
        #endregion
    }
}
