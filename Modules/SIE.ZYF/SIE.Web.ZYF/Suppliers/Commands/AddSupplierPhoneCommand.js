SIE.defineCommand("SIE.Web.ZYF.Suppliers.Commands.AddSupplierPhoneCommand", {
    extend: "SIE.cmd.Add",
    meta: { text: "添加", group: "edit" },
    onItemCreated: function (entity) {
        var supplierId = this.view.getParent().getCurrent().getId();
        entity.setSuConcatId(supplierId);
    }
});