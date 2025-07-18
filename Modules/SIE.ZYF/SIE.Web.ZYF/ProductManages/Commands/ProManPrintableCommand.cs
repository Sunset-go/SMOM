using SIE.Web.Command;
using SIE.Web.Common.Prints;
using SIE.ZYF.ProductManages;
using System;
using System.Collections.Generic;

namespace SIE.Web.ZYF.ProductManages.Commands
{
    /// <summary>
    /// 产品管理打印命令
    /// </summary>
    public class ProManPrintableCommand : ViewCommand
    {
        protected override object Excute(ViewArgs args, string scope)
        {
            List<double> ids = args.Data.ToJsonObject<List<double>>();
            // 获取打印模板
            var template = RT.Service.Resolve<ProductManageController>().GetPrintTemplate();
            // 根据类型获取报表处理对象
            var report = ReportFactory.Current.GetReportByExtension(template.Type);
            // 获取打印实体对象
            var printableType = Type.GetType(template.EntityType);
            // 获取打印数据
            var printData = RT.Service.Resolve<ProductManageController>().GetProManPrintData(ids);
            // 调用打印处理函数，返回打印模板Base6字符串
            var printable = new ProManLabelPrintable();
            return report.PrintProcess(printable, template.Id, template.Content, () =>
            {
                return printData;
            });

        }
    }
}
