$(function () {
    if ($('.body').height() < $(window).outerHeight()-180) {
        $('.body').height($(window).height()-180);
    }

    $('select#ChemicalNames').addClass('form-control');
});

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})