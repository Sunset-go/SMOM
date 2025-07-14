SIE.defineCommand('SIE.Web.ZYF.ProductManages.Commands.ProManPrintableCommand', {
    meta: { text: "标签打印", group: "edit", iconCls: "icon-PrintData icon-blue" },
    canExecute: function (view) {
        return view.hasSelectedEntities();
    },
    execute: function (view, source) {
        var me = this;
        view.execute({
            data: view.getSelectionIds(),
            success: function (res) {
                var param = { content: res.Result };
                CRT.Workbench.showPageDialog({
                    id: 'Label_rpt',
                    text: "标签打印".t(),
                    url: '/Modules/PrintTemplate/DevPrint',
                    params: param,
                    method: 'POST'
                });
            }
        });
    }
});
