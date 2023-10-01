var table;
var selectedCategory;
$(document).ready(function () {
    getDataToApi(base_url + '/api/CategoryAPI/?page=0&size=10').then((res) => {
        jQuery.fn.dataTableExt.pager.numbers_length = res.DataObj.Count;
        table = new DataTable('#categoryTable', {
            data: res.DataObj.Items,
            pagingType: 'simple',
            paging: true,
            pageLength: 10,
            language: {
                paginate: mainPaginate(res.DataObj),
                info: mainPaginateInfo(res.DataObj),
            },
            columns: [
                { data: 'CategoryName' },
                {
                    data: 'CreatedAt',
                    render: function (data, type, row, meta) {
                        var dateStr = '<p>' + new Date(data).toLocaleString() + '</p>';
                        return dateStr;
                    }
                },
                {
                    data: 'Id',
                    render: function (data, type, row, meta) {
                        var buffer = '<a onclick="getById(' + data + ')" class="btn btn-sm btn-primary js-action">Edit</a>&nbsp;';
                        buffer += '<a onclick="getDeleteById(' + data + ')" class="btn btn-sm btn-danger js-action">Delete</a>';
                        return buffer;
                    }
                }
            ],
            processing: true
        });
    });
});

function getLisWithDataTable(page, size) {
    getDataToApi(base_url + '/api/CategoryAPI/?page=' + page + '&size=' + size).then((res) => {
        table.destroy();
        table = new DataTable('#categoryTable', {
            data: res.DataObj.Items,
            pagingType: 'simple',
            language: {
                paginate: mainPaginate(res.DataObj),
                info: mainPaginateInfo(res.DataObj),
            },
            columns: [
                { data: 'CategoryName' },
                { data: 'CreatedAt' },
                {
                    data: 'Id',
                    render: function (data, type, row, meta) {
                        var buffer = '<a onclick="getById(' + data + ')" class="btn btn-sm btn-primary js-action">Edit</a>&nbsp;';
                        buffer += '<a onclick="getDeleteById(' + data + ')" class="btn btn-sm btn-danger js-action">Delete</a>';
                        return buffer;
                    }
                }
            ],
            processing: true
        });

    });
}

function getById(id) {
    getDataToApi(base_url + '/api/CategoryAPI/' + id).then((res) => {
        let response = res.DataObj;
        selectedCategory = response;
        $("#editModal").modal('show');
        $("#categoryId").val(response.Id);
        $("#categoryName").val(response.CategoryName);
    })
}

function add() {
    let category_name = $("#addCategoryName").val();
    if (category_name.toString().trim().lenght == 0) {
        alert('Lütfen kategori bilgisini yazınız.');
    } else {
        let category = {
            categoryName: category_name,
        }
        postDataToApi(base_url + '/api/CategoryAPI', category).then((res) => {
            $("#addCategoryName").val('');
            closeModal('addModal');
            getLisWithDataTable(0, 10);
        });
    }
}

function getDeleteById(id) {
    getDataToApi(base_url + '/api/CategoryAPI/' + id).then((res) => {
        let response = res.DataObj;
        selectedCategory = response;
        if (confirm("Bu kategoriyi kalıcı olarak silinecektir, devam etmek istiyor musunuz?")) {
            deleteDataToApi('https://localhost:44326/api/CategoryAPI', selectedCategory).then((res) => {
                getLisWithDataTable(0, 10);
            });
        }
    })
}
function update() {
    let category_name = $("#categoryName").val();
    let category_id = $("#categoryId").val();
    if (category_name.toString().trim().lenght == 0) {
        alert('Lütfen kategori bilgisini yazınız.');
    } else {
        let category = {
            categoryName: category_name,
            id: category_id,
            createdAt: selectedCategory.CreatedAt
        }
        putDataToApi(base_url + '/api/CategoryAPI', category).then((res) => {
            closeModal('editModal');
            getLisWithDataTable(0, 10);
        });
    }
}
