using SIE.Domain;
using SIE.Web.Command;
using SIE.ZYF.ProductManages;
using SIE.ZYF.Suppliers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIE.Web.ZYF.Suppliers.Commands
{
    internal class SelectionMaterialsCommand : ViewCommand
    {   
        protected override object Excute(ViewArgs args, string scope)
        {
            // 反序列化获取供应商Id及所选的物料
            var savedData = new EntityList<SupplierMaterials>();
            var selectionMaterialsArgs = args.Data.ToJsonObject<List<SupplierMaterials>>();
            if (null == selectionMaterialsArgs || selectionMaterialsArgs.Count == 0)
            {
                throw new ArgumentNullException("{0}数据参数不能为空".FormatArgs(nameof(selectionMaterialsArgs)));
            }
            foreach (var selectionMaterial in selectionMaterialsArgs)
            {
                var supplierMaterials = new SupplierMaterials();
                supplierMaterials.MaterialId = selectionMaterial.MaterialId;
                supplierMaterials.SupplierId = selectionMaterial.SupplierId;
                savedData.Add(supplierMaterials);
            }
            //Console.WriteLine(savedData);
            RT.Service.Resolve<ProductManageController>().SaveProviderMaterial(savedData);
            return true;
        }
    }
}
