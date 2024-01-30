$(document).ready(function () {
    $("#GetToDos").click(function () {
        $.ajax({
            url: 'https://localhost:7077/api/TodoItems',
            type: 'GET',
            success: function (data, status) {
                alert("$ajax - Data: " + data + "\nStatus: " + status);
            },
            error: function (xhr) {
                alert("Error: " + xhr.status + " " + xhr.statusText);
            }
        });
       
       
        $.get("https://localhost:7077/api/TodoItems", function (data, status) {
            alert("$get - data.Name " + data[0].name + "\nStatus: " + status);
        });
    });
    $("#PostToDos").click(function () {
        var todoItem = {
            "id": 0,
            "name": "ein Demo",
            "isComplete": false
        };

        $.ajax({
            type: "POST",
            url: "https://localhost:7077/api/TodoItems",
            contentType: "application/json",
            data: JSON.stringify(todoItem),
            success: function (response) {                
                console.log("Success: ", response);
            },
            error: function (error) {               
                console.error("Error: ", error);
            }
        });
        
    });
});