using SIE.Domain.Validation;
using SIE.ZYF.Materials;
using System;

namespace SIE.ZYF.Units
{
    /// <summary>
	/// 单位被引用不允许删除
	/// </summary>
	[System.ComponentModel.DisplayName("单位被引用不允许删除")]
    [System.ComponentModel.Description("单位被物料引用不允许删除")]
    public class UnitRule : NoReferencedRule<Unit>
    {
        public UnitRule()
        {
            // 设置被引用的属性的ID属性
            Properties.Add(Material.UnitIdProperty);
            /// 设置错误消息
            MessageBuilder = (e, c) =>
            {
                var func = e as Unit;
                return "单位[{0}]被物料引用了，不允许删除".L10nFormat(func.Name);
            };
        }
    }
}
