
$(document).ready(function () {
    getlist();
})

var saveLecture = function () {
    var message = "";
    $formData = new FormData();

    debugger
    var Photo1 = document.getElementById('LecturePhoto1');;
    if (Photo1.files.length > 0) {
        for (var i = 0; i < Photo1.files.length; i++) {
            $formData.append('file-' + i, Photo1.files[i]);
        }
    }

    var Photo2 = document.getElementById('LecturePhoto2');;
    if (Photo2.files.length > 0) {
        for (var i = 0; i < Photo2.files.length; i++) {
            $formData.append('file-' + i, Photo2.files[i]);
        }
    }

    var lectureDate = $("#TxtLectureDate").val();
    var timeSlot = $("#TxtTimeSlot").val();
    var topic = $("#TxtTopic").val();
    var details = $("#TxtDetails").val();
    var lectureById = $("#TxtLectureById").val();
    var notesDocument = $("#TxtNotesDocument").val();
    var testDocument = $("#TxtTestDocument").val();
    var isActive = $("#TxtIsActive").val();

    $formData.append('LectureDate', lectureDate);
    $formData.append('TimeSlot', timeSlot);
    $formData.append('Topic', topic);
    $formData.append('Details', details);
    $formData.append('LectureById', lectureById);
    $formData.append('NotesDocument', notesDocument);
    $formData.append('TestDocument', testDocument);
    $formData.append('IsActive', isActive);


      $.ajax({
        url: "/Lecture/SaveLecture",
        method: "post",
        data: $formData,
        //data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        //datatype: "json",
        contentType: false,
        processData: false,
        success: function (response) {
            alert("Successfull");

        }
    });
}

var getlist = function () {
    {
        $.ajax({
            url: "/Lecture/GetLectureList",
            method: "post",
            contentType: "application/json;charset=utf-8",
            async: false,
            dataType: "json",
            success: function (response) {
                var html = "";
                $.each(response.model, function (index, elementValue) {
                    html += "<tr><td>" + elementValue.LectureId +
                        "</td><td>" + elementValue.LectureDate +
                        "</td><td>" + elementValue.TimeSlot +
                        "</td><td>" + elementValue.Topic +
                        "</td><td>" + elementValue.Details +
                        "</td><td>" + elementValue.LectureById +
                        "</td><td> <img src ='/Content/img/" + elementValue.Photo + "'height = '100px',width = '100px'/> " +
                        "</td><td> <img src ='/Content/img/" + elementValue.Photo + "'height = '100px',width = '100px'/> " +
                        "</td><td>" + elementValue.NotesDocument +
                        "</td><td>" + elementValue.TestDocument +
                        "</td><td>" + elementValue.IsActive +
                        "</td></tr>"
                });
                $("#tblLecture tbody").append(html);
            }
        });
    }
};