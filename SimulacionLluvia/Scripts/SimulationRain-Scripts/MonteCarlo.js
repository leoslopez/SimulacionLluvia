$(document).ready(function () {
    
    $('#importFile').attr('disabled', 'disabled');

    $('#rdInputValues').change(function () {
        $('#inputFileDiv').hide();
        $('#inputValuesDiv').show();
    });

    $('#rdInputFile').change(function () {
        $('#inputValuesDiv').hide();
        $('#inputFileDiv').show();
    });

});
