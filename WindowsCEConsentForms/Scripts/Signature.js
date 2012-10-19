$(function () {
    function resetSignatures() {
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
    }

    resetSignatures();

    //procedure method
    var procedures = $("select[id$='DdLProcedures']");
    if (procedures.size() > 0) {
        procedures.multiselect({
            selectedList: 4,
            header: "Choose procedures below",
            noneSelectedText: 'Procedures',
            click: function () {
                setProcedures();
            }
        });
    }

    // setting values here
    var ddlSelectedProcedures = $('input[id$="SelectedProcedures"]');
    if (ddlSelectedProcedures.size() > 0) {
        var proceduresList = $('input[id$="SelectedProcedures"]').val().split(',');
        procedures.multiselect("widget").find(":checkbox").each(function () {
            var thisObj = $(this);
            for (var j = 0; j < proceduresList.length; j++) {
                if (thisObj.val().trim() == proceduresList[j].toString().trim()) {
                    thisObj.click();
                    break;
                }
            }
        });

        function setProcedures() {
            var values = '';
            procedures.multiselect("widget").find(":checkbox").each(function () {
                var thisObj = $(this);
                if (thisObj.is(':checked')) {
                    values += thisObj.val() + '#';
                }
            });
            $('input[id$="SelectedProcedures"]').val(values);
        }
    }

    // Patient not able to sign check box handling here
    var checkbox = $('input[id$="ChkPatientisUnableToSign"]');
    if ($('input[id$="TxtPatientNotSignedBecause"]').val() == null || $('input[id$="TxtPatientNotSignedBecause"]').val() == '') {
        hideElement($('.PatientReason'));
        showElement($('.PatientSign'));
    } else {
        showElement($('.PatientReason'));
        hideElement($('.PatientSign'));
    }
    checkbox.bind('click', function () {
        if ($(this).is(':checked')) {
            showElement($('.PatientReason'));
            hideElement($('.PatientSign'));
            $('input[id$="TxtPatientNotSignedBecause"]').focus();
        } else {
            hideElement($('.PatientReason'));
            showElement($('.PatientSign'));
        }
    });

    function hideElement(element) {
        //element.hide();
        //setTimeout(resetSignatures(), 1000);
    }

    function showElement(element) {
        //element.show();
        //setTimeout(resetSignatures(), 1000);
    }
});