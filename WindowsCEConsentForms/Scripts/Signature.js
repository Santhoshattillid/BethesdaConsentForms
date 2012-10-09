$(function () {
    try {
        for (var i = 0; i < 7; i++) {
            var options = {
                'drawOnly': true,
                'output': '.HdnImage' + i.toString()
            };
            $('.sig' + +i.toString()).signaturePad(options);
        }
    } catch (e) {
    }
});