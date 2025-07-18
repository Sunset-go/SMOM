using SIE.Domain;
using SIE.Web.ZYF.OrderCollections.Commands;
using SIE.Web.ZYF.PurchaseOrders;
using SIE.ZYF.PurchaseOrders;

namespace SIE.Web.ZYF.OrderCollections
{
    /// <summary>
    /// 订单采集视图界面配置
    /// </summary>
    public class OrderCollectionViewConfig : WebViewConfig<OrderCollectionViewModel>
    {
        /// <summary>
        /// 配置详细视图
        /// </summary>
        protected override void ConfigDetailsView()
        {
            View.AddBehavior("SIE.Web.ZYF.OrderCollections.Behaviors.OrderCollectionBehavior");
            View.UseCommands(typeof(ResetCommand).FullName);
            using (View.DeclareGroup("提示信息"))
            {
                View.Property(p=>p.Tips).ShowInDetail(columnSpan:2,hideLabel:true).Readonly();
                View.Property(p=>p.Errors).ShowInDetail(columnSpan:2,hideLabel:true).Readonly();
            }
            using (View.DeclareGroup("扫描信息",2))
            {
                View.Property(p => p.Input).ShowInDetail(columnSpan: 2);
            }
            View.AttachChildrenProperty(typeof(OrderDetail), (c) =>
            {
                var args = c as ChildPagingDataArgs;
                var dp = c as ChildPagingDataWithParentEntityArgs;
                if (string.IsNullOrEmpty(dp.ParentEntity)) return new EntityList<OrderDetail>();
                var collection = dp.ParentEntity.ToJsonObject<OrderCollectionViewModel>();
                var orderNumbers = RT.Service.Resolve<OrderCollectionController>()
                .GetOrderDetail(collection.OrderNumber,args?.SortInfo,args?.PagingInfo);
                return orderNumbers;
            },OrderDetailViewConfig.CollectionListViewGroup).HasLabel("采购订单明细").Show(ChildShowInWhere.All);
        }
    }
}
