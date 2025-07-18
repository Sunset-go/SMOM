Ext.define("SIE.Web.ZYF.PurchaseOrders.Behaviors.ModifyPurTotalAmountBehavior",
    {
        onDataLoaded: function (view) {
            var me = this;
            view.mon(view._control, 'celldblclick', me.cellDblClickFun, view);
        },
        cellDblClickFun: function () {
            var me = this;
            if (me._parent.getCurrent().getStatus() !== 0) return false;
            var entity = me.getCurrent();
            if (entity) {
                me.mon(entity, "propertyChanged", SIE.Web.ZYF.PurchaseOrders.Action.UpdateAction.onEntityPropertyChanged, this);
            }
        }
    }
);