$(document).ready(function () {
    getDataToApi(base_url + '/api/CategoryAPI/?page=0&size=100').then((res) => {
        let response = res.DataObj;
        $("#SelectedCategory").empty();
        addSearchCategoryOptionsToSelect(response.Items);
    });
});

function getListAccount(page, size) {
    getDataToApi(base_url + '/api/UserAccountAPI/?page=' + page + '&size=' + size).then((res) => {
    });
}

function openAddAccountModal(){
    if (document.getElementById("categoryId") !== undefined) {
        getDataToApi(base_url + '/api/CategoryAPI/?page=0&size=100').then((res) => {
            let response = res.DataObj;
            $("#categoryId").empty();
            addCategoryOptionsToSelect(response.Items);
        });
    }
}

function addCategoryOptionsToSelect(data) {
    var opt = document.createElement('option');
    opt.value = "0";
    opt.innerHTML = "Seçiniz";
    document.getElementById("categoryId").appendChild(opt);
    for (var i = 0; i < data.length; i++) {
        var opt = document.createElement('option');
        opt.value = data[i].Id;
        opt.innerHTML = data[i].CategoryName;
        document.getElementById("categoryId").appendChild(opt);
    }
    $("#addPasswordModal").modal('show');
}

function addSearchCategoryOptionsToSelect(data) {
    var opt = document.createElement('option');
    opt.value = "0";
    opt.innerHTML = "Seçiniz";
    document.getElementById("SelectedCategory").appendChild(opt);
    for (var i = 0; i < data.length; i++) {
        var opt = document.createElement('option');
        opt.value = data[i].Id;
        opt.innerHTML = data[i].CategoryName;
        document.getElementById("SelectedCategory").appendChild(opt);
    }
}

function addCategoryOptionsToEditSelect(data) {
    var opt = document.createElement('option');
    opt.value = "0";
    opt.innerHTML = "Seçiniz";
    document.getElementById("editCategoryId").appendChild(opt);
    for (var i = 0; i < data.length; i++) {
        var opt = document.createElement('option');
        opt.value = data[i].Id;
        opt.innerHTML = data[i].CategoryName;
        document.getElementById("editCategoryId").appendChild(opt);
    }
}

function addCategory() {
    let category_name = $("#categoryName").val();
    if (category_name.toString().trim().lenght == 0) {
        alert('Lütfen kategori bilgisini yazınız.');
    } else {
        let category = {
            categoryName: category_name,
        }
        postDataToApi(base_url + '/api/CategoryAPI', category).then((res) => {
            $("#categoryName").val('');
            getDataToApi(base_url + '/api/CategoryAPI/?page=0&size=100').then((res) => {
                let response = res.DataObj;
                $("#categoryId").empty();
                addCategoryOptionsToSelect(response.Items);
                closeModal('addCategoryModal');
            });
        });
    }
}

function openCategoryModal() {
    $("#addCategoryModal").modal('show');
}

function openEditAccountModal(id) {
    getDataToApi(base_url + '/api/UserAccountAPI/' + id).then((res) => {
        let data = res.DataObj;
        $('#editAccountTitle').val(data.AccountTitle);
        $('#editAccountUrl').val(data.AccountUrl);
        $('#editUserName').val(data.Username);
        $('#editPassword').val(data.Password);
        $('#editAccountId').val(data.Id);
        getDataToApi(base_url + '/api/CategoryAPI/?page=0&size=100').then((res) => {
            let response = res.DataObj;
            $("#editCategoryId").empty();
            addCategoryOptionsToEditSelect(response.Items);
            $("#editCategoryId").val(data.CategoryId).trigger("change");
        });
        $("#editPasswordModal").modal('show');
    });
    
}

function addAccount() {
    var status = checkValuesInputsFromModal('addPasswordModal');
    if (status) {
        let accountTitle = $('#accountTitle').val();
        let categoryId = parseInt($('#categoryId').val());
        let accountUrl = $('#accountUrl').val();
        let userName = $('#userName').val();
        let password = $('#password').val();
        let accountData = {
            accountTitle: accountTitle,
            categoryId: categoryId,
            accountUrl: accountUrl,
            userName: userName,
            password: password
        };
        postDataToApi(base_url + '/api/UserAccountAPI', accountData).then((res) => {
            if (res.Status == false) {
                alert(res.Message);
            } else {
                closeModal('addPasswordModal');
                window.location.href = base_url + "/MyPasswords";
            }
        });
    } else {
        alert('Lütfen tüm bilgileri giriniz');
    } 
}

function updateAccount() {
    var status = checkValuesInputsFromModal('editPasswordModal');
    if (status) {
        let accountTitle = $('#editAccountTitle').val();
        let categoryId = parseInt($('#editCategoryId').val());
        let accountUrl = $('#editAccountUrl').val();
        let userName = $('#editUserName').val();
        let password = $('#editPassword').val();
        let id = $('#editAccountId').val();
        let accountData = {
            accountTitle: accountTitle,
            categoryId: categoryId,
            accountUrl: accountUrl,
            userName: userName,
            password: password,
            id: id
        };
        putDataToApi(base_url + '/api/UserAccountAPI', accountData).then((res) => {
            if (res.Status == false) {
                alert(res.Message);
            } else {
                closeModal('editPasswordModal');
                window.location.href = base_url + "/MyPasswords";
            }
            
        });
    } else {
        alert('Lütfen tüm bilgileri giriniz');
    }
}

function getDeleteById(id) {
    getDataToApi(base_url + '/api/UserAccountAPI/' + id).then((res) => {
        let response = res.DataObj;
        if (confirm("Bu hesap kalıcı olarak silinecektir, devam etmek istiyor musunuz?")) {
            deleteDataToApi(base_url + '/api/UserAccountAPI', response).then((res) => {
                if (res.Status == false) {
                    alert(res.Message);
                } else {
                    window.location.href = base_url + "/MyPasswords";
                }
            });
        }
    })
}