Ext.define("SIE.Web.ZYF.ProductManages.Behaviors.AddProductManageBehavior", {
    onCreated: function (view) {
        var entity = CRT.Context.PageContext.getCurrentRecord();
        entity.setPurchaseQuantity(1);
    }
})