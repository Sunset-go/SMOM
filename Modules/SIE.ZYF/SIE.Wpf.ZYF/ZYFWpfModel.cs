using SIE.Modules;
using SIE.Wpf.ZYF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Module(typeof(ZYFWpfModel))]
namespace SIE.Wpf.ZYF
{
    public class ZYFWpfModel : UIModule
    {
        public override void Initialize(IApp app)
        {
            app.ModuleOperations += App_ModuleOperations;
        }

        private void App_ModuleOperations(object sender, EventArgs e)
        {
        }
    }
}
