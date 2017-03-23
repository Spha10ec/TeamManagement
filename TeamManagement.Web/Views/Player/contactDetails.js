$(document).ready(function () {
    $('#ISAddressTheSame').click(function () {
        if ($('#ISAddressTheSame').is(':checked')) {
            $('#PostalAddressLine1').val($('#PhysicalAddressLine1').val());
            $('#PostalAddressLine2').val($('#PhysicalAddressLine2').val());
            $('#PostalAddressLine3').val($('#PhysicalAddressLine3').val());
            $('#PostalAddressLine4').val($('#PhysicalAddressLine4').val());
            $('#PostalAddressLine5').val($('#PhysicalAddressLine5').val());
            $('#PostalPostalCode').val($('#PhysicalPostalCode').val());
        }
        //else {
        //    $('#PostalAddressLine1').val();
        //    $('#PostalAddressLine2').val();
        //    $('#PostalAddressLine3').val();
        //    $('#PostalAddressLine4').val();
        //    $('#PostalAddressLine5').val();
        //    $('#PostalPostalCode').val();
        //}
    });
});