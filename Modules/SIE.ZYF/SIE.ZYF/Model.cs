using SIE.Modules;
using System;

[assembly :Module(typeof(SIE.ZYF.Model))]

namespace SIE.ZYF
{
    public class Model : DomainModule
    {
        public override void Initialize(IApp app)
        {
        }
    }
}
