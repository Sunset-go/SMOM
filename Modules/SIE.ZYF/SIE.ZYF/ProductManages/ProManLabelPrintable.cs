using SIE.Common.Prints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SIE.ZYF.ProductManages
{
    [DisplayName("产品管理标签打印")]
    public class ProManLabelPrintable : LabelPrintable<ProductManage>
    {
        public override IEnumerable<string> GetPropertys(Type type = null)
        {
            var properties = base.GetPropertys(type).ToList();
            properties.Add("供应商编码");
            properties.Add("供应商名称");
            return properties;
        }
        public override string ConverterData(object data)
        {
            var Separator = "|";
            var cData = base.ConverterData(data);
            if (data is ProductManage pm)
            {
                cData += pm.Supplier.Code
                    += Separator
                    += pm.Supplier.Name;
            }
            return cData;
        }
    }
}
