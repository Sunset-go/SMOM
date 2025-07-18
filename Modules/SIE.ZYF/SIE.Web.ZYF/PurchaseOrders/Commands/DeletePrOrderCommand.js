SIE.defineCommand("SIE.Web.ZYF.PurchaseOrders.Commands.DeletePrOrderCommand", {
    extend: 'SIE.cmd.Delete',
    meta: { text: "删除", group: "edit", iconCls: "icon-DeleteEntity icon-red" },
    canExecute: function (view) {
        var p = view.getCurrent();
        if (p == null || p.length === 0 || p.getStatus() !== 0) {
            return false;
        }
        return true;
    },
});