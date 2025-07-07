Ext.define('SIE.Web.ZYF.Editors.ImageInlineEditor', {
    extend: "Ext.grid.column.Column",
    alias: 'widget.ImageInlineEditor',
    renderer: function (value, meta, record) {
        if (value) {
            return "<img style='width:60px;height:12px' src='" + value + "'";
        }
    }
});