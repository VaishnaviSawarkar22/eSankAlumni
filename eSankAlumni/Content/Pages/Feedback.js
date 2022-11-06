$(document).ready(function () {
    getlist();
})

var saveFeedback = function () {
    
    var StudentName = $("#txtStudentName").val();
    var eSankalpId = $("#txteSankalpId").val();
    var LectureId = $("#txtLectureId").val();
    var QueId = $("#txtQueId").val();
    var Rating = $("#txtRating").val();
    var FeedbackDate = $("#txtDString").val();
   

    var model = { StudentName: StudentName, eSankalpId: eSankalpId, LectureId: LectureId, QueId: QueId, Rating: Rating, FeedbackDate: FeedbackDate };


    $.ajax({
        url: "/Feedback/SaveFeedback",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (response) {
            alert("Successfull");
        }
    });
}


var getlist = function () {
    
        $.ajax({
            url: "/Feedback/GetFeedbackList",
            method: "post",
            contentType: "application/json;charset=utf-8",
            async: false,
            dataType: "json",
            success: function (response) {
                var html = "";
                $.each(response.model, function (index, elementValue) {
                    html += "<tr><td>" + elementValue.FeedbackId +
                        "</td><td>" + elementValue.StudentName +
                        "</td><td>" + elementValue.eSankalpId +
                        "</td><td>" + elementValue.LectureId +
                        "</td><td>" + elementValue.QueId +
                        "</td><td>" + elementValue.Rating +
                        "</td><td>" + elementValue.FeedbackDate + "</td></tr>"
                });
                $("#tblFeedback tbody").append(html);
            }
        });
    
}