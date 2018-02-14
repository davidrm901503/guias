jQuery(document).ready(function ($) {
    $('#advanced-search-action').click(function () {
        if ($('#advanced-search-div').hasClass('hide-advanced-search')) {
            $('#advanced-search-div').removeClass('hide-advanced-search');
            $('#advanced-search-action').addClass('rotate');
        } else {
            $('#advanced-search-div').addClass('hide-advanced-search');
            $('#advanced-search-action').removeClass('rotate');
        }
    });

    $('#plazas-range-badge').text($('input[name=people]:checked').val());
    $('#date-range-badge').text($('input[name=days]:checked').val());
    $('#price-range-badge').text($('input[name=price]:checked').val());

    $('input[name=days]').click(function () {
        $('#date-range-badge').text($('input[name=days]:checked').val());
    });
    $('input[name=price]').click(function () {
        $('#price-range-badge').text($('input[name=price]:checked').val());
    });
    $('input[name=people]').click(function () {
        $('#plazas-range-badge').text($('input[name=people]:checked').val());
    });

    $("#datepicker").datepicker({dateFormat: 'dd-mm-yyyy'});


});
