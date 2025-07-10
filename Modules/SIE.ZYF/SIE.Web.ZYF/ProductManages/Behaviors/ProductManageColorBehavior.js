Ext.define("SIE.Web.ZYF.ProductManages.Behaviors.ProductManageColorBehavior", {
    onViewReady: function (view) {
        var me = this;
        if (view.isListView) {
            var grid = view._control.getView();
            grid.mon(grid, 'refresh', me.OnRefresh);
        }
    },
    OnRefresh: function (grid,record) {
        var rowData = record;
        if (rowData.length > 0) {
            for (var i = 0; i < rowData.length; i++) {
                var data = rowData[i];
                var sPrice = data.getPrice(); // 销售价
                var pPrice = data.getPurchasePrice(); // 收购价
                if (sPrice > 0 && sPrice < 2 * pPrice) {
                    grid.getRow(i).style.color = 'red';
                }
                else if (sPrice >= 2 * pPrice && sPrice <= 3 * pPrice) {
                    grid.getRow(i).style.color = 'blue';
                } else if (sPrice > 3 * pPrice) {
                    grid.getRow(i).style.color = 'green';
                }
            }
        }
    }
});