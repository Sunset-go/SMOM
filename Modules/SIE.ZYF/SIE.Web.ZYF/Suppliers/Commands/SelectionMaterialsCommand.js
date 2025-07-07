SIE.defineCommand("SIE.Web.ZYF.Suppliers.Commands.SelectionMaterialsCommand", {
    extend: 'SIE.cmd.LookupCommandBase',
    meta: { text: "选择", group: "edit", iconCls: "icon-PlaylistCheck icon-blue" },
    userConfig: { // 用户配置
        dataParams: { specKeyPrototyName: 'MaterialId', targetClassName: 'SIE.ZYF.Materials.Material' },
    },
    canExecute: function (view) {
        var pv = view.getParent();
        if (!pv) { return true; }
        var entity = pv.getCurrent();
        var result = entity !== null;
        if (result) {
            //result = pv.getSelection().length == 1;
        }
        if (result) {
            result = !entity.isNew();
        }
        return result;
    },
    save: function (win) {
        /// <summary>  
        /// 保存选择的操作列表 
        /// </summary>  
        var me = this;
        var indata = {};
        /* post数据结构*/
        var selections = this._targetSelectItems.items;
        if (selections && selections.length > 0) {
            var supplierMaterials = [];
            SIE.each(selections, function (item) {
                var materialId = item.getId();
                if (me._sourceViewSelectItems.indexOf(materialId) === -1) { // 排除已经选择的物料
                    var supplierMaterial = { SupplierId: me._sourceId, MaterialId: materialId };
                    supplierMaterials.push(supplierMaterial);
                }
            });
            indata = supplierMaterials;
            me._targetView.execute({
                data: indata,
                success: function (res) {
                    win.close();  //关闭模态窗口  
                    me._ownerView.loadChildData(true); //重载视图数据  
                },
                failure: function (res) {
                    SIE.Msg.showError(res.msg);
                }
            }, me._ownerView);
        }
        else {
            SIE.Msg.showWarning('没有可提交的数据');
        }
    },
});