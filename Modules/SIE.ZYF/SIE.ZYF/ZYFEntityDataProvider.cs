using SIE.Domain;
using SIE.Domain.ORM;
using SIE.ZYF;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: Repository(typeof(ZYFEntityDataProvider<>))]
namespace SIE.ZYF
{
    [DataProvider(typeof(ZYFEntityDataProvider))]
    internal class ZYFEntityDataProvider<T> : EntityRepository<T> where T : Entity
    {
    }

    public class ZYFEntityDataProvider : RdbDataProvider
    {
        public const string ConnectionStringName = "ZYF";
        protected override string ConnectionStringSettingName
        {
            get { return ConnectionStringName; }
        }
    }
}
