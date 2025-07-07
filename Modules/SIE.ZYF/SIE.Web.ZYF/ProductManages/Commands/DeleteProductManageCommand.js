SIE.defineCommand("SIE.Web.ZYF.ProductManages.Commands.DeleteProductManageCommand", {
    extend: 'SIE.cmd.Delete',
    meta: { text: "删除", group: "edit", iconCls: "icon-DeleteEntity icon-red" },
    canExecute: function (view) {
        this.selectItems = view.getSelectedEntities();
        if (this.selectItems.length === 0) return false; // 选择实体数量为空
        return this.selectItems.every(item => item.getStatus() === 0); // 选择实体的状态都为未审核
    }
});