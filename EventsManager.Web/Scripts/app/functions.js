jQuery(document).ready(function ($) {

    $('a[href*="#"]:not([href="#"])').click(function (e) {
        const target = $(e.target.hash);

        if (target.length) {
            $('html, body').animate({
                scrollTop: target.offset().top
            }, 1000);

            return false;
        }
    });
    $(window).scroll(function () {
        if ($(window).scrollTop() > 56) {
            $(".navbar").addClass("bg-primary");
        } else {
            $(".navbar").removeClass("bg-primary");
        }
    });
    // If Mobile, add background color when toggler is clicked
    $(".navbar-toggler").click(function () {
        if (!$(".navbar-collapse").hasClass("show")) {
            $(".navbar").addClass("bg-primary");
        } else {
            if ($(window).scrollTop() < 56) {
                $(".navbar").removeClass("bg-primary");
            } else {
            }
        }
    });

    // when opening the sidebar
    $('#sidebarCollapse').on('click', function () {
        $("#account-img").addClass('op-0');
        //document.getElementById("account-img").classList.add("");
        $("#sidebarCollapse").addClass('op-0');
        //document.getElementById("sidebarCollapse").classList.add("d-none");
        $("#sidebar").addClass('abierto');
        //document.getElementById("sidebar").classList.add("abierto");
    });
    $('#dismiss').on('click', function () {
        $("#sidebar").removeClass('abierto');
        //document.getElementById("sidebar").classList.remove("abierto");
        $("#account-img").removeClass('op-0');
        //document.getElementById("account-img").classList.remove("d-none");
        $("#sidebarCollapse").removeClass('op-0');
        //document.getElementById("sidebarCollapse").classList.remove("d-none");
    });
// Determine if this browser supports the date input type.
    var dateSupported = (function () {
        var el = document.createElement('input'),
            invalidVal = 'foo'; // Any value that is not a date
        el.setAttribute('type', 'date');
        el.setAttribute('value', invalidVal);
        // A supported browser will modify this if it is a true date field
        return el.value !== invalidVal;
    }());

    if (!dateSupported) {
        $("#datepicker").datepicker({dateFormat: 'yy-mm-dd'});
    }

});


