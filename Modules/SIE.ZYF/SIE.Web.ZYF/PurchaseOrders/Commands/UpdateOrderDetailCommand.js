SIE.defineCommand("SIE.Web.ZYF.PurchaseOrders.Commands.UpdateOrderDetailCommand", {
    extend: 'SIE.cmd.Edit',
    meta: { text: "修改", group: "edit", iconCls: "icon-EditEntity icon-blue" },
    canExecute: function (view) {
        if (view.getSelection() == null || view.getSelection().length !== 1) {
            return false;
        }
        var parent = view._parent.getCurrent();
        if (parent.getStatus() !== 0 || parent == null) {
            return false;
        }
        return true;
    },
});