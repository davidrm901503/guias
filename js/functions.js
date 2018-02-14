jQuery(document).ready(function ($) {


    $(window).scroll(function () {
        if ($(window).scrollTop() > 56) {
            $(".navbar").addClass("bg-primary");
        } else {
            $(".navbar").removeClass("bg-primary");
        }

        if ($('body > div').hasClass('wrapper-event')) {

            // Cache selectors
            var topMenu = $("#sec-how-works"),
                topMenuHeight = topMenu.outerHeight() + 15,
                // All list items
                menuItems = topMenu.find("a"),
                // Anchors corresponding to menu items
                scrollItems = menuItems.map(function () {
                    var item = $($(this).attr("href"));
                    if (item.length) {
                        return item;
                    }
                });

            var navHeight = $(window).height() - 56;
            if ($(window).scrollTop() > navHeight) {
                $('#sec-how-works').addClass('fixed');
                $('#desc').addClass('mt-5');
                if ($(window).width() > 768)
                    $('#calendar-reserva').addClass('r-fixed')
            }
            else {
                $('#sec-how-works').removeClass('fixed');
                $('#desc').removeClass('mt-5');
                if ($(window).width() > 768)
                    $('#calendar-reserva').removeClass('r-fixed')

            }

            // Get container scroll position
            var fromTop = $(this).scrollTop() + topMenuHeight;

            // Get id of current scroll item
            var cur = scrollItems.map(function () {
                if ($(this).offset().top < fromTop)
                    return this;
            });
            // Get the id of the current element
            cur = cur[cur.length - 1];
            var id = cur && cur.length ? cur[0].id : "";
            // Set/remove active class
            menuItems
                .parent().removeClass("active")
                .end().filter("[href='#" + id + "']").parent().addClass("active");


        }

        var scrollHeight = $(document).height();
        var scrollPosition = $(window).height() + $(window).scrollTop();
        if ((scrollHeight - scrollPosition) % scrollHeight <= 359) {
            // when scroll to bottom of the page
            $('#calendar-reserva').removeClass('r-fixed');
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
        $("#datepicker").datepicker();
        $('input#cal-datepicker').datepicker();
    }

    $('input#event-range-date').daterangepicker({
        timePicker: true,
        timePickerIncrement: 30,
        locale: {
            format: 'DD/MM/YYYY h:mm A'
        }
    });
    $('#date-llegada').datepicker();

});


