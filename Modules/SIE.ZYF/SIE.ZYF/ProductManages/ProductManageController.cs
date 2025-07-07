using SIE.Domain;
using SIE.Web.ZYF.ProductManages;
using SIE.ZYF.Materials;
using SIE.ZYF.Suppliers;
using System;
using System.Linq;

namespace SIE.ZYF.ProductManages
{
    public class ProductManageController : DomainController
    {
        /// <summary>
        /// 获取启用供应商的信息
        /// </summary>
        /// <param name="pageingInfo">分页信息</param>
        /// <param name="state">状态</param>
        /// <param name="keyword">查询参数</param>
        /// <returns></returns>
        public virtual EntityList<Supplier> OpenState(PagingInfo pageingInfo, State state, string keyword)
        {
            var query = DB.Query<Supplier>().Where(p => p.State == state);

            // 关键词搜索
            if (keyword.IsNotEmpty())
            {
                query.Where(p => p.Code.Contains(keyword) || p.Name.Contains(keyword));
            }
            return query.ToList();
        }
        /// <summary>
        /// 获取供应商对应的物料信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pageingInfo"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public virtual EntityList<Material> QueryMaterial(Entity entity, PagingInfo pageingInfo, string keyword)
        {
            var query = DB.Query<Material>();
            if (entity != null)
            {
                var s = entity as ProductManage;
                query.Exists<SupplierMaterials>((m, sm) => sm.Where(p=>p.MaterialId == m.Id && p.SupplierId == s.SupplierId));
                if (keyword.IsNotEmpty())
                {
                    query.Where(p => p.Code.Contains(keyword) || p.Name.Contains(keyword));
                }
            }
            var list = query.ToList();
            return list;
        }
        /// <summary>
        /// 保存供应商物料信息
        /// </summary>
        /// <param name="providerMaterials">供应商物料</param>
        public virtual void SaveProviderMaterial(EntityList<SupplierMaterials>supplierMaterials)
        {
            RF.Save(supplierMaterials);
        }
        /// <summary>
        /// 修改产品功能修改次数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ModifyCount"></param>
        public virtual void UpdataModTimes(double id, int ModifyCount)
        {
            DB.Update<ProductManage>()
                .Where(p => p.Id == id) // 条件
                .Set(p => p.ModifyCount, ModifyCount+1)  // 修改次数加1
                .Execute();
        }
        public virtual EntityList<ProductManage> GetProducManage(ProductManageCriteria criteria) 
        {
            var query = DB.Query<ProductManage>();
            query.WhereIf(criteria.Supplier!=null, p => p.SupplierId == criteria.SupplierId);
            return query.Where(
                p=>p.Name.Contains(criteria.Name) && 
                p.Code.Contains(criteria.Code)).ToList(
                    criteria.PagingInfo,new EagerLoadOptions().LoadWithViewProperty()
                );
        }
    }
}
