SIE.defineCommand("SIE.Web.ZYF.PurchaseOrders.Commands.UpdatePurOrderCommand", {
extend: 'SIE.cmd.Edit',
    meta: { text: "修改", group: "edit", iconCls: "icon-EditEntity icon-blue" },
    canExecute: function(view) {
        var p = view.getCurrent();
        var s = view.getSelection();
        if (s == null || s.length !== 1 || p.getStatus() !== 0)
        {
            return false;
        }
        return true;
    },
});