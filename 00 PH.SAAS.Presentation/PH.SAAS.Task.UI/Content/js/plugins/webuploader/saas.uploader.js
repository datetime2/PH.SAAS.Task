var isloaduploader = false;
$(function () {
    //初始化绑定默认的属性
    $.upLoadDefaults = $.upLoadDefaults || {};
    $.upLoadDefaults.property = {
        multiple: false, //是否多文件
        water: false, //是否加水印
        thumbnail: false, //是否生成缩略图
        sendurl: null, //发送地址
        filetypes: "jpg,jpge,png,gif", //文件类型
        filesize: 2048, //文件大小
        btntext: "浏览...", //上传按钮的文字
        swf: null //SWF上传控件相对地址
    };
    //初始化上传控件
    $.fn.InitUploader = function (b) {
        var fun = function (parentObj) {
            var p = $.extend({}, $.upLoadDefaults.property, b || {});
            parentObj.find("div.upload-btn").remove();
            var btnObj = $('<div class="upload-btn">' + p.btntext + '</div>').appendTo(parentObj);
            //初始化属性
            p.sendurl += "?action=Task";
            if (!p.multiple) {
                p.sendurl += "&delfile=" + parentObj.siblings(".upload-path").val();
            }
            //初始化WebUploader
            var uploader = WebUploader.create({
                compress: false, //不压缩
                auto: true, //自动上传
                swf: p.swf, //SWF路径
                server: p.sendurl, //上传地址
                pick: {
                    id: btnObj,
                    multiple: p.multiple
                },
                accept: {
                    extensions: p.filetypes
                },
                formData: {
                    'DelFilePath': '' //定义参数
                },
                fileVal: 'Filedata', //上传域的名称
                fileSingleSizeLimit: p.filesize * 1024 //文件大小
            });

            //当validate不通过时，会以派送错误事件的形式通知
            uploader.on('error', function (type) {
                switch (type) {
                    case 'Q_EXCEED_NUM_LIMIT':
                        $.modalAlert("上传文件数量过多", "warning");
                        break;
                    case 'Q_EXCEED_SIZE_LIMIT':
                        $.modalAlert("文件总大小超出限制", "warning");
                        break;
                    case 'F_EXCEED_SIZE':
                        $.modalAlert("文件大小超出限制", "warning");
                        break;
                    case 'Q_TYPE_DENIED':
                        $.modalAlert("禁止上传非" + p.filetypes + "格式文件", "warning");
                        break;
                    case 'F_DUPLICATE':
                        $.modalAlert("请勿重复上传该文件", "warning");
                        break;
                    default:
                        $.modalAlert(type, "warning");
                        break;
                }
            });

            //当有文件添加进来的时候
            uploader.on('fileQueued', function (file) {
                //如果是单文件上传，把旧的文件地址传过去
                if (!p.multiple) {
                    uploader.options.formData.DelFilePath = parentObj.siblings(".upload-path").val();
                }
                //防止重复创建
                if (parentObj.children(".upload-progress").length === 0) {
                    //创建进度条
                    var fileProgressObj = $('<div class="upload-progress"></div>').appendTo(parentObj);
                    var progressCancel = $('<a class="close" title="取消上传">关闭</a>').appendTo(fileProgressObj);
                    //绑定点击事件
                    progressCancel.click(function () {
                        uploader.cancelFile(file);
                        fileProgressObj.remove();
                    });
                }
            });

            //文件上传过程中创建进度条实时显示
            uploader.on('uploadProgress', function (file, percentage) {
                var progressObj = parentObj.children(".upload-progress");
                progressObj.children(".txt").html(file.name);
                progressObj.find(".bar b").width(percentage * 100 + "%");
            });

            //当文件上传出错时触发
            uploader.on('uploadError', function (file, reason) {
                uploader.removeFile(file); //从队列中移除
                $.modalAlert("错误代码：" + reason, "warning");
            });

            //当文件上传成功时触发
            uploader.on('uploadSuccess', function (file, data) {
                var progressObj = parentObj.children(".upload-progress");
                if (data.code === 0) {
                    if (!p.multiple) {
                        parentObj.siblings(".upload-name").val(data.name);
                        parentObj.siblings(".upload-path").val(data.path);
                        parentObj.siblings(".upload-size").val(data.size);
                    } 
                    progressObj.children(".txt").html("上传成功：" + file.name);

                } else {
                    progressObj.children(".txt").html(data.errors);
                }
                uploader.removeFile(file); //从队列中移除
            });
            //不管成功或者失败，文件上传完成时触发
            uploader.on('uploadComplete', function () {
                var progressObj = parentObj.children(".upload-progress");
                progressObj.children(".txt").html("上传完成");
                //如果队列为空，则移除进度条
                if (uploader.getStats().queueNum === 0) {
                    progressObj.remove();
                }
            });
        };
        return $(this).each(function () {
            fun($(this));
        });
    }
});
