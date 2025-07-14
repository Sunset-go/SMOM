Ext.define("SIE.Web.ZYF.Materials.Behaviors.MaterialAction", {
    statics: {
        onEntityPropertyChanged: function (e) {
            var entity = e.entity;
            if (e.property.length > 0 && e.property.indexOf('Name') != null) {
                entity.setDescription(entity.getName());
            }
        },
    }
});