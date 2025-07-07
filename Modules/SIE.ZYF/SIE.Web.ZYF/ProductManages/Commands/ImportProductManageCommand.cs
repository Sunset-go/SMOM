using SIE.Common.ImportHelper;
using SIE.Web.Common.Import.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SIE.Web.ZYF.ProductManages.Commands
{
    /// <summary>
    /// 产品管理导入命令
    /// </summary>
    public class ImportProductManageCommand : ImportCommandBase
    {
        protected override ImportCompleted GetImportCompleted()
        {
            return (DataRow[] drsSuccess, DataRow[] drsFailed) =>
            {

            };
        }

        protected override Type GetImportHandleType()
        {
            return typeof(ProductManageImportHandle);
        }
    }
}
