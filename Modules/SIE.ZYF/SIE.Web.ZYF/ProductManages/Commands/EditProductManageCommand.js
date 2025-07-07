SIE.defineCommand("SIE.Web.ZYF.ProductManages.Commands.EditProductManageCommand", {
    extend: 'SIE.cmd.Edit',
    meta: { text: "修改", group: "edit", iconCls: "icon-EditEntity icon-blue" },
    canExecute: function (view) {
        if (view.getSelection() == null || view.getSelection().length !== 1) {
            return false;
        }
        var p = view.getCurrent();
        if (p == null || p[0].Status == 1) {
            return false;
        }
        return true;
    },
    showView: function (editEntity) {
        var me = this;
        if (!this.viewMeta) {
            // 获取元数据
            SIE.AutoUI.getMeta({
                async: false, // 同步
                isDetail: true, // 是否详情
                ignoreQuery: true, // 忽略查询条件
                viewGroup: "EditProductManageCommand",
                model: this.view.model, // 模型
                callback: function (meta) { // 回调
                    meta.token = me.view.token;
                    me.viewMeta = meta;
                }
            });
        }
        
        var cfg = { // 弹窗配置
            associateCmd: me, // 关联命令
            viewMeta: me.viewMeta, // 元数据
            entity: editEntity, // 实体
            editMode: this.view.editMode, // 编辑模式
            title: this.getEditViewTitle(editEntity),// 标题
            confirm: function (isNoSave) { // 确认
                // 可设置修改数量
                modifyCount = editEntity.getData().ModifyCount;
                if (modifyCount == null) {
                    modifyCount = 1;
                } else {
                    modifyCount += 1;
                }
                editEntity.set("ModifyCount", modifyCount);
                //弹窗的确认后回调 
                var isImmediate = me.view.isImmediate(); // 是否立即刷新
                var phantom = editEntity.phantom; // 是否是新增
                var dirty = editEntity.dirty; // 是否是修改
                editEntity.commit(); // 提交
                editEntity.phantom = phantom; // 还原新增
                editEntity.dirty = dirty; // 还原修改
                me.view.afterEdit(editEntity, isImmediate, me.isCopy); // 编辑后回调
                me.confirm(editEntity, isImmediate, me.isCopy); // 命令确认
            }
        };
        //子视图弹框显示
        me.setDialogAttribute
        //设置弹窗属性
        var dialogcfg = {};
        dialogcfg = me.setDialogAttribute(dialogcfg); // 设置弹窗属性
        cfg.dialogcfg = dialogcfg; // 设置弹窗属性
        me._editingView = SIE.App.showDialog(cfg); // 显示弹窗
    },
});