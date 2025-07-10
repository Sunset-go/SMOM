SIE.defineCommand("SIE.Web.ZYF.Materials.Commands.AddMaterialCommand", {
    extend: "SIE.cmd.Add",
    meta: { text: "添加", group: "edit" },
    onItemCreated: function (entity) {
        var model = entity.data;
        var me = this;
        me.view.execute({
            data: model,
            success: function (res) {
                entity.setCode(res.Result);
            }
        }, me.view);
    }
});