using SIE.Domain;
using SIE.Web.Command;
using SIE.ZYF.ProductManages;

namespace SIE.Web.ZYF.ProductManages.Commands
{
    public class SaveProductManageCommand: FormSaveCommand
    {
        protected override void DoSave(Entity entity)
        {
            if (entity is ProductManage product)
            {
                RT.Service.Resolve<ProductManageController>().UpdataModTimes(product.Id, product.ModifyCount);
            }
            base.OnSaved(entity); // 调用父类方法
        }
    }
}
