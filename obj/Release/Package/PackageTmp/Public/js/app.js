$(function () {
    if ($('.body').height() < $(window).outerHeight() - 180) {
        $('.body').height($(window).height() - 180);
    }

    $('select#ChemicalNames').addClass('form-control');
});

$(function () {
    $('[data-toggle="tooltip"]').tooltip();

    $('.datepicker').datepicker({
        autoclose: true
    });
})

$(function () {
    // Hook up the print link.
    $("a.print").click(function () {
        console.log('asdasd');
        $(".print-area").print();
        // Cancel click event.                
        return (false);        
    });            
});    