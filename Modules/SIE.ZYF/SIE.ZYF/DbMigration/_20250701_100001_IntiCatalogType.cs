using System;
using System.Collections.Generic;
using System.Text;
using SIE.Common.Catalogs;
using SIE.Data.DbMigration;
using SIE.Domain;
using System.Linq;
using SIE.ZYF.Suppliers;
using SIE.ZYF.Units;

namespace SIE.ZYF.DbMigration
{
    /// <summary>
    /// 初始化快码
    /// </summary>
    public class _20250701_100001_IntiCatalogType : ManualDbMigration
    {
        /// <summary>  
        /// 数据库设置  
        /// </summary>  
        public override string DbSetting
        {
            get { return ZYFEntityDataProvider.ConnectionStringName; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public override string Description
        {
            get { return "添加快码"; }
        }
        /// <summary>
        /// 手动升级的类型：数据
        /// </summary>
        public override ManualMigrationType Type
        {
            get { return ManualMigrationType.Data; }
        }

        /// <summary>
        /// 不支持 Down
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        protected override void Down()
        {
        }
        /// <summary>
        /// 注入
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        protected override void Up()
        {
            RunCode(db =>
            {
                AppRuntime.InvOrg = 1;
                if (RT.Service.Resolve<CatalogController>().GetCatalogTypeList().FirstOrDefault(p => p.Code == Supplier.SupperType) == null)
                {
                    RF.Save(new CatalogType
                    {
                        Code = Supplier.SupperType,
                        Name = "供应商类型",
                        Description = "供应商类型",
                    });
                }
            });
            RunCode(db =>
            {
                AppRuntime.InvOrg = 1;
                if (RT.Service.Resolve<CatalogController>().GetCatalogTypeList().FirstOrDefault(p => p.Code == Supplier.SupperRegion) == null)
                {
                    RF.Save(new CatalogType
                    {
                        Code = Supplier.SupperRegion,
                        Name = "供应商区域",
                        Description = "供应商区域",
                    });
                }
            });
            RunCode(db =>
            {
                AppRuntime.InvOrg = 1;
                if (RT.Service.Resolve<CatalogController>().GetCatalogTypeList().FirstOrDefault(p => p.Code == Unit.UnitType) == null)
                {
                    RF.Save(new CatalogType
                    {
                        Code = Unit.UnitType,
                        Name = "类型",
                        Description = "单位类型",
                    });
                }
            });
        }
    }
}
