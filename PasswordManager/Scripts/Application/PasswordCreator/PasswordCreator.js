let sliderData = {
    minLength: 6,
    numeric: true,
    upperCase: true,
    lowerCase: true,
    specialChars: true
};

$(document).ready(function () {
    $("#passwordLen").val(sliderData.minLength);
    $('#sliderInput').slider({
        range: "min",
        value: sliderData.minLength,
        step: 1,
        min: 0,
        max: 99,
        animate: true,
        slide: function (event, ui) {
            $("#passwordLen").val(ui.value);
            sliderData.minLength = parseInt(ui.value);
            createPasswordRequest(sliderData);
        }
    });
    $("#passwordLen").change(function () {
        $('#sliderInput').slider("value", parseInt(this.value));
    });
    $(":checkbox").on('click', function () {
        let id = $(this).attr('id');
        var isChecked = $('#' + id).is(":checked");
        if (id === "upperCaseCheck") {
            sliderData.upperCase = isChecked;
        }
        if (id === "lowerCaseCheck") {
            sliderData.lowerCase = isChecked;
        }
        if (id === "numericCheck") {
            sliderData.numeric = isChecked;
        }
        if (id === "specialCheck") {
            sliderData.specialChars = isChecked;
        }
        createPasswordRequest(sliderData);
    });
});

function copyText(elementId) {
    var element = document.getElementById(elementId);
    element.select();
    element.setSelectionRange(0, 99999);
    navigator.clipboard.writeText(element.value);
    openSnackbar('Parola kopyalandı');
}

function openPasswordModal() {
    $('#createPasswordModal').modal('show');
    $("#passwordLen").val(sliderData.minLength);
    createPasswordRequest(sliderData);
}

function createPasswordRequest(data) {
    postDataToApi(base_url + '/api/PasswordGenerator', data).then((res) => {
        $("#currentPassword").val(res);
    });
}