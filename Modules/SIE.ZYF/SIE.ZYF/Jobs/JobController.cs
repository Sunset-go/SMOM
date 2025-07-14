using SIE.Domain;
using SIE.ZYF.Materials;

namespace SIE.ZYF.Jobs
{
    public class JobController : DomainController
    {
        public virtual int GetMaterialTypeCount(MaterialType? types)
        {
            return DB.Query<Material>().Where(c => types == c.MaterialTypes).Count();
        }
    }
}
