using SIE.Domain;
using SIE.Web.Command;
using SIE.ZYF.ProductManages;

namespace SIE.Web.ZYF.ProductManages.Commands
{
    public class SaveProductManageCommand: FormSaveCommand
    {
        protected override void OnSaved(Entity entity)
        {
            ProductManage product = entity as ProductManage;
            RT.Service.Resolve<ProductManageController>().UpdataModTimes(product.Id, product.ModifyCount);
            base.OnSaved(entity); // 调用父类方法
        }
    }
}
