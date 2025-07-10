using Castle.Core.Internal;
using NPOI.SS.Formula.Functions;
using SIE.Api;
using SIE.Common.Configs;
using SIE.Common.Configs.CommonConfigs;
using SIE.Common.NumberRules;
using SIE.Domain;
using SIE.Domain.Validation;
using SIE.ZYF.Controllers;
using SIE.ZYF.Materials;
using SIE.ZYF.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIE.ZYF.Materials
{
    public partial class MaterialsController : DomainController
    {
        /// <summary>
        /// 获取物料信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ApiService("获取物料信息")]
        [return: ApiReturn("物料信息")]
        public virtual List<MaterialQuery> GetMaterialList([ApiParameter("物料名称/编码")] string name)
        {
            // 返回物料编码，物料名称，物料类型，单位编码，单位名称
            var result = Query<Material>().Where(c => c.Name.Contains(name)||c.Code.Contains(name))
                .ToList(null, new EagerLoadOptions().LoadWithViewProperty());
            if (result.IsNullOrEmpty())
            {
                // 若为空，返回失败以及提示"物料[name]不存在"
                throw new ValidationException("物料[{0}]不存在".L10nFormat(name));
            }
            var r = new List<MaterialQuery>();
            foreach (var item in result)
            {
                r.Add(new MaterialQuery
                {
                    Code = item.Code,
                    Name = item.Name,
                    Material_Types = item.MaterialTypes.ToLabel(),
                    Unit_Code = item.Unit.Code,
                    Unit_Name = item.Unit.Name
                });
            }
            return r;
        }

        /// <summary>
        /// 更新物料名称
        /// </summary>
        /// <param name="code">物料编码</param>
        /// <param name="NewName">新物料名称</param>
        [ApiService("更新物料名称")]
        public virtual void UpdateMaterial([ApiParameter("物料编码")]string code, [ApiParameter("物料名称")]string NewName)
        {
            // 更新物料名称
            DB.Update<Material>().Where(c=>c.Code==code).Set(c=>c.Name,NewName).Execute();
        }
        /// <summary>
        /// 获取启用单位的信息
        /// </summary>
        /// <param name="pagingInfo">分页信息</param>
        /// <param name="state">状态</param>
        /// <param name="keyword">查询参数</param>
        /// <returns></returns>
        public virtual EntityList<Unit> GetUnit(PagingInfo pagingInfo, State state, string keyword)
        {
            var query = DB.Query<Unit>().Where(p => p.State == state);

            // 关键词搜索
            if (keyword.IsNotEmpty())
            {

                // 判断是否包含百分号
                bool isLike = keyword.StartsWith("%") || keyword.EndsWith("%");
                if (isLike)
                {
                    // 去掉前后百分号
                    var search = keyword.Trim('%');
                    // 包含百分号，则模糊查询
                    query.Where(p => p.Code.Contains(search) || p.Name.Contains(search));
                }
                else
                {
                    // 不包含百分号，则精确查询
                    query.Where(p => p.Code.Contains(keyword) || p.Name.Contains(keyword));
                }
            }
            return query.ToList();
        }
        public virtual string GetCode()
        {
            var config = ConfigService.GetConfig(new NoConfig(), typeof(Material));
            if (config == null || config.BacodeRule == null)
            {
                throw new ValidationException("没有配置产品编码规则".L10N());
            }
            return RT.Service.Resolve<NumberRuleController>()
                .GenerateSegment(config.NumberRuleId.Value, 1)
                .FirstOrDefault();
        }
    }
}
