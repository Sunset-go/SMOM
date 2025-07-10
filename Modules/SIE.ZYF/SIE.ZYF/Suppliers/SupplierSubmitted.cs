using SIE.Domain;

namespace SIE.ZYF.Suppliers
{
    [System.ComponentModel.DisplayName("供应商地址提交")]
    [System.ComponentModel.Description("供应商地址提交")]
    public class SupplierSubmitted : OnSubmitted<Supplier>
    {
        protected override void Invoke(Supplier entity, EntitySubmittedEventArgs e)
        {
            if (e.Action == SubmitAction.Insert || e.Action == SubmitAction.Update)
            { // 新增或修改供应商时，自动生成供应商地址
                var supplierAddress = entity.GetProperty(SupplierExtension.SuAddressProperty); // 供应商地址
                if (supplierAddress != null && supplierAddress.SupAddressId == 0) // 新增供应商地址
                {
                    supplierAddress.SupAddressId = entity.Id; // 供应商地址ID
                    supplierAddress.SupAddress = entity; // 供应商地址
                    supplierAddress.PersistenceStatus = PersistenceStatus.New; // 状态
                    RF.Save(supplierAddress); // 保存供应商地址
                }
                else if (supplierAddress != null && supplierAddress.SupAddressId > 0) // 修改供应商地址
                {
                    RF.Save(supplierAddress); // 保存供应商地址
                }
            }
            if (e.Action == SubmitAction.Delete)
            {
                var address = RT.Service.Resolve<SupplierController>().SupplierAddressBySupplierId(entity.Id);
                RF.Save(address);
            }
        }
    }
}
