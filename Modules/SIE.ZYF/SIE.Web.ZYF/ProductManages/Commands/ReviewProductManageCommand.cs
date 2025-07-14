using SIE.Web.Command;
using SIE.ZYF.ProductManages;
using static SIE.ZYF.ProductManages.ProductManageController;

namespace SIE.Web.ZYF.ProductManages.Commands
{
    /// <summary>
    /// 审核产品
    /// </summary>
    public class ReviewProductManageCommand : ViewCommand
    {
        /// <summary>
        /// 反序列化参数
        /// </summary>
        /// <param name="args"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        protected override object Excute(ViewArgs args, string scope)
        {
            var argument = args.Data.ToJsonObject<ReviewProductManageCommandArgument>();
            return RT.Service.Resolve<ProductManageController>().IsReview(argument);
        }

    }

}
