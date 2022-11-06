$(document).ready(function () {
    getlist();
})
var saveFeedbackQuest = function () {
    var question = $("#TxtQuestion").val();
    var model = {
        Question: question,
    };
    $.ajax({
        url: "/FeedbackQuest/SaveFeedbackQuest",
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
        url: "/FeedbackQuest/GetFeedbackQuest",
        method: "post",
        contentType: "application/json;charset=utf-8",
        async: false,
        dataType: "json",
        success: function (response) {
            var html = "";
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Que +
                    "</td><td>" + elementValue.Question + "</td></tr"
            });
            $("#tblFeedbackQuest tbody").append(html);
        }
    });

};
