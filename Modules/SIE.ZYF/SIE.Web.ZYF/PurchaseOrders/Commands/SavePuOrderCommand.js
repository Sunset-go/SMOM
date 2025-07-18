SIE.defineCommand("SIE.Web.ZYF.PurchaseOrders.Commands.SavePurOrderCommand", {
    extend: 'SIE.cmd.Save',
    meta: { text: "保存", group: "edit", iconCls: "icon-SaveEntity icon-blue" },
    onSavedMsg: function (view, res) {
        var me = this;
        SIE.Msg.showInstantMessage('保存成功');
        view.getParent().refreshData()
    }
});