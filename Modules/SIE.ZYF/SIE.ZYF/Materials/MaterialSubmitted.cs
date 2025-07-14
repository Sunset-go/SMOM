using SIE.Domain;
using SIE.ZYF.Suppliers;

namespace SIE.ZYF.Materials
{
    [System.ComponentModel.DisplayName("物料提交后事件")]
    [System.ComponentModel.Description("物料提交后事件")]
    public class MaterialSubmitted : OnSubmitted<Material>
    {
        protected override void Invoke(Material entity, EntitySubmittedEventArgs e)
        {
            if (e.Action == SubmitAction.Update)
            {
                var ac = entity as Material;
                DB.Update<SupplierMaterials>().Set(p => p.Material.Name, ac.Name);
            }
        }
    }
}
