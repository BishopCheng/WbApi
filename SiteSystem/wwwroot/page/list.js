// 控制器地址
var controllerPath;
var maingrid;
// 主键
var keyField;
// ligerGrid列集合
var maingridColumns;
// ligerGrid按钮集合
var maingridButtons;
// 查询条件标题
var searchTitle;
// 数据列表标题
var gridTitle = null;
// 模块关键词
var KeyName = null;
// 传递参数
var Params = "";
// 是否有详细页面
var HasDetail = true;
var ListName = "GetList";
var pageSize = 20;

var isMultiSelect = true;

// 查询参数
var PostData = {};

// 数配置 {columnId: 'PAGE_ID', idField: 'PAGE_ID', parentIDField: 'PAGE_PARENT' }
var treeParms = {};

// 主方法页面加载
function loadPage() {
    // css_init();
    initData();
    initSearch();
    initGrid();
    extendGrid();
}


// 初始化参数
function initData() {
}

// 初始化查询UI
function initSearch() {


}

// 初始化数据列表
function initGrid() {
    gridband();
}

// 数据列表扩展
function extendGrid() {

}

// 表格数据查询
function gridband() {

    GetMainGridParms();

    $("#maingrid").jqGrid({
        caption: gridTitle,
        url: controllerPath + ListName,
        mtype: "POST",
        datatype: "json",
        styleUI: "Bootstrap",
        colModel: maingridColumns,
        viewrecords: true, // show the current page, data rang and total records on the toolbar
        multiselect: isMultiSelect,
        autowidth: true,
        height: "100%",
        rownumbers: true,
        rowList: [10, 20, 30, 50, 100],
        rowNum: pageSize,
        rownumbers: true, // 显示行号  
        rownumWidth: 35, // the width of the row numbers columns  
        subGrid: false,//是否启用子表格  
        postData: PostData,
        loadonce: false, // this is just for the demo
        pager: "#gridPager",
        jsonReader: { repeatitems: false },
        loadComplete: function (xhr) {
            //查询为空的处理方式  
            var rowNum = $("#maingrid").jqGrid('getGridParam', 'records');
            if (rowNum == '0') {
                if ($("#norecords").html() == null)
                    $("#maingrid").parent().append("</pre><div id='norecords' style='text:center;padding: 8px 8px;'>没有查询记录！</div>");
                $("#norecords").show();
            } else {
                $("#norecords").hide();
            }

        }
    });

}

// 获取ligerGrid查询条件
function GetMainGridParms() {

}

// 数据查询 
function search() {
    GetMainGridParms();
    $("#maingrid").jqGrid("setGridParam", { datatype: "json", page: 1, postData: PostData }).trigger("reloadGrid");

}


// 打开添加界面
function create() {
    layer_show("新增" + KeyName + "信息", controllerPath + "DataForm/" + Params, 0, 0);
}

// 打开修改界面
function update(name, key) {
    layer_show(name + "信息修改", controllerPath + "DataForm/" + key + Params, 0, 0);
}


// 浏览单条信息
function detail(name, key) {
    layer_show(name + "信息浏览", controllerPath + "Detail/" + key + Params, 0, 0);
}

// 删除单条信息
function deleteitem(key) {

    layer.msg('确定要删除该' + KeyName + '信息吗？', {
        time: 0
        , btn: ['确定', '取消']
        , yes: function (index) {
            layer.close(index);

            // ajax回调
            ajaxcallback(controllerPath + "Delete", { id: key }, function (data) {
                if (!data.Success) {
                    layer.alert(data.Message, { icon: 2 });
                    $.ligerDialog.error(data.Message);
                }
                else {
                    layer.alert(KeyName + "信息删除成功", { icon: 1 });
                    reload();
                }
            })

        }
    });
}

// 删除多条信息
function deleteitems() {

    var ids = $('#maingrid').jqGrid('getGridParam', 'selarrrow');
    if (ids.length <= 0) { layer.alert("请选择要删除的" + KeyName + "信息!", { icon: 0 }); return; }

    layer.msg('确定要删除选中的' + KeyName + '信息吗？', {
        time: 0
        , btn: ['确定', '取消']
        , yes: function (index) {
            layer.close(index);

            var keys = "";
            for (var i = 0; i < ids.length; i++) {
                keys += "," + ids[i];
            }
            keys = keys.substring(1);

            // ajax回调
            ajaxcallback(controllerPath + "Deletes", { ids: keys }, function (data) {
                if (!data.Success) {
                    layer.alert(data.Message, { icon: 2 });
                }
                else {
                    layer.alert(KeyName + "信息删除成功", { icon: 1 });
                    reload();
                }
            });

        }
    });
}




// 审核多条信息
function checkitems(value) {

    var ids = $('#maingrid').jqGrid('getGridParam', 'selarrrow');
    if (ids.length <= 0) {
        if (value === "1") {
            layer.alert("请选择要审核通过的" + KeyName + "信息!", { icon: 0 }); return;
        }
        else if (value === "2") {
            layer.alert("请选择要审核不通过的" + KeyName + "信息!", { icon: 0 }); return;
        }
        else {
            layer.alert("请选择要审核的" + KeyName + "信息!", { icon: 0 }); return;
        }
    }

    var keys = "";
    for (var i = 0; i < ids.length; i++) {
        keys += "," + ids[i];
    }
    keys = keys.substring(1);

    // ajax回调
    ajaxcallback(controllerPath + "Checks", { ids: keys, status: value }, function (data) {
        if (!data.Success) {
            layer.alert(data.Message, { icon: 2 });
        }
        else {
            if (value === "1") {
                layer.alert(KeyName + "信息审核通过成功", { icon: 1 });
            }
            else if (value === "2") {
                layer.alert(KeyName + "信息审核不通过成功", { icon: 1 });
            }
            else {
                layer.alert(KeyName + "信息审核成功", { icon: 1 });
            }

            reload();
        }
    });

}




// 关闭子窗口
function closewinform() {
    layer_close();
}

// 表格数据刷新 
function reload() {
    search();
}


