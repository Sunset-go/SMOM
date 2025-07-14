using SIE.Common.Prints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SIE.ZYF.Suppliers
{
    [DisplayName("供应商标签打印")]
    public class SupplierBillPrintable : BillPrintable<Supplier>
    {
        public override IEnumerable<string> GetPropertys(Type type = null)
        {
            var property = base.GetPropertys(type).ToList();
            property.Add("物料名称");
            return property;
        }

        public override string ConverterData(object data)
        {
            var converterData = base.ConverterData(data);
            if (data is SupplierMaterials sm)
            {
                converterData += sm.Material?.Name;
            }
            return converterData;
        }
    }
}
