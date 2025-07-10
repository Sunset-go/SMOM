Ext.define("SIE.Web.ZYF.ProductManages.Behaviors.ProductManageAutoAddBehaviors",
    {
        onViewReady: function (view) {
            var entity = view.getCurrent();
            if (entity) {
                view.mon(entity,"propertyChanged", this.onEntityPropertyChanged, this);
            }
        },
        onEntityPropertyChanged: function (e) {
            var entity = e.entity;
            if (e.property.length > 0 && e.property === 'PurchasePrice') {
                entity.setPrice(entity.getPurchasePrice()+10);
            }
        }
    }
);