$(function () {
    try {
        var sigdiv1 = $('.signature');
        sigdiv1.jSignature();
        sigdiv1.bind('change', function (e) {
            var datapair = $(e.target).jSignature("getData");
            //var i = new Image();
            //i.src = "data:" + datapair[0] + "," + datapair[1];
            //$(i).appendTo($("body"));
            //alert(datapair[0]);
            var ele = $('INPUT[id$=' + $(e.target).attr('hdfld').toString() + "]");
            ele.val(datapair);
        });
        $('#TxtSignature1').jSignature('setData', $('INPUT[id$=HdnImage1').val());
        $('#TxtSignature2').jSignature('setData', $('INPUT[id$=HdnImage2').val());
        $('#TxtSignature3').jSignature('setData', $('INPUT[id$=HdnImage3').val());
        $('#TxtSignature4').jSignature('setData', $('INPUT[id$=HdnImage4').val());
        $('#TxtSignature5').jSignature('setData', $('INPUT[id$=HdnImage5').val());
        $('#TxtSignature6').jSignature('setData', $('INPUT[id$=HdnImage6').val());
    } catch (e) {
    }
});