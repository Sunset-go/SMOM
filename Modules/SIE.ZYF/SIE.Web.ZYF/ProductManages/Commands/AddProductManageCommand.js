SIE.defineCommand("SIE.Web.ZYF.ProductManages.Commands.AddProductManageCommand", {
    extend: 'SIE.cmd.Add',
    meta: { text: "添加", group: "edit", iconCls: "icon-AddEntity icon-green" },
    
    showView: function (entity) {
        var model = entity.data;
        var me = this;
        this.view.execute({
            data: model,
            success: function (res) {
                var code = res.Result.Code;
                var qty = res.Result.PurchaseQuantity;
                CRT.Workbench.addPage({
                    entityType: me.view.model,
                    recordId: entity.getId(),   
                    viewGroup: "DetailsView",
                    title: me.getEditViewTitle(entity),
                    params: {
                        Code: code,
                        Qty: qty
                    },
                    isDetail: true,
                })
            }
        }, me.view);
    }
});