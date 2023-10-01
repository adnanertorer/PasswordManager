
async function postDataToApi(url = '', data = {}) {

    const response = await fetch(url, {
        method: "POST",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
            "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
        body: JSON.stringify(data),
    });
    return response.json();

}

async function getDataToApi(url = '') {

    const response = await fetch(url, {
        method: "GET",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
            "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
    });
    return response.json();

}

async function putDataToApi(url = '', data = {}) {

    const response = await fetch(url, {
        method: "PUT",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
            "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
        body: JSON.stringify(data),
    });
    return response.json();

}

async function deleteDataToApi(url = '', data = {}) {

    const response = await fetch(url, {
        method: "DELETE",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
            "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
        body: JSON.stringify(data),
    });
    return response.json();

}

var base_url = window.location.origin;

function mainPaginate(data) {
    return {
        next: data.HasNext ? '<a onclick="getLisWithDataTable(' + (data.Index + 1) + ',10)">Sonraki</a>' : '',
        previous: data.HasPrevious ? '<a onclick="getLisWithDataTable(' + (data.Index - 1) + ',10)">Önceki</a>' : ''
    }
}

function mainPaginateInfo(data) {
    return "Toplam " + data.Count + " kayıttan " + data.Size + " kayıt gösteriliyor";
}

function closeModal(modalId) {
    $("#" + modalId).modal('hide');
}

function openModal(modalId) {
    $("#" + modalId).modal('show');
}


function openSnackbar(message) {
    var x = document.getElementById("snackbar");
    x.innerHTML = message;
    x.className = "show";
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
}


function checkValuesInputsFromModal(modalId) {
    let status = true;
    $(`#${modalId} :input`).each(function (element) {
        if ($(this).is(':text') || $(this).is('textarea') || $(this).is(':password')) {
            console.log($(this));
            if ($(this).val().toString().trim().length == 0) {
                status = false;
            }
        }
    });
    return status;
}

function showHidePassword(elementId) {
    var passInput = $('#' + elementId);
    if (passInput.attr('type') === 'password') {
        passInput.attr('type', 'text');
    } else {
        passInput.attr('type', 'password');
    }
}






