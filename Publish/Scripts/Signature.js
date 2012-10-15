$(function () {
    try {
        for (var i = 0; i < 7; i++) {
            var options = {
                'drawOnly': true,
                'output': '.HdnImage' + i.toString(),
                'validateFields': false
            };
            var value = undefined;
            if ($('.HdnImage' + i.toString()).size() > 0)
                value = $('.HdnImage' + i.toString()).val();
            if (value != undefined) {
                try
                {
                    $('.sig' + +i.toString()).signaturePad(options).regenerate(value);
                } catch (e) {
                    $('.sig' + +i.toString()).signaturePad(options);
                }
            }
        }
    } catch (e) {

    }
});