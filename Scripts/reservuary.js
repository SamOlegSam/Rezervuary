function WriteDB() {
    var tabletab = document.getElementById('tabb');

    var isValid = true;

    for (var i = 1; i <= tabletab.rows.length; i++) {

        if ($('#datapicker').val() == "") {
            $('#datapicker').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#datapicker').css('border-color', 'lightgrey');
        }

        if (($('#Urovenn_' + Number(i)).val() == "") || ($('#Urovenn_' + Number(i)).val() == "Упс!")) {
            $('#Urovenn_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Urovenn_' + Number(i)).css('border-color', 'lightgrey');

        }
        if ($('#V20_' + Number(i)).val() == "" || $('#Urovenn_' + Number(i)).val() == "Упс!") {
            $('#V20_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#V20_' + Number(i)).css('border-color', 'lightgrey');
        }

        if ($('#Temperat_' + Number(i)).val() == "" || $('#Urovenn_' + Number(i)).val() == "Упс!") {
            $('#Temperat_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Temperat_' + Number(i)).css('border-color', 'lightgrey');
        }

        if ($('#V_' + Number(i)).val() == "" || $('#Urovenn_' + Number(i)).val() == "Упс!") {
            $('#V_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#V_' + Number(i)).css('border-color', 'lightgrey');
        }

        if ($('#Plotnost_' + Number(i)).val() == "" || $('#Urovenn_' + Number(i)).val() == "Упс!") {
            $('#Plotnost_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Plotnost_' + Number(i)).css('border-color', 'lightgrey');
        }

        if ($('#massa_' + Number(i)).val() == "" || $('#Urovenn_' + Number(i)).val() == "Упс!") {
            $('#massa_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#massa_' + Number(i)).css('border-color', 'lightgrey');
        }

        if ($('#UrovH2O_' + Number(i)).val() == "") {
            $('#UrovH2O_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#UrovH2O_' + Number(i)).css('border-color', 'lightgrey');
        }

        if ($('#VH2O_' + Number(i)).val() == "") {
            $('#VH2O_' + Number(i)).css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#VH2O_' + Number(i)).css('border-color', 'lightgrey');
        }

    }
    if (isValid == false) {
        return false;
    }

    for (var i = 1; i <= tabletab.rows.length; i++) {
        var data = {
            'datapicker': $('#datapicker').val(),
            'LocID': $('#LocID_' + Number(i)).val(),
            'IDRez': $('#ID_' + Number(i)).val(),
            'Uroven': $('#Urovenn_' + Number(i)).val(),
            'V20': $('#V20_' + Number(i)).val(),
            'Temperat': $('#Temperat_' + Number(i)).val(),
            'V': $('#V_' + Number(i)).val(),
            'Plotnost': $('#Plotnost_' + Number(i)).val(),
            'massa': $('#massa_' + Number(i)).val(),
            'UrovH2O': $('#UrovH2O_' + Number(i)).val(),
            'User': $('#User_' + Number(i)).val(),
            'VH2O': $('#VH2O_' + Number(i)).val()
        };

        $.ajax({
            url: "/Home/WriteDB",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(data),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //---------------------------------------------------------------
    $.ajax({
        url: "/Home/ModalDB",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
    //---------------------------------------------------------------
//--------------------------------//
function GetDBGomel()
{
    var isValid = true;
        
    if ($('#datapicker').val() == "")    {
            $('#datapicker').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#datapicker').css('border-color', 'lightgrey');
        }
    let date1 = new Date($('#datapicker').val());
    let date2 = new Date();

    if (date1 > date2) {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }
    
    if (isValid == false) {
        return false;
    }

    var data = {
        'datapicker': $('#datapicker').val(),        
    };

        $.ajax({
        url: "/Home/GetDBGomel",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
            success: function (result) {
               
            $('#tab').html(result);
            $('#tabl').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

        
}
//---------------------------------------------------------------
//--------------------------------//
function GetDBZasch() {
    var isValid = true;

    if ($('#datapicker').val() == "") {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }
    let date1 = new Date($('#datapicker').val());
    let date2 = new Date();

    if (date1 > date2) {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }
    
    if (isValid == false) {
        return false;
    }

    var data = {
        'datapicker': $('#datapicker').val(),        
    };

    $.ajax({
        url: "/Home/GetDBZasch",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {

            $('#tab').html(result);
            $('#tabl').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });


}
//---------------------------------------------------------------
//--------------------------------//
function GetDBMozyr() {
    var isValid = true;

    if ($('#datapicker').val() == "") {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }
    let date1 = new Date($('#datapicker').val());
    let date2 = new Date();

    if (date1 > date2) {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        'datapicker': $('#datapicker').val(),
    };

    $.ajax({
        url: "/Home/GetDBMozyr",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {

            $('#tab').html(result);
            $('#tabl').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//---------------------------------------------------------------
//--------------------------------//
function GetDBTurov() {
    var isValid = true;

    if ($('#datapicker').val() == "") {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }
    let date1 = new Date($('#datapicker').val());
    let date2 = new Date();

    if (date1 > date2) {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        'datapicker': $('#datapicker').val(),
    };

    $.ajax({
        url: "/Home/GetDBTurov",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {

            $('#tab').html(result);
            $('#tabl').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//---------------------------------------------------------------
//--------------------------------//
function GetDBPinsk() {
    var isValid = true;

    if ($('#datapicker').val() == "") {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }
    let date1 = new Date($('#datapicker').val());
    let date2 = new Date();

    if (date1 > date2) {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        'datapicker': $('#datapicker').val(),
    };

    $.ajax({
        url: "/Home/GetDBPinsk",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {

            $('#tab').html(result);
            $('#tabl').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//---------------------------------------------------------------
//--------------------------------//
function GetDBKobrin() {
    var isValid = true;

    if ($('#datapicker').val() == "") {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }
    let date1 = new Date($('#datapicker').val());
    let date2 = new Date();

    if (date1 > date2) {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        'datapicker': $('#datapicker').val(),
    };

    $.ajax({
        url: "/Home/GetDBKobrin",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {

            $('#tab').html(result);
            $('#tabl').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//---------------------------------------------------------------
//--------------------------------//
function GetDBGorki() {
    var isValid = true;

    if ($('#datapicker').val() == "") {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }
    let date1 = new Date($('#datapicker').val());
    let date2 = new Date();

    if (date1 > date2) {
        $('#datapicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
        'datapicker': $('#datapicker').val(),
    };

    $.ajax({
        url: "/Home/GetDBGorki",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {

            $('#tab').html(result);
            $('#tabl').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });


}
//---------------------------------------------------------------

// Редактирование члена комиссии //

function KomissiyaEdit(ID) {
    $.ajax({
        url: "/Home/KomissiyaEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования члена комиссии //

function KomissiyaEditSave() {

    var isValid = true;

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'Nazn': $(Nazn).val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val(),

    };

    $.ajax({
        url: "/Home/KomissiyaEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
// Редактирование члена комиссии Гомель//

function KomissiyaEditGomel(ID) {
    $.ajax({
        url: "/Home/KomissiyaEditGomel/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования члена комиссии Гомель//

function KomissiyaEditGomelSave() {

    var isValid = true;

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'Nazn': $(Nazn).val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val(),

    };

    $.ajax({
        url: "/Home/KomissiyaEditGomelSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
// Редактирование члена комиссии Защебье//

function KomissiyaEditZasch(ID) {
    $.ajax({
        url: "/Home/KomissiyaEditZasch/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования члена комиссии Защебье//

function KomissiyaEditZaschSave() {

    var isValid = true;

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'Nazn': $(Nazn).val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val(),

    };

    $.ajax({
        url: "/Home/KomissiyaEditZaschSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
// Редактирование члена комиссии Кобрин//

function KomissiyaEditKobrin(ID) {
    $.ajax({
        url: "/Home/KomissiyaEditKobrin/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования члена комиссии Кобрин//

function KomissiyaEditKobrinSave() {

    var isValid = true;

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'Nazn': $(Nazn).val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val(),

    };

    $.ajax({
        url: "/Home/KomissiyaEditKobrinSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
// Редактирование члена комиссии Мозырь//

function KomissiyaEditMozyr(ID) {
    $.ajax({
        url: "/Home/KomissiyaEditMozyr/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования члена комиссии Мозырь//

function KomissiyaEditMozyrSave() {

    var isValid = true;

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'Nazn': $(Nazn).val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val(),

    };

    $.ajax({
        url: "/Home/KomissiyaEditMozyrSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
// Редактирование члена комиссии Новополоцк//

function KomissiyaEditNovop(ID) {
    $.ajax({
        url: "/Home/KomissiyaEditNovop/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования члена комиссии Новополоцк//

function KomissiyaEditNovopSave() {

    var isValid = true;

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'Nazn': $(Nazn).val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val(),

    };

    $.ajax({
        url: "/Home/KomissiyaEditNovopSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
// Редактирование члена комиссии Пинск//

function KomissiyaEditPinsk(ID) {
    $.ajax({
        url: "/Home/KomissiyaEditPinsk/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования члена комиссии Пинск//

function KomissiyaEditPinskSave() {

    var isValid = true;

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'Nazn': $(Nazn).val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val(),

    };

    $.ajax({
        url: "/Home/KomissiyaEditPinskSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
// Редактирование члена комиссии Туров//

function KomissiyaEditTurov(ID) {
    $.ajax({
        url: "/Home/KomissiyaEditTurov/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования члена комиссии Туров//

function KomissiyaEditTurovSave() {

    var isValid = true;

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'Nazn': $(Nazn).val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val(),

    };

    $.ajax({
        url: "/Home/KomissiyaEditTurovSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
// Редактирование члена комиссии Горки//

function KomissiyaEditGorki(ID) {
    $.ajax({
        url: "/Home/KomissiyaEditGorki/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования члена комиссии Горки//

function KomissiyaEditGorkiSave() {

    var isValid = true;

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'Nazn': $(Nazn).val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val(),

    };

    $.ajax({
        url: "/Home/KomissiyaEditGorkiSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}



//-------Добавление члена комиссии--------------//
function AddKomissiya() {
    $.ajax({
        url: "/Home/AddKomissiya/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления члена комиссии----------//
function KomissiyaSave() {

    var isValid = true;
    if ($('#komis').val() == "") {
        $('#komis').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#komis').css('border-color', 'lightgrey');
    }

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'location': $('#komis').val(),
        'Nazn': $('#Nazn').val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val()

    };

    $.ajax({
        url: "/Home/KomissiyaSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление члена комиссии Гомель--------------//
function AddKomissiyaGomel() {
    $.ajax({
        url: "/Home/AddKomissiyaGomel/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления члена комиссии Гомель----------//
function KomissiyaGomelSave() {

    var isValid = true;
    if ($('#komis').val() == "") {
        $('#komis').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#komis').css('border-color', 'lightgrey');
    }

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'location': $('#komis').val(),
        'Nazn': $('#Nazn').val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val()

    };

    $.ajax({
        url: "/Home/KomissiyaGomelSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление члена комиссии Защебье--------------//
function AddKomissiyaZasch() {
    $.ajax({
        url: "/Home/AddKomissiyaZasch/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления члена комиссии Защебье----------//
function KomissiyaZaschSave() {

    var isValid = true;
    if ($('#komis').val() == "") {
        $('#komis').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#komis').css('border-color', 'lightgrey');
    }

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'location': $('#komis').val(),
        'Nazn': $('#Nazn').val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val()

    };

    $.ajax({
        url: "/Home/KomissiyaZaschSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление члена комиссии Мозырь--------------//
function AddKomissiyaMozyr() {
    $.ajax({
        url: "/Home/AddKomissiyaMozyr/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления члена комиссии Мозырь----------//
function KomissiyaMozyrSave() {

    var isValid = true;
    if ($('#komis').val() == "") {
        $('#komis').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#komis').css('border-color', 'lightgrey');
    }

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'location': $('#komis').val(),
        'Nazn': $('#Nazn').val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val()

    };

    $.ajax({
        url: "/Home/KomissiyaMozyrSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление члена комиссии Туров--------------//
function AddKomissiyaTurov() {
    $.ajax({
        url: "/Home/AddKomissiyaTurov/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления члена комиссии Туров----------//
function KomissiyaTurovSave() {

    var isValid = true;
    if ($('#komis').val() == "") {
        $('#komis').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#komis').css('border-color', 'lightgrey');
    }

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'location': $('#komis').val(),
        'Nazn': $('#Nazn').val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val()

    };

    $.ajax({
        url: "/Home/KomissiyaTurovSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление члена комиссии Пинск--------------//
function AddKomissiyaPinsk() {
    $.ajax({
        url: "/Home/AddKomissiyaPinsk/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}

//-------Сохранение добавления члена комиссии Пинск----------//
function KomissiyaPinskSave() {

    var isValid = true;
    if ($('#komis').val() == "") {
        $('#komis').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#komis').css('border-color', 'lightgrey');
    }

    if ($('#Doljnost').val() == "") {
        $('#Doljnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Doljnost').css('border-color', 'lightgrey');
    }

    if ($('#FIO').val() == "") {
        $('#FIO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FIO').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'location': $('#komis').val(),
        'Nazn': $('#Nazn').val(),
        'Doljnost': $('#Doljnost').val(),
        'FIO': $('#FIO').val()

    };

    $.ajax({
        url: "/Home/KomissiyaPinskSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------------------------//
//-------Добавление члена комиссии Кобрин--------------//
function AddKomissiyaKobrin() {
    
        $.ajax({
            url: "/Home/AddKomissiyaKobrin/",
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalContent').html(result);
                $('#ServicesModal').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }

        })
    }

    //-------Сохранение добавления члена комиссии Кобрин----------//
    function KomissiyaKobrinSave() {

        var isValid = true;
        if ($('#komis').val() == "") {
            $('#komis').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#komis').css('border-color', 'lightgrey');
        }

        if ($('#Doljnost').val() == "") {
            $('#Doljnost').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Doljnost').css('border-color', 'lightgrey');
        }

        if ($('#FIO').val() == "") {
            $('#FIO').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#FIO').css('border-color', 'lightgrey');
        }


        if (isValid == false) {
            return false;
        }

        var data = {
            //'ID': ID,
            'location': $('#komis').val(),
            'Nazn': $('#Nazn').val(),
            'Doljnost': $('#Doljnost').val(),
            'FIO': $('#FIO').val()

        };

        $.ajax({
            url: "/Home/KomissiyaKobrinSave",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(data),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });

    }
    //--------------------------------//
    //-------Добавление члена комиссии Новополоцк--------------//
    function AddKomissiyaNovop() {
        $.ajax({
            url: "/Home/AddKomissiyaNovop/",
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalContent').html(result);
                $('#ServicesModal').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }

        })
    }

    //-------Сохранение добавления члена комиссии Новополоцк----------//
    function KomissiyaNovopSave() {

        var isValid = true;
        if ($('#komis').val() == "") {
            $('#komis').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#komis').css('border-color', 'lightgrey');
        }

        if ($('#Doljnost').val() == "") {
            $('#Doljnost').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Doljnost').css('border-color', 'lightgrey');
        }

        if ($('#FIO').val() == "") {
            $('#FIO').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#FIO').css('border-color', 'lightgrey');
        }


        if (isValid == false) {
            return false;
        }

        var data = {
            //'ID': ID,
            'location': $('#komis').val(),
            'Nazn': $('#Nazn').val(),
            'Doljnost': $('#Doljnost').val(),
            'FIO': $('#FIO').val()

        };

        $.ajax({
            url: "/Home/KomissiyaNovopSave",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(data),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });

    }
    //--------------------------------//
    //-------Добавление члена комиссии Горки--------------//
    function AddKomissiyaGorki() {
        $.ajax({
            url: "/Home/AddKomissiyaGorki/",
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalContent').html(result);
                $('#ServicesModal').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }

        })
    }

    //-------Сохранение добавления члена комиссии Горки----------//
    function KomissiyaGorkiSave() {

        var isValid = true;
        if ($('#komis').val() == "") {
            $('#komis').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#komis').css('border-color', 'lightgrey');
        }

        if ($('#Doljnost').val() == "") {
            $('#Doljnost').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Doljnost').css('border-color', 'lightgrey');
        }

        if ($('#FIO').val() == "") {
            $('#FIO').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#FIO').css('border-color', 'lightgrey');
        }


        if (isValid == false) {
            return false;
        }

        var data = {
            //'ID': ID,
            'location': $('#komis').val(),
            'Nazn': $('#Nazn').val(),
            'Doljnost': $('#Doljnost').val(),
            'FIO': $('#FIO').val()

        };

        $.ajax({
            url: "/Home/KomissiyaGorkiSave",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(data),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });

    }
    //--------------------------------//
    //--------------------------------//
    // Удаление члена//

    function DeletePodpis(ID) {
        $.ajax({
            url: "/Home/DeletePodpis/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
                $('#ServicesModalDelete').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //-----------------------------//
    //Подтверждение удаления члена //
    function DeletePodpisOK(ID) {


        $.ajax({
            url: "/Home/DeletePodpisOK/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    // Удаление члена Гомель//

    function DeletePodpisGomel(ID) {
        $.ajax({
            url: "/Home/DeletePodpisGomel/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
                $('#ServicesModalDelete').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //-----------------------------//
    //Подтверждение удаления члена Гомель//
    function DeletePodpisGomelOK(ID) {

        $.ajax({
            url: "/Home/DeletePodpisGomelOK/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    // Удаление члена Защебье//

    function DeletePodpisZasch(ID) {
        $.ajax({
            url: "/Home/DeletePodpisZasch/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
                $('#ServicesModalDelete').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //-----------------------------//
    //Подтверждение удаления члена Защебье//
    function DeletePodpisZaschOK(ID) {

        $.ajax({
            url: "/Home/DeletePodpisZaschOK/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    // Удаление члена Мозырь//

    function DeletePodpisMozyr(ID) {
        $.ajax({
            url: "/Home/DeletePodpisMozyr/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
                $('#ServicesModalDelete').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //-----------------------------//
    //Подтверждение удаления члена Мозырь//
    function DeletePodpisMozyrOK(ID) {

        $.ajax({
            url: "/Home/DeletePodpisMozyrOK/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    // Удаление члена Туров//

    function DeletePodpisTurov(ID) {
        $.ajax({
            url: "/Home/DeletePodpisTurov/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
                $('#ServicesModalDelete').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //-----------------------------//
    //Подтверждение удаления члена Туров//
    function DeletePodpisTurovOK(ID) {

        $.ajax({
            url: "/Home/DeletePodpisTurovOK/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    // Удаление члена Пинск//

    function DeletePodpisPinsk(ID) {
        $.ajax({
            url: "/Home/DeletePodpisPinsk/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
                $('#ServicesModalDelete').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //-----------------------------//
    //Подтверждение удаления члена Пинск//
    function DeletePodpisPinskOK(ID) {

        $.ajax({
            url: "/Home/DeletePodpisPinskOK/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    // Удаление члена Кобрин//

    function DeletePodpisKobrin(ID) {
        $.ajax({
            url: "/Home/DeletePodpisKobrin/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
                $('#ServicesModalDelete').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //-----------------------------//
    //Подтверждение удаления члена Кобрин//
    function DeletePodpisKobrinOK(ID) {

        $.ajax({
            url: "/Home/DeletePodpisKobrinOK/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    // Удаление члена Новополоцк//

    function DeletePodpisNovop(ID) {
        $.ajax({
            url: "/Home/DeletePodpisNovop/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
                $('#ServicesModalDelete').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //-----------------------------//
    //Подтверждение удаления члена Новополоцк//
    function DeletePodpisNovopOK(ID) {

        $.ajax({
            url: "/Home/DeletePodpisNovopOK/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    // Удаление члена Горки//

    function DeletePodpisGorki(ID) {
        $.ajax({
            url: "/Home/DeletePodpisGorki/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
                $('#ServicesModalDelete').modal('show');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //-----------------------------//
    //Подтверждение удаления члена Горки//
    function DeletePodpisGorkiOK(ID) {

        $.ajax({
            url: "/Home/DeletePodpisGorkiOK/" + ID,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(),
            dataType: "html",
            success: function (result) {
                $('#ServicesModalDeleteContent').html(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    //----------Отчет в PDF ------------------------------------------------
    function Report() {

        var isValid = true;
        if ($('#datapicker1').val() == "0") {
            $('#datapicker1').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#datapicker1').css('border-color', 'lightgrey');
        }

        if (isValid == false) {
            return false;
        }

        var stringhref = "Report?";

        stringhref += "dat=" + $('#datapicker1').val() + "&" + "location=" + $('#LocID_1').val(); /*+ "&" + "IDPodrPr=" + $('#pppp').val() + "&" + "IDPodrOtd=" + $('#otdel').val() + "&" + "IDPodrPodr=" + $('#gruppa').val() + "&" + "IDPodrUch=" + $('#uch').val();*/
        window.location = stringhref;
        //window.location = "/Home/ExportGroup/";
    }

//----------------------------------------------------------
// Редактирование Инвенторизации//

function InventoryEdit(ID) {
    $.ajax({
        url: "/Home/InventoryEdit/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
            $('#ServicesModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    })
}
//-------------------------//
// Сохранение редактирования члена комиссии Гомель//

function InventoryEditSave() {

    var isValid = true;

    if ($('#UserDC').val() == "") {
        $('#UserDC').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#UserDC').css('border-color', 'lightgrey');
    }

    if ($('#Urovenn').val() == "") {
        $('#Urovenn').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Urovenn').css('border-color', 'lightgrey');
    }

    if ($('#V20').val() == "") {
        $('#V20').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#V20').css('border-color', 'lightgrey');
    }

    if ($('#Temper').val() == "") {
        $('#Temper').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Temper').css('border-color', 'lightgrey');
    }

    if ($('#Vol').val() == "") {
        $('#Vol').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Vol').css('border-color', 'lightgrey');
    }

    if ($('#Plotnost').val() == "") {
        $('#Plotnost').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Plotnost').css('border-color', 'lightgrey');
    }

    if ($('#Massa').val() == "") {
        $('#Massa').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Massa').css('border-color', 'lightgrey');
    }

    if ($('#UrovH2O').val() == "") {
        $('#UrovH2O').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#UrovH2O').css('border-color', 'lightgrey');
    }

    if ($('#VH2O').val() == "") {
        $('#VH2O').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#VH2O').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {

        'ID': $('#ID').val(),
        'UserDC': $('#UserDC').val(),
        'Uroven': $('#Uroven').val(),
        'V20': $('#V20').val(),
        'Temper': $('#Temper').val(),
        'Vol': $('#Vol').val(),
        'Plotnost': $('#Plotnost').val(),
        'Massa': $('#Massa').val(),
        'UrovH2O': $('#UrovH2O').val(),
        'VH2O': $('#VH2O').val(),
    };

    $.ajax({
        url: "/Home/InventoryEditSave",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#ServicesModalContent').html(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//--------------Получение инвенторизации Гомеля в зависимости от даты----------------------------------------------

function GetInventoryGomel() {

    var isValid = true;
       
    if ($('#datapicker1').val() == "0") {
        $('#datapicker1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker1').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {
                
        'datapicker': $('#datapicker1').val(),
            };

    $.ajax({
        url: "/Home/GetInventoryGomel",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#invent').html(result);
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

//--------------Получение инвенторизации Защебье в зависимости от даты----------------------------------------------

function GetInventoryZasch() {

    var isValid = true;

    if ($('#datapicker1').val() == "0") {
        $('#datapicker1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker1').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {

        'datapicker': $('#datapicker1').val(),
    };

    $.ajax({
        url: "/Home/GetInventoryZasch",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#invent').html(result);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

//--------------Получение инвенторизации Мозыря в зависимости от даты----------------------------------------------

function GetInventoryMozyr() {

    var isValid = true;

    if ($('#datapicker1').val() == "0") {
        $('#datapicker1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker1').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {

        'datapicker': $('#datapicker1').val(),
    };

    $.ajax({
        url: "/Home/GetInventoryMozyr",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#invent').html(result);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

//--------------Получение инвенторизации Кобрина в зависимости от даты----------------------------------------------

function GetInventoryKobrin() {

    var isValid = true;

    if ($('#datapicker1').val() == "0") {
        $('#datapicker1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker1').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {

        'datapicker': $('#datapicker1').val(),
    };

    $.ajax({
        url: "/Home/GetInventoryKobrin",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#invent').html(result);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

//--------------Получение инвенторизации Турова в зависимости от даты----------------------------------------------

function GetInventoryTurov() {

    var isValid = true;

    if ($('#datapicker1').val() == "0") {
        $('#datapicker1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker1').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {

        'datapicker': $('#datapicker1').val(),
    };

    $.ajax({
        url: "/Home/GetInventoryTurov",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#invent').html(result);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

//--------------Получение инвенторизации Пинска в зависимости от даты----------------------------------------------

function GetInventoryPinsk() {

    var isValid = true;

    if ($('#datapicker1').val() == "0") {
        $('#datapicker1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker1').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {

        'datapicker': $('#datapicker1').val(),
    };

    $.ajax({
        url: "/Home/GetInventoryPinsk",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#invent').html(result);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

//--------------Получение инвенторизации Новополоцка в зависимости от даты----------------------------------------------

function GetInventoryNovop() {

    var isValid = true;

    if ($('#datapicker1').val() == "0") {
        $('#datapicker1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker1').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {

        'datapicker': $('#datapicker1').val(),
    };

    $.ajax({
        url: "/Home/GetInventoryNovop",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#invent').html(result);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

//--------------Получение инвенторизации Горки в зависимости от даты----------------------------------------------

function GetInventoryGorki() {

    var isValid = true;

    if ($('#datapicker1').val() == "0") {
        $('#datapicker1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datapicker1').css('border-color', 'lightgrey');
    }

    if (isValid == false) {
        return false;
    }

    var data = {

        'datapicker': $('#datapicker1').val(),
    };

    $.ajax({
        url: "/Home/GetInventoryGorki",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (result) {
            $('#invent').html(result);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
