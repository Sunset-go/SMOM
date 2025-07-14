Ext.define("SIE.Web.ZYF.Materials.Behaviors.DescriptionToNameBehavior",
    {
        onDataLoaded: function (view) {
            var me = this;
            view.mon(view._control, 'celldblclick', me.cellDblClickFun, view);
        },
        cellDblClickFun: function () {
            var me = this;
            var entity = me.getCurrent();
            if (entity) {
                me.mon(entity, "propertyChanged", SIE.Web.ZYF.Materials.Behaviors.MaterialAction.onEntityPropertyChanged, this);
            }
        },
    }
)