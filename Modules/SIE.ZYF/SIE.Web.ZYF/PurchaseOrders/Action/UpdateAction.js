Ext.define("SIE.Web.ZYF.PurchaseOrders.Action.UpdateAction", {
    statics: {
        onEntityPropertyChanged: function (e) {
            var entity = e.entity;
            if (e.property.length > 0 && e.property.indexOf('PurQty') != null) {
                entity.setTotalAmount(entity.getPurPrice() * entity.getPurQty());
            }
            PurTotalMount = 0
            var data = this.getData().data;
            for (i = 0; i < data.items.length; i++) {
                PurTotalMount = PurTotalMount + parseInt(data.items[i].getTotalAmount());
            }
            this._parent.getCurrent().setTotalAmount(PurTotalMount);
        },
    }
});