using NPOI.SS.Formula.Functions;
using SIE.Api;
using SIE.Domain;
using SIE.ZYF.Controllers;
using SIE.ZYF.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SIE.ZYF.Suppliers
{
    public partial class SupplierController : DomainController
    {
        /// <summary>
        /// 获取物料信息
        /// </summary>
        /// <param name="suppliersCode">供应商编码</param>
        /// <param name="materialCode">物料编码</param>
        /// <param name="suppliersDateStart">供应商修改时间开始</param>
        /// <param name="suppliersDateEnd">供应商修改时间结束</param>
        /// <param name="pagination">分页参数</param>
        /// <returns>
        /// </returns>
        [ApiService("获取供应商信息")]
        [return: ApiReturn("供应商信息")]
        public virtual Supplier1Info GetSuppliers(
            [ApiParameter("供应商编码编码")] string suppliersCode,
            [ApiParameter("物料编码")] string materialCode,
            [ApiParameter("供应商修改时间开始")] DateTime suppliersDateStart,
            [ApiParameter("供应商修改时间结束")] DateTime suppliersDateEnd,
            [ApiParameter("分页参数")] PagingInfo pagingInfo
        )
        {
            var elo = new EagerLoadOptions();
            elo.LoadWithViewProperty();
            elo.LoadWith(Supplier.SupplierMaterialsListProperty);
            elo.LoadWith(SupplierMaterials.MaterialProperty);
            var query = DB.Query<Supplier>().WhereIf(suppliersCode.IsNotEmpty(), s => s.Code == suppliersCode);
            //select l.*from SUPPLIER l
            //where l.CODE = 'a1Code'
            //and exists(
            //    select o.* from SUPPLIER_MATERIALS o
            //    join MATERIAL m
            //    on m.Id = o.MATERIAL_ID and o.SUPPLIER_ID = l.Id and m.CODE like 'a1%'
            //);
            query.Exists<SupplierMaterials>(
                (p, sm) => sm.Join<Material>((o, m) => m.Code.Contains(materialCode) && m.Id == o.MaterialId && o.SupplierId == p.Id)
            );

            query.Where(p=>p.UpdateDate>=  suppliersDateStart).Where(p=>p.UpdateDate <= suppliersDateEnd);
            var result = query.ToList(new PagingInfo
            {
                IsNeedCount = true,
                PageNumber = pagingInfo.PageNumber,
                PageSize = pagingInfo.PageSize
            }, elo);
            var res = new Supplier1Info
            {
                Count = result.TotalCount,
                SuppliersList = new List<Supplier2Info>()
            };
            foreach (var supplier in result)
            {
                var materialsList = new List<Materials3Info>();

                // 添加 null 检查
                if (supplier.SupplierMaterialsList != null)
                {
                    foreach (var supplierMaterial in supplier.SupplierMaterialsList)
                    {
                        // 添加 null 检查
                        if (supplierMaterial?.Material != null)
                        {
                            materialsList.Add(new Materials3Info
                            {
                                Code = supplierMaterial.Material.Code,
                                Name = supplierMaterial.Material.Name
                            });
                        }
                    }
                }

                res.SuppliersList.Add(new Supplier2Info
                {
                    Code = supplier.Code,
                    Name = supplier.Name,
                    materialsList = materialsList // 使用实际填充的列表而非 null
                });
            }
            return res;
        }
    }
}
