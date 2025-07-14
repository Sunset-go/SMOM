using SIE.Web.Command;
using SIE.ZYF.Materials;

namespace SIE.Web.ZYF.Materials.Commands
{
    public class AddMaterialCommand : ViewCommand
    {
        protected override object Excute(ViewArgs args, string scope)
        {
            var material = args.Data.ToJsonObject<Material>();
            material.Code = RT.Service.Resolve<MaterialsController>().GetCode();

            return material.Code;
        }
    }
}
