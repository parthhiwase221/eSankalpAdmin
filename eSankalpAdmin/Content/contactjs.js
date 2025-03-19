$(document).ready(function () {

    getlist();
});



var getlist = function () {
    debugger;
    $.ajax({
        url: "/Home/GetContactlist",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#Reg tbody").empty();
            var html = "";
            $.each(response.model, function (Index, elementValue) {
                html += "<tr><td>" + elementValue.Id + "</td><td>" + elementValue.fullname + "</td><td>" + elementValue.email + "</td><td>" + elementValue.mob + "</td><td>" +
                    elementValue.msg + "</td><td><input type='button' value='Delete' onClick='deleteRegistration(" + elementValue.ID + ")' />  </td></tr>";

            })
            $("#Reg tbody").append(html);

        }

    });

}

var deleteContact = function (Id) {
    debugger
    var model = { Id: ID };
    $.ajax({
        url: "/Contact/deletereg",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
            getlist();
        }
    });
}
