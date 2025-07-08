SIE.defineCommand("SIE.Web.ZYF.ProductManages.Commands.AddProductManageCommand", {
    extend: 'SIE.cmd.Add',
    meta: { text: "添加", group: "edit", iconCls: "icon-AddEntity icon-green" },
    onItemCreated: function (entity) {
        entity.set("PurchaseQuantity", 1);
    },
});