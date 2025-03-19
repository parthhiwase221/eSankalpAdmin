$(document).ready(function () {
    
    getlist();
   
});


var SaveRegistration = function () {
    var RegId = $("#hdnRegId").val();
        var Name = $("#txtName").val();
        var MobileNo = $("#txtMobileNo").val();
        var Email = $("#txtEmail").val();
        var Education = $("#txtEducation").val();
        var Percentage = $("#txtPercentage").val();
        var Service = $("#txtService").val();
        var Technology = $("#txtTechnology").val();
        var Office = $("#txtOffice").val();
        var College = $("#txtCollege").val();
        var Address = $("#txtAddress").val();
    var model =
    {
       
                RegId: RegId,
                Name: Name,
                MobileNo: MobileNo,
                Email: Email,
                Education: Education,
                Percentage: Percentage,
                Service: Service,
                Technology: Technology,
                Office: Office,
                College: College,
                Address: Address,

    };

    $.ajax({
        url: "/Registration/SaveRegistration",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            getlist();
           
            alert(response.Message);
        }

    });
};


var getlist = function () {
    debugger;
    $.ajax({
        url: "/Registration/GetReglist",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#Reg tbody").empty();
            var html = "";
            $.each(response.model, function (Index, elementValue) {
                html += "<tr><td>" + elementValue.RegId + "</td><td>" + elementValue.Name + "</td><td>" + elementValue.MobileNo + "</td><td>" + elementValue.Email + "</td><td>" +
                    elementValue.Education + "</td><td>" +
                    elementValue.Percentage + "</td><td>" +
                    elementValue.Service + "</td><td>" +
                    elementValue.Technology + "</td><td>" +
                    elementValue.Office + "</td><td>" +
                    elementValue.College + "</td><td>" +
                    elementValue.Address + "</td><td><input type='button' value='Delete' onClick='deleteRegistration(" + elementValue.RegId + ")' /> <input type='button' value='Edit' onClick='Getdetails(" + elementValue.RegId + ")' />  </td></tr>";

            })
            $("#Reg tbody").append(html);

        }

    });

}

var deleteRegistration = function (RegId) {
    debugger
    $.ajax({
        url: "/Registration/deletereg",
        method: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ ID: RegId }),
        success: function (response) {
            if (response.model) {
                alert(response.model);
            } else if (response.ex) {
                alert("Error: " + response.ex);
            }
            getlist();
        },
        error: function (xhr, status, error) {
            alert("An error occurred: " + error);
        }
    });
}



var Getdetails = function (RegId) {
    var model = { RegId: RegId }
    debugger
    $.ajax({
        url: "/Registration/Getdetails",
        method: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(model),
        success: function (response) {

            $("#GetdetailsModal").modal('show');

            $("#hdnRegId").val(response.model.RegId);
            $("#txtName").val(response.model.Name);
            $("#txtMobileNo").val(response.model.MobileNo);
            $("#txtEmail").val(response.model.Email);
            $("#txtEducation").val(response.model.Education);
            $("#txtPercentage").val(response.model.Percentage);
            $("#txtService").val(response.model.Service);
            $("#txtTechnology").val(response.model.Technology);
            $("#txtOffice").val(response.model.Office);
            $("#txtCollege").val(response.model.College);
            $("#txtAddress").val(response.model.Address);


        },
        error: function (xhr, status, error)  {
            alert("An error occurred: " + error);
        }

    });
}

//var GetNextPage = function (RegId) {
//    window.location.href = "/Registration/detailIndex?RegID" + RegId;

//}

