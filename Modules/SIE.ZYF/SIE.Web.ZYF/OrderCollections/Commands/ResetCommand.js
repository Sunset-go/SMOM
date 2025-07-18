SIE.defineCommand("SIE.Web.ZYF.OrderCollections.Commands.ResetCommand", {
    meta: { text: "重置", group: "edit", iconCls: "icon-Refresh icon-blue" },
    canExecute: function (view) {
        return this.callParent(arguments)
    },
    execute: function (view, source) {
        var cur = view.getCurrent();
        cur.setOrderNumber(null);
        cur.setCode(null);
        cur.setTips("请扫描采购订单单号");
        cur.setErrors("错误信息");
        cur.setInput("");
        view.getChildren()[0].setData(null);
    },
    
})