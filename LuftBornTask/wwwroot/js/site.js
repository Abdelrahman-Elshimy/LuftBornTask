
$(document).ready(function () {
    if (document.getElementById("name").value == "" || document.getElementById("name").value == undefined) {
        document.getElementById("save").setAttribute("disabled", "disbaled");
    }
    GetAllAuthors();
});
function CreateOrUpdate() {
    var name = document.getElementById("name").value;
    var authorId = document.getElementById("authorId").value;
    var error = document.getElementById("error");
    if (name == "" || name == undefined) {
        error.innerHTML = "Name field is required";
    }
    else {
        error.innerHTML = "";
    }
    var id = 0;
    if (authorId != "")
        id = +authorId;

    $.ajax({
        type: "GET",
        url: "/Home/CreateOrEdit",
        data: { "name": name, "id": id },
        success: function (response) {
            document.getElementById("name").value = "";
            document.getElementById("authorId").value = "";
            console.log(response)
            alert(response.message)
        },
        failure: function (response) {
            alert(response);
        },
        error: function (response) {
            alert(response);
        }
    });
    document.getElementById("name").value = "";
    document.getElementById("authorId").value = "";


}
function ChangeAuthorId(id, name) {
    document.getElementById("name").value = name;
    document.getElementById("authorId").value = id;
    console.log(name)
}
function CheckDisabled() {
    console.log(document.getElementById("name").value)
    if (document.getElementById("name").value == undefined || document.getElementById("name").value == "") {
        document.getElementById("save").setAttribute("disabled", "disbaled");
    }
    else {
        document.getElementById("save").removeAttribute("disabled");
    }
}
function EmptyInputs() {
    document.getElementById("name").value = "";
    document.getElementById("authorId").value = "";
}

function Delete(id) {
    $.ajax({
        type: "GET",
        url: "/Home/Delete",
        data: { "id": id },
        success: function (response) {
            alert("Delete Successfully");
        },
        failure: function (response) {
            alert(response);
        },
        error: function (response) {
            alert(response);
        }
    });
}
function GetAllAuthors() {
    $.ajax({
        type: "GET",
        url: "/Home/GetAllAuthors",
        data: { },
        success: function (response) {
            console.log(response)
        },
        failure: function (response) {
            alert(response);
        },
        error: function (response) {
            alert(response);
        }
    });
}