SIE.defineCommand("SIE.Web.ZYF.PurchaseOrders.Commands.AddPurOrderCommand", {
    extend: 'SIE.cmd.Add',
    meta: { text: "添加", group: "edit", iconCls: "icon-AddEntity icon-green" },
    showView: function (entity) {
        var model = entity.data;
        var me = this;
        this.view.execute({
            data: model,
            success: function (res) {
                var number = res.Result;
                CRT.Workbench.addPage({
                    entityType: me.view.model,
                    recordId: entity.getId(),
                    viewGroup: "DetailsView",
                    title: me.getEditViewTitle(entity),
                    params: {
                        Number: number
                    },
                    isDetail: true,
                })
            }
        }, me.view);
    }
});