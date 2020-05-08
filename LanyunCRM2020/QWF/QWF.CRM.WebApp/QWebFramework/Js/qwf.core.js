//全局方法
var debug = true;
//var author = getToken();

$.ajaxSetup({
    /*xhrFields:
        {
            withCredentials: true
        },
    crossDomain: true,*/
    global: false,
    type: "post",
    dataType: "json",
    timeOut: 1000 * 300, //5分钟
    headers: {
      /*  "_qwf_appid": author.appid,
        "_qwf_token": author.token*/
    },
    success: function (res) {
        ajaxSuccess(res);
    },
    error: function (xhr, textStatus) {
        ajaxError(xhr, textStatus);
    }
});

(function ($) {
    $.fn.serializeJSON = function () {
        var serializeObj = {};
        $(this.serializeArray()).each(function () {
            serializeObj[this.name] = this.value;
        });
        return serializeObj;
    };
})(jQuery);

function setToken() {
    //写COOKIE
}
//function getToken() {
//    var o = {
//        appid: 'qwf.base',
//        token: 'token123232'
//    };
//    return o;
//}

function ajaxLoading() {
   
    $("<div class=\"datagrid-mask\" style=\"z-index:9999\" ></div>").css({ display: "block", width: "100%", height: $(document).height() }).appendTo("body");
    $("<div class=\"datagrid-mask-msg\"  style=\"z-index:99999\" ></div>").html("处理中,请稍候。。。").appendTo("body").css({ display: "block", left: ($(document).outerWidth(true) - 190) / 2, top: (document.outerWidth - 30) / 2, height: "34px" });
}
function ajaxLoadEnd() {
    $(".datagrid-mask").remove();
    $(".datagrid-mask-msg").remove();
}

function alertError(msg) {
    $.messager.alert('错误', msg, 'error');
}

function alertInfo(msg) {
    $.messager.alert('消息', msg, 'info');
}

function ajaxCore(o) {
    $.ajax({
        type: (o.type == undefined || o.type == null || o.type == '') ? "POST" : o.type, //默认POST
        url: o.url,
        data: o.data,
        beforeSend: function (xhr) {
            ajaxLoading();
            //alert('函数方法。。。。');
            //call back
            o.beforeSend != undefined && typeof o.beforeSend == 'function' && o.beforeSend(xhr);
        },
        success: function (res) {
            ajaxSuccess(res);
            //call back
            o.success != undefined && typeof o.success == 'function' && o.success(res);
        },
        complete: function (xhr, textStatus) {

            o.complete != undefined && typeof o.complete == 'function' && o.complete(xhr, textStatus);
        },
        error: function (xhr, textStatus) {
            ajaxError(xhr, textStatus);
            o.error != undefined && typeof o.error == 'function' && o.error(xhr, textStatus);
        }

    })
}
//统一错误处理：
function ajaxError(xhr, textStatus) {
    ajaxLoadEnd();
    var msg = 'ajax 请求错误:\r\n'
        + 'textStatus: ' + textStatus + '\r\n'
        + 'readyState: ' + xhr.readyState + '\r\n'
        + "status: " + xhr.status + '\r\n'
        + "responseText:" + "\r\n" + xhr.responseText;

    if (debug) {
        console.log(msg);
        
    }

}


//统一请求返回处理
function ajaxSuccess(res) {
    //关闭LOADING
    ajaxLoadEnd();
    
    console.log(res);

    if (res.Success == false) {
        //console.log('------------ 统一错误处理--------------');
        if (res.ReturnUrl != undefined && res.ReturnUrl.length > 0) {
            window.location.href = res.ReturnUrl; //调转到指定页面页面
        }
        //打印错误信息
        alertError(res.Message);
    }
    else {
        return res
    }
}
