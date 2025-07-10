Ext.define("SIE.Web.ZYF.ProductManages.Behaviors.ProductManageAction", {
    statics: {
        onEntityPropertyChanged: function (e) {
            var entity = e.entity;
            if (e.property.length > 0 && e.property.indexOf('PurchasePrice') > 0) {
                entity.setPrice(entity.getPurchasePrice());
            }
        },
    }
});