$(function () {
    $("#CityId").change(function () {
        $.ajax({
            url: "/townships/gettownshipsbycityid",//controller
            data: { cityId: $("#CityId").val() },//url
            type: "get",//method
            contextType: "application/json",
            success: function (data)// return back datatype
            {
                console.log(data);
                $("#TownshipId").empty();
                $("#TownshipId").append("<option value>---select a township----")
                for (var i = 0; i < data.length; i++) {
                    var item = data[i];
                    $("#TownshipId").append("<option value=" + item.Id + ">" + item.TownshipName + "</option>");
                }
            }
        });
    });
});