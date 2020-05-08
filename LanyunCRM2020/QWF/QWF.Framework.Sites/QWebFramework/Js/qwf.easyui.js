(function ($) {
    // datagrid begin
    $.fn.qwfDataGrid = function (options) {
        var defaults = {
            rownumbers:  false,
            singleSelect: true,
            fit: true,
            fitColumns: false,
            border: false,
            pagination: true,
            pageSize: 30,
            toolbar: '#tb'
           
        };

        var settings = $.extend(defaults, options);
        var dg = this.datagrid(settings);

        //dg.datagrid({
        //    onLoadSuccess: function (data) {
        //        console.log('父方法。。。。。。');
        //        //回调函数
        //        ajaxSuccess(data);
        //        options.onLoadSuccess != undefined && typeof options.onLoadSuccess != 'undefined' && options.onLoadSuccess(data);
        //    },

        //});
        ////设置标题,工具条
        dg.datagrid("getPanel").panel({
            tools: [{
                iconCls: 'icon-help',
                handler: function () { alert('help') }
            }, {
                iconCls: 'icon-reload',
                handler: function () { window.location.href = settings.url }
            }, {
                iconCls: 'panel-tool-collapse',
                handler: function () {
                    if ($(".qwf-searchbar").is(":hidden")) {
                        $(".qwf-searchbar").show();    //如果元素为隐藏,则将它显现
                    } else {
                        $(".qwf-searchbar").hide();     //如果元素为显现,则将其隐藏
                    }
                    //重设datagrid
                    dg.datagrid('resize');
                }
            }]
        });

        if (settings.pagination) {
            dg.datagrid('getPager').pagination({
                pageList: [30, 50, 100],
                beforePageText: '第', //页数文本框前显示的汉字  
                afterPageText: '页    共 {pages} 页',
                displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
            });
        }
    }
    // end

    //$.fn.qwfDiglog = function(options)
})(jQuery);