$(document).ready(function () {
    $.ajax({
        type: "Get",
        url: "/Index/PopularPosts"
    }).done(function (res) {
        $("#PopularPosts").html(res);
    });
    $.ajax({
        type: "Get",
        url: "/Index/Categories"
    }).done(function (res) {
        $("#Categories").html(res);
    });
    $.ajax({
        type: "Get",
        url: "/Index/HeaderCategories"
    }).done(function (res) {
        $("#MainHeader").html(res);
    });

    $("#searchbtn").click(function (e) {
        $.ajax({
            type: "Get",
            data: "q=qtxt",
            url: "/search?q=${qtxt}"
        }).done(function (res) {
            $("#searchbody").html(res);
        });
    });
    $.ajax({
        type: "Get",
        url: "/Index/FooterCategories"
    }).done(function (res) {
        $("#FooterCategories").html(res);
    });
    $.ajax({
        type: "Get",
        url: "/Index/FooterPopularPosts"
    }).done(function (res) {
        $("#FooterPopularPosts").html(res);
    });
});
