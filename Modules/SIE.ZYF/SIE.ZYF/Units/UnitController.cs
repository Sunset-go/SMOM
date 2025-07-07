using SIE.Api;
using SIE.Domain;
using System;

namespace SIE.ZYF.Units
{
    public class UnitController : DomainController
    {
        /// <summary>
        /// 保存单位信息
        /// </summary>
        /// <param name="unitCode">单位编码</param>
        /// <param name="unitName">单位名称</param>
        /// <param name="unitType">单位类型</param>
        /// <param name="unitPrecision">单位精度</param>
        [ApiService("保存单位信息")]
        public virtual void SaveUnit(
            [ApiParameter("单位编码")] string unitCode,
            [ApiParameter("单位名称")]string unitName, 
            [ApiParameter("单位类型")]string unitType,
            [ApiParameter("单位精度")]int unitPrecision
        )
        {
            var query = Query<Unit>().Where(u => u.Code == unitCode).ToList(null, new EagerLoadOptions().LoadWithViewProperty());
            if (query.Count != 0)
            {
                foreach (var item in query)
                {
                    item.Name = unitName;
                    item.Type = unitType;
                    item.UnitPrecision = unitPrecision;
                }
                RF.Save(query);
            }
            else
            {
                var unit = new Unit
                {
                    Code = unitCode,
                    Name = unitName,
                    Type = unitType,
                    UnitPrecision = unitPrecision
                };
                RF.Save(unit);
            }
        }
    }
}
