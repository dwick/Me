/* Author: 
    David Wick
*/

$(function () {
    $(".social").bind("webkitAnimationEnd mozAnimationEnd animationEnd", function() {
        $(this).removeClass("animated");
    }).bind('mouseenter', function() {
        $(this).addClass("animated");
    });
});







