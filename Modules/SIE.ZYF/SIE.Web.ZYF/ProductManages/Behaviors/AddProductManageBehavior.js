Ext.define("SIE.Web.ZYF.ProductManages.Behaviors.AddProductManageBehavior",
    {
        /**
         * 创建view之后
         * @param {any} view
         */
        onCreated: function (view) {
            var params = CRT.Context.PageContext.getParams();
            var entity = CRT.Context.PageContext.getCurrentRecord();
            if (params) {
                entity.setCode(params.Code);
                entity.setPurchaseQuantity(params.Qty);
            }
        },
    }
);