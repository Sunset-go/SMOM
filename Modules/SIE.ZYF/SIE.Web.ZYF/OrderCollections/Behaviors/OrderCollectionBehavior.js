Ext.define("SIE.Web.ZYF.OrderCollections.Behaviors.OrderCollectionBehavior", {
    detailView: null,
    beforeCreate: function (meta, curEntity) {
        var me = this;
        meta.formConfig.items[0].items[0].fieldStyle = {
            background: "lightgray",
            border: 0,
            color: "green",
            fontSize: "20px",
            fontWeight: "bold"
        };
        meta.formConfig.items[0].items[1].fieldStyle = {
            background: "lightgray",
            border: 0,
            color: "red",
            fontSize: "20px",
            fontWeight: "bold"
        };
        meta.formConfig.items[1].items[0].fieldStyle = {
            background: "lightgreen",
            border: 0,
            fontSize: "20px",
            fontWeight: "bold"
        };
        //监听回车事件
        meta.formConfig.items[1].items[0].enableKeyEvents = true;
        meta.formConfig.items[1].items[0].listeners = {
            keyup: function (self, e, eOpt) {
                if (e.keyCode == 13) {
                    // 回车后的逻辑
                    var entity = me.detailView.getCurrent(); // 获取当前实体
                    if (entity.getInput() == "") {
                        if (entity.getOrderNumber() == "") {
                            entity.setTips("请扫描采购订单单号!");
                            return false;
                        }
                        if (entity.getCode() == "") {
                            entity.setTips("请扫描产品编码!");
                            return false;
                        }
                    }
                    if (entity.getOrderNumber() == "") {
                        LoadOrder(me, entity); // 加载订单明细
                    }else {
                        AddEntry(me, entity); // 添加明细的入库
                    }
                }
            }
        }
    },
    /**
     * 视图加载完成
     * @param {any} view
     */
    onViewReady: function (view) {
        this.detailView = view;
        var entity = Ext.create(view.model);
        entity.setTips("请扫描采购订单单号");
        entity.setErrors("错误信息");
        view.setCurrent(entity);
    },
});

// 加载订单明细
function LoadOrder(me, entity) {
    Ajax({
        method: 'LoadOrderDetails', //执行方法
        params: [entity.getInput()], //传入参数
        action: 'queryer',
        async: true,
        type: 'SIE.Web.ZYF.DataQuerys.CollectionDataQuery',//路径
        token: me.detailView.getToken(),
        //采购单号扫描成功
        success: function (result) {
            entity.setTips("采购订单：" + entity.getInput() + "扫描成功！");
            entity.setErrors("错误信息");
            //扫描成功展示视图，设置采购单号的值
            entity.setOrderNumber(entity.getInput());
            entity.setInput("");
            me.detailView.getChildren().forEach(function (v) {
                loadData(v);
            })
            //输入完采购单号或产品编码时验证扫描是否完成
            ValidationOrder(me, entity);
        },
        error: function (errorMessage) {
            entity.setErrors(errorMessage);
            entity.setTips("请重新扫描采购单号");
            //清空输入值
            entity.setInput("");
        }
    });
}

//验证扫描是否完成
function ValidationOrder(me, entity) {
    Ajax({
        method: 'ValidationOrder', //执行方法
        params: [entity.getOrderNumber()], //传入订单号
        action: 'queryer',
        async: true,
        type: 'SIE.Web.ZYF.DataQuerys.CollectionDataQuery',//路径
        token: me.detailView.getToken(),
        //新建或者部分接收
        success: function (result) {

        },
        //全部接收
        error: function (errorMessage) {
            entity.setTips("采购订单：" + entity.getOrderNumber() + "入库完成！请输入新的采购单号");
            entity.setErrors("错误信息");
            //清空采购单号，展示空视图
            entity.setOrderNumber("");
            me.detailView.getChildren().forEach(function (v) {
                loadData(v);
            })
        }
    });
}

function AddEntry(me, entity) {
    Ajax({
        method: 'AddEntry', //执行方法
        params: [entity.getOrderNumber(), entity.getInput()], //传入参数
        action: 'queryer',
        async: true,
        type: 'SIE.Web.ZYF.DataQuerys.CollectionDataQuery',//路径
        token: me.detailView.getToken(),
        //扫描成功
        success: function (result) {
            entity.setTips("产品编号：" + entity.getInput() + "入库成功！");
            entity.setErrors("错误信息");
            //执行结束后清空输入值
            entity.setInput("");
            me.detailView.getChildren().forEach(function (v) {
                loadData(v);
            })
            //输入完采购单号或产品编码时验证扫描是否完成
            ValidationOrder(me, entity);
        },
        error: function (errorMessage) {
            entity.setErrors(errorMessage);
            entity.setTips("请重新扫描产品编码");
            //执行结束后清空输入值
            entity.setInput("");
        }
    });
}

function Ajax(op) {
    var me, action, filter;
    op = Ext.apply({
        "async": !0
    }, op);
    me = this;
    action = "queryer";
    op.action && (action = op.action);
    filter = {
        Method: op.method,
        Parameters: op.params || []
    };
    SIE.Ajax({
        url: "/api/DataPortal/Query",
        timeout: op.timeout,
        "async": op.async,
        method: "POST",
        params: {
            action: action,
            type: op.type,
            filter: SIE.data.Utils.seriaizeRequest(filter),
            token: op.token
        },
        success: function (response) {
            var res = response.responseJson;
            !res && response.responseText && (res = Ext.decode(response.responseText));
            SIE.data.Utils.deserializeResponse(res);
            res.Success
                ? (op.success && op.success(res.Result))
                : (op.error ? op.error(res.Message) : SIE.Msg.showError(res.Message))
        },
        failure: function (response) {
            if ("communication failure" === response.statusText)
                SIE.Msg.showWarning("请求时间超时".t());
            else if (response.statusText !== "") {
                var res = response.responseJson;
                !res && response.responseText && (res = Ext.decode(response.responseText),
                    SIE.Msg.showError(res.Message))
            }
        }
    })
};
function loadData(view) {
    var args = {};
    var me = view, parent, pName, root;
    args = args || me._lastDataArgs || {};
    Ext.isFunction(args) && (args = {
        callback: args
    });
    this._lastDataArgs = args;
    var entity = me.getCurrent()
        , store = me.getData()
        , proxy = store.proxy;
    args.clearSort && (store.sorters = null);
    proxy.setExtraParams({});
    proxy.setExtraParam("token", args.token || me.getToken());
    proxy.extraParams && proxy.extraParams.action || proxy.setExtraParam("action", args.action || proxy.action || "entity");
    args.action && proxy.setExtraParam("action", args.action);
    proxy.extraParams && proxy.extraParams.type || proxy.setExtraParam("type", args.type || me.model);
    proxy.setExtraParam("viewGroup", me.viewGroup);
    proxy.setExtraParam("url", args.url || proxy.url);
    proxy.setExtraParam("parentEntity", Ext.encode(me._parent.getData().data));
    typeof args.async == "undefined" || (proxy.isSynchronous = !args.async);
    proxy.setExtraParam("searchKeyWord", args.searchKeyWord || proxy.searchKeyWord);
    (args.filter || proxy.filter) && proxy.setExtraParam("filter", args.filter || proxy.filter);
    args.sort && proxy.setExtraParam("sort", args.sort);
    args.page && proxy.setExtraParam("page", args.page);
    args.method ? SIE.data.Utils.filterByMethod(store, args.method, args.params) : args.criteria && SIE.data.Utils.filterByCriteria(store, args.criteria);
    parent = me._parent;

    parent && parent._current && (pName = me._childProperty,
        pName || (proxy.setExtraParam("action", "delegate"),
            proxy.setExtraParam("parent", parent.model),
            proxy.setExtraParam("filter", Ext.encode([{
                property: SIE._KeyPropertyName,
                value: parent._current.data[SIE._KeyPropertyName],
                exactMatch: !0
            }]))));
    proxy.timeout = args.timeout || !1;
    store._ondataloaded || (store.mon(store, "load", function () {
        me.fireEvent("ondataloaded")
    }),
        store._ondataloaded = !0);
    me._isTree ? (Ext.apply(proxy, {
        extractResponseData: function (response) {
            var responseObj = response.responseJson, entities;
            return (!responseObj && response.responseText && (responseObj = Ext.decode(response.responseText)),
                responseObj.Success) ? (entities = responseObj.Result.entities,
                    Ext.each(entities, function (o) {
                        o.leaf = !0;
                        o.parentId = o.TreePId;
                        Ext.each(entities, function (x) {
                            if (o.Id == x.TreePId)
                                return o.leaf = !1,
                                    !1
                        })
                    }),
                    responseObj.Result) : (SIE.Msg.showError(responseObj.Message),
                        response)
        }
    }),
        me._treeStoreInited || (me._treeStoreInited = !0,
            root = store.getRootNode(),
            root.set("loaded", !1)),
        store.load(function (records, operation, success) {
            me.setCurrent(null, !0);
            store._loaded = success;
            args.callback && args.callback(arguments);
            delete proxy.getExtraParams().page
        })) : (store.rejectChanges(),
            store.autoLoad = !0,
            store.load({
                url: args.url || proxy.url,
                callback: function (records, operation, success) {
                    me.getCurrent() != null ? me.setCurrent(null, !0) : me.syncCmdState();
                    store._loaded = success;
                    me.fireReloadData(me, entity);
                    args.callback && args.callback(arguments);
                    delete proxy.getExtraParams().page
                }
            })
        )
}
