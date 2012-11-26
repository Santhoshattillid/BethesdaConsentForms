$(function () {
    function resetSignatures() {
        try {
            for (var i = 0; i < 20; i++) {
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

    // loading associated doctors using ajax method
    $(".DdlPrimaryDoctors").live('change', function () {
        var This = $(this);
        var value = $(this).val();
        $.ajax({
            type: 'POST',
            url: '/AjaxMethods.asmx/GetAssociatedDoctors',
            data: "{'primaryPhysicianId':'" + value + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            before: function () {
            },
            success: function (data) {
                This.parents('li').find(".LblAssociatedDoctors").html(data.d);
            },
            error: function (e) {
            }
        });
        return false;
    });

    // repeating doctors and procedures here
    var emptyCloneDocProc = $('.LiDoctorsAndProcedures').eq(0).clone();
    $('#AddNewProcedure').click(function () {
        var liClone = $(this).parents('li');
        var cloneData = emptyCloneDocProc.clone();
        cloneData.find('.LblAssociatedDoctors').empty();
        cloneData.find('.TxtProcedures').empty();
        cloneData.find('.TxtProcedures').val('');
        cloneData.find('.DdlPrimaryDoctors').val('0');
        cloneData.find('.ui-multiselect.ui-widget.ui-state-default.ui-corner-all').remove();
        liClone.eq(0).before(cloneData);
        initializeProcedures(cloneData.find('select.DdLProcedures'));
        return false;
    });

    //procedure method
    initializeProcedures($("select.DdLProcedures"));

    var pageLoadStarted = true;

    // setting values here
    var ddlSelectedProcedures = $('.HdnSelectedProcedures');
    if (ddlSelectedProcedures.size() > 0) {
        ddlSelectedProcedures.each(function () {
            var proceduresList = $(this).val().split('#');
            var ddlProcedures = $(this).parents('li').find('select.DdLProcedures');
            ddlProcedures.multiselect("widget").find(":checkbox").each(function () {
                var thisObj = $(this);
                for (var j = 0; j < proceduresList.length; j++) {
                    if (thisObj.val().trim() == proceduresList[j].toString().trim()) {
                        thisObj.attr('checked', false);
                        thisObj.click();
                        thisObj.attr('checked', true);
                        break;
                    }
                }
            });
        });
        pageLoadStarted = false;
        updateSelectedProcedures();
    }

    $.ech.multiselect.prototype.options.selectedList = "4";
    $.ech.multiselect.prototype.options.header = "Choose procedures below";
    $.ech.multiselect.prototype.options.noneSelectedText = 'Procedures';
    $.ech.multiselect.prototype.options.click = function (e) {
        setProcedures(e);
    };
    function initializeProcedures(procedureDdl) {
        if (procedureDdl.size() > 0) {
            procedureDdl.multiselect({
                selectedList: "4",
                header: "Choose procedures below",
                noneSelectedText: 'Procedures',
                click: function (event, ui) {
                    setProcedures(event);
                    //ui.value + ' ' + (ui.checked ? 'checked' : 'unchecked');
                }
            });
        }
    }

    function setProcedures(e) {
        // code to check whether the doctor selects other
        if (e.srcElement != undefined && e.srcElement.value == "Other") {
            if ($(e.srcElement).is(':checked')) {
                showOrHideOtherProcedureBox(true);
                //$(this).parents('li').eq(0).find('.DivOtherProcedure').show();
            } else {
                showOrHideOtherProcedureBox(false);
                //$(this).parents('li').eq(0).find('.DivOtherProcedure').hide();
            }
        }
        updateSelectedProcedures();
    }

    function updateSelectedProcedures() {
        if (!pageLoadStarted) {
            $('.DdLProcedures').each(function () {
                var arrayOfCheckedValues = $(this).multiselect("getChecked").map(function () {
                    return this.value;
                }).get();
                var values = '';
                for (var i = 0; i < arrayOfCheckedValues.length; i++) {
                    values += $.trim(arrayOfCheckedValues[i]) + "#";
                }
                $(this).parents('li.LiDoctorsAndProcedures').eq(0).find('input.HdnSelectedProcedures').val(values);
            });
        }
    }

    function showOrHideOtherProcedureBox(state) {
        $('.DivOtherProcedure:hidden').each(function () {
            var arrayOfCheckedValues = $(this).parents('li.LiDoctorsAndProcedures').find('.DdLProcedures').multiselect("getChecked").map(function () {
                return this.value;
            }).get();
            for (var i = 0; i < arrayOfCheckedValues.length; i++) {
                if ($.trim(arrayOfCheckedValues[i]) == "Other") {
                    if (state == true)
                        $(this).show();
                    else
                        $(this).hide();
                    break;
                }
            }
        });
    }

    // Patient not able to sign check box handling here
    //    var checkbox = $('input[id$="ChkPatientisUnableToSign"]');
    //    if ($('input[id$="TxtPatientNotSignedBecause"]').val() == null || $('input[id$="TxtPatientNotSignedBecause"]').val() == '') {
    //        hideElement($('.PatientReason'));
    //        showElement($('.PatientSign'));
    //        setTimeout(resetSignatures, 1000);
    //    } else {
    //        showElement($('.PatientReason'));
    //        hideElement($('.PatientSign'));
    //        setTimeout(resetSignatures, 1000);
    //    }
    //    checkbox.bind('click', function () {
    //        if ($(this).is(':checked')) {
    //            showElement($('.PatientReason'));
    //            hideElement($('.PatientSign'));
    //            setTimeout(resetSignatures, 1000);
    //            $('input[id$="TxtPatientNotSignedBecause"]').focus();
    //        } else {
    //            hideElement($('.PatientReason'));
    //            showElement($('.PatientSign'));
    //            setTimeout(resetSignatures, 1000);
    //        }
    //    });
    //function hideElement(element) {
    //    element.hide();
    //}

    //function showElement(element) {
    //    element.show();
    //}
});