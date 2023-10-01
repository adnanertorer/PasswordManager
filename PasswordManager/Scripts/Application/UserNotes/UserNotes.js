$(document).ready(function () {
    getDataToApi(base_url + '/api/UserNotesAPI/?page=0&size=100').then((res) => {
        let response = res.DataObj;
    });

    all_notes = $("li a");
    all_notes.on("keyup", function () {
        note_title = $(this).find("h2").text();
        note_content = $(this).find("p").text();
        item_key = "list_" + $(this).parent().index();
        data = {
            title: note_title,
            content: note_content
        };
        window.localStorage.setItem(item_key, JSON.stringify(data));
    });
    all_notes.each(function (index) {
        data = JSON.parse(window.localStorage.getItem("list_" + index));
        if (data !== null) {
            note_title = data.title;
            note_content = data.content;
            $(this).find("h2").text(note_title);
            $(this).find("p").text(note_content);
        }
    });
});

function getNotes(page, size) {
    getDataToApi(base_url + '/api/UserNotesAPI/?page=' + page + '&size=' + size).then((res) => {
    });
}

function openEditNoteModal(id) {
    getDataToApi(base_url + '/api/UserNotesAPI/' + id).then((res) => {
        let response = res.DataObj;
        $("#editNoteModal").modal('show');
        $("#editTitle").val(response.NoteTitle);
        $("#editNoteText").val(response.NoteText);
        $("#editId").val(id);
    });

}


function openNoteModal() {
    $("#addNoteModal").modal('show');
}

function addNote() {
    var status = checkValuesInputsFromModal('addNoteModal');
    if (status) {
        let noteTitle = $('#title').val();
        let noteText = $('#noteText').val();
        let noteData = {
            noteTitle: noteTitle,
            noteText: noteText,
        };
        postDataToApi(base_url + '/api/UserNotesAPI', noteData).then((res) => {

            if (res.Status == false) {
                alert(res.Message);
            } else {
                closeModal('addNoteModal');
                window.location.href = base_url + "/UserNotes";
            }
           
        });
    } else {
        alert('Lütfen tüm bilgileri giriniz');
    }
}

function updateNote() {
    var status = checkValuesInputsFromModal('editNoteModal');
    if (status) {
        let noteTitle = $('#editTitle').val();
        let noteText = $('#editNoteText').val();
        let noteId = parseInt($('#editId').val());
        let noteData = {
            noteTitle: noteTitle,
            noteText: noteText,
            id: noteId
        };
        putDataToApi(base_url + '/api/UserNotesAPI', noteData).then((res) => {
            if (res.Status == false) {
                alert(res.Message);
            } else {
                closeModal('editNoteModal');
                window.location.href = base_url + "/UserNotes";
            }

        });
    } else {
        alert('Lütfen tüm bilgileri giriniz');
    }
}

function getDeleteById(id) {
    getDataToApi(base_url + '/api/UserNotesAPI/' + id).then((res) => {
        let response = res.DataObj;
        if (confirm("Bu not kalıcı olarak silinecektir, devam etmek istiyor musunuz?")) {
            deleteDataToApi(base_url + '/api/UserNotesAPI', response).then((res) => {
                if (res.Status == false) {
                    alert(res.Message);
                } else {
                    closeModal('editNoteModal');
                    window.location.href = base_url + "/UserNotes";
                }
            });
        }
    })
}