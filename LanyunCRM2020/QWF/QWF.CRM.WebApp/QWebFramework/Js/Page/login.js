
document.onkeydown = function (event) {
    e = event ? event : (window.event ? window.event : null);
    if (e.keyCode == 13) {
        btnLogin();
        return false;
    }
}

$(function () {
    initData();

    $('#btnLogin').click(function () {
        btnLogin();
    });
});
function initData() {

}

//登录请求
function btnLogin() {
    var param = {
        userName: $('#userName').val(),
        passWord: $('#passWord').val()
    };
    if (param.userName.length == 0) {
        alertError('请填写用户名');
        return false;
    } else if (param.passWord.length == 0) {
        alertError('请填写密码');
        return false;
    }

    param.passWord = md5(param.passWord);

    ajaxCore({
        url: '/QWebFramework/Users/UserLogin',
        data: param,
        success: function (data) {
            if (data.Success) {
                window.location.href = qwfConfig.mainUrl;
            } 
        }
    });
}
