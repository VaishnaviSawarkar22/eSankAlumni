$(document).ready(function () {
    GetAlumniRegList();
})

var SaveAlumniReg = function () {
    var message = "";
    $formData = new FormData();
    
    var Photo = document.getElementById('File1');;
    if (Photo.files.length > 0) {
        for (var i = 0; i < Photo.files.length; i++) {
            $formData.append('file-' + i, Photo.files[i]);
        }
    }

    var alumniName = $("#txtAlumniName").val();
    var eSankalpId = $("#txtESankalpId").val();
    var passoutYr = $("#txtPassoutYr").val();
    var dob = $("#txtDOB").val();
    var totalExp = $("#txtTotalExp").val();
    var currentcompany = $("#txtCurrentCompany").val();
    var ctc = $("#txtCTC").val();
    var photo = $("#File1").val();
    var city = $("#ddlCity").val();
    var address = $("#txtAddress").val();
    var collegename = $("#txCollegeName").val();
    var education = $("#txtEducation").val();
    var isactive = $("#txtIsActive").val();

    $formData.append('AlumniName', alumniName);
    $formData.append('eSankalpId', eSankalpId);
    $formData.append('PassoutYr', passoutYr);
    $formData.append('DOB', dob);
    $formData.append('TotalExp', totalExp);
    $formData.append('CurrentCompany', currentcompany);
    $formData.append('CTC', ctc);
    $formData.append('Photo', photo);
    $formData.append('City', city);
    $formData.append('Address', address);
    $formData.append('CollegeName', collegename);
    $formData.append('Education', education);
    $formData.append('IsActive', isactive);

    $.ajax({
        url: "/AlumniReg/SaveAlumniReg",
        method: "post",
        data: $formData,
        contentType: "application/json;charset=utf-8",
        contentType: false,
        processData: false,
        success: function (response) {
            alert("succesfull");

        }
    });
};

var GetAlumniRegList = function () {
    $.ajax({
        url: "/AlumniReg/GetAlumniReg",
        method: "post",
        //data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tbl_AlumniReg tbody").empty();

            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.AlumniId +
                    "</td><td>" + elementValue.AlumniName +
                    "</td><td>" + elementValue.eSankalpId +
                    "</td><td>" + elementValue.PassoutYr +
                    "</td><td>" + elementValue.DOB +
                    "</td><td>" + elementValue.TotalExp +
                    "</td><td>" + elementValue.CurrentCompany +
                    "</td><td>" + elementValue.CTC +
                    "</td><td> <img src ='/Content/img/" + elementValue.Photo + "'height = '100px',width = '100px'/> "+
                "</td><td>" + elementValue.City +
                    "</td>><td>" + elementValue.Address +
                    "</td><td>" + elementValue.CollegeName +
                    "</td><td>" + elementValue.Education +
                    "</td><td>" + elementValue.IsActive +
                    "</td></tr>";
            });
            $("#tbl_AlumniReg tbody").append(html);
        }
    })
}

