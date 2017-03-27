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

    var next = 1;
    $(".add-more").click(function (e) {
        e.preventDefault();
        var addto = "#field" + next;
        var addRemove = "#field" + (next);
        next = next + 1;
        
        var newIn = '<input class="form-control width35" id="SubjectCode' + next + '"name="SubjectCode" type="text"><input class="form-control width35" id="SubjectName' + next + '"name="SubjectName" type="text">';
        var newInput = $(newIn);
        var removeBtn = '<button id="remove' + (next - 1) + '" class="btn btn-danger remove-me" >-</button></div><div id="field">';
        var removeButton = $(removeBtn);
        $(addto).after(newInput);
        $(addRemove).after(removeButton);
        $("#field" + next).attr('data-source', $(addto).attr('data-source'));
        $("#count").val(next);

        $('.remove-me').click(function (e) {
            e.preventDefault();
            var fieldNum = this.id.charAt(this.id.length - 1);
            var fieldID = "#field" + fieldNum;
            $(this).remove();
            $(fieldID).remove();
        });
    });
});