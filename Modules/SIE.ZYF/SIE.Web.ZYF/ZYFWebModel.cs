using SIE.MetaModel;
using SIE.Modules;
using SIE.Web.ZYF;
using SIE.Web.ZYF.OrderCollections;
using System;
[assembly: Module(typeof(ZYFWebModel))]
namespace SIE.Web.ZYF
{
    public class ZYFWebModel : UIModule
    {
        /// <summary>
        /// 模块初始化
        /// </summary>
        /// <param name="app"></param>
        public override void Initialize(IApp app)
        {
            app.ModuleOperations += App_ModuleOperations;
        }

        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void App_ModuleOperations(object sender, EventArgs e)
        {
            CommonModel.Modules.AddModules(
            new WebModuleMeta()
            {
                EntityType = typeof(SIE.ZYF.Units.Unit),
                Label = "单位"
            },
            new WebModuleMeta()
            {
                EntityType = typeof(SIE.ZYF.Materials.Material),
                Label = "物料"
            },
            new WebModuleMeta()
            {
                EntityType = typeof(SIE.ZYF.Suppliers.Supplier),
                Label = "供应商"
            },
            new WebModuleMeta()
            {
                EntityType = typeof(SIE.ZYF.ProductManages.ProductManage),
                Label = "产品管理"
            },
            new WebModuleMeta()
            {
                EntityType = typeof(SIE.ZYF.PurchaseOrders.PurchaseOrder),
                Label = "采购订单"
            },
            new WebModuleMeta()
            {
                EntityType = typeof(OrderCollectionViewModel),
                Label = "订单采集",
                ViewGroup = ViewConfig.DetailsView
            }
            );
        }
    }
}
