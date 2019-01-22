// 获取url参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

// 获取字典项名称 json-字典项集合的Json，value字典项的值
function getDicName(json, value) {
    var strName;

    $.each(json, function (j, item) {
        if (item.Value == value) {
            strName = item.Text;
        }
    });

    return strName;
}

// 获取字典项名称 json-字典项集合的Json，value字典项的值
function getSerName(json, value) {

    var arys = json.split(';')
    var length = arys.length;
    for (var i = 0; i < length; i++) {
        var arys_ = arys[i].split(':');
        if (arys_[0] == value) {
            return arys_[1];
        }
    }
    return value;

}

// 获取字典项名称 json-字典项集合的Json，value字典项的值
function getDicNameLower(json, value) {
    var strName;

    $.each(json, function (j, item) {
        if (item.value == value) {
            strName = item.text;
        }
    });

    return strName;
}

function guidItem() {
    return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
}

function guid() {
    return guidItem() + guidItem() + guidItem() + guidItem() + guidItem() + guidItem() + guidItem() + guidItem();
}

// 获取随机数字字符
function getRandomId() {
    var intId = Math.random();
    return intId.toString().substring(2);
}


// 操作返回提示
function ajaxMessager(url, params, async, cache) {

    if (cache == undefined) cache = false;
    if (async == undefined) async = true;

    layer.load();
    $.ajax({
        type: "post",
        url: url,
        dataType: "text",
        data: params,
        async: async,
        cache: cache,
        success: function (data) {
            alert(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (data.Type == "json") {
                // showvalidateset(data.Message);
                layer.alert(data.Message, { icon: 2 });
            }
            else {
                document.write(XMLHttpRequest.responseText);
            }
        },
        complete: function (XMLHttpRequest, textStatus) {
            layer.closeAll('loading');
        }
    });
}
// 操作标签绑定html
function ajaxHtmlToControl(url, params, showid, async, cache) {

    if (cache == undefined) cache = false;
    if (async == undefined) async = true;
    layer.load();
    $.ajax({
        type: "post",
        url: url,
        dataType: "text",
        data: params,
        async: async,
        cache: cache,
        success: function (data) {
            $("#" + showid).html(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            document.write(XMLHttpRequest.responseText);
        },
        complete: function (XMLHttpRequest, textStatus) {
            layer.closeAll('loading');
        }
    });
}
// 操作标签绑定text
function ajaxTextToControl(url, params, showid, async, cache) {

    if (cache == undefined) cache = false;
    if (async == undefined) async = true;
    layer.load();
    $.ajax({
        type: "post",
        url: url,
        dataType: "text",
        data: params,
        async: async,
        cache: cache,
        success: function (data) {
            $("#" + showid).val(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            document.write(XMLHttpRequest.responseText);
        },
        complete: function (XMLHttpRequest, textStatus) {
            layer.closeAll('loading');
        }
    });

}

// ajax回调
function ajaxcallback(url, params, callback, async, cache) {

    if (cache == undefined) cache = false;
    if (async == undefined) async = true;
    layer.load();
    $.ajax({
        type: "post",
        url: url,
        dataType: "json",
        data: params,
        async: async,
        cache: cache,
        success: callback,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            document.write(XMLHttpRequest.responseText);
        },
        complete: function (XMLHttpRequest, textStatus) {
            layer.closeAll('loading');
        }
    });

}
// ajax回调
function ajaxcallbacktext(url, params, callback, async, cache) {

    if (cache == undefined) cache = false;
    if (async == undefined) async = true;
    layer.load();
    $.ajax({
        type: "post",
        url: url,
        dataType: "text",
        data: params,
        async: async,
        cache: cache,
        success: callback,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            document.write(XMLHttpRequest.responseText);
        },
        complete: function (XMLHttpRequest, textStatus) {
            layer.closeAll('loading');
        }
    });
}

// 设置表单数据提交
function summit(url, formid, close) {

    if (!close) close = "none"; //tab选项卡 / none仅提示 / window表单
    if (!formid) formid = "form";

    layer.load();

    $.ajax({
        type: "post",
        url: url,
        data: $('#' + formid).serialize(),
        dataType: "json",
        cache: false,
        success: function (data) {
            // 360急速浏览器返回会多出<audio controls="controls" style="display: none;"></audio>,需处理
            //if (data.lastIndexOf("}") != data.length - 1) {
            //    data = data.substr(0, data.lastIndexOf("}") + 1)
            //}

            if (!data.Success) {
                layer.alert(data.Message, { icon: 2 });
            }
            else {

                switch (close) {
                    case "window":
                        window.parent.gridband();
                        layer.msg("操作成功，是否关闭当前窗口？", {
                            time: 0, yes: function (index) {
                                layer_close();
                            }
                        });
                        break;
                    case "tab":
                        layer.msg("操作成功，是否关闭当前窗口？", {
                            time: 0, yes: function (index) {
                                removeIframe();
                            }
                        });
                        break;
                    default:
                        layer.alert("操作成功", { icon: 1 });
                        break;
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            document.write(XMLHttpRequest.responseText);
        },
        complete: function (XMLHttpRequest, textStatus) {
            layer.closeAll('loading');
        }

    });
}


// 设置表单数据提交
function summitcallback(url, callback, formid) {

    //close = close || "none"; //tab选项卡 / none仅提示 / window表单
    //formid = formid || "form";
    if (!close) close = "none";
    if (!formid) formid = "form";

    layer.load();

    $.ajax({
        type: "post",
        url: url,
        data: $('#' + formid).serialize(),
        dataType: "json",
        cache: false,
        success: callback,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            document.write(XMLHttpRequest.responseText);
        },
        complete: function (XMLHttpRequest, textStatus) {
            layer.closeAll('loading');
        }

    });

}

function getSpaceNum(wbs) {
    wbs = wbs + "";
    var count = wbs.length - wbs.replace('.', '').length;
    var strSpace = "";
    while (true) {
        if (wbs.length - wbs.replace('.', '').length > 0) {
            strSpace += "&nbsp;&nbsp;";
            wbs = wbs.replace('.', '');
        }
        else {
            break;
        }
    }
    return strSpace;
}

function exportExcel(url, data, failAction) {

    layer.load();

    var iframe = $('.excel-iframe');
    if (iframe.length === 0) {
        iframe = $('<iframe class="excel-iframe hidden">');
        $(document.body).append(iframe);
    }
    $.post(url, data, function (result) {

        if (result.Code == 0) {
            iframe.attr('src', '/Export/Excel?fileName=' + escape(result.Result));
        }
        else {
            if (failAction)
                failAction(result.Message);
        }
        layer.closeAll('loading');
    });
}

