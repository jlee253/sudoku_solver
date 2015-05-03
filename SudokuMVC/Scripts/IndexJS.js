$(document).ready(function () {
    $("#testButton").click(function (event) {
        event.preventDefault();
        
        $.get("http://localhost:52403/api/test/", "", function (data) {
            $("#api_test").html(data);
        });
    });

    $("#dropdownDifficulty").on("show.bs.dropdown", function(e) {
        var linkText = $(e.relatedTarget).text();
        alert(linkText);
    }
});