SIE.defineCommand('SIE.Web.ZYF.ProductManages.Commands.ReviewProductManageCommand', {
    meta: { text: "审核", group: "edit", iconCls: "icon-NetworkNormal icon-blue" },
    //按钮是否置灰
    canExecute: function (view) {
        this.selectItems = view.getSelectedEntities();
        if (this.selectItems.length === 0) return false; // 选择实体数量为空

        return this.selectItems.every(item => item.getStatus() === 0); // 选择实体的状态都为未审核
    },
    execute: function (view, source) {
        var me = view;
        var selectModels = view.getSelection(); // 获取选择实体
        var selectIds = view.getSelectionIds(selectModels); // 获取选择实体ID
        var mainBlock; // 主块
        //获取页面元数据
        SIE.AutoUI.getMeta({ // 获取元数据
            model: "SIE.ZYF.ProductManages.ProductManage",//指定实体
            viewGroup: "ReviewProductManageCommand", //指定视图
            async: false,
            ignoreCommands: false,
            isDetail: true, //是否表单页面
            ignoreQuery: true,  //是否忽略查询
            callback: function (res) {
                if (res.mainBlock) mainBlock = res.mainBlock;
                else mainBlock = res;
            }
        });
        var detailView = SIE.AutoUI.createDetailView(mainBlock);
        detailView.token = view.getToken();
        var model = new detailView._model();
        model.markSaved();
        detailView.setData(model);
        var win = SIE.Window.show({
            title: "Review".t(),
            width: 500,
            height: 200,
            items: detailView.getControl(),
            callback: function (btn) {
                if (btn == "确定".t()) {
                    var remark = detailView.getData().getRemark();
                    if (remark == null || remark == '') {
                        SIE.Msg.showError("备注不能为空!".t());
                    } else {
                        // 调用后端命令
                        view.execute({
                            withIds: true,
                            data: { SelectIds: selectIds, Remark: remark },
                            success: function (res) {
                                SIE.Msg.showMessage("设置成功!".t());
                                view.reloadData();
                            }
                        })
                    }
                }
            }
        });
    },
});