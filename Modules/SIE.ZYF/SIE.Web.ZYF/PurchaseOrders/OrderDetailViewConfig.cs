using SIE.MetaModel.View;
using SIE.Web.ZYF.PurchaseOrders.Commands;
using SIE.ZYF.PurchaseOrders;
using System;
using System.Collections.Generic;

namespace SIE.Web.ZYF.PurchaseOrders
{
    /// <summary>
    /// 订单详情配置
    /// </summary>
    public partial class OrderDetailViewConfig : WebViewConfig<OrderDetail>
    {
        public const string ListViewGroup = "ListViewGroup";
        public const string CollectionListViewGroup = "CollectionListViewGroup";

        /// <summary>
        /// 配置视图
        /// </summary>
        protected override void ConfigView()
        {
            View.DeclareExtendViewGroup(ListViewGroup, CollectionListViewGroup);
            if (ViewGroup == ListViewGroup)
            {
                ListViewConfigView();
            }
            else if(ViewGroup == CollectionListViewGroup)
            {
                ConfigCollectionListView();
            }
        }
        /// <summary>
        /// 配置扫描的列表视图
        /// </summary>
        private void ConfigCollectionListView()
        {
            //View.Property(p => p.ProManDetail).Show().Readonly().HasLabel("产品编码");
            View.Property(p => p.ProManDetailId)
            .UsePagingLookUpEditor((c, p) =>
            {   //   配置下拉框，通过编码动态设置名称
                Dictionary<string, string> dic = new Dictionary<string, string>
            {
                    { nameof(p.Name), nameof(p.ProManDetail.Name) },
                    { nameof(p.Remark), nameof(p.ProManDetail.Remark) },
                    { nameof(p.PurPrice), nameof(p.ProManDetail.PurchasePrice) },

            };
                c.DicLinkField = dic;
            }).Show().Readonly().HasLabel("产品编码").FixColumn();
            View.Property(p => p.Name).Readonly().Show().Readonly().HasLabel("产品名称");
            View.Property(p => p.PurPrice).Show().Readonly();
            View.Property(p => p.PurQty).Show().Readonly();
            View.Property(p => p.EnterQty).Show().Readonly();
            View.Property(p => p.CreateByName).Show(ShowInWhere.Hide).Readonly();
            View.Property(p => p.CreateDate).Show(ShowInWhere.Hide).Readonly();
            View.Property(p => p.UpdateByName).Show(ShowInWhere.Hide).Readonly();
            View.Property(p => p.UpdateDate).Show(ShowInWhere.Hide).Readonly();
        }

        /// <summary>
        /// 配置主列表中的列表视图
        /// </summary>
        private void ListViewConfigView()
        {
            View.AddBehavior("SIE.Web.ZYF.PurchaseOrders.Behaviors.ModifyPurTotalAmountBehavior");
            View.UseCommands("SIE.Web.ZYF.PurchaseOrders.Commands.AddOrderDetailCommand");
            View.UseCommands("SIE.Web.ZYF.PurchaseOrders.Commands.UpdateOrderDetailCommand");
            View.UseCommands("SIE.Web.ZYF.PurchaseOrders.Commands.DeleteOrderDetailCommand");
            View.UseCommands(WebCommandNames.ExportXls);
            View.UseCommands(WebCommandNames.ExportXlsMS);
            View.UseCommands(WebCommandNames.ExportXlsSelection);
            View.UseCommands(typeof(SavePurOrderCommand).FullName);
            //View.UseCommands("SIE.Web.ZYF.PurchaseOrders.Commands.SavePurOrderCommand");
            View.Property(p => p.ProManDetailId)
            .UsePagingLookUpEditor((c, p) =>
            {   //   配置下拉框，通过编码动态设置名称
                Dictionary<string, string> dic = new Dictionary<string, string>
            {
                    { nameof(p.Name), nameof(p.ProManDetail.Name) },
                    { nameof(p.Remark), nameof(p.ProManDetail.Remark) },
                    { nameof(p.PurPrice), nameof(p.ProManDetail.PurchasePrice) },
            };
                c.DicLinkField = dic;
            }).Show();
            View.Property(p => p.Name).Readonly().Show();
            //View.Property(p=>p.EnterQty).Show();
            View.Property(p => p.PurPrice).Show();
            View.Property(p => p.PurQty).DefaultValue(0).Show();
            View.Property(p => p.TotalAmount).Readonly().Show();
            View.Property(p => p.Remark).Show();
        }

        /// <summary>
        /// 配置列表视图
        /// </summary>
        protected override void ConfigListView()
        {
            View.AddBehavior("SIE.Web.ZYF.PurchaseOrders.Behaviors.ModifyPurTotalAmountBehavior");
            View.UseCommands("SIE.Web.ZYF.PurchaseOrders.Commands.AddOrderDetailCommand");
            View.UseCommands("SIE.Web.ZYF.PurchaseOrders.Commands.UpdateOrderDetailCommand");
            View.UseCommands("SIE.Web.ZYF.PurchaseOrders.Commands.DeleteOrderDetailCommand");
            View.UseCommands(WebCommandNames.ExportXls);
            View.UseCommands(WebCommandNames.ExportXlsMS);
            View.UseCommands(WebCommandNames.ExportXlsSelection);
            View.Property(p => p.ProManDetailId)
                .UsePagingLookUpEditor((c, p) =>
                {   //   配置下拉框，通过编码动态设置名称
                    Dictionary<string, string> dic = new Dictionary<string, string>
                {
                    { nameof(p.Name), nameof(p.ProManDetail.Name) },
                    { nameof(p.Remark), nameof(p.ProManDetail.Remark) },
                    { nameof(p.PurPrice), nameof(p.ProManDetail.PurchasePrice) },
                        //{ nameof(p.PurQty), nameof(p.ProManDetail.PurchaseQuantity) }
                };
                    c.DicLinkField = dic;
                });
            View.Property(p => p.Name).Readonly();
            View.Property(p => p.PurPrice);
            View.Property(p => p.PurQty).DefaultValue(0);
            View.Property(p => p.TotalAmount).Readonly();
            View.Property(p => p.Remark);
        }
    }
}
