$(document).ready(function () {
    $(".bg").interactive_bg();
    $("#btns").interactive_bg({
        strength: 10,
        scale: 1.15,
        contain: false,
        wrapContent: true
    });
});

$(window).resize(function () {
    $(".wrapper > .ibg-bg").css({
        width: $(window).outerWidth(),
        height: $(window).outerHeight()
    })
})
var x = "ggg";
