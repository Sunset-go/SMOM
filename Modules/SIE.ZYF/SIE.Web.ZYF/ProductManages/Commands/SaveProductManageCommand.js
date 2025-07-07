﻿SIE.defineCommand("SIE.Web.ZYF.ProductManages.Commands.SaveProductManageCommand", {
    extend: 'SIE.cmd.FormSave',
    meta: { text: "保存", group: "edit", iconCls: "icon-SaveEntity icon-blue" },
    onSavedMsg: function (view, res) {
        var me = this;
        SIE.Msg.showInstantMessage('保存成功');
        setTimeout(function () { CRT.Workbench.closeCurrentTab(); }, 3000, me);
    }
});