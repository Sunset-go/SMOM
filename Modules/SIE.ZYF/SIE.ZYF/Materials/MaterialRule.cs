using SIE.Domain;
using SIE.Domain.Validation;
using SIE.ZYF.Suppliers;
using SIE.ZYF.Units;
using System;

namespace SIE.ZYF.Materials
{
    /// <summary>
	/// 单位被引用不允许删除
	/// </summary>
	[System.ComponentModel.DisplayName("物料被引用不允许删除")]
    [System.ComponentModel.Description("物料被供应商引用不允许删除")]
    public class MaterialRule: NoReferencedRule<Material>
    {
        public MaterialRule()
        {
            Properties.Add(SupplierMaterials.MaterialIdProperty);
            /// 设置错误消息
            MessageBuilder = (e,c) =>
            {
                var func = e as Material;
                return "物料[{0}]被供应商物料引用了，不允许删除".L10nFormat(func.Name);
            };
        }
    }
}
