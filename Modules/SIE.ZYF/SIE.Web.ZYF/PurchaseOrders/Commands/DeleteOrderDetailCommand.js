SIE.defineCommand("SIE.Web.ZYF.PurchaseOrders.Commands.DeleteOrderDetailCommand", {
    extend: 'SIE.cmd.Delete',
    meta: { text: "删除", group: "edit", iconCls: "icon-DeleteEntity icon-red" },
    canExecute: function (view) {
        if (view.getSelectedEntities() == null || view.getSelectedEntities().length === 0) {
            return false;
        }
        var parent = view._parent.getCurrent();
        if (parent.getStatus() !== 0 || parent == null) {
            return false;
        }
        return true;
    },
});