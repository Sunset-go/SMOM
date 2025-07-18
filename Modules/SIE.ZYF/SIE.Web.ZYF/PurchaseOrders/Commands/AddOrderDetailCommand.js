SIE.defineCommand("SIE.Web.ZYF.PurchaseOrders.Commands.AddOrderDetailCommand", {
    extend: 'SIE.cmd.Add',
    meta: { text: "添加", group: "edit", iconCls: "icon-AddEntity icon-green" },
    canExecute: function (view) {
        if (view._meta.viewGroup == "ListViewGroup") {
            var p = view._parent.getSelection();
            var parent = view._parent.getCurrent();
            if (p == null || p.length !== 1 || parent.getStatus() !== 0) {
                return false;
            }
        }
        return true;
    },
    onItemCreated: function (entity) {
        if (entity) {
            this.mon(entity,"propertyChanged", this.onEntityPropertyChanged, this);
        }
    },
    onEntityPropertyChanged: function (e) {
        var entity = e.entity;
        if (e.property.length > 0 && e.property.indexOf('PurQty') != null) {
            var parentTotalAmount = this.view._parent.getCurrent().getTotalAmount() - entity.getTotalAmount();
            var orderTotalMount = entity.getPurPrice() * entity.getPurQty()
            entity.setTotalAmount(orderTotalMount);
            this.view._parent.getCurrent().setTotalAmount(parentTotalAmount + orderTotalMount) // 设置主表总金额
        } else {
            entity.setPurQty(0);
            entity.setTotalAmount(0);
        }
    }  
});