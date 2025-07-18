using SIE.Common.Configs;
using SIE.Common.Configs.CommonConfigs;
using SIE.Common.NumberRules;
using SIE.Common.Prints;
using SIE.Domain;
using SIE.Domain.Validation;
using SIE.ZYF.Materials;
using SIE.ZYF.ProductManages.Configs;
using SIE.ZYF.Suppliers;
using System;
using System.Collections.Generic;
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
            return query.ToList(pageingInfo, new EagerLoadOptions().LoadWithViewProperty());
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
                query.Exists<SupplierMaterials>((m, sm) => sm.Where(p => p.MaterialId == m.Id && p.SupplierId == s.SupplierId));
                if (keyword.IsNotEmpty())
                {
                    query.Where(p => p.Code.Contains(keyword) || p.Name.Contains(keyword));
                }
            }
            var list = query.ToList(pageingInfo, new EagerLoadOptions().LoadWithViewProperty());
            return list;
        }
        /// <summary>
        /// 保存供应商物料信息
        /// </summary>
        /// <param name="providerMaterials">供应商物料</param>
        public virtual void SaveProviderMaterial(EntityList<SupplierMaterials> supplierMaterials)
        {
            RF.Save(supplierMaterials);
        }
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public virtual EntityList<ProductManage> GetProducManage(ProductManageCriteria criteria)
        {
            var query = DB.Query<ProductManage>();
            query.WhereIf(criteria.Supplier != null, p => p.SupplierId == criteria.SupplierId);
            query.OrderBy(criteria.OrderInfoList);
            return query.Where(
                p => p.Name.Contains(criteria.Name) &&
                p.Code.Contains(criteria.Code)).ToList(
                    criteria.PagingInfo, new EagerLoadOptions().LoadWithViewProperty()
                );
        }
        /// <summary>
        /// 审核产品
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual bool IsReview(ReviewProductManageCommandArgument args)
        {
            var query = DB.Update<ProductManage>().Where(p => args.SelectIds.ToList().Contains(p.Id));
            query.Set(d => d.Remark, args.Remark);
            query.Set(d => d.Status, ProductStatus.Audited);
            query.Execute();
            return true;
        }
        /// <summary>
        /// 审核产品参数
        /// </summary>
        public class ReviewProductManageCommandArgument
        {
            public double[] SelectIds { get; set; }
            public string Remark { get; set; }
        }
        /// <summary>
        /// 获取产品编码
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public virtual string GetCode()
        {
            var config = ConfigService.GetConfig(new NoConfig(), typeof(ProductManage));
            if (config == null || config.BacodeRule == null)
            {
                throw new ValidationException("没有配置产品编码规则".L10N());
            }
            return RT.Service.Resolve<NumberRuleController>()
                .GenerateSegment(config.NumberRuleId.Value, 1)
                .FirstOrDefault();
        }
        /// <summary>
        /// 获取产品数量
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public virtual int GetQuantity()
        {
            var config = ConfigService.GetConfig(new QuantityConfig(), typeof(ProductManage)) ?? throw new ValidationException("没有配置产品数量规则".L10N());
            return config.Quantity;
        }
        /// <summary>
        /// 获取打印模板
        /// </summary>
        /// <returns></returns>
        public virtual PrintTemplate GetPrintTemplate()
        {
            return RT.Service.Resolve<PrintsController>().GetPrintTemplates("SIE.ZYF.ProductManages.ProManLabelPrintable,SIE.ZYF", true).FirstOrDefault();
        }
        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual EntityList<ProductManage> GetProManPrintData(List<double> ids)
        {
            return Query<ProductManage>().Where(p => ids.Contains(p.Id)).ToList();
        }
    }
}
