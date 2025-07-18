Ext.define("SIE.Web.ZYF.ProductManages.Behaviors.AddPurOrderBehavior",
    {
        /**
         * 创建view之后
         * @param {any} view
         */
        onCreated: function (view) {
            var params = CRT.Context.PageContext.getParams(); // 获取参数
            var entity = CRT.Context.PageContext.getCurrentRecord(); // 获取当前实体
            if (params) {
                entity.setOrderNumber(params.Number); // 设置单号
            }
        }
    }
);