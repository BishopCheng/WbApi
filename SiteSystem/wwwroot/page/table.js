// 控制器地址
var controllerPath;
var maingrid;
var rowData;
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

var pageSize = 10;

var isMultiSelect = true;

// 数配置 {columnId: 'PAGE_ID', idField: 'PAGE_ID', parentIDField: 'PAGE_PARENT' }
var treeParms = {};

// 查询参数
var PostData = {};

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

// 数据查询 
function search() {
    //gridband();

    GetMainGridParms();
    $("#maingrid").jqGrid("setGridParam", { datatype: "json", page: 1, postData: PostData }).trigger("reloadGrid");
}

// 初始化数据列表
function initGrid() {
    gridband();
}

// 数据列表扩展
function extendGrid() {

}

// 数据列表扩展
function getNewOrderNum() {
    return $("#maingrid").children("tbody").children("tr").length;
}

var lastSelect;

// 表格数据查询
function gridband() {

    GetMainGridParms();

    $("#maingrid").jqGrid({
        url: controllerPath + "GetList",
        editurl: controllerPath + "Update",
        mtype: "POST",
        datatype: "json",
        styleUI: "Bootstrap",
        colModel: maingridColumns,
        viewrecords: true, // show the current page, data rang and total records on the toolbar
        multiselect: isMultiSelect,
        autowidth: true,
        forceFit: true,
        shrinkToFit: false,
        width: "100%",
        height: "100%",
        rownumbers: true,
        rowNum: pageSize,
        rowList: [10, 20, 30, 50, 100],  //设置分页下拉列表  
        rownumbers: true, // 显示行号  
        rownumWidth: 35, // the width of the row numbers columns  
        subGrid: false,//是否启用子表格  
        postData: PostData,
        loadonce: false, // this is just for the demo
        pager: "#gridPager",
        keys: true,
        onSelectRow: function (id) {
            if (lastSelect && id) {
                if (id != lastSelect) {
                    $('#maingrid').jqGrid('saveRow', lastSelect);
                    $('#maingrid').jqGrid('restoreRow', lastSelect);
                    $('#maingrid').jqGrid('editRow', id, true);

                    lastSelect = id;
                }
            }
        },
        ondblClickRow: function (rowId, rowIndex, colnumIndex, event) {
            lastSelect = rowId;
            $('#maingrid').jqGrid('editRow', rowId, true);
        },
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

function saveLine() {
    if (lastSelect) {
        $('#maingrid').jqGrid('saveRow', lastSelect);
        $('#maingrid').jqGrid('restoreRow', lastSelect);
        lastSelect = null;
    }
}

// 获取ligerGrid查询条件
function GetMainGridParms() {

}

// 删除单条信息
function deleteitem(key) {
    layer.msg("确定要删除该"+KeyName+"信息吗？", {
        time: 0
        , btn: ['确定', '取消']
        , yes: function (index) {
            layer.close(index);

            // ajax回调
            ajaxcallback(controllerPath + "Delete", { id: key }, function (data) {
                if (!data.Success) {
                    layer.alert(data.Message, { icon: 2 });
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

    layer.msg('确定要删除选中的系统信息吗？', {
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

function getNewRowData() {
    return {};
}


// 新增数据
function addNewRow() {

    var newRecord = getNewRowData();

    ajaxcallback(controllerPath + "Insert", newRecord, function (data) {
        if (!data.Success) {
            showvalidateset(data.Message);
        }
        else {
            reload();
        }
    });
}

// 表格数据刷新 
function reload() {
    search();
}


// 设置表单验证结果
function showvalidateset(result) {

    var showinfo = "";
    var jsonResult = eval('(' + result + ')');

    $.each(jsonResult, function (j, item) {
        showinfo += item.result + "<br/>";
    });

    layer.alert(showinfo, { icon: 2 });
}