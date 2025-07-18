using SIE.MetaModel.View;
using SIE.Web.ZYF.PurchaseOrders.Commands;
using SIE.ZYF.PurchaseOrders;
using System;

namespace SIE.Web.ZYF.PurchaseOrders
{
    /// <summary>
    /// 采购订单视图配置
    /// </summary>
    public class PurchaseOrderViewConfig : WebViewConfig<PurchaseOrder>
    {
        protected override void ConfigView()
        {
        }
        /// <summary>
        /// 配置列表视图
        /// </summary>
        protected override void ConfigListView()
        {
            View.FormEdit();
            View.UseCommands(typeof(AddPurOrderCommand).FullName);
            View.UseCommands("SIE.Web.ZYF.PurchaseOrders.Commands.UpdatePurOrderCommand");
            //View.UseCommands(WebCommandNames.Edit);
            View.UseCommands("SIE.Web.ZYF.PurchaseOrders.Commands.DeletePrOrderCommand");
            //View.UseCommands(WebCommandNames.Delete);
            View.UseCommands(WebCommandNames.ExportXls);
            View.UseCommands(WebCommandNames.ExportXlsMS);
            View.UseCommands(WebCommandNames.ExportXlsSelection);
            View.Property(p => p.OrderNumber);
            View.Property(p => p.PurchaseDate).UseDateEditor(p => p.Format = "Y-m-d");
            View.Property(p => p.TotalAmount);
            View.Property(p => p.Status);
            View.Property(p => p.Remarks);
            View.ChildrenProperty(p => p.PurchaseOrderList)
            .UseViewGroup(OrderDetailViewConfig.ListViewGroup);
        }

        /// <summary>
        /// 配置明细视图
        /// </summary>
        protected override void ConfigDetailsView()
        {
            View.UseCommands("SIE.Web.ZYF.PurchaseOrders.Commands.SaveFormOrderCommand");
            //View.UseCommands(WebCommandNames.FormSave);
            View.AddBehavior("SIE.Web.ZYF.ProductManages.Behaviors.AddPurOrderBehavior");
            View.HasDetailColumnsCount(2);
            View.Property(p => p.OrderNumber).Readonly();
            View.Property(p => p.PurchaseDate).UseDateEditor(p => p.Format = "Y-m-d").DefaultValue(DateTime.Now);
            View.Property(p => p.TotalAmount).Readonly();
            View.Property(p => p.Status).DefaultValue(OrderStatus.NewBuild).Readonly();
            View.Property(p => p.Remarks);
            View.ChildrenProperty(p => p.PurchaseOrderList);
            //.UseViewGroup(OrderDetailViewConfig.DetailViewGroup);
        }
        /// <summary>
        /// 配置查询视图
        /// </summary>
        protected override void ConfigQueryView()
        {
            View.Property(p => p.OrderNumber);
            View.Property(p => p.PurchaseDate)
                .UseDateRangeEditor(p =>
                {
                    p.DateRangeType = ObjectModel.DateRangeType.Month;
                    p.DateFormat = "Y-m-d H:i:s";
                }); ;
            View.Property(p => p.Status.ToLabel());
        }
    }
}
