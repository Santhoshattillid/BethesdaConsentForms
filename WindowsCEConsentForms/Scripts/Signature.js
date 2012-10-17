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
                try {
                    $('.sig' + +i.toString()).signaturePad(options).regenerate(value);
                } catch (e) {
                    $('.sig' + +i.toString()).signaturePad(options);
                }
            }
        }
    } catch (e) {
    }
    var procedures = $("select[id$='DdLProcedures']");
    if (procedures.size() > 0) {
        //procedures.dropdownchecklist();
        procedures.multiselect({
            selectedList: 4,
            header: "Choose procedures below"
        });
        /*$('.ui-dropdownchecklist-item input[type="checkbox"]').change(function () {
            if (!$(this).is(':checked')) {
                setProcedures();
            }
            return false;
        });
        function setProcedures() {
            var outPut = '';
            $('.ui-dropdownchecklist-item input[type="checkbox"]').each(function () {
                if ($(this).is(':checked')) {
                    outPut += $(this).val();
                }
            });
            var ele = $('.ui-dropdownchecklist-wrapper .ui-dropdownchecklist .ui-dropdownchecklist-text');
            //var text = ele.html().replace($(this).val(), '');
            ele[0].innerHTML = outPut;
            ele[0].title = outPut;
        } */
    }
});