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
                product.ModifyCount += 1;
                base.DoSave(product); // 调用父类方法
            }
        }
    }
}
