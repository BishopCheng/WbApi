// 控制器地址
var controllerPath;
// 主键
var keyField;
// 模块关键词
var KeyName;
// 子窗口
var winform;

// 主方法页面加载
function loadPage() {

    layer.load(); 

    // css_init();
    initData();
    initOperate();
    initForm();
    initValidation();
    loadData();
}

// 加载表单初始化信息
function initData() {

}

// 加载表单初始化信息
function initForm() {

}

// 加载表单验证
function initValidation() {

    ajaxcallback(controllerPath + "GetFormCheck", {}, function (data) {
        if (!data.Success) { 
            layer.alert(data.Message, { icon: 2 });
        }
        else {
            $("#form").formvalidate(data.Data);
        }
    })

}


// 设置表单验证结果
function showvalidateset(result) {

    var showinfo = "";
    var jsonResult = eval('(' + result + ')');

    $.each(jsonResult, function (j, item) {

        var limsg = $("[name='" + item.name + "']");
        if (!$(limsg).hasClass("msg_error")) $(limsg).addClass("msg_error");

        showinfo += item.result + "<br/>";
    });
     
    layer.alert(showinfo, { icon: 2 });
}


// 设置表单数据提交
function summit(url, formid, close) {

    //var formData = new FormData($('#uploadForm')[0]);
    //formData.append('num', '1');//可以在已有表单数据的基础上，继续添加新的键值对
    //$.ajax({
    //    url: '/upload',
    //    type: 'POST',
    //    cache: false,
    //    data: new FormData($('#uploadForm')[0]),
    //    processData: false,
    //    contentType: false
    //}).done(function (res) { }).fail(function (res) { });


    layer.load();

    $.ajax({
        type: "post",
        url: url,
        data: $('#' + formid).serialize(),
        // data: new FormData($('#' + formid)[0]),
        dataType: "json",
        cache: false,
        success: function (data) {

            // 360急速浏览器返回会多出<audio controls="controls" style="display: none;"></audio>,需处理
            //if (data.lastIndexOf("}") != data.length - 1) {
            //    data = data.substr(0, data.lastIndexOf("}") + 1)
            //}

            if (!data.Success) {
                if (data.Type == "json") {
                    showvalidateset(data.Message);
                }
                else { 
                    layer.alert(data.Message, { icon: 2 });
                }
            }
            else {
                switch (close) {
                    case "window":
                        window.parent.reload();

                        layer.msg('操作成功，是否关闭当前窗口？', {
                            time: 0
                            , btn: ['确定', '取消']
                            , yes: function (index) {
                                layer.close(index);

                                closewinform();
                            }
                        });

                        break;
                    case "tab":

                        layer.msg('操作成功，是否关闭当前窗口？', {
                            time: 0
                            , btn: ['确定', '取消']
                            , yes: function (index) {
                                layer.close(index);

                                removeIframe();
                            }
                        });

                        break;
                    default:
                        layer.alert("操作成功!", { icon: 0 });
                        break;
                }

                aftersummit();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            layer.alert(XMLHttpRequest.responseText, { icon: 2 });
        },
        complete: function (XMLHttpRequest, textStatus) {
            layer.closeAll('loading');
        }

    });

}

function aftersummit() {

}

// 初始化操作
function initOperate() {

    if ($("#btnSave").length > 0) {
        $("#btnSave").click(function () {
            summit(controllerPath + "Save", "form", "window");
        });
    }

    if ($("#BtnReset").length > 0) {
        $("#BtnReset").click(function () {
            formreset();
        });
    }

    if ($("#BtnClose").length > 0) {
        $("#BtnClose").click(function () {
            closewinform();
        });
    }

}

function formreset() {

    if (!$("#Key").val()) {
        $("#form")[0].reset();
    }
    else {
        loadData();
    }
}


// 加载表单数据
function loadData() {

    var id = $("#Key").val();
    if (!id) {
        loadDefaultValue();
    }
    else {
        getData(id);
    }
}

function getData(id) {
    ajaxcallback(controllerPath + "Get", { id: id }, function (data) {
        if (!data.Success) { 
            layer.alert(data.Message, { icon: 2 });
        }
        else {
            _loadform(data);
        }
    });
}

function loadDefaultValue() {

}

function _loadform(data) {
    $("#form").loadform(data.Data);

    if (data.DataExt) {
        $("#form").loadform(data.DataExt);
    }

    showData();
}

// 数据展示处理
function showData() {

}

// 关闭子窗口
function closewinform() {
    layer_close();
}

//初始化多选下拉框chosen选中的值$elm:juery的select元素，datas:选中的值多个用,隔开,option参数
var chosenSetValues = ($elm, datas, option = {}) => {
    option = $.extend({}, { no_results_text: '无结果匹配！' }, option);
    var url = $elm.attr('data_url') || option.url;
    if (url) {
        $.post(url, (result) => {
            _chosenSetValues($elm, result, datas, option)
        }, 'json');
    } else {
        var tempArr = [];
        $elm.children('option').each(function () {
            tempArr.push({ id: $(this).attr('value'), name: $(this).text() })
        });
        _chosenSetValues($elm, tempArr, datas, option)
    }
};
var _chosenSetValues = ($elm, result, datas, option) => {
    var html = '';
    var flag = false;
    $elm.empty();
    $elm.chosen("destroy");
    if (typeof datas === 'string') {
        if (datas.length == 0) {
            datas = [];
        } else {
            datas = datas.split(',');
        }
    }
    for (var i = 0; i < result.length; i++) {
        for (var j = 0; j < datas.length; j++) {
            if (datas[j] == result[i].id) flag = true;
        }
        if (flag) {
            html += "<option value=" + result[i].id + " selected >" + result[i].name + "</option>";
            flag = false;
        } else {
            html += "<option value=" + result[i].id + ">" + result[i].name + "</option>"
        }
    }
    $elm.append(html);
    //设置未找到时的显示文字
    $elm.chosen(option);
};

