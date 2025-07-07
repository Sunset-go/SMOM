SIE.defineCommand("SIE.Web.ZYF.ProductManages.Commands.AddProductManageCommand", {
    extend: 'SIE.cmd.Add',
    meta: { text: "添加", group: "edit", iconCls: "icon-AddEntity icon-green" },
    onItemCreated: function (entity) {
        this.getEntity().data.setPurchaseQuantity(1);
    },
    getEntity: function () {
        return new SIE.ZYF.ProductManages.ProductManage();
    }
});