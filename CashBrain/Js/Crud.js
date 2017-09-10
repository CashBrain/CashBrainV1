function Add() {
   
    var empObj = {
        Question: $('#Text1').val(),
        Choice1: $('#Text1').val(),
        Choice2: $('#Text1').val(),
        Choice3: $('#Text1').val(),
        Choice4: $('#Text1').val(),
        CorrectAnswers: $('#Text1').val()
    };
    $.ajax({
        url: "/Admin/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("record Added Successfully");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}