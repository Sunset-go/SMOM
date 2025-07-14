using SIE.Domain.Validation;
using System;

namespace SIE.ZYF.Suppliers
{

    /// <summary>
    /// 供应商物料不允许重复规则
    /// </summary>
    [System.ComponentModel.DisplayName("供应商、物料不允许重复")]
    [System.ComponentModel.Description("同一供应商下，不允许存在重复物料")]
    public class SupperMaterialsRule : NotDuplicateRule<SupplierMaterials>
    {
        public SupperMaterialsRule()
        {
            Properties.Add(SupplierMaterials.MaterialIdProperty);
            Properties.Add(SupplierMaterials.SupplierIdProperty);
            // 错误消息
            MessageBuilder = (e) =>
            {
                var supplier = e as SupplierMaterials;
                return "已存在物料为[{0}]的数据".L10nFormat(supplier.Material.Name);
            };
        }
    }
}