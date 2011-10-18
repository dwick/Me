/* Author: 
    David Wick
*/

$(function () {
    $(".social").bind("webkitAnimationEnd mozAnimationEnd animationEnd", function () {
        $(this).removeClass("animated");
    }).bind('mouseenter', function () {
        $(this).addClass("animated");
    });
    $(window).bind('load resize', function () {
        var $height = $(document).height(),
            $helpers = $('#grid-helper .col');
        
        $helpers.css({ 'min-height': $height });
        if (Modernizr.mq('only screen and (max-width: 767px)')) {
            $helpers.not(':first-child').hide();
        } else {
            $helpers.show();
        }
    });
    $('#grid-toggle').click(function () {
        var $grid = $('#grid-helper');

        $grid.toggle();
        $(this).text($grid.is(':visible') ? 'Hide grid' : 'Show grid');
    });
});







